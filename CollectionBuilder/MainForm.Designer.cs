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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            browseButton = new Button();
            collectionDatabaseTextBox = new TextBox();
            label1 = new Label();
            sessionDatabaseTextBox = new TextBox();
            label4 = new Label();
            label2 = new Label();
            getDecksButton = new Button();
            listTextBox = new TextBox();
            outputText = new TextBox();
            outputCollectionButton = new Button();
            newSessionButton = new Button();
            label3 = new Label();
            addSessionButton = new Button();
            outputSessionButton = new Button();
            mergeSessionButton = new Button();
            clearSessionLabel = new LinkLabel();
            SuspendLayout();
            // 
            // browseButton
            // 
            browseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseButton.Location = new Point(996, 28);
            browseButton.Margin = new Padding(4, 3, 4, 3);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(88, 27);
            browseButton.TabIndex = 5;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // collectionDatabaseTextBox
            // 
            collectionDatabaseTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            collectionDatabaseTextBox.Location = new Point(18, 31);
            collectionDatabaseTextBox.Margin = new Padding(4, 3, 4, 3);
            collectionDatabaseTextBox.Name = "collectionDatabaseTextBox";
            collectionDatabaseTextBox.Size = new Size(971, 23);
            collectionDatabaseTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 3;
            label1.Text = "Collection Database";
            // 
            // sessionDatabaseTextBox
            // 
            sessionDatabaseTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sessionDatabaseTextBox.Location = new Point(18, 76);
            sessionDatabaseTextBox.Margin = new Padding(4, 3, 4, 3);
            sessionDatabaseTextBox.Name = "sessionDatabaseTextBox";
            sessionDatabaseTextBox.Size = new Size(971, 23);
            sessionDatabaseTextBox.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 57);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 12;
            label4.Text = "Session Database";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 144);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(162, 15);
            label2.TabIndex = 14;
            label2.Text = "List of Cards/Event Addresses";
            // 
            // getDecksButton
            // 
            getDecksButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            getDecksButton.Location = new Point(926, 444);
            getDecksButton.Margin = new Padding(4, 3, 4, 3);
            getDecksButton.Name = "getDecksButton";
            getDecksButton.Size = new Size(158, 27);
            getDecksButton.TabIndex = 16;
            getDecksButton.Text = "Scrape Decks to Session";
            getDecksButton.UseVisualStyleBackColor = true;
            getDecksButton.Click += getDecksButton_Click;
            // 
            // listTextBox
            // 
            listTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listTextBox.Location = new Point(18, 162);
            listTextBox.Margin = new Padding(4, 3, 4, 3);
            listTextBox.Multiline = true;
            listTextBox.Name = "listTextBox";
            listTextBox.Size = new Size(1066, 276);
            listTextBox.TabIndex = 15;
            // 
            // outputText
            // 
            outputText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            outputText.Location = new Point(18, 488);
            outputText.Margin = new Padding(4, 3, 4, 3);
            outputText.Multiline = true;
            outputText.Name = "outputText";
            outputText.ReadOnly = true;
            outputText.ScrollBars = ScrollBars.Both;
            outputText.Size = new Size(1066, 306);
            outputText.TabIndex = 17;
            // 
            // outputCollectionButton
            // 
            outputCollectionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            outputCollectionButton.Location = new Point(954, 801);
            outputCollectionButton.Margin = new Padding(4, 3, 4, 3);
            outputCollectionButton.Name = "outputCollectionButton";
            outputCollectionButton.Size = new Size(130, 27);
            outputCollectionButton.TabIndex = 18;
            outputCollectionButton.Text = "Output Collection";
            outputCollectionButton.UseVisualStyleBackColor = true;
            outputCollectionButton.Click += OutputCollectionButtonClick;
            // 
            // newSessionButton
            // 
            newSessionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newSessionButton.Location = new Point(997, 73);
            newSessionButton.Margin = new Padding(4, 3, 4, 3);
            newSessionButton.Name = "newSessionButton";
            newSessionButton.Size = new Size(88, 27);
            newSessionButton.TabIndex = 20;
            newSessionButton.Text = "New Session";
            newSessionButton.UseVisualStyleBackColor = true;
            newSessionButton.Click += newSessionButton_Click;
            // 
            // label3
            // 
            label3.Location = new Point(18, 102);
            label3.Name = "label3";
            label3.Size = new Size(1068, 42);
            label3.TabIndex = 21;
            label3.Text = resources.GetString("label3.Text");
            // 
            // addSessionButton
            // 
            addSessionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addSessionButton.Location = new Point(760, 444);
            addSessionButton.Margin = new Padding(4, 3, 4, 3);
            addSessionButton.Name = "addSessionButton";
            addSessionButton.Size = new Size(158, 27);
            addSessionButton.TabIndex = 22;
            addSessionButton.Text = "Add cards to Session";
            addSessionButton.UseVisualStyleBackColor = true;
            addSessionButton.Click += addSessionButton_Click;
            // 
            // outputSessionButton
            // 
            outputSessionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            outputSessionButton.Location = new Point(816, 802);
            outputSessionButton.Margin = new Padding(4, 3, 4, 3);
            outputSessionButton.Name = "outputSessionButton";
            outputSessionButton.Size = new Size(130, 27);
            outputSessionButton.TabIndex = 23;
            outputSessionButton.Text = "Output Session";
            outputSessionButton.UseVisualStyleBackColor = true;
            outputSessionButton.Click += outputSessionButton_Click;
            // 
            // mergeSessionButton
            // 
            mergeSessionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            mergeSessionButton.Location = new Point(594, 444);
            mergeSessionButton.Margin = new Padding(4, 3, 4, 3);
            mergeSessionButton.Name = "mergeSessionButton";
            mergeSessionButton.Size = new Size(158, 27);
            mergeSessionButton.TabIndex = 24;
            mergeSessionButton.Text = "Merge cards to Session";
            mergeSessionButton.UseVisualStyleBackColor = true;
            mergeSessionButton.Click += mergeSessionButton_Click;
            // 
            // clearSessionLabel
            // 
            clearSessionLabel.AutoSize = true;
            clearSessionLabel.Location = new Point(18, 450);
            clearSessionLabel.Name = "clearSessionLabel";
            clearSessionLabel.Size = new Size(76, 15);
            clearSessionLabel.TabIndex = 25;
            clearSessionLabel.TabStop = true;
            clearSessionLabel.Text = "Clear Session";
            clearSessionLabel.LinkClicked += clearSessionLabel_LinkClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 841);
            Controls.Add(clearSessionLabel);
            Controls.Add(mergeSessionButton);
            Controls.Add(outputSessionButton);
            Controls.Add(addSessionButton);
            Controls.Add(label3);
            Controls.Add(newSessionButton);
            Controls.Add(outputCollectionButton);
            Controls.Add(outputText);
            Controls.Add(getDecksButton);
            Controls.Add(listTextBox);
            Controls.Add(label2);
            Controls.Add(sessionDatabaseTextBox);
            Controls.Add(label4);
            Controls.Add(browseButton);
            Controls.Add(collectionDatabaseTextBox);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Collection Builder";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox collectionDatabaseTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sessionDatabaseTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getDecksButton;
        private System.Windows.Forms.TextBox listTextBox;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Button outputCollectionButton;
        private System.Windows.Forms.CheckBox deleteExistingCheckbox;
        private Button newSessionButton;
        private Label label3;
        private Button addSessionButton;
        private Button outputSessionButton;
        private Button mergeSessionButton;
        private LinkLabel clearSessionLabel;
    }
}

