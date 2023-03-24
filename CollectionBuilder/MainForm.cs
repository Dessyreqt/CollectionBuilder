using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CollectionBuilder.Properties;

namespace CollectionBuilder
{
    public partial class MainForm : Form
    {
        private Thread scraperThread;

        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private delegate void EnableGetDecksButtonCallback();

        private delegate void AddOutputCallback(string text);

        private void LoadSettings()
        {
            outputFolderText.Text = Settings.Default.OutputFolder;
            eventAddressText.Text = Settings.Default.EventAddresses;
            outputFileText.Text = Settings.Default.OutputCollection;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var browser = new FolderBrowserDialog();
            browser.SelectedPath = outputFolderText.Text;

            if (browser.ShowDialog() == DialogResult.OK)
            {
                outputFolderText.Text = browser.SelectedPath;
                Settings.Default.OutputFolder = browser.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void getDecksButton_Click(object sender, EventArgs e)
        {
            FixOutputFolder();

            outputText.Text = "";

            Settings.Default.OutputCollection = outputFileText.Text;
            Settings.Default.EventAddresses = eventAddressText.Text;
            Settings.Default.Save();

            getDecksButton.Enabled = false;
            scraperThread = new Thread(ScrapeDecks);
            scraperThread.Start();
        }

        private void ScrapeDecks()
        {
            AddOutput(String.Format("Grabbing decks from {0}{1}", eventAddressText.Text, Environment.NewLine));

            var filename = GetOutputLocation();

            if (deleteExistingCheckbox.Checked && File.Exists(filename)) { File.Delete(filename); }

            try
            {
                foreach (var line in eventAddressText.Lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) { continue; }

                    var scraper = DeckScraperFactory.GetDeckScraper(line);

                    var gameType = GetGameType();

                    if (!Directory.Exists(outputFolderText.Text)) { Directory.CreateDirectory(outputFolderText.Text); }

                    var writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
                    scraper.GetDecks(line, writer);
                }
            }
            catch (ArgumentException ex) { AddOutput(String.Format("{0}{1}", ex.Message, Environment.NewLine)); }
            finally { EnableGetDecksButton(); }

            AddOutput("Finished grabbing decks.");
        }

        private void EnableGetDecksButton()
        {
            if (outputText.InvokeRequired)
            {
                try
                {
                    var d = new EnableGetDecksButtonCallback(EnableGetDecksButton);
                    Invoke(d);
                }
                catch (InvalidOperationException)
                {
                    //This is probably safely ignored.
                }
            }
            else { getDecksButton.Enabled = true; }
        }

        private string GetOutputLocation()
        {
            FixOutputFolder();

            return string.Format("{0}{1}.sdf", outputFolderText.Text, outputFileText.Text);
        }

        private DeckWriterGameType GetGameType()
        {
            return DeckWriterGameType.Mtg;
        }

        private void FixOutputFolder()
        {
            if (!outputFolderText.Text.EndsWith("\\"))
            {
                outputFolderText.Text += "\\";
                Settings.Default.OutputFolder = outputFolderText.Text;
                Settings.Default.Save();
            }
        }

        private void AddOutput(string text)
        {
            if (outputText.InvokeRequired)
            {
                try
                {
                    var d = new AddOutputCallback(AddOutput);
                    Invoke(d, text);
                }
                catch (InvalidOperationException)
                {
                    //This is probably safely ignored.
                }
            }
            else { outputText.Text += text; }
        }

        private void generateOutputButton_Click(object sender, EventArgs e)
        {
            Settings.Default.OutputCollection = outputFileText.Text;
            Settings.Default.OutputFolder = outputFolderText.Text;
            Settings.Default.EventAddresses = eventAddressText.Text;
            Settings.Default.Save();

            var filename = GetOutputLocation();
            var gameType = GetGameType();

            var writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
            var deck = writer.GetDeckFromCollection();

            outputText.Text = deck.GetFormattedList();
        }
    }
}
