namespace LLB_Mod_Manager
{
    partial class App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.LabelGameLocation = new System.Windows.Forms.Label();
            this.gameFolderPath = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.availableMods = new System.Windows.Forms.ListBox();
            this.installedMods = new System.Windows.Forms.ListBox();
            this.sendToPendingModsButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pendingMods = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelGameLocation
            // 
            this.LabelGameLocation.AutoSize = true;
            this.LabelGameLocation.Location = new System.Drawing.Point(12, 9);
            this.LabelGameLocation.Name = "LabelGameLocation";
            this.LabelGameLocation.Size = new System.Drawing.Size(163, 13);
            this.LabelGameLocation.TabIndex = 0;
            this.LabelGameLocation.Text = "LLBlaze/LLBlaze_Data directory:";
            // 
            // gameFolderPath
            // 
            this.gameFolderPath.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gameFolderPath.Location = new System.Drawing.Point(15, 26);
            this.gameFolderPath.Name = "gameFolderPath";
            this.gameFolderPath.ReadOnly = true;
            this.gameFolderPath.ShortcutsEnabled = false;
            this.gameFolderPath.Size = new System.Drawing.Size(285, 20);
            this.gameFolderPath.TabIndex = 1;
            this.gameFolderPath.TabStop = false;
            this.gameFolderPath.Text = "Please select a location using the browse button";
            this.gameFolderPath.WordWrap = false;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(306, 23);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(58, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // availableMods
            // 
            this.availableMods.FormattingEnabled = true;
            this.availableMods.Location = new System.Drawing.Point(15, 78);
            this.availableMods.Name = "availableMods";
            this.availableMods.Size = new System.Drawing.Size(150, 82);
            this.availableMods.TabIndex = 3;
            this.availableMods.SelectedIndexChanged += new System.EventHandler(this.availableMods_SelectedIndexChanged);
            // 
            // installedMods
            // 
            this.installedMods.FormattingEnabled = true;
            this.installedMods.Location = new System.Drawing.Point(15, 214);
            this.installedMods.Name = "installedMods";
            this.installedMods.Size = new System.Drawing.Size(349, 108);
            this.installedMods.TabIndex = 4;
            this.installedMods.SelectedIndexChanged += new System.EventHandler(this.installedMods_SelectedIndexChanged);
            // 
            // sendToPendingModsButton
            // 
            this.sendToPendingModsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.sendToPendingModsButton.Location = new System.Drawing.Point(171, 78);
            this.sendToPendingModsButton.Name = "sendToPendingModsButton";
            this.sendToPendingModsButton.Size = new System.Drawing.Size(37, 23);
            this.sendToPendingModsButton.TabIndex = 5;
            this.sendToPendingModsButton.Text = ">>";
            this.sendToPendingModsButton.UseVisualStyleBackColor = true;
            this.sendToPendingModsButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(171, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Available mods:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mods to install:";
            // 
            // pendingMods
            // 
            this.pendingMods.FormattingEnabled = true;
            this.pendingMods.Location = new System.Drawing.Point(214, 78);
            this.pendingMods.Name = "pendingMods";
            this.pendingMods.Size = new System.Drawing.Size(150, 82);
            this.pendingMods.TabIndex = 10;
            this.pendingMods.SelectedIndexChanged += new System.EventHandler(this.pendingMods_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Installed mods:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(214, 166);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Install Selected Mods";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(15, 328);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(349, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "Uninstall All Mods";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(381, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 319);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mod information";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(338, 299);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show LLBMM Readme";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 361);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pendingMods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.sendToPendingModsButton);
            this.Controls.Add(this.installedMods);
            this.Controls.Add(this.availableMods);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.gameFolderPath);
            this.Controls.Add(this.LabelGameLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LLB Mod Manager";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelGameLocation;
        private System.Windows.Forms.TextBox gameFolderPath;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.ListBox availableMods;
        private System.Windows.Forms.ListBox installedMods;
        private System.Windows.Forms.Button sendToPendingModsButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox pendingMods;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
    }
}

