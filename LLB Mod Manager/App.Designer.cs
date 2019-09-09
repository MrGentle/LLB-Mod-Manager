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
            this.availableModsLabel = new System.Windows.Forms.Label();
            this.installedModsLabel = new System.Windows.Forms.Label();
            this.installModsButton = new System.Windows.Forms.Button();
            this.uninstallModsButton = new System.Windows.Forms.Button();
            this.readmeButton = new System.Windows.Forms.Button();
            this.readmeBox = new System.Windows.Forms.RichTextBox();
            this.modInfoLabel = new System.Windows.Forms.Label();
            this.uninstallSelectedModButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.AvailableModsDGV = new System.Windows.Forms.DataGridView();
            this.InstalledModsDGV = new System.Windows.Forms.DataGridView();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.DeselectAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableModsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstalledModsDGV)).BeginInit();
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
            this.gameFolderPath.Location = new System.Drawing.Point(15, 55);
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
            this.BrowseButton.Location = new System.Drawing.Point(431, 55);
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
            this.availableModsLabel.Location = new System.Drawing.Point(15, 103);
            this.availableModsLabel.Name = "availableModsLabel";
            this.availableModsLabel.Size = new System.Drawing.Size(500, 17);
            this.availableModsLabel.TabIndex = 8;
            this.availableModsLabel.Text = "Available mods:";
            // 
            // installedModsLabel
            // 
            this.installedModsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installedModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.installedModsLabel.Location = new System.Drawing.Point(15, 329);
            this.installedModsLabel.Name = "installedModsLabel";
            this.installedModsLabel.Size = new System.Drawing.Size(500, 17);
            this.installedModsLabel.TabIndex = 11;
            this.installedModsLabel.Text = "Installed mods:";
            // 
            // installModsButton
            // 
            this.installModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.installModsButton.Location = new System.Drawing.Point(227, 280);
            this.installModsButton.Name = "installModsButton";
            this.installModsButton.Size = new System.Drawing.Size(288, 23);
            this.installModsButton.TabIndex = 13;
            this.installModsButton.Text = "Install Selected Mods";
            this.installModsButton.UseVisualStyleBackColor = true;
            this.installModsButton.Click += new System.EventHandler(this.InstallModsButton_Click);
            // 
            // uninstallModsButton
            // 
            this.uninstallModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallModsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.uninstallModsButton.Location = new System.Drawing.Point(412, 505);
            this.uninstallModsButton.Name = "uninstallModsButton";
            this.uninstallModsButton.Size = new System.Drawing.Size(103, 23);
            this.uninstallModsButton.TabIndex = 14;
            this.uninstallModsButton.Text = "Uninstall All Mods";
            this.uninstallModsButton.UseVisualStyleBackColor = true;
            this.uninstallModsButton.Click += new System.EventHandler(this.UninstallModsButton_Click);
            // 
            // readmeButton
            // 
            this.readmeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readmeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.readmeButton.Location = new System.Drawing.Point(547, 505);
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
            this.readmeBox.Size = new System.Drawing.Size(500, 464);
            this.readmeBox.TabIndex = 0;
            this.readmeBox.Text = "";
            this.readmeBox.Enter += new System.EventHandler(this.readmeBox_Enter);
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
            this.uninstallSelectedModButton.Location = new System.Drawing.Point(15, 505);
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
            // AvailableModsDGV
            // 
            this.AvailableModsDGV.AllowUserToAddRows = false;
            this.AvailableModsDGV.AllowUserToDeleteRows = false;
            this.AvailableModsDGV.AllowUserToResizeColumns = false;
            this.AvailableModsDGV.AllowUserToResizeRows = false;
            this.AvailableModsDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AvailableModsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableModsDGV.Location = new System.Drawing.Point(15, 123);
            this.AvailableModsDGV.Name = "AvailableModsDGV";
            this.AvailableModsDGV.ReadOnly = true;
            this.AvailableModsDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AvailableModsDGV.RowHeadersVisible = false;
            this.AvailableModsDGV.ShowEditingIcon = false;
            this.AvailableModsDGV.Size = new System.Drawing.Size(500, 151);
            this.AvailableModsDGV.TabIndex = 19;
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
            this.InstalledModsDGV.Location = new System.Drawing.Point(15, 349);
            this.InstalledModsDGV.Name = "InstalledModsDGV";
            this.InstalledModsDGV.ReadOnly = true;
            this.InstalledModsDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.InstalledModsDGV.RowHeadersVisible = false;
            this.InstalledModsDGV.ShowEditingIcon = false;
            this.InstalledModsDGV.Size = new System.Drawing.Size(500, 151);
            this.InstalledModsDGV.TabIndex = 20;
            this.InstalledModsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InstalledModsDGV_CellContentClick);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectAllButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SelectAllButton.Location = new System.Drawing.Point(15, 280);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(100, 23);
            this.SelectAllButton.TabIndex = 21;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // DeselectAllButton
            // 
            this.DeselectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeselectAllButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DeselectAllButton.Location = new System.Drawing.Point(121, 280);
            this.DeselectAllButton.Name = "DeselectAllButton";
            this.DeselectAllButton.Size = new System.Drawing.Size(100, 23);
            this.DeselectAllButton.TabIndex = 22;
            this.DeselectAllButton.Text = "Deselect All";
            this.DeselectAllButton.UseVisualStyleBackColor = true;
            this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllButton_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1062, 540);
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
        private System.Windows.Forms.Button uninstallModsButton;
        private System.Windows.Forms.Button readmeButton;
        private System.Windows.Forms.RichTextBox readmeBox;
        private System.Windows.Forms.Label modInfoLabel;
        private System.Windows.Forms.Button uninstallSelectedModButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.DataGridView AvailableModsDGV;
        private System.Windows.Forms.DataGridView InstalledModsDGV;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button DeselectAllButton;
    }
}

