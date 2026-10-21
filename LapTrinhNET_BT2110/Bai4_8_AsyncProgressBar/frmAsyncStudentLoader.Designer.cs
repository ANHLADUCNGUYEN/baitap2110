namespace Bai4_8_AsyncProgressBar
{
    partial class frmAsyncStudentLoader
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
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoadAsync = new System.Windows.Forms.Button();
            this.numRecordCount = new System.Windows.Forms.NumericUpDown();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.grpProgress = new System.Windows.Forms.GroupBox();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.prgLoading = new System.Windows.Forms.ProgressBar();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();

            this.grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRecordCount)).BeginInit();
            this.grpProgress.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();

            // 
            // grpControl
            // 
            this.grpControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpControl.Controls.Add(this.btnClear);
            this.grpControl.Controls.Add(this.btnCancel);
            this.grpControl.Controls.Add(this.btnLoadAsync);
            this.grpControl.Controls.Add(this.numRecordCount);
            this.grpControl.Controls.Add(this.lblTotalRecords);
            this.grpControl.Location = new System.Drawing.Point(12, 12);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(860, 75);
            this.grpControl.TabIndex = 0;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Điều khiển tác vụ nạp dữ liệu bất đồng bộ (Async/Await)";

            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(620, 26);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 32);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Xóa dữ liệu";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(495, 26);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy tiến trình";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // btnLoadAsync
            // 
            this.btnLoadAsync.Location = new System.Drawing.Point(275, 26);
            this.btnLoadAsync.Name = "btnLoadAsync";
            this.btnLoadAsync.Size = new System.Drawing.Size(205, 32);
            this.btnLoadAsync.TabIndex = 2;
            this.btnLoadAsync.Text = "Nạp dữ liệu bất đồng bộ (Async)";
            this.btnLoadAsync.UseVisualStyleBackColor = true;
            this.btnLoadAsync.Click += new System.EventHandler(this.btnLoadAsync_Click);

            // 
            // numRecordCount
            // 
            this.numRecordCount.Location = new System.Drawing.Point(165, 32);
            this.numRecordCount.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numRecordCount.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numRecordCount.Name = "numRecordCount";
            this.numRecordCount.Size = new System.Drawing.Size(90, 23);
            this.numRecordCount.TabIndex = 1;
            this.numRecordCount.Value = new decimal(new int[] { 50, 0, 0, 0 });

            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Location = new System.Drawing.Point(20, 34);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(130, 15);
            this.lblTotalRecords.TabIndex = 0;
            this.lblTotalRecords.Text = "Số bản ghi mô phỏng:";

            // 
            // grpProgress
            // 
            this.grpProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProgress.Controls.Add(this.lblProgressStatus);
            this.grpProgress.Controls.Add(this.lblProgressPercent);
            this.grpProgress.Controls.Add(this.prgLoading);
            this.grpProgress.Location = new System.Drawing.Point(12, 93);
            this.grpProgress.Name = "grpProgress";
            this.grpProgress.Size = new System.Drawing.Size(860, 85);
            this.grpProgress.TabIndex = 1;
            this.grpProgress.TabStop = false;
            this.grpProgress.Text = "Tiến trình hoàn thành (ProgressBar & IProgress<int>)";

            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Location = new System.Drawing.Point(20, 56);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(124, 15);
            this.lblProgressStatus.TabIndex = 2;
            this.lblProgressStatus.Text = "Trạng thái: Sẵn sàng";

            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressPercent.AutoSize = true;
            this.lblProgressPercent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProgressPercent.Location = new System.Drawing.Point(815, 29);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(25, 15);
            this.lblProgressPercent.TabIndex = 1;
            this.lblProgressPercent.Text = "0%";

            // 
            // prgLoading
            // 
            this.prgLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgLoading.Location = new System.Drawing.Point(20, 25);
            this.prgLoading.Name = "prgLoading";
            this.prgLoading.Size = new System.Drawing.Size(780, 23);
            this.prgLoading.TabIndex = 0;

            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Controls.Add(this.dgvStudents);
            this.grpData.Location = new System.Drawing.Point(12, 184);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(860, 345);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            this.grpData.Text = "Dữ liệu sinh viên đã nạp";

            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.Location = new System.Drawing.Point(3, 19);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(854, 323);
            this.dgvStudents.TabIndex = 0;

            // 
            // frmAsyncStudentLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpProgress);
            this.Controls.Add(this.grpControl);
            this.MinimumSize = new System.Drawing.Size(900, 580);
            this.Name = "frmAsyncStudentLoader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nạp dữ liệu Bất đồng bộ (Async/Await) & ProgressBar";
            this.Load += new System.EventHandler(this.frmAsyncStudentLoader_Load);

            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRecordCount)).EndInit();
            this.grpProgress.ResumeLayout(false);
            this.grpProgress.PerformLayout();
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.NumericUpDown numRecordCount;
        private System.Windows.Forms.Button btnLoadAsync;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpProgress;
        private System.Windows.Forms.ProgressBar prgLoading;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView dgvStudents;
    }
}
