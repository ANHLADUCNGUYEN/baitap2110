namespace Bai4_8_AsyncProgressBar
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunctions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAsyncLoader = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStudentManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNavAsync = new System.Windows.Forms.ToolStripButton();
            this.btnNavStudent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNavCascade = new System.Windows.Forms.ToolStripButton();
            this.btnNavTileH = new System.Windows.Forms.ToolStripButton();
            this.btnNavTileV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNavExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbMainProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.sslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSystem,
            this.menuFunctions,
            this.menuWindow});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.menuWindow;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogout,
            this.toolStripSeparator1,
            this.menuExit});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(69, 20);
            this.menuSystem.Text = "&Hệ thống";

            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(128, 22);
            this.menuLogout.Text = "Đăng &xuất";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);

            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);

            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(128, 22);
            this.menuExit.Text = "&Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);

            // 
            // menuFunctions
            // 
            this.menuFunctions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAsyncLoader,
            this.menuStudentManager});
            this.menuFunctions.Name = "menuFunctions";
            this.menuFunctions.Size = new System.Drawing.Size(77, 20);
            this.menuFunctions.Text = "&Chức năng";

            // 
            // menuAsyncLoader
            // 
            this.menuAsyncLoader.Name = "menuAsyncLoader";
            this.menuAsyncLoader.Size = new System.Drawing.Size(227, 22);
            this.menuAsyncLoader.Text = "&Nạp dữ liệu Bất đồng bộ (Async)";
            this.menuAsyncLoader.Click += new System.EventHandler(this.menuAsyncLoader_Click);

            // 
            // menuStudentManager
            // 
            this.menuStudentManager.Name = "menuStudentManager";
            this.menuStudentManager.Size = new System.Drawing.Size(227, 22);
            this.menuStudentManager.Text = "Quản lý &Sinh viên";
            this.menuStudentManager.Click += new System.EventHandler(this.menuStudentManager_Click);

            // 
            // menuWindow
            // 
            this.menuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCascade,
            this.menuTileHorizontal,
            this.menuTileVertical});
            this.menuWindow.Name = "menuWindow";
            this.menuWindow.Size = new System.Drawing.Size(60, 20);
            this.menuWindow.Text = "&Cửa sổ";

            // 
            // menuCascade
            // 
            this.menuCascade.Name = "menuCascade";
            this.menuCascade.Size = new System.Drawing.Size(151, 22);
            this.menuCascade.Text = "&Cascade";
            this.menuCascade.Click += new System.EventHandler(this.menuCascade_Click);

            // 
            // menuTileHorizontal
            // 
            this.menuTileHorizontal.Name = "menuTileHorizontal";
            this.menuTileHorizontal.Size = new System.Drawing.Size(151, 22);
            this.menuTileHorizontal.Text = "Tile &Horizontal";
            this.menuTileHorizontal.Click += new System.EventHandler(this.menuTileHorizontal_Click);

            // 
            // menuTileVertical
            // 
            this.menuTileVertical.Name = "menuTileVertical";
            this.menuTileVertical.Size = new System.Drawing.Size(151, 22);
            this.menuTileVertical.Text = "Tile &Vertical";
            this.menuTileVertical.Click += new System.EventHandler(this.menuTileVertical_Click);

            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNavAsync,
            this.btnNavStudent,
            this.toolStripSeparator2,
            this.btnNavCascade,
            this.btnNavTileH,
            this.btnNavTileV,
            this.toolStripSeparator3,
            this.btnNavExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1104, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";

            // 
            // btnNavAsync
            // 
            this.btnNavAsync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavAsync.Name = "btnNavAsync";
            this.btnNavAsync.Size = new System.Drawing.Size(147, 22);
            this.btnNavAsync.Text = "Nạp dữ liệu Async";
            this.btnNavAsync.Click += new System.EventHandler(this.menuAsyncLoader_Click);

            // 
            // btnNavStudent
            // 
            this.btnNavStudent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavStudent.Name = "btnNavStudent";
            this.btnNavStudent.Size = new System.Drawing.Size(105, 22);
            this.btnNavStudent.Text = "Quản lý Sinh viên";
            this.btnNavStudent.Click += new System.EventHandler(this.menuStudentManager_Click);

            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);

            // 
            // btnNavCascade
            // 
            this.btnNavCascade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavCascade.Name = "btnNavCascade";
            this.btnNavCascade.Size = new System.Drawing.Size(55, 22);
            this.btnNavCascade.Text = "Cascade";
            this.btnNavCascade.Click += new System.EventHandler(this.menuCascade_Click);

            // 
            // btnNavTileH
            // 
            this.btnNavTileH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavTileH.Name = "btnNavTileH";
            this.btnNavTileH.Size = new System.Drawing.Size(66, 22);
            this.btnNavTileH.Text = "Tile Ngang";
            this.btnNavTileH.Click += new System.EventHandler(this.menuTileHorizontal_Click);

            // 
            // btnNavTileV
            // 
            this.btnNavTileV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavTileV.Name = "btnNavTileV";
            this.btnNavTileV.Size = new System.Drawing.Size(55, 22);
            this.btnNavTileV.Text = "Tile Dọc";
            this.btnNavTileV.Click += new System.EventHandler(this.menuTileVertical_Click);

            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);

            // 
            // btnNavExit
            // 
            this.btnNavExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavExit.Name = "btnNavExit";
            this.btnNavExit.Size = new System.Drawing.Size(41, 22);
            this.btnNavExit.Text = "Thoát";
            this.btnNavExit.Click += new System.EventHandler(this.menuExit_Click);

            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslCurrentUser,
            this.sslStatus,
            this.tspbMainProgress,
            this.sslTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1104, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";

            // 
            // sslCurrentUser
            // 
            this.sslCurrentUser.Name = "sslCurrentUser";
            this.sslCurrentUser.Size = new System.Drawing.Size(147, 19);
            this.sslCurrentUser.Text = "Người dùng: Administrator";

            // 
            // sslStatus
            // 
            this.sslStatus.Name = "sslStatus";
            this.sslStatus.Size = new System.Drawing.Size(602, 19);
            this.sslStatus.Spring = true;
            this.sslStatus.Text = "Trạng thái: Sẵn sàng làm việc";
            this.sslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // tspbMainProgress
            // 
            this.tspbMainProgress.Name = "tspbMainProgress";
            this.tspbMainProgress.Size = new System.Drawing.Size(180, 18);
            this.tspbMainProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.tspbMainProgress.Visible = false;

            // 
            // sslTime
            // 
            this.sslTime.Name = "sslTime";
            this.sslTime.Size = new System.Drawing.Size(160, 19);
            this.sslTime.Text = "Thời gian: dd/MM/yyyy HH:mm:ss";

            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 711);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1020, 650);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 4.8: Lập trình Bất đồng bộ (Async/Await) & Tiến trình ProgressBar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuFunctions;
        private System.Windows.Forms.ToolStripMenuItem menuAsyncLoader;
        private System.Windows.Forms.ToolStripMenuItem menuStudentManager;
        private System.Windows.Forms.ToolStripMenuItem menuWindow;
        private System.Windows.Forms.ToolStripMenuItem menuCascade;
        private System.Windows.Forms.ToolStripMenuItem menuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem menuTileVertical;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNavAsync;
        private System.Windows.Forms.ToolStripButton btnNavStudent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnNavCascade;
        private System.Windows.Forms.ToolStripButton btnNavTileH;
        private System.Windows.Forms.ToolStripButton btnNavTileV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnNavExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslCurrentUser;
        private System.Windows.Forms.ToolStripStatusLabel sslStatus;
        private System.Windows.Forms.ToolStripProgressBar tspbMainProgress;
        private System.Windows.Forms.ToolStripStatusLabel sslTime;
        private System.Windows.Forms.Timer timerClock;
    }
}
