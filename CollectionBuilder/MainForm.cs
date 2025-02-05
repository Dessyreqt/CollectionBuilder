using CollectionBuilder.Mtg;
using CollectionBuilder.Properties;

namespace CollectionBuilder;

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
        var defaultFolder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CollectionBuilder");

        collectionDatabaseTextBox.Text = Path.Join(defaultFolder, "collection.db");
        sessionDatabaseTextBox.Text = Path.Join(defaultFolder, "session.db");
        listTextBox.Text = Settings.Default.EventAddresses;
    }

    private void browseButton_Click(object sender, EventArgs e)
    {
        var browser = new OpenFileDialog();
        browser.InitialDirectory = collectionDatabaseTextBox.Text;

        if (browser.ShowDialog() == DialogResult.OK) { collectionDatabaseTextBox.Text = browser.FileName; }
    }

    private void getDecksButton_Click(object sender, EventArgs e)
    {
        outputText.Text = "";

        Settings.Default.EventAddresses = listTextBox.Text;
        Settings.Default.Save();

        getDecksButton.Enabled = false;
        scraperThread = new(ScrapeDecks);
        scraperThread.Start();
    }

    private void ScrapeDecks()
    {
        AddOutput($"Grabbing decks from {listTextBox.Text}{Environment.NewLine}");

        var filename = sessionDatabaseTextBox.Text;

        try
        {
            foreach (var line in listTextBox.Lines)
            {
                if (string.IsNullOrWhiteSpace(line)) { continue; }

                var scraper = DeckScraperFactory.GetDeckScraper(line);
                var gameType = GetGameType();
                var writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
                scraper.GetDecks(line, writer);
            }
        }
        catch (ArgumentException ex) { AddOutput($"{ex.Message}{Environment.NewLine}"); }
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

    private DeckWriterGameType GetGameType()
    {
        return DeckWriterGameType.Mtg;
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

    private async void OutputCollectionButtonClick(object sender, EventArgs e)
    {
        Settings.Default.EventAddresses = listTextBox.Text;
        Settings.Default.Save();

        var filename = sessionDatabaseTextBox.Text;
        var gameType = GetGameType();

        var writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
        var deck = await writer.GetDeckFromCollectionAsync();

        outputText.Text = deck.GetFormattedList();
    }

    private async void clearSessionLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var filename = sessionDatabaseTextBox.Text;
        var gameType = GetGameType();
        var writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
        await writer.ClearCollectionAsync();
    }

    private async void outputSessionButton_Click(object sender, EventArgs e)
    {
        Settings.Default.EventAddresses = listTextBox.Text;
        Settings.Default.Save();

        var filename = sessionDatabaseTextBox.Text;
        var gameType = GetGameType();

        var writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
        var deck = await writer.GetDeckFromCollectionAsync();

        outputText.Text = deck.GetFormattedList();
    }

    private void newSessionButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Not implemented yet...");
    }

    private void addSessionButton_Click(object sender, EventArgs e)
    {
        var parser = new MtgoDeckParser();
        var filename = sessionDatabaseTextBox.Text;
        var gameType = GetGameType();
        var writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
        var parsedDeck = parser.ParseDeck(listTextBox.Text);

        outputText.Text = "";

        writer.WriteDeck(parsedDeck, true);
        AddOutput("Added cards to deck");
    }

    private void mergeSessionButton_Click(object sender, EventArgs e)
    {
        var parser = new MtgoDeckParser();
        var filename = sessionDatabaseTextBox.Text;
        var gameType = GetGameType();
        var writer = DeckWriterFactory.GetDeckWriter(gameType, filename);
        var parsedDeck = parser.ParseDeck(listTextBox.Text);

        outputText.Text = "";

        writer.WriteDeck(parsedDeck);
        AddOutput("Added cards to deck");
    }

    private void updateCardDatabaseButton_Click(object sender, EventArgs e)
    {
        var updateDatabaseForm = new UpdateDatabaseForm();
        updateDatabaseForm.ShowDialog();
    }
}
