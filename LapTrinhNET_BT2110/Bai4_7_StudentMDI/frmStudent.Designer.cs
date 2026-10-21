namespace Bai4_7_StudentMDI
{
    partial class frmStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnChooseAvatar = new System.Windows.Forms.Button();
            this.txtAvatarPath = new System.Windows.Forms.TextBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.cmsStudents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCtxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCtxRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCtxDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialogAvatar = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogCsv = new System.Windows.Forms.SaveFileDialog();

            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.grpActions.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.cmsStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // 
            // grpInput
            // 
            this.grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInput.Controls.Add(this.txtAvatarPath);
            this.grpInput.Controls.Add(this.btnChooseAvatar);
            this.grpInput.Controls.Add(this.picAvatar);
            this.grpInput.Controls.Add(this.lblAvatar);
            this.grpInput.Controls.Add(this.cboGender);
            this.grpInput.Controls.Add(this.lblGender);
            this.grpInput.Controls.Add(this.txtAge);
            this.grpInput.Controls.Add(this.lblAge);
            this.grpInput.Controls.Add(this.txtFullName);
            this.grpInput.Controls.Add(this.lblFullName);
            this.grpInput.Controls.Add(this.txtStudentId);
            this.grpInput.Controls.Add(this.lblStudentId);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(840, 180);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Thông tin sinh viên";

            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(15, 28);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(77, 15);
            this.lblStudentId.TabIndex = 0;
            this.lblStudentId.Text = "Mã sinh viên:";

            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(105, 25);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(200, 23);
            this.txtStudentId.TabIndex = 1;

            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(15, 65);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(61, 15);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Họ và tên:";

            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(105, 62);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 23);
            this.txtFullName.TabIndex = 3;

            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(15, 102);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(33, 15);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "Tuổi:";

            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(105, 99);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(200, 23);
            this.txtAge.TabIndex = 5;

            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(15, 139);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(55, 15);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Giới tính:";

            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(105, 136);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(200, 23);
            this.cboGender.TabIndex = 7;

            // 
            // lblAvatar
            // 
            this.lblAvatar.AutoSize = true;
            this.lblAvatar.Location = new System.Drawing.Point(350, 28);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(77, 15);
            this.lblAvatar.TabIndex = 8;
            this.lblAvatar.Text = "Ảnh đại diện:";

            // 
            // picAvatar
            // 
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(440, 25);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(125, 135);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 9;
            this.picAvatar.TabStop = false;

            // 
            // btnChooseAvatar
            // 
            this.btnChooseAvatar.Location = new System.Drawing.Point(580, 25);
            this.btnChooseAvatar.Name = "btnChooseAvatar";
            this.btnChooseAvatar.Size = new System.Drawing.Size(100, 30);
            this.btnChooseAvatar.TabIndex = 10;
            this.btnChooseAvatar.Text = "Chọn ảnh...";
            this.btnChooseAvatar.UseVisualStyleBackColor = true;
            this.btnChooseAvatar.Click += new System.EventHandler(this.btnChooseAvatar_Click);

            // 
            // txtAvatarPath
            // 
            this.txtAvatarPath.Location = new System.Drawing.Point(580, 62);
            this.txtAvatarPath.Name = "txtAvatarPath";
            this.txtAvatarPath.ReadOnly = true;
            this.txtAvatarPath.Size = new System.Drawing.Size(235, 23);
            this.txtAvatarPath.TabIndex = 11;

            // 
            // grpActions
            // 
            this.grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActions.Controls.Add(this.btnExportCsv);
            this.grpActions.Controls.Add(this.btnClear);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.btnUpdate);
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Location = new System.Drawing.Point(12, 198);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(840, 60);
            this.grpActions.TabIndex = 1;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Chức năng";

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(125, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(235, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(345, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(455, 20);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(105, 30);
            this.btnExportCsv.TabIndex = 4;
            this.btnExportCsv.Text = "Xuất CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);

            // 
            // grpList
            // 
            this.grpList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpList.Controls.Add(this.dgvStudents);
            this.grpList.Location = new System.Drawing.Point(12, 264);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(840, 275);
            this.grpList.TabIndex = 2;
            this.grpList.TabStop = false;
            this.grpList.Text = "Danh sách sinh viên (Nhấp chuột phải để mở menu ngữ cảnh)";

            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.ContextMenuStrip = this.cmsStudents;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.Location = new System.Drawing.Point(3, 19);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(834, 253);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvStudents_MouseDown);

            // 
            // cmsStudents
            // 
            this.cmsStudents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCtxDelete,
            this.menuCtxRefresh,
            this.toolStripSeparator1,
            this.menuCtxDetails});
            this.cmsStudents.Name = "cmsStudents";
            this.cmsStudents.Size = new System.Drawing.Size(157, 76);

            // 
            // menuCtxDelete
            // 
            this.menuCtxDelete.Name = "menuCtxDelete";
            this.menuCtxDelete.Size = new System.Drawing.Size(156, 22);
            this.menuCtxDelete.Text = "Xóa dòng";
            this.menuCtxDelete.Click += new System.EventHandler(this.menuCtxDelete_Click);

            // 
            // menuCtxRefresh
            // 
            this.menuCtxRefresh.Name = "menuCtxRefresh";
            this.menuCtxRefresh.Size = new System.Drawing.Size(156, 22);
            this.menuCtxRefresh.Text = "Làm mới dữ liệu";
            this.menuCtxRefresh.Click += new System.EventHandler(this.menuCtxRefresh_Click);

            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);

            // 
            // menuCtxDetails
            // 
            this.menuCtxDetails.Name = "menuCtxDetails";
            this.menuCtxDetails.Size = new System.Drawing.Size(156, 22);
            this.menuCtxDetails.Text = "Xem chi tiết";
            this.menuCtxDetails.Click += new System.EventHandler(this.menuCtxDetails_Click);

            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;

            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 551);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpInput);
            this.MinimumSize = new System.Drawing.Size(880, 560);
            this.Name = "frmStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Sinh viên";
            this.Load += new System.EventHandler(this.frmStudent_Load);

            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.grpActions.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.cmsStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseAvatar;
        private System.Windows.Forms.TextBox txtAvatarPath;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ContextMenuStrip cmsStudents;
        private System.Windows.Forms.ToolStripMenuItem menuCtxDelete;
        private System.Windows.Forms.ToolStripMenuItem menuCtxRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuCtxDetails;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialogAvatar;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCsv;
    }
}
