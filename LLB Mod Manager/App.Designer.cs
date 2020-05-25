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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.LabelGameLocation = new System.Windows.Forms.Label();
            this.gameFolderPath = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.availableModsLabel = new System.Windows.Forms.Label();
            this.installedModsLabel = new System.Windows.Forms.Label();
            this.installModsButton = new System.Windows.Forms.Button();
            this.readmeButton = new System.Windows.Forms.Button();
            this.readmeBox = new System.Windows.Forms.RichTextBox();
            this.modInfoLabel = new System.Windows.Forms.Label();
            this.uninstallSelectedModButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.AvailableModsDGV = new System.Windows.Forms.DataGridView();
            this.InstalledModsDGV = new System.Windows.Forms.DataGridView();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.DeselectAllButton = new System.Windows.Forms.Button();
            this.uninstallModsButton = new System.Windows.Forms.Button();
            this.refreshInstalledModsButton = new System.Windows.Forms.Button();
            this.RefreshResetTimer = new System.Windows.Forms.Timer(this.components);
            this.stepByStepGuideButton = new System.Windows.Forms.Button();
            this.showReadmeLabel = new System.Windows.Forms.Label();
            this.showReadmeCheckbox = new System.Windows.Forms.CheckBox();
            this.buyMeACoffeeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableModsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstalledModsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelGameLocation
            // 
            this.LabelGameLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGameLocation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LabelGameLocation.Location = new System.Drawing.Point(12, 44);
            this.LabelGameLocation.Name = "LabelGameLocation";
            this.LabelGameLocation.Size = new System.Drawing.Size(500, 17);
            this.LabelGameLocation.TabIndex = 0;
            this.LabelGameLocation.Text = "Lethal League Blaze Game Directory";
            // 
            // gameFolderPath
            // 
            this.gameFolderPath.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gameFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameFolderPath.ForeColor = System.Drawing.SystemColors.Control;
            this.gameFolderPath.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gameFolderPath.Location = new System.Drawing.Point(12, 64);
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
            this.BrowseButton.Location = new System.Drawing.Point(428, 64);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(84, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // availableModsLabel
            // 
            this.availableModsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.availableModsLabel.Location = new System.Drawing.Point(12, 112);
            this.availableModsLabel.Name = "availableModsLabel";
            this.availableModsLabel.Size = new System.Drawing.Size(500, 17);
            this.availableModsLabel.TabIndex = 8;
            this.availableModsLabel.Text = "Available mods";
            // 
            // installedModsLabel
            // 
            this.installedModsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installedModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.installedModsLabel.Location = new System.Drawing.Point(12, 338);
            this.installedModsLabel.Name = "installedModsLabel";
            this.installedModsLabel.Size = new System.Drawing.Size(250, 17);
            this.installedModsLabel.TabIndex = 11;
            this.installedModsLabel.Text = "Installed mods";
            // 
            // installModsButton
            // 
            this.installModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.installModsButton.Location = new System.Drawing.Point(212, 289);
            this.installModsButton.Name = "installModsButton";
            this.installModsButton.Size = new System.Drawing.Size(300, 23);
            this.installModsButton.TabIndex = 13;
            this.installModsButton.Text = "Install Selected Mods";
            this.installModsButton.UseVisualStyleBackColor = true;
            this.installModsButton.Click += new System.EventHandler(this.InstallModsButton_Click);
            // 
            // readmeButton
            // 
            this.readmeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readmeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.readmeButton.Location = new System.Drawing.Point(544, 515);
            this.readmeButton.Name = "readmeButton";
            this.readmeButton.Size = new System.Drawing.Size(177, 23);
            this.readmeButton.TabIndex = 1;
            this.readmeButton.Text = "Show LLBMM Readme";
            this.readmeButton.UseVisualStyleBackColor = true;
            this.readmeButton.Click += new System.EventHandler(this.readmeButton_Click);
            // 
            // readmeBox
            // 
            this.readmeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.readmeBox.ForeColor = System.Drawing.SystemColors.Control;
            this.readmeBox.Location = new System.Drawing.Point(544, 44);
            this.readmeBox.Name = "readmeBox";
            this.readmeBox.ReadOnly = true;
            this.readmeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.readmeBox.Size = new System.Drawing.Size(500, 465);
            this.readmeBox.TabIndex = 0;
            this.readmeBox.Text = "";
            this.readmeBox.Enter += new System.EventHandler(this.readmeBox_Enter);
            // 
            // modInfoLabel
            // 
            this.modInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modInfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.modInfoLabel.Location = new System.Drawing.Point(544, 18);
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
            this.uninstallSelectedModButton.Location = new System.Drawing.Point(318, 514);
            this.uninstallSelectedModButton.Name = "uninstallSelectedModButton";
            this.uninstallSelectedModButton.Size = new System.Drawing.Size(194, 23);
            this.uninstallSelectedModButton.TabIndex = 17;
            this.uninstallSelectedModButton.Text = "Uninstall Selected Mods";
            this.uninstallSelectedModButton.UseVisualStyleBackColor = true;
            this.uninstallSelectedModButton.Click += new System.EventHandler(this.uninstallSelectedModButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.versionLabel.Location = new System.Drawing.Point(12, 18);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(500, 17);
            this.versionLabel.TabIndex = 18;
            this.versionLabel.Text = "versionLabel";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // AvailableModsDGV
            // 
            this.AvailableModsDGV.AllowUserToAddRows = false;
            this.AvailableModsDGV.AllowUserToDeleteRows = false;
            this.AvailableModsDGV.AllowUserToResizeColumns = false;
            this.AvailableModsDGV.AllowUserToResizeRows = false;
            this.AvailableModsDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AvailableModsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableModsDGV.Location = new System.Drawing.Point(12, 132);
            this.AvailableModsDGV.Name = "AvailableModsDGV";
            this.AvailableModsDGV.ReadOnly = true;
            this.AvailableModsDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AvailableModsDGV.RowHeadersVisible = false;
            this.AvailableModsDGV.ShowEditingIcon = false;
            this.AvailableModsDGV.Size = new System.Drawing.Size(500, 151);
            this.AvailableModsDGV.TabIndex = 19;
            this.AvailableModsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailableModsDGV_CellClick);
            this.AvailableModsDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailableModsDGV_CellContentClick);
            // 
            // InstalledModsDGV
            // 
            this.InstalledModsDGV.AllowUserToAddRows = false;
            this.InstalledModsDGV.AllowUserToDeleteRows = false;
            this.InstalledModsDGV.AllowUserToResizeColumns = false;
            this.InstalledModsDGV.AllowUserToResizeRows = false;
            this.InstalledModsDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.InstalledModsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InstalledModsDGV.Location = new System.Drawing.Point(12, 358);
            this.InstalledModsDGV.Name = "InstalledModsDGV";
            this.InstalledModsDGV.ReadOnly = true;
            this.InstalledModsDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.InstalledModsDGV.RowHeadersVisible = false;
            this.InstalledModsDGV.ShowEditingIcon = false;
            this.InstalledModsDGV.Size = new System.Drawing.Size(500, 151);
            this.InstalledModsDGV.TabIndex = 20;
            this.InstalledModsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InstalledModsDGV_CellClick);
            this.InstalledModsDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InstalledModsDGV_CellContentClick);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectAllButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SelectAllButton.Location = new System.Drawing.Point(12, 289);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(94, 23);
            this.SelectAllButton.TabIndex = 21;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // DeselectAllButton
            // 
            this.DeselectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeselectAllButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DeselectAllButton.Location = new System.Drawing.Point(112, 289);
            this.DeselectAllButton.Name = "DeselectAllButton";
            this.DeselectAllButton.Size = new System.Drawing.Size(94, 23);
            this.DeselectAllButton.TabIndex = 22;
            this.DeselectAllButton.Text = "Deselect All";
            this.DeselectAllButton.UseVisualStyleBackColor = true;
            this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllButton_Click);
            // 
            // uninstallModsButton
            // 
            this.uninstallModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.uninstallModsButton.Location = new System.Drawing.Point(212, 514);
            this.uninstallModsButton.Name = "uninstallModsButton";
            this.uninstallModsButton.Size = new System.Drawing.Size(100, 23);
            this.uninstallModsButton.TabIndex = 14;
            this.uninstallModsButton.Text = "Uninstall All Mods";
            this.uninstallModsButton.UseVisualStyleBackColor = true;
            this.uninstallModsButton.Click += new System.EventHandler(this.UninstallModsButton_Click);
            // 
            // refreshInstalledModsButton
            // 
            this.refreshInstalledModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshInstalledModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.refreshInstalledModsButton.Location = new System.Drawing.Point(12, 514);
            this.refreshInstalledModsButton.Name = "refreshInstalledModsButton";
            this.refreshInstalledModsButton.Size = new System.Drawing.Size(194, 23);
            this.refreshInstalledModsButton.TabIndex = 23;
            this.refreshInstalledModsButton.Text = "Refresh Installed Mods";
            this.refreshInstalledModsButton.UseVisualStyleBackColor = true;
            this.refreshInstalledModsButton.Click += new System.EventHandler(this.refreshInstalledModsButton_Click);
            // 
            // RefreshResetTimer
            // 
            this.RefreshResetTimer.Interval = 2000;
            this.RefreshResetTimer.Tick += new System.EventHandler(this.RefreshResetTimer_Tick);
            // 
            // stepByStepGuideButton
            // 
            this.stepByStepGuideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stepByStepGuideButton.ForeColor = System.Drawing.SystemColors.Control;
            this.stepByStepGuideButton.Location = new System.Drawing.Point(727, 515);
            this.stepByStepGuideButton.Name = "stepByStepGuideButton";
            this.stepByStepGuideButton.Size = new System.Drawing.Size(177, 23);
            this.stepByStepGuideButton.TabIndex = 24;
            this.stepByStepGuideButton.Text = "Mod Creation Step By Step Guide";
            this.stepByStepGuideButton.UseVisualStyleBackColor = true;
            this.stepByStepGuideButton.Click += new System.EventHandler(this.stepByStepGuideButton_Click);
            // 
            // showReadmeLabel
            // 
            this.showReadmeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showReadmeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.showReadmeLabel.Location = new System.Drawing.Point(262, 338);
            this.showReadmeLabel.Name = "showReadmeLabel";
            this.showReadmeLabel.Size = new System.Drawing.Size(250, 17);
            this.showReadmeLabel.TabIndex = 25;
            this.showReadmeLabel.Text = "Show Readme   ";
            this.showReadmeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // showReadmeCheckbox
            // 
            this.showReadmeCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.showReadmeCheckbox.Checked = true;
            this.showReadmeCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showReadmeCheckbox.FlatAppearance.BorderSize = 0;
            this.showReadmeCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.showReadmeCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showReadmeCheckbox.ForeColor = System.Drawing.Color.Black;
            this.showReadmeCheckbox.Location = new System.Drawing.Point(499, 342);
            this.showReadmeCheckbox.Name = "showReadmeCheckbox";
            this.showReadmeCheckbox.Size = new System.Drawing.Size(12, 12);
            this.showReadmeCheckbox.TabIndex = 26;
            this.showReadmeCheckbox.UseVisualStyleBackColor = false;
            this.showReadmeCheckbox.CheckedChanged += new System.EventHandler(this.showReadmeCheckbox_CheckedChanged);
            // 
            // buyMeACoffeeButton
            // 
            this.buyMeACoffeeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buyMeACoffeeButton.BackgroundImage")));
            this.buyMeACoffeeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buyMeACoffeeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buyMeACoffeeButton.FlatAppearance.BorderSize = 0;
            this.buyMeACoffeeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buyMeACoffeeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.buyMeACoffeeButton.Location = new System.Drawing.Point(910, 515);
            this.buyMeACoffeeButton.Name = "buyMeACoffeeButton";
            this.buyMeACoffeeButton.Size = new System.Drawing.Size(134, 23);
            this.buyMeACoffeeButton.TabIndex = 27;
            this.buyMeACoffeeButton.Text = "     Buy Me A Coffee";
            this.buyMeACoffeeButton.UseVisualStyleBackColor = false;
            this.buyMeACoffeeButton.Click += new System.EventHandler(this.buyMeACoffeeButton_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1062, 551);
            this.Controls.Add(this.buyMeACoffeeButton);
            this.Controls.Add(this.showReadmeCheckbox);
            this.Controls.Add(this.showReadmeLabel);
            this.Controls.Add(this.stepByStepGuideButton);
            this.Controls.Add(this.refreshInstalledModsButton);
            this.Controls.Add(this.DeselectAllButton);
            this.Controls.Add(this.SelectAllButton);
            this.Controls.Add(this.InstalledModsDGV);
            this.Controls.Add(this.AvailableModsDGV);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.uninstallSelectedModButton);
            this.Controls.Add(this.modInfoLabel);
            this.Controls.Add(this.readmeBox);
            this.Controls.Add(this.readmeButton);
            this.Controls.Add(this.uninstallModsButton);
            this.Controls.Add(this.installModsButton);
            this.Controls.Add(this.installedModsLabel);
            this.Controls.Add(this.availableModsLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.AvailableModsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstalledModsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelGameLocation;
        private System.Windows.Forms.TextBox gameFolderPath;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label availableModsLabel;
        private System.Windows.Forms.Label installedModsLabel;
        private System.Windows.Forms.Button installModsButton;
        private System.Windows.Forms.Button readmeButton;
        private System.Windows.Forms.RichTextBox readmeBox;
        private System.Windows.Forms.Label modInfoLabel;
        private System.Windows.Forms.Button uninstallSelectedModButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.DataGridView AvailableModsDGV;
        private System.Windows.Forms.DataGridView InstalledModsDGV;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button DeselectAllButton;
        private System.Windows.Forms.Button uninstallModsButton;
        private System.Windows.Forms.Button refreshInstalledModsButton;
        private System.Windows.Forms.Timer RefreshResetTimer;
        private System.Windows.Forms.Button stepByStepGuideButton;
        private System.Windows.Forms.Label showReadmeLabel;
        private System.Windows.Forms.CheckBox showReadmeCheckbox;
        private System.Windows.Forms.Button buyMeACoffeeButton;
    }
}

