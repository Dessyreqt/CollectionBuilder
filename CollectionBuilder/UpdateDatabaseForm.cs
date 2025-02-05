using System.Net;

namespace CollectionBuilder;

public partial class UpdateDatabaseForm : Form
{
    public UpdateDatabaseForm()
    {
        InitializeComponent();
    }

    private void updateDatabaseButton_Click(object sender, EventArgs e)
    {
        try
        {
            File.Delete("cards.json");

            using var client = new WebClient();

            client.DownloadFile(downloadLocationTextBox.Text, "cards.json");

            MessageBox.Show("Update successful.");
        }
        catch (Exception ex) { MessageBox.Show($"Update failed: {ex.Message}"); }
    }
}
