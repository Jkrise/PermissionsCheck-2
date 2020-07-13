namespace AttribChanger
{
    partial class FileAttributeChanger
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
            this.btn_ChangeAttribs = new System.Windows.Forms.Button();
            this.chk_archive = new System.Windows.Forms.CheckBox();
            this.gbx_attributes = new System.Windows.Forms.GroupBox();
            this.chk_system = new System.Windows.Forms.CheckBox();
            this.chk_readonly = new System.Windows.Forms.CheckBox();
            this.chk_hidden = new System.Windows.Forms.CheckBox();
            this.chk_encrypted = new System.Windows.Forms.CheckBox();
            this.chk_compressed = new System.Windows.Forms.CheckBox();
            this.chk_ChangeAccessedDate = new System.Windows.Forms.CheckBox();
            this.chk_ChangeModifiedDate = new System.Windows.Forms.CheckBox();
            this.chk_ChangeCreatedDate = new System.Windows.Forms.CheckBox();
            this.lbl_AccessedDate = new System.Windows.Forms.Label();
            this.dtp_accesseddate = new System.Windows.Forms.DateTimePicker();
            this.lbl_modifiedDate = new System.Windows.Forms.Label();
            this.lbl_CreatedDate = new System.Windows.Forms.Label();
            this.dtp_modifieddate = new System.Windows.Forms.DateTimePicker();
            this.dtp_creationdate = new System.Windows.Forms.DateTimePicker();
            this.btn_AddFiles = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.gbx_filedates = new System.Windows.Forms.GroupBox();
            this.dgv_filescollection = new System.Windows.Forms.DataGridView();
            this.btn_addfolder = new System.Windows.Forms.Button();
            this.rbtn_folderonly = new System.Windows.Forms.RadioButton();
            this.rbtn_changestoall = new System.Windows.Forms.RadioButton();
            this.gbx_folderoptions = new System.Windows.Forms.GroupBox();
            this.gbx_attributes.SuspendLayout();
            this.gbx_filedates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_filescollection)).BeginInit();
            this.gbx_folderoptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ChangeAttribs
            // 
            this.btn_ChangeAttribs.Location = new System.Drawing.Point(161, 417);
            this.btn_ChangeAttribs.Name = "btn_ChangeAttribs";
            this.btn_ChangeAttribs.Size = new System.Drawing.Size(129, 23);
            this.btn_ChangeAttribs.TabIndex = 1;
            this.btn_ChangeAttribs.Text = "Change Attributes";
            this.btn_ChangeAttribs.UseVisualStyleBackColor = true;
            this.btn_ChangeAttribs.Click += new System.EventHandler(this.btn_ChangeAttribs_Click);
            // 
            // chk_archive
            // 
            this.chk_archive.AutoSize = true;
            this.chk_archive.Location = new System.Drawing.Point(6, 19);
            this.chk_archive.Name = "chk_archive";
            this.chk_archive.Size = new System.Drawing.Size(62, 17);
            this.chk_archive.TabIndex = 2;
            this.chk_archive.Text = "Archive";
            this.chk_archive.UseVisualStyleBackColor = true;
            // 
            // gbx_attributes
            // 
            this.gbx_attributes.Controls.Add(this.chk_system);
            this.gbx_attributes.Controls.Add(this.chk_readonly);
            this.gbx_attributes.Controls.Add(this.chk_hidden);
            this.gbx_attributes.Controls.Add(this.chk_encrypted);
            this.gbx_attributes.Controls.Add(this.chk_compressed);
            this.gbx_attributes.Controls.Add(this.chk_archive);
            this.gbx_attributes.Location = new System.Drawing.Point(44, 198);
            this.gbx_attributes.Name = "gbx_attributes";
            this.gbx_attributes.Size = new System.Drawing.Size(393, 93);
            this.gbx_attributes.TabIndex = 3;
            this.gbx_attributes.TabStop = false;
            this.gbx_attributes.Text = "FileFolderAttributes";
            // 
            // chk_system
            // 
            this.chk_system.AutoSize = true;
            this.chk_system.Location = new System.Drawing.Point(214, 42);
            this.chk_system.Name = "chk_system";
            this.chk_system.Size = new System.Drawing.Size(60, 17);
            this.chk_system.TabIndex = 9;
            this.chk_system.Text = "System";
            this.chk_system.UseVisualStyleBackColor = true;
            // 
            // chk_readonly
            // 
            this.chk_readonly.AutoSize = true;
            this.chk_readonly.Location = new System.Drawing.Point(214, 19);
            this.chk_readonly.Name = "chk_readonly";
            this.chk_readonly.Size = new System.Drawing.Size(73, 17);
            this.chk_readonly.TabIndex = 8;
            this.chk_readonly.Text = "ReadOnly";
            this.chk_readonly.UseVisualStyleBackColor = true;
            // 
            // chk_hidden
            // 
            this.chk_hidden.AutoSize = true;
            this.chk_hidden.Location = new System.Drawing.Point(6, 42);
            this.chk_hidden.Name = "chk_hidden";
            this.chk_hidden.Size = new System.Drawing.Size(60, 17);
            this.chk_hidden.TabIndex = 7;
            this.chk_hidden.Text = "Hidden";
            this.chk_hidden.UseVisualStyleBackColor = true;
            // 
            // chk_encrypted
            // 
            this.chk_encrypted.AutoSize = true;
            this.chk_encrypted.Enabled = false;
            this.chk_encrypted.Location = new System.Drawing.Point(214, 65);
            this.chk_encrypted.Name = "chk_encrypted";
            this.chk_encrypted.Size = new System.Drawing.Size(142, 17);
            this.chk_encrypted.TabIndex = 6;
            this.chk_encrypted.Text = "Encrypted (NTFS drives)";
            this.chk_encrypted.UseVisualStyleBackColor = true;
            // 
            // chk_compressed
            // 
            this.chk_compressed.AutoSize = true;
            this.chk_compressed.Enabled = false;
            this.chk_compressed.Location = new System.Drawing.Point(6, 65);
            this.chk_compressed.Name = "chk_compressed";
            this.chk_compressed.Size = new System.Drawing.Size(84, 17);
            this.chk_compressed.TabIndex = 3;
            this.chk_compressed.Text = "Compressed";
            this.chk_compressed.UseVisualStyleBackColor = true;
            // 
            // chk_ChangeAccessedDate
            // 
            this.chk_ChangeAccessedDate.AutoSize = true;
            this.chk_ChangeAccessedDate.Location = new System.Drawing.Point(304, 82);
            this.chk_ChangeAccessedDate.Name = "chk_ChangeAccessedDate";
            this.chk_ChangeAccessedDate.Size = new System.Drawing.Size(63, 17);
            this.chk_ChangeAccessedDate.TabIndex = 24;
            this.chk_ChangeAccessedDate.Text = "Change";
            this.chk_ChangeAccessedDate.UseVisualStyleBackColor = true;
            this.chk_ChangeAccessedDate.CheckedChanged += new System.EventHandler(this.chk_ChangeAccessedDate_CheckedChanged);
            // 
            // chk_ChangeModifiedDate
            // 
            this.chk_ChangeModifiedDate.AutoSize = true;
            this.chk_ChangeModifiedDate.Location = new System.Drawing.Point(304, 50);
            this.chk_ChangeModifiedDate.Name = "chk_ChangeModifiedDate";
            this.chk_ChangeModifiedDate.Size = new System.Drawing.Size(63, 17);
            this.chk_ChangeModifiedDate.TabIndex = 23;
            this.chk_ChangeModifiedDate.Text = "Change";
            this.chk_ChangeModifiedDate.UseVisualStyleBackColor = true;
            this.chk_ChangeModifiedDate.CheckedChanged += new System.EventHandler(this.chk_ChangeModifiedDate_CheckedChanged);
            // 
            // chk_ChangeCreatedDate
            // 
            this.chk_ChangeCreatedDate.AutoSize = true;
            this.chk_ChangeCreatedDate.Location = new System.Drawing.Point(304, 19);
            this.chk_ChangeCreatedDate.Name = "chk_ChangeCreatedDate";
            this.chk_ChangeCreatedDate.Size = new System.Drawing.Size(63, 17);
            this.chk_ChangeCreatedDate.TabIndex = 22;
            this.chk_ChangeCreatedDate.Text = "Change";
            this.chk_ChangeCreatedDate.UseVisualStyleBackColor = true;
            this.chk_ChangeCreatedDate.CheckedChanged += new System.EventHandler(this.chk_ChangeCreatedDate_CheckedChanged);
            // 
            // lbl_AccessedDate
            // 
            this.lbl_AccessedDate.AutoSize = true;
            this.lbl_AccessedDate.Location = new System.Drawing.Point(17, 84);
            this.lbl_AccessedDate.Name = "lbl_AccessedDate";
            this.lbl_AccessedDate.Size = new System.Drawing.Size(80, 13);
            this.lbl_AccessedDate.TabIndex = 21;
            this.lbl_AccessedDate.Text = "Accessed Date";
            // 
            // dtp_accesseddate
            // 
            this.dtp_accesseddate.Enabled = false;
            this.dtp_accesseddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_accesseddate.Location = new System.Drawing.Point(106, 80);
            this.dtp_accesseddate.Name = "dtp_accesseddate";
            this.dtp_accesseddate.Size = new System.Drawing.Size(105, 20);
            this.dtp_accesseddate.TabIndex = 20;
            // 
            // lbl_modifiedDate
            // 
            this.lbl_modifiedDate.AutoSize = true;
            this.lbl_modifiedDate.Location = new System.Drawing.Point(17, 51);
            this.lbl_modifiedDate.Name = "lbl_modifiedDate";
            this.lbl_modifiedDate.Size = new System.Drawing.Size(73, 13);
            this.lbl_modifiedDate.TabIndex = 19;
            this.lbl_modifiedDate.Text = "Modified Date";
            // 
            // lbl_CreatedDate
            // 
            this.lbl_CreatedDate.AutoSize = true;
            this.lbl_CreatedDate.Location = new System.Drawing.Point(20, 20);
            this.lbl_CreatedDate.Name = "lbl_CreatedDate";
            this.lbl_CreatedDate.Size = new System.Drawing.Size(70, 13);
            this.lbl_CreatedDate.TabIndex = 18;
            this.lbl_CreatedDate.Text = "Created Date";
            // 
            // dtp_modifieddate
            // 
            this.dtp_modifieddate.Enabled = false;
            this.dtp_modifieddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_modifieddate.Location = new System.Drawing.Point(106, 48);
            this.dtp_modifieddate.Name = "dtp_modifieddate";
            this.dtp_modifieddate.Size = new System.Drawing.Size(105, 20);
            this.dtp_modifieddate.TabIndex = 17;
            // 
            // dtp_creationdate
            // 
            this.dtp_creationdate.Enabled = false;
            this.dtp_creationdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_creationdate.Location = new System.Drawing.Point(106, 16);
            this.dtp_creationdate.Name = "dtp_creationdate";
            this.dtp_creationdate.Size = new System.Drawing.Size(105, 20);
            this.dtp_creationdate.TabIndex = 16;
            // 
            // btn_AddFiles
            // 
            this.btn_AddFiles.Location = new System.Drawing.Point(443, 29);
            this.btn_AddFiles.Name = "btn_AddFiles";
            this.btn_AddFiles.Size = new System.Drawing.Size(75, 23);
            this.btn_AddFiles.TabIndex = 4;
            this.btn_AddFiles.Text = "Add Files";
            this.btn_AddFiles.UseVisualStyleBackColor = true;
            this.btn_AddFiles.Click += new System.EventHandler(this.btn_AddFiles_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(443, 112);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "Clear List";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // gbx_filedates
            // 
            this.gbx_filedates.Controls.Add(this.lbl_CreatedDate);
            this.gbx_filedates.Controls.Add(this.chk_ChangeAccessedDate);
            this.gbx_filedates.Controls.Add(this.chk_ChangeModifiedDate);
            this.gbx_filedates.Controls.Add(this.dtp_creationdate);
            this.gbx_filedates.Controls.Add(this.chk_ChangeCreatedDate);
            this.gbx_filedates.Controls.Add(this.dtp_modifieddate);
            this.gbx_filedates.Controls.Add(this.lbl_modifiedDate);
            this.gbx_filedates.Controls.Add(this.lbl_AccessedDate);
            this.gbx_filedates.Controls.Add(this.dtp_accesseddate);
            this.gbx_filedates.Location = new System.Drawing.Point(44, 297);
            this.gbx_filedates.Name = "gbx_filedates";
            this.gbx_filedates.Size = new System.Drawing.Size(393, 114);
            this.gbx_filedates.TabIndex = 25;
            this.gbx_filedates.TabStop = false;
            this.gbx_filedates.Text = "DateAttributes";
            // 
            // dgv_filescollection
            // 
            this.dgv_filescollection.AllowUserToAddRows = false;
            this.dgv_filescollection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_filescollection.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_filescollection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_filescollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_filescollection.Location = new System.Drawing.Point(33, 29);
            this.dgv_filescollection.Name = "dgv_filescollection";
            this.dgv_filescollection.ReadOnly = true;
            this.dgv_filescollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_filescollection.Size = new System.Drawing.Size(404, 115);
            this.dgv_filescollection.TabIndex = 26;
            this.dgv_filescollection.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_filescollection_RowEnter);
            // 
            // btn_addfolder
            // 
            this.btn_addfolder.Location = new System.Drawing.Point(444, 69);
            this.btn_addfolder.Name = "btn_addfolder";
            this.btn_addfolder.Size = new System.Drawing.Size(75, 23);
            this.btn_addfolder.TabIndex = 27;
            this.btn_addfolder.Text = "Add Folder";
            this.btn_addfolder.UseVisualStyleBackColor = true;
            this.btn_addfolder.Click += new System.EventHandler(this.btn_addfolder_Click);
            // 
            // rbtn_folderonly
            // 
            this.rbtn_folderonly.AutoSize = true;
            this.rbtn_folderonly.Location = new System.Drawing.Point(6, 18);
            this.rbtn_folderonly.Name = "rbtn_folderonly";
            this.rbtn_folderonly.Size = new System.Drawing.Size(161, 17);
            this.rbtn_folderonly.TabIndex = 28;
            this.rbtn_folderonly.TabStop = true;
            this.rbtn_folderonly.Text = "Apply changes to Folder only";
            this.rbtn_folderonly.UseVisualStyleBackColor = true;
            // 
            // rbtn_changestoall
            // 
            this.rbtn_changestoall.AutoSize = true;
            this.rbtn_changestoall.Checked = true;
            this.rbtn_changestoall.Location = new System.Drawing.Point(193, 18);
            this.rbtn_changestoall.Name = "rbtn_changestoall";
            this.rbtn_changestoall.Size = new System.Drawing.Size(241, 17);
            this.rbtn_changestoall.TabIndex = 29;
            this.rbtn_changestoall.TabStop = true;
            this.rbtn_changestoall.Text = "Apply Changes to Folder, Subfolders and Files";
            this.rbtn_changestoall.UseVisualStyleBackColor = true;
            // 
            // gbx_folderoptions
            // 
            this.gbx_folderoptions.Controls.Add(this.rbtn_folderonly);
            this.gbx_folderoptions.Controls.Add(this.rbtn_changestoall);
            this.gbx_folderoptions.Location = new System.Drawing.Point(33, 151);
            this.gbx_folderoptions.Name = "gbx_folderoptions";
            this.gbx_folderoptions.Size = new System.Drawing.Size(440, 41);
            this.gbx_folderoptions.TabIndex = 30;
            this.gbx_folderoptions.TabStop = false;
            this.gbx_folderoptions.Text = "FolderAttributeChangeOptions";
            // 
            // FileAttributeChanger
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 469);
            this.Controls.Add(this.gbx_folderoptions);
            this.Controls.Add(this.btn_addfolder);
            this.Controls.Add(this.dgv_filescollection);
            this.Controls.Add(this.gbx_filedates);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_AddFiles);
            this.Controls.Add(this.gbx_attributes);
            this.Controls.Add(this.btn_ChangeAttribs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FileAttributeChanger";
            this.Text = "FileAttributeChanger";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileAttributeChanger_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.FileAttributeChanger_DragOver);
            this.gbx_attributes.ResumeLayout(false);
            this.gbx_attributes.PerformLayout();
            this.gbx_filedates.ResumeLayout(false);
            this.gbx_filedates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_filescollection)).EndInit();
            this.gbx_folderoptions.ResumeLayout(false);
            this.gbx_folderoptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ChangeAttribs;
        private System.Windows.Forms.CheckBox chk_archive;
        private System.Windows.Forms.GroupBox gbx_attributes;
        private System.Windows.Forms.CheckBox chk_system;
        private System.Windows.Forms.CheckBox chk_readonly;
        private System.Windows.Forms.CheckBox chk_hidden;
        private System.Windows.Forms.CheckBox chk_encrypted;
        private System.Windows.Forms.CheckBox chk_compressed;
        private System.Windows.Forms.DateTimePicker dtp_modifieddate;
        private System.Windows.Forms.DateTimePicker dtp_creationdate;
        private System.Windows.Forms.Label lbl_AccessedDate;
        private System.Windows.Forms.DateTimePicker dtp_accesseddate;
        private System.Windows.Forms.Label lbl_modifiedDate;
        private System.Windows.Forms.Label lbl_CreatedDate;
        private System.Windows.Forms.CheckBox chk_ChangeModifiedDate;
        private System.Windows.Forms.CheckBox chk_ChangeCreatedDate;
        private System.Windows.Forms.Button btn_AddFiles;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.CheckBox chk_ChangeAccessedDate;
        private System.Windows.Forms.GroupBox gbx_filedates;
        private System.Windows.Forms.DataGridView dgv_filescollection;
        private System.Windows.Forms.Button btn_addfolder;
        private System.Windows.Forms.RadioButton rbtn_folderonly;
        private System.Windows.Forms.RadioButton rbtn_changestoall;
        private System.Windows.Forms.GroupBox gbx_folderoptions;
    }
}

