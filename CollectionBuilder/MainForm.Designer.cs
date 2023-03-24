namespace CollectionBuilder
{
    partial class MainForm
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
            this.browseButton = new System.Windows.Forms.Button();
            this.outputFolderText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outputFileText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.getDecksButton = new System.Windows.Forms.Button();
            this.eventAddressText = new System.Windows.Forms.TextBox();
            this.outputText = new System.Windows.Forms.TextBox();
            this.generateOutputButton = new System.Windows.Forms.Button();
            this.deleteExistingCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(854, 24);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // outputFolderText
            // 
            this.outputFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFolderText.Location = new System.Drawing.Point(15, 27);
            this.outputFolderText.Name = "outputFolderText";
            this.outputFolderText.Size = new System.Drawing.Size(833, 20);
            this.outputFolderText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output Folder";
            // 
            // outputFileText
            // 
            this.outputFileText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFileText.Location = new System.Drawing.Point(15, 66);
            this.outputFileText.Name = "outputFileText";
            this.outputFileText.Size = new System.Drawing.Size(914, 20);
            this.outputFileText.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Output File (extension will be appended)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Event Addresses";
            // 
            // getDecksButton
            // 
            this.getDecksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.getDecksButton.Location = new System.Drawing.Point(15, 694);
            this.getDecksButton.Name = "getDecksButton";
            this.getDecksButton.Size = new System.Drawing.Size(75, 23);
            this.getDecksButton.TabIndex = 16;
            this.getDecksButton.Text = "Get Decks";
            this.getDecksButton.UseVisualStyleBackColor = true;
            this.getDecksButton.Click += new System.EventHandler(this.getDecksButton_Click);
            // 
            // eventAddressText
            // 
            this.eventAddressText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventAddressText.Location = new System.Drawing.Point(15, 105);
            this.eventAddressText.Multiline = true;
            this.eventAddressText.Name = "eventAddressText";
            this.eventAddressText.Size = new System.Drawing.Size(914, 275);
            this.eventAddressText.TabIndex = 15;
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputText.Location = new System.Drawing.Point(15, 394);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputText.Size = new System.Drawing.Size(914, 294);
            this.outputText.TabIndex = 17;
            // 
            // generateOutputButton
            // 
            this.generateOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateOutputButton.Location = new System.Drawing.Point(818, 694);
            this.generateOutputButton.Name = "generateOutputButton";
            this.generateOutputButton.Size = new System.Drawing.Size(111, 23);
            this.generateOutputButton.TabIndex = 18;
            this.generateOutputButton.Text = "Generate Output";
            this.generateOutputButton.UseVisualStyleBackColor = true;
            this.generateOutputButton.Click += new System.EventHandler(this.generateOutputButton_Click);
            // 
            // deleteExistingCheckbox
            // 
            this.deleteExistingCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteExistingCheckbox.AutoSize = true;
            this.deleteExistingCheckbox.Checked = true;
            this.deleteExistingCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.deleteExistingCheckbox.Location = new System.Drawing.Point(96, 698);
            this.deleteExistingCheckbox.Name = "deleteExistingCheckbox";
            this.deleteExistingCheckbox.Size = new System.Drawing.Size(145, 17);
            this.deleteExistingCheckbox.TabIndex = 19;
            this.deleteExistingCheckbox.Text = "Delete Existing Database";
            this.deleteExistingCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 729);
            this.Controls.Add(this.deleteExistingCheckbox);
            this.Controls.Add(this.generateOutputButton);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.getDecksButton);
            this.Controls.Add(this.eventAddressText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputFileText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.outputFolderText);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Collection Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox outputFolderText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputFileText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getDecksButton;
        private System.Windows.Forms.TextBox eventAddressText;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Button generateOutputButton;
        private System.Windows.Forms.CheckBox deleteExistingCheckbox;
    }
}

