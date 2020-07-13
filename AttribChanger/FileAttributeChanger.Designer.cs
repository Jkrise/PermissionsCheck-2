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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileAttributeChanger));
            this.btn_ChangeAttribs = new System.Windows.Forms.Button();
            this.chk_archive = new System.Windows.Forms.CheckBox();
            this.gbx_attributes = new System.Windows.Forms.GroupBox();
            this.chk_system = new System.Windows.Forms.CheckBox();
            this.chk_readonly = new System.Windows.Forms.CheckBox();
            this.chk_hidden = new System.Windows.Forms.CheckBox();
            this.chk_encrypted = new System.Windows.Forms.CheckBox();
            this.chk_compressed = new System.Windows.Forms.CheckBox();
            this.CuserFP = new System.Windows.Forms.CheckBox();
            this.lbl_CreatedDate = new System.Windows.Forms.Label();
            this.gbx_filedates = new System.Windows.Forms.GroupBox();
            this.AdminUserFP = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AuthuserFP = new System.Windows.Forms.CheckBox();
            this.lbl_modifiedDate = new System.Windows.Forms.Label();
            this.dgv_filescollection = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.takeOwnershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rbtn_folderonly = new System.Windows.Forms.RadioButton();
            this.rbtn_changestoall = new System.Windows.Forms.RadioButton();
            this.gbx_folderoptions = new System.Windows.Forms.GroupBox();
            this.Exit = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Status2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.AddFile = new System.Windows.Forms.Button();
            this.AddFolders = new System.Windows.Forms.Button();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.gbx_attributes.SuspendLayout();
            this.gbx_filedates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_filescollection)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.gbx_folderoptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ChangeAttribs
            // 
            this.btn_ChangeAttribs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ChangeAttribs.Location = new System.Drawing.Point(156, 448);
            this.btn_ChangeAttribs.Name = "btn_ChangeAttribs";
            this.btn_ChangeAttribs.Size = new System.Drawing.Size(125, 28);
            this.btn_ChangeAttribs.TabIndex = 1;
            this.btn_ChangeAttribs.Text = "&Apply";
            this.btn_ChangeAttribs.UseVisualStyleBackColor = true;
            this.btn_ChangeAttribs.Click += new System.EventHandler(this.btn_ChangeAttribs_Click);
            // 
            // chk_archive
            // 
            this.chk_archive.AutoSize = true;
            this.chk_archive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_archive.Location = new System.Drawing.Point(20, 19);
            this.chk_archive.Name = "chk_archive";
            this.chk_archive.Size = new System.Drawing.Size(62, 17);
            this.chk_archive.TabIndex = 2;
            this.chk_archive.Text = "Archive";
            this.chk_archive.UseVisualStyleBackColor = true;
            // 
            // gbx_attributes
            // 
            this.gbx_attributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_attributes.BackColor = System.Drawing.Color.Transparent;
            this.gbx_attributes.Controls.Add(this.chk_system);
            this.gbx_attributes.Controls.Add(this.chk_readonly);
            this.gbx_attributes.Controls.Add(this.chk_hidden);
            this.gbx_attributes.Controls.Add(this.chk_encrypted);
            this.gbx_attributes.Controls.Add(this.chk_compressed);
            this.gbx_attributes.Controls.Add(this.chk_archive);
            this.gbx_attributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_attributes.Location = new System.Drawing.Point(12, 349);
            this.gbx_attributes.Name = "gbx_attributes";
            this.gbx_attributes.Size = new System.Drawing.Size(293, 93);
            this.gbx_attributes.TabIndex = 3;
            this.gbx_attributes.TabStop = false;
            this.gbx_attributes.Text = "File Folder Attributes";
            // 
            // chk_system
            // 
            this.chk_system.AutoSize = true;
            this.chk_system.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_system.Location = new System.Drawing.Point(109, 42);
            this.chk_system.Name = "chk_system";
            this.chk_system.Size = new System.Drawing.Size(60, 17);
            this.chk_system.TabIndex = 9;
            this.chk_system.Text = "System";
            this.chk_system.UseVisualStyleBackColor = true;
            // 
            // chk_readonly
            // 
            this.chk_readonly.AutoSize = true;
            this.chk_readonly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_readonly.Location = new System.Drawing.Point(109, 19);
            this.chk_readonly.Name = "chk_readonly";
            this.chk_readonly.Size = new System.Drawing.Size(73, 17);
            this.chk_readonly.TabIndex = 8;
            this.chk_readonly.Text = "ReadOnly";
            this.chk_readonly.UseVisualStyleBackColor = true;
            // 
            // chk_hidden
            // 
            this.chk_hidden.AutoSize = true;
            this.chk_hidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_hidden.Location = new System.Drawing.Point(20, 42);
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
            this.chk_encrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_encrypted.Location = new System.Drawing.Point(109, 65);
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
            this.chk_compressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_compressed.Location = new System.Drawing.Point(20, 65);
            this.chk_compressed.Name = "chk_compressed";
            this.chk_compressed.Size = new System.Drawing.Size(84, 17);
            this.chk_compressed.TabIndex = 3;
            this.chk_compressed.Text = "Compressed";
            this.chk_compressed.UseVisualStyleBackColor = true;
            // 
            // CuserFP
            // 
            this.CuserFP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CuserFP.AutoSize = true;
            this.CuserFP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CuserFP.Location = new System.Drawing.Point(185, 19);
            this.CuserFP.Name = "CuserFP";
            this.CuserFP.Size = new System.Drawing.Size(95, 17);
            this.CuserFP.TabIndex = 22;
            this.CuserFP.Text = "Full Permission";
            this.CuserFP.UseVisualStyleBackColor = true;
            // 
            // lbl_CreatedDate
            // 
            this.lbl_CreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_CreatedDate.AutoSize = true;
            this.lbl_CreatedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CreatedDate.Location = new System.Drawing.Point(29, 20);
            this.lbl_CreatedDate.Name = "lbl_CreatedDate";
            this.lbl_CreatedDate.Size = new System.Drawing.Size(69, 13);
            this.lbl_CreatedDate.TabIndex = 18;
            this.lbl_CreatedDate.Text = "Current User:";
            // 
            // gbx_filedates
            // 
            this.gbx_filedates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_filedates.BackColor = System.Drawing.Color.Transparent;
            this.gbx_filedates.Controls.Add(this.AdminUserFP);
            this.gbx_filedates.Controls.Add(this.label1);
            this.gbx_filedates.Controls.Add(this.lbl_CreatedDate);
            this.gbx_filedates.Controls.Add(this.AuthuserFP);
            this.gbx_filedates.Controls.Add(this.CuserFP);
            this.gbx_filedates.Controls.Add(this.lbl_modifiedDate);
            this.gbx_filedates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_filedates.Location = new System.Drawing.Point(311, 349);
            this.gbx_filedates.Name = "gbx_filedates";
            this.gbx_filedates.Size = new System.Drawing.Size(382, 93);
            this.gbx_filedates.TabIndex = 25;
            this.gbx_filedates.TabStop = false;
            this.gbx_filedates.Text = "Permissions";
            // 
            // AdminUserFP
            // 
            this.AdminUserFP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AdminUserFP.AutoSize = true;
            this.AdminUserFP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminUserFP.Location = new System.Drawing.Point(185, 64);
            this.AdminUserFP.Name = "AdminUserFP";
            this.AdminUserFP.Size = new System.Drawing.Size(95, 17);
            this.AdminUserFP.TabIndex = 25;
            this.AdminUserFP.Text = "Full Permission";
            this.AdminUserFP.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Administrators:";
            // 
            // AuthuserFP
            // 
            this.AuthuserFP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AuthuserFP.AutoSize = true;
            this.AuthuserFP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthuserFP.Location = new System.Drawing.Point(185, 42);
            this.AuthuserFP.Name = "AuthuserFP";
            this.AuthuserFP.Size = new System.Drawing.Size(95, 17);
            this.AuthuserFP.TabIndex = 23;
            this.AuthuserFP.Text = "Full Permission";
            this.AuthuserFP.UseVisualStyleBackColor = true;
            // 
            // lbl_modifiedDate
            // 
            this.lbl_modifiedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_modifiedDate.AutoSize = true;
            this.lbl_modifiedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modifiedDate.Location = new System.Drawing.Point(28, 42);
            this.lbl_modifiedDate.Name = "lbl_modifiedDate";
            this.lbl_modifiedDate.Size = new System.Drawing.Size(106, 13);
            this.lbl_modifiedDate.TabIndex = 19;
            this.lbl_modifiedDate.Text = "Authenticated Users:";
            // 
            // dgv_filescollection
            // 
            this.dgv_filescollection.AllowUserToAddRows = false;
            this.dgv_filescollection.AllowUserToDeleteRows = false;
            this.dgv_filescollection.AllowUserToResizeColumns = false;
            this.dgv_filescollection.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_filescollection.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_filescollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_filescollection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgv_filescollection.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv_filescollection.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_filescollection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_filescollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_filescollection.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_filescollection.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_filescollection.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgv_filescollection.Location = new System.Drawing.Point(12, 10);
            this.dgv_filescollection.Name = "dgv_filescollection";
            this.dgv_filescollection.ReadOnly = true;
            this.dgv_filescollection.RowHeadersWidth = 28;
            this.dgv_filescollection.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.dgv_filescollection.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_filescollection.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_filescollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_filescollection.Size = new System.Drawing.Size(681, 286);
            this.dgv_filescollection.TabIndex = 26;
            this.dgv_filescollection.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_filescollection_CellContentClick);
            this.dgv_filescollection.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_filescollection_DoubleClick);
            this.dgv_filescollection.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_filescollection_RowEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeOwnershipToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // takeOwnershipToolStripMenuItem
            // 
            this.takeOwnershipToolStripMenuItem.Name = "takeOwnershipToolStripMenuItem";
            this.takeOwnershipToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.takeOwnershipToolStripMenuItem.Text = "Take Ownership";
            this.takeOwnershipToolStripMenuItem.Click += new System.EventHandler(this.takeOwnershipToolStripMenuItem_Click);
            // 
            // rbtn_folderonly
            // 
            this.rbtn_folderonly.AutoSize = true;
            this.rbtn_folderonly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_folderonly.Location = new System.Drawing.Point(13, 18);
            this.rbtn_folderonly.Name = "rbtn_folderonly";
            this.rbtn_folderonly.Size = new System.Drawing.Size(161, 17);
            this.rbtn_folderonly.TabIndex = 28;
            this.rbtn_folderonly.TabStop = true;
            this.rbtn_folderonly.Text = "Apply changes to Folder only";
            this.rbtn_folderonly.UseVisualStyleBackColor = true;
            this.rbtn_folderonly.CheckedChanged += new System.EventHandler(this.rbtn_folderonly_CheckedChanged);
            // 
            // rbtn_changestoall
            // 
            this.rbtn_changestoall.AutoSize = true;
            this.rbtn_changestoall.Checked = true;
            this.rbtn_changestoall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_changestoall.Location = new System.Drawing.Point(205, 18);
            this.rbtn_changestoall.Name = "rbtn_changestoall";
            this.rbtn_changestoall.Size = new System.Drawing.Size(241, 17);
            this.rbtn_changestoall.TabIndex = 29;
            this.rbtn_changestoall.TabStop = true;
            this.rbtn_changestoall.Text = "Apply Changes to Folder, Subfolders and Files";
            this.rbtn_changestoall.UseVisualStyleBackColor = true;
            // 
            // gbx_folderoptions
            // 
            this.gbx_folderoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_folderoptions.BackColor = System.Drawing.Color.Transparent;
            this.gbx_folderoptions.Controls.Add(this.rbtn_folderonly);
            this.gbx_folderoptions.Controls.Add(this.rbtn_changestoall);
            this.gbx_folderoptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_folderoptions.Location = new System.Drawing.Point(12, 302);
            this.gbx_folderoptions.Name = "gbx_folderoptions";
            this.gbx_folderoptions.Size = new System.Drawing.Size(681, 41);
            this.gbx_folderoptions.TabIndex = 30;
            this.gbx_folderoptions.TabStop = false;
            this.gbx_folderoptions.Text = "Folder Attribute Change Options";
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exit.Location = new System.Drawing.Point(156, 486);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(125, 28);
            this.Exit.TabIndex = 32;
            this.Exit.Text = "E&xit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // status
            // 
            this.status.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.Color.MidnightBlue;
            this.status.Location = new System.Drawing.Point(3, 16);
            this.status.Margin = new System.Windows.Forms.Padding(0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(400, 47);
            this.status.TabIndex = 33;
            this.status.UseMnemonic = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Status2);
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(287, 448);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 66);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Status2
            // 
            this.Status2.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.Status2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Status2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Status2.Location = new System.Drawing.Point(3, 16);
            this.Status2.Margin = new System.Windows.Forms.Padding(0);
            this.Status2.MinimumSize = new System.Drawing.Size(400, 47);
            this.Status2.Name = "Status2";
            this.Status2.Size = new System.Drawing.Size(400, 47);
            this.Status2.TabIndex = 34;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // AddFile
            // 
            this.AddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddFile.Location = new System.Drawing.Point(12, 448);
            this.AddFile.Name = "AddFile";
            this.AddFile.Size = new System.Drawing.Size(125, 28);
            this.AddFile.TabIndex = 35;
            this.AddFile.Text = "Add Additional &Files";
            this.AddFile.UseVisualStyleBackColor = true;
            this.AddFile.Click += new System.EventHandler(this.AddFile_Click);
            // 
            // AddFolders
            // 
            this.AddFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddFolders.Location = new System.Drawing.Point(12, 486);
            this.AddFolders.Name = "AddFolders";
            this.AddFolders.Size = new System.Drawing.Size(125, 28);
            this.AddFolders.TabIndex = 36;
            this.AddFolders.Text = "Add Additional Fol&ders";
            this.AddFolders.UseVisualStyleBackColor = true;
            this.AddFolders.Click += new System.EventHandler(this.AddFolders_Click);
            // 
            // myTimer
            // 
            this.myTimer.Interval = 1000;
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // FileAttributeChanger
            // 
            this.AcceptButton = this.btn_ChangeAttribs;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 526);
            this.Controls.Add(this.AddFolders);
            this.Controls.Add(this.AddFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.gbx_folderoptions);
            this.Controls.Add(this.dgv_filescollection);
            this.Controls.Add(this.gbx_filedates);
            this.Controls.Add(this.gbx_attributes);
            this.Controls.Add(this.btn_ChangeAttribs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(662, 449);
            this.Name = "FileAttributeChanger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permissions Check";
            this.Load += new System.EventHandler(this.FileAttributeChanger_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileAttributeChanger_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.FileAttributeChanger_DragOver);
            this.gbx_attributes.ResumeLayout(false);
            this.gbx_attributes.PerformLayout();
            this.gbx_filedates.ResumeLayout(false);
            this.gbx_filedates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_filescollection)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbx_folderoptions.ResumeLayout(false);
            this.gbx_folderoptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Label lbl_CreatedDate;
        private System.Windows.Forms.CheckBox CuserFP;
        private System.Windows.Forms.GroupBox gbx_filedates;
        private System.Windows.Forms.DataGridView dgv_filescollection;
        private System.Windows.Forms.RadioButton rbtn_folderonly;
        private System.Windows.Forms.RadioButton rbtn_changestoall;
        private System.Windows.Forms.GroupBox gbx_folderoptions;
        private System.Windows.Forms.CheckBox AuthuserFP;
        private System.Windows.Forms.Label lbl_modifiedDate;
        private System.Windows.Forms.CheckBox AdminUserFP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button AddFile;
        private System.Windows.Forms.Button AddFolders;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem takeOwnershipToolStripMenuItem;
        private System.Windows.Forms.Timer myTimer;
        private System.Windows.Forms.Label Status2;
    }
}

