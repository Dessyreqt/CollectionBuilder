namespace CollectionBuilder;

partial class UpdateDatabaseForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        downloadLocationTextBox = new TextBox();
        updateDatabaseButton = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(143, 15);
        label1.TabIndex = 0;
        label1.Text = "Download database from:";
        // 
        // downloadLocationTextBox
        // 
        downloadLocationTextBox.Location = new Point(12, 27);
        downloadLocationTextBox.Name = "downloadLocationTextBox";
        downloadLocationTextBox.Size = new Size(274, 23);
        downloadLocationTextBox.TabIndex = 1;
        downloadLocationTextBox.Text = "https://mtgjson.com/api/v5/AtomicCards.json";
        // 
        // updateDatabaseButton
        // 
        updateDatabaseButton.Location = new Point(12, 56);
        updateDatabaseButton.Name = "updateDatabaseButton";
        updateDatabaseButton.Size = new Size(143, 23);
        updateDatabaseButton.TabIndex = 2;
        updateDatabaseButton.Text = "Update Database";
        updateDatabaseButton.UseVisualStyleBackColor = true;
        updateDatabaseButton.Click += updateDatabaseButton_Click;
        // 
        // UpdateDatabaseForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(327, 91);
        Controls.Add(updateDatabaseButton);
        Controls.Add(downloadLocationTextBox);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "UpdateDatabaseForm";
        Text = "UpdateDatabaseForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox downloadLocationTextBox;
    private Button updateDatabaseButton;
}