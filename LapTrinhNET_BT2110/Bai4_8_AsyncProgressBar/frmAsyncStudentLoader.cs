using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4_8_AsyncProgressBar
{
    public partial class frmAsyncStudentLoader : Form
    {
        private BindingList<Student> listData = new BindingList<Student>();
        private BindingSource bindingSource = new BindingSource();
        private CancellationTokenSource? cts;

        public frmAsyncStudentLoader()
        {
            InitializeComponent();
        }

        private void frmAsyncStudentLoader_Load(object sender, EventArgs e)
        {
            // Cấu hình DataGridView bằng code
            CauHinhDataGridView();

            bindingSource.DataSource = listData;
            dgvStudents.DataSource = bindingSource;

            ThongBaoFormCha("Đã sẵn sàng thực hiện nạp dữ liệu bất đồng bộ.");
        }

        #region Cấu hình DataGridView
        private void CauHinhDataGridView()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.ReadOnly = true;
            dgvStudents.MultiSelect = false;

            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.StudentId),
                HeaderText = "Mã SV",
                Name = "colStudentId",
                Width = 90
            };

            var colName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.FullName),
                HeaderText = "Họ và tên",
                Name = "colFullName",
                Width = 200
            };

            var colAge = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.Age),
                HeaderText = "Tuổi",
                Name = "colAge",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var colGender = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.Gender),
                HeaderText = "Giới tính",
                Name = "colGender",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var colDept = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.Department),
                HeaderText = "Khoa / Chuyên ngành",
                Name = "colDepartment",
                Width = 220
            };

            var colGpa = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.Gpa),
                HeaderText = "Điểm GPA",
                Name = "colGpa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "0.00",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            dgvStudents.Columns.AddRange(new DataGridViewColumn[] {
                colId, colName, colAge, colGender, colDept, colGpa
            });
        }
        #endregion

        #region Giao tiếp với Form Cha MDI
        private void ThongBaoFormCha(string thongDiep)
        {
            if (this.MdiParent is frmMain main)
            {
                main.CapNhatTrangThai(thongDiep);
            }
        }
        #endregion

        #region Phương thức Nạp dữ liệu Bất đồng bộ (Async/Await)
        /// <summary>
        /// Phương thức nạp dữ liệu bất đồng bộ trả về Task<List<Student>>.
        /// Sử dụng Task.Run để đẩy công việc nặng xuống luồng ngầm (Worker Thread),
        /// sử dụng IProgress<int> để báo cáo phần trăm tiến trình thời gian thực về UI Thread.
        /// </summary>
        private async Task<List<Student>> LoadStudentsAsync(int count, IProgress<int> progress, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                List<Student> result = new List<Student>();
                string[] ho = { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Vũ", "Đặng", "Bùi", "Đỗ", "Hồ" };
                string[] demNam = { "Văn", "Đức", "Hữu", "Hoàng", "Quốc", "Minh" };
                string[] demNu = { "Thị", "Thu", "Mai", "Ngọc", "Phương", "Hải" };
                string[] tenNam = { "An", "Bình", "Cường", "Dũng", "Hải", "Khang", "Long", "Nam", "Phúc", "Thịnh" };
                string[] tenNu = { "Anh", "Chi", "Dung", "Hoa", "Lan", "Linh", "Mai", "Nhi", "Trang", "Yến" };
                string[] khoa = { "Công nghệ thông tin", "Kỹ thuật phần mềm", "Khoa học máy tính", "Hệ thống thông tin", "An toàn thông tin" };

                Random rnd = new Random();

                for (int i = 1; i <= count; i++)
                {
                    // Kiểm tra yêu cầu hủy tác vụ từ người dùng
                    cancellationToken.ThrowIfCancellationRequested();

                    // Mô phỏng độ trễ truy vấn CSDL / đọc file lớn (35ms cho mỗi bản ghi)
                    Thread.Sleep(35);

                    bool isNam = rnd.Next(2) == 0;
                    string gender = isNam ? "Nam" : "Nữ";
                    string h = ho[rnd.Next(ho.Length)];
                    string d = isNam ? demNam[rnd.Next(demNam.Length)] : demNu[rnd.Next(demNu.Length)];
                    string t = isNam ? tenNam[rnd.Next(tenNam.Length)] : tenNu[rnd.Next(tenNu.Length)];
                    string fullName = $"{h} {d} {t}";
                    int age = rnd.Next(18, 25);
                    string dept = khoa[rnd.Next(khoa.Length)];
                    double gpa = Math.Round(rnd.NextDouble() * (4.0 - 2.2) + 2.2, 2);

                    result.Add(new Student($"SV{i:D4}", fullName, age, gender, dept, gpa));

                    // Tính toán và truyền phần trăm hoàn thành về UI Thread qua IProgress<int>
                    int percent = (int)((double)i / count * 100);
                    progress.Report(percent);
                }

                return result;
            }, cancellationToken);
        }
        #endregion

        #region Xử lý nút bấm Nạp dữ liệu Async
        private async void btnLoadAsync_Click(object sender, EventArgs e)
        {
            // 1. Khóa nút bấm để tránh kích hoạt trùng lặp, mở nút Hủy
            btnLoadAsync.Enabled = false;
            btnCancel.Enabled = true;
            btnClear.Enabled = false;
            numRecordCount.Enabled = false;

            cts = new CancellationTokenSource();
            prgLoading.Value = 0;
            lblProgressPercent.Text = "0%";
            lblProgressStatus.Text = "Đang khởi tạo tiến trình nạp dữ liệu ngầm...";

            var parentMain = this.MdiParent as frmMain;
            parentMain?.CapNhatTienTrinh(0, true, "Đang khởi chạy nạp dữ liệu...");

            // Khởi tạo đối tượng IProgress<int> để hứng phần trăm tiến trình từ tiến trình ngầm
            var progress = new Progress<int>(percent =>
            {
                prgLoading.Value = Math.Max(0, Math.Min(100, percent));
                lblProgressPercent.Text = $"{percent}%";
                lblProgressStatus.Text = $"Đang nạp dữ liệu: {percent}% hoàn thành...";

                // Cập nhật đồng thời lên StatusStrip của Form cha MDI
                parentMain?.CapNhatTienTrinh(percent, true, $"Đang nạp dữ liệu: {percent}% hoàn thành...");
            });

            try
            {
                int count = (int)numRecordCount.Value;

                // Gọi hàm nạp dữ liệu bất đồng bộ với await (UI Thread không bị treo, form vẫn kéo thả bình thường)
                List<Student> loadedData = await LoadStudentsAsync(count, progress, cts.Token);

                // Nạp kết quả lên danh sách liên kết
                listData.Clear();
                foreach (var item in loadedData)
                {
                    listData.Add(item);
                }

                lblProgressStatus.Text = $"Nạp hoàn tất {loadedData.Count} sinh viên thành công!";
                parentMain?.CapNhatTienTrinh(100, true, $"Hoàn tất nạp {loadedData.Count} bản ghi.");
                MessageBox.Show($"Nạp thành công {loadedData.Count} sinh viên qua tác vụ bất đồng bộ!", "Hoàn tất nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                lblProgressStatus.Text = "Tiến trình nạp dữ liệu đã bị người dùng hủy bỏ.";
                parentMain?.DatLaiTienTrinh("Tác vụ đã bị hủy bỏ bởi người dùng.");
                MessageBox.Show("Tiến trình nạp dữ liệu đã được hủy bỏ an toàn!", "Đã hủy tác vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                lblProgressStatus.Text = $"Xảy ra lỗi: {ex.Message}";
                parentMain?.DatLaiTienTrinh($"Lỗi tác vụ: {ex.Message}");
                MessageBox.Show($"Lỗi trong quá trình nạp dữ liệu:\n{ex.Message}", "Lỗi tiến trình", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khối finally đảm bảo luôn mở lại trạng thái các nút bấm sau khi hoàn tất hoặc gặp lỗi
                btnLoadAsync.Enabled = true;
                btnCancel.Enabled = false;
                btnClear.Enabled = true;
                numRecordCount.Enabled = true;

                cts?.Dispose();
                cts = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cts != null && !cts.IsCancellationRequested)
            {
                lblProgressStatus.Text = "Đang gửi yêu cầu hủy tiến trình...";
                cts.Cancel();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listData.Clear();
            prgLoading.Value = 0;
            lblProgressPercent.Text = "0%";
            lblProgressStatus.Text = "Trạng thái: Sẵn sàng";

            var parentMain = this.MdiParent as frmMain;
            parentMain?.DatLaiTienTrinh("Trạng thái: Sẵn sàng làm việc");
            ThongBaoFormCha("Đã xóa trắng danh sách sinh viên.");
        }
        #endregion
    }
}
