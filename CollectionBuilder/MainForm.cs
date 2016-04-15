using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CollectionBuilder.Common;
using CollectionBuilder.Data;
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

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            try
            {
                foreach (string line in eventAddressText.Lines)
                {
                    IDeckScraper scraper = DeckScraperFactory.GetDeckScraper(line);

                    var gameType = GetGameType();

                    if (!Directory.Exists(outputFolderText.Text))
                    {
                        Directory.CreateDirectory(outputFolderText.Text);
                    }

                    IDeckWriter writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
                    scraper.GetDecks(line, writer);
                }
            }
            catch (ArgumentException ex)
            {
                AddOutput(String.Format("{0}{1}", ex.Message, Environment.NewLine));
            }
            finally
            {
                EnableGetDecksButton();
            }
            AddOutput(String.Format("Finished grabbing decks."));
        }

        private delegate void EnableGetDecksButtonCallback();

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
            else
            {
                getDecksButton.Enabled = true;
            }
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

        private delegate void AddOutputCallback(string text);

        private void AddOutput(string text)
        {
            if (outputText.InvokeRequired)
            {
                try
                {
                    var d = new AddOutputCallback(AddOutput);
                    Invoke(d, new[] { text });
                }
                catch (InvalidOperationException)
                {
                    //This is probably safely ignored.
                }
            }
            else
            {
                outputText.Text += text;
            }
        }

        private void generateOutputButton_Click(object sender, EventArgs e)
        {
            Settings.Default.OutputCollection = outputFileText.Text;
            Settings.Default.OutputFolder = outputFolderText.Text;
            Settings.Default.EventAddresses = eventAddressText.Text;
            Settings.Default.Save();
            
            var filename = GetOutputLocation();
            var gameType = GetGameType();

            IDeckWriter writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
            IDeck deck = writer.GetDeckFromCollection();

            outputText.Text = deck.GetFormattedList();
        }
    }
}
