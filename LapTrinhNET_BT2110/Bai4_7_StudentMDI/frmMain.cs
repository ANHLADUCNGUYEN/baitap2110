using System;
using System.Windows.Forms;

namespace Bai4_7_StudentMDI
{
    public partial class frmMain : Form
    {
        private bool isClosingConfirmed = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            sslCurrentUser.Text = "Người dùng: Administrator";
            sslStatus.Text = "Trạng thái: Sẵn sàng làm việc";
            CapNhatDongHo();

            // Tự động mở Form Quản lý Sinh viên khi khởi động ứng dụng
            MoFormCon(typeof(frmStudent));
        }

        #region Thuật toán Quản lý Form con MDI (Chống mở trùng lặp)
        /// <summary>
        /// Mở form con an toàn: Nếu form đã mở thì đưa lên trên cùng, không tạo trùng lặp instance.
        /// </summary>
        public void MoFormCon(Type loaiForm)
        {
            Form? formCon = null;

            // Duyệt danh sách các Form con đang mở trong MdiChildren
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == loaiForm)
                {
                    formCon = f;
                    break;
                }
            }

            if (formCon != null)
            {
                // Form đã mở -> Phục hồi nếu đang bị thu nhỏ và kích hoạt lên trước
                if (formCon.WindowState == FormWindowState.Minimized)
                {
                    formCon.WindowState = FormWindowState.Normal;
                }
                formCon.Activate();
                formCon.BringToFront();
                CapNhatTrangThai($"Kích hoạt cửa sổ: {formCon.Text}");
            }
            else
            {
                // Form chưa mở -> Khởi tạo mới, gán MdiParent và hiển thị
                Form fMoi = (Form)Activator.CreateInstance(loaiForm)!;
                fMoi.MdiParent = this;
                fMoi.StartPosition = FormStartPosition.CenterScreen;
                fMoi.Show();
                CapNhatTrangThai($"Mở cửa sổ mới: {fMoi.Text}");
            }
        }
        #endregion

        #region Giao tiếp giữa MDI Parent và MDI Child
        /// <summary>
        /// Phương thức nhận thông điệp từ Form con để cập nhật StatusStrip của Form cha.
        /// </summary>
        public void CapNhatTrangThai(string thongDiep)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => CapNhatTrangThai(thongDiep)));
                return;
            }

            sslStatus.Text = $"Trạng thái: {thongDiep}";
        }
        #endregion

        #region Xử lý Menu & ToolStrip
        private void menuStudentManager_Click(object sender, EventArgs e)
        {
            MoFormCon(typeof(frmStudent));
        }

        private void menuProductManager_Click(object sender, EventArgs e)
        {
            MoFormCon(typeof(frmProduct));
        }

        private void menuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
            CapNhatTrangThai("Sắp xếp cửa sổ: Cascade (Xếp chồng)");
        }

        private void menuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            CapNhatTrangThai("Sắp xếp cửa sổ: Tile Horizontal (Xếp ngang)");
        }

        private void menuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
            CapNhatTrangThai("Sắp xếp cửa sổ: Tile Vertical (Xếp dọc)");
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi phiên làm việc hiện tại?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                // Đóng toàn bộ các Form con đang mở
                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                }

                sslCurrentUser.Text = "Người dùng: Đã đăng xuất";
                CapNhatTrangThai("Đã đăng xuất. Vui lòng đăng nhập lại để sử dụng.");
                MessageBox.Show("Đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosingConfirmed) return;

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng MDI?",
                "Xác nhận thoát hệ thống",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                isClosingConfirmed = true;
            }
        }
        #endregion

        #region Đồng hồ thời gian thực
        private void CapNhatDongHo()
        {
            sslTime.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo();
        }
        #endregion
    }
}
