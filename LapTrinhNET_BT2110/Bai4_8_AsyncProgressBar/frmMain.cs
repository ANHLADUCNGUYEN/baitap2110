using System;
using System.Windows.Forms;

namespace Bai4_8_AsyncProgressBar
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

            // Tự động mở form Nạp dữ liệu Bất đồng bộ khi khởi chạy
            MoFormCon(typeof(frmAsyncStudentLoader));
        }

        #region Thuật toán Mở Form con MDI (Chống mở trùng lặp)
        public void MoFormCon(Type loaiForm)
        {
            Form? formCon = null;

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
                if (formCon.WindowState == FormWindowState.Minimized)
                {
                    formCon.WindowState = FormWindowState.Normal;
                }
                formCon.Activate();
                formCon.BringToFront();
                CapNhatTrangThai($"Kích hoạt: {formCon.Text}");
            }
            else
            {
                Form fMoi = (Form)Activator.CreateInstance(loaiForm)!;
                fMoi.MdiParent = this;
                fMoi.StartPosition = FormStartPosition.CenterScreen;
                fMoi.Show();
                CapNhatTrangThai($"Mở cửa sổ: {fMoi.Text}");
            }
        }
        #endregion

        #region Báo cáo tiến trình trên StatusStrip của Form Cha (Safe Cross-Thread)
        public void CapNhatTienTrinh(int phanTram, bool hienThi = true, string thongDiep = "")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => CapNhatTienTrinh(phanTram, hienThi, thongDiep)));
                return;
            }

            tspbMainProgress.Visible = hienThi;
            tspbMainProgress.Value = Math.Max(0, Math.Min(100, phanTram));

            if (!string.IsNullOrEmpty(thongDiep))
            {
                sslStatus.Text = thongDiep;
            }
        }

        public void DatLaiTienTrinh(string thongDiep = "Trạng thái: Sẵn sàng làm việc")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DatLaiTienTrinh(thongDiep)));
                return;
            }

            tspbMainProgress.Visible = false;
            tspbMainProgress.Value = 0;
            sslStatus.Text = thongDiep;
        }

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
        private void menuAsyncLoader_Click(object sender, EventArgs e)
        {
            MoFormCon(typeof(frmAsyncStudentLoader));
        }

        private void menuStudentManager_Click(object sender, EventArgs e)
        {
            MoFormCon(typeof(frmStudent));
        }

        private void menuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
            CapNhatTrangThai("Sắp xếp Cascade");
        }

        private void menuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            CapNhatTrangThai("Sắp xếp Tile Horizontal");
        }

        private void menuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
            CapNhatTrangThai("Sắp xếp Tile Vertical");
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn đăng xuất khỏi hệ thống?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                }
                sslCurrentUser.Text = "Người dùng: Đã đăng xuất";
                CapNhatTrangThai("Đã đăng xuất");
                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
                "Xác nhận thoát",
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
