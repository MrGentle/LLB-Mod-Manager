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
            this.returnFromPendingModsButton = new System.Windows.Forms.Button();
            this.availableModsLabel = new System.Windows.Forms.Label();
            this.pendingModsLabel = new System.Windows.Forms.Label();
            this.pendingMods = new System.Windows.Forms.ListBox();
            this.installedModsLabel = new System.Windows.Forms.Label();
            this.installModsButton = new System.Windows.Forms.Button();
            this.uninstallModsButton = new System.Windows.Forms.Button();
            this.sendAllModsToPendingModsButton = new System.Windows.Forms.Button();
            this.readmeButton = new System.Windows.Forms.Button();
            this.readmeBox = new System.Windows.Forms.RichTextBox();
            this.modInfoLabel = new System.Windows.Forms.Label();
            this.uninstallSelectedModButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelGameLocation
            // 
            this.LabelGameLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGameLocation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LabelGameLocation.Location = new System.Drawing.Point(15, 35);
            this.LabelGameLocation.Name = "LabelGameLocation";
            this.LabelGameLocation.Size = new System.Drawing.Size(500, 17);
            this.LabelGameLocation.TabIndex = 0;
            this.LabelGameLocation.Text = "LLBlaze\\LLBlaze_Data directory:";
            // 
            // gameFolderPath
            // 
            this.gameFolderPath.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gameFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameFolderPath.ForeColor = System.Drawing.SystemColors.Control;
            this.gameFolderPath.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gameFolderPath.Location = new System.Drawing.Point(15, 54);
            this.gameFolderPath.Name = "gameFolderPath";
            this.gameFolderPath.ReadOnly = true;
            this.gameFolderPath.ShortcutsEnabled = false;
            this.gameFolderPath.Size = new System.Drawing.Size(410, 23);
            this.gameFolderPath.TabIndex = 1;
            this.gameFolderPath.TabStop = false;
            this.gameFolderPath.Text = "Please select a location using the browse button";
            this.gameFolderPath.WordWrap = false;
            // 
            // BrowseButton
            // 
            this.BrowseButton.AutoEllipsis = true;
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(431, 54);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(84, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // availableMods
            // 
            this.availableMods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.availableMods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableMods.ForeColor = System.Drawing.SystemColors.Control;
            this.availableMods.FormattingEnabled = true;
            this.availableMods.ItemHeight = 15;
            this.availableMods.Location = new System.Drawing.Point(15, 109);
            this.availableMods.Name = "availableMods";
            this.availableMods.Size = new System.Drawing.Size(212, 150);
            this.availableMods.TabIndex = 3;
            this.availableMods.SelectedIndexChanged += new System.EventHandler(this.AvailableMods_SelectedIndexChanged);
            // 
            // installedMods
            // 
            this.installedMods.BackColor = System.Drawing.Color.DimGray;
            this.installedMods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.installedMods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installedMods.ForeColor = System.Drawing.SystemColors.Control;
            this.installedMods.FormattingEnabled = true;
            this.installedMods.ItemHeight = 15;
            this.installedMods.Location = new System.Drawing.Point(15, 321);
            this.installedMods.Name = "installedMods";
            this.installedMods.Size = new System.Drawing.Size(500, 150);
            this.installedMods.TabIndex = 4;
            this.installedMods.SelectedIndexChanged += new System.EventHandler(this.InstalledMods_SelectedIndexChanged);
            // 
            // sendToPendingModsButton
            // 
            this.sendToPendingModsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.sendToPendingModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendToPendingModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.sendToPendingModsButton.Location = new System.Drawing.Point(233, 178);
            this.sendToPendingModsButton.Name = "sendToPendingModsButton";
            this.sendToPendingModsButton.Size = new System.Drawing.Size(63, 23);
            this.sendToPendingModsButton.TabIndex = 5;
            this.sendToPendingModsButton.Text = ">>";
            this.sendToPendingModsButton.UseVisualStyleBackColor = true;
            this.sendToPendingModsButton.Click += new System.EventHandler(this.sendToPendingModsButton_Click);
            // 
            // returnFromPendingModsButton
            // 
            this.returnFromPendingModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnFromPendingModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.returnFromPendingModsButton.Location = new System.Drawing.Point(233, 207);
            this.returnFromPendingModsButton.Name = "returnFromPendingModsButton";
            this.returnFromPendingModsButton.Size = new System.Drawing.Size(63, 23);
            this.returnFromPendingModsButton.TabIndex = 6;
            this.returnFromPendingModsButton.Text = "<<";
            this.returnFromPendingModsButton.UseVisualStyleBackColor = true;
            this.returnFromPendingModsButton.Click += new System.EventHandler(this.returnFromPendingModsButton_Click);
            // 
            // availableModsLabel
            // 
            this.availableModsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.availableModsLabel.Location = new System.Drawing.Point(15, 89);
            this.availableModsLabel.Name = "availableModsLabel";
            this.availableModsLabel.Size = new System.Drawing.Size(212, 17);
            this.availableModsLabel.TabIndex = 8;
            this.availableModsLabel.Text = "Available mods:";
            // 
            // pendingModsLabel
            // 
            this.pendingModsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.pendingModsLabel.Location = new System.Drawing.Point(303, 89);
            this.pendingModsLabel.Name = "pendingModsLabel";
            this.pendingModsLabel.Size = new System.Drawing.Size(212, 17);
            this.pendingModsLabel.TabIndex = 9;
            this.pendingModsLabel.Text = "Mods to install:";
            // 
            // pendingMods
            // 
            this.pendingMods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pendingMods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingMods.ForeColor = System.Drawing.SystemColors.Control;
            this.pendingMods.FormattingEnabled = true;
            this.pendingMods.ItemHeight = 15;
            this.pendingMods.Location = new System.Drawing.Point(303, 109);
            this.pendingMods.Name = "pendingMods";
            this.pendingMods.Size = new System.Drawing.Size(212, 150);
            this.pendingMods.TabIndex = 10;
            this.pendingMods.SelectedIndexChanged += new System.EventHandler(this.PendingMods_SelectedIndexChanged);
            // 
            // installedModsLabel
            // 
            this.installedModsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installedModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.installedModsLabel.Location = new System.Drawing.Point(15, 301);
            this.installedModsLabel.Name = "installedModsLabel";
            this.installedModsLabel.Size = new System.Drawing.Size(500, 17);
            this.installedModsLabel.TabIndex = 11;
            this.installedModsLabel.Text = "Installed mods:";
            // 
            // installModsButton
            // 
            this.installModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.installModsButton.Location = new System.Drawing.Point(303, 265);
            this.installModsButton.Name = "installModsButton";
            this.installModsButton.Size = new System.Drawing.Size(212, 23);
            this.installModsButton.TabIndex = 13;
            this.installModsButton.Text = "Install Selected Mods";
            this.installModsButton.UseVisualStyleBackColor = true;
            this.installModsButton.Click += new System.EventHandler(this.InstallModsButton_Click);
            // 
            // uninstallModsButton
            // 
            this.uninstallModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.uninstallModsButton.Location = new System.Drawing.Point(411, 477);
            this.uninstallModsButton.Name = "uninstallModsButton";
            this.uninstallModsButton.Size = new System.Drawing.Size(103, 23);
            this.uninstallModsButton.TabIndex = 14;
            this.uninstallModsButton.Text = "Uninstall All Mods";
            this.uninstallModsButton.UseVisualStyleBackColor = true;
            this.uninstallModsButton.Click += new System.EventHandler(this.UninstallModsButton_Click);
            // 
            // sendAllModsToPendingModsButton
            // 
            this.sendAllModsToPendingModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendAllModsToPendingModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.sendAllModsToPendingModsButton.Location = new System.Drawing.Point(233, 236);
            this.sendAllModsToPendingModsButton.Name = "sendAllModsToPendingModsButton";
            this.sendAllModsToPendingModsButton.Size = new System.Drawing.Size(63, 23);
            this.sendAllModsToPendingModsButton.TabIndex = 15;
            this.sendAllModsToPendingModsButton.Text = "All >>";
            this.sendAllModsToPendingModsButton.UseVisualStyleBackColor = true;
            this.sendAllModsToPendingModsButton.Click += new System.EventHandler(this.sendAllModsToPendingModsButton_Click);
            // 
            // readmeButton
            // 
            this.readmeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readmeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.readmeButton.Location = new System.Drawing.Point(547, 477);
            this.readmeButton.Name = "readmeButton";
            this.readmeButton.Size = new System.Drawing.Size(500, 23);
            this.readmeButton.TabIndex = 1;
            this.readmeButton.Text = "Show LLBMM Readme";
            this.readmeButton.UseVisualStyleBackColor = true;
            this.readmeButton.Click += new System.EventHandler(this.readmeButton_Click);
            // 
            // readmeBox
            // 
            this.readmeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.readmeBox.ForeColor = System.Drawing.SystemColors.Control;
            this.readmeBox.Location = new System.Drawing.Point(547, 35);
            this.readmeBox.Name = "readmeBox";
            this.readmeBox.ReadOnly = true;
            this.readmeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.readmeBox.Size = new System.Drawing.Size(500, 436);
            this.readmeBox.TabIndex = 0;
            this.readmeBox.Text = "";
            // 
            // modInfoLabel
            // 
            this.modInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modInfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.modInfoLabel.Location = new System.Drawing.Point(547, 9);
            this.modInfoLabel.Name = "modInfoLabel";
            this.modInfoLabel.Size = new System.Drawing.Size(500, 17);
            this.modInfoLabel.TabIndex = 16;
            this.modInfoLabel.Text = "modInfo";
            this.modInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uninstallSelectedModButton
            // 
            this.uninstallSelectedModButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallSelectedModButton.ForeColor = System.Drawing.SystemColors.Control;
            this.uninstallSelectedModButton.Location = new System.Drawing.Point(15, 477);
            this.uninstallSelectedModButton.Name = "uninstallSelectedModButton";
            this.uninstallSelectedModButton.Size = new System.Drawing.Size(390, 23);
            this.uninstallSelectedModButton.TabIndex = 17;
            this.uninstallSelectedModButton.Text = "Uninstall Selected Mod";
            this.uninstallSelectedModButton.UseVisualStyleBackColor = true;
            this.uninstallSelectedModButton.Click += new System.EventHandler(this.uninstallSelectedModButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.versionLabel.Location = new System.Drawing.Point(15, 9);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(500, 17);
            this.versionLabel.TabIndex = 18;
            this.versionLabel.Text = "versionLabel";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1064, 510);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.uninstallSelectedModButton);
            this.Controls.Add(this.modInfoLabel);
            this.Controls.Add(this.readmeBox);
            this.Controls.Add(this.readmeButton);
            this.Controls.Add(this.sendAllModsToPendingModsButton);
            this.Controls.Add(this.uninstallModsButton);
            this.Controls.Add(this.installModsButton);
            this.Controls.Add(this.installedModsLabel);
            this.Controls.Add(this.pendingMods);
            this.Controls.Add(this.pendingModsLabel);
            this.Controls.Add(this.availableModsLabel);
            this.Controls.Add(this.returnFromPendingModsButton);
            this.Controls.Add(this.sendToPendingModsButton);
            this.Controls.Add(this.installedMods);
            this.Controls.Add(this.availableMods);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.gameFolderPath);
            this.Controls.Add(this.LabelGameLocation);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LLB Mod Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelGameLocation;
        private System.Windows.Forms.TextBox gameFolderPath;
        private System.Windows.Forms.Button BrowseButton;
        public System.Windows.Forms.ListBox availableMods;
        public System.Windows.Forms.ListBox installedMods;
        private System.Windows.Forms.Button sendToPendingModsButton;
        private System.Windows.Forms.Button returnFromPendingModsButton;
        private System.Windows.Forms.Label availableModsLabel;
        private System.Windows.Forms.Label pendingModsLabel;
        public System.Windows.Forms.ListBox pendingMods;
        private System.Windows.Forms.Label installedModsLabel;
        private System.Windows.Forms.Button installModsButton;
        private System.Windows.Forms.Button uninstallModsButton;
        private System.Windows.Forms.Button sendAllModsToPendingModsButton;
        private System.Windows.Forms.Button readmeButton;
        private System.Windows.Forms.RichTextBox readmeBox;
        private System.Windows.Forms.Label modInfoLabel;
        private System.Windows.Forms.Button uninstallSelectedModButton;
        private System.Windows.Forms.Label versionLabel;
    }
}

