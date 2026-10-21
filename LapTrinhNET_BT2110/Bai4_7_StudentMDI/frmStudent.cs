using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai4_7_StudentMDI
{
    public partial class frmStudent : Form
    {
        private BindingList<Student> listStudents = new BindingList<Student>();
        private BindingSource bindingSource = new BindingSource();
        private int autoIdCounter = 1;

        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            // 1. Nạp danh mục Giới tính
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.SelectedIndex = 0;

            // 2. Cấu hình DataGridView bằng code
            CauHinhDataGridView();

            // 3. Thêm dữ liệu mẫu ban đầu
            ThemDuLieuMau();

            // 4. Gắn BindingSource với BindingList<Student>
            bindingSource.DataSource = listStudents;
            dgvStudents.DataSource = bindingSource;

            // 5. Thiết lập Data Binding tự động giữa BindingSource và các Control nhập liệu
            ThietLapDataBinding();

            // 6. Lắng nghe sự kiện chuyển dòng của BindingSource để nạp ảnh đại diện và thông báo
            bindingSource.CurrentChanged += BindingSource_CurrentChanged;

            // Kích hoạt nạp ảnh cho phần tử đầu tiên
            if (bindingSource.Current is Student firstStudent)
            {
                SafeLoadImage(firstStudent.AvatarPath);
            }

            ThongBaoTrangThaiCha("Đã sẵn sàng trên giao diện Quản lý Sinh viên (Data Binding kích hoạt).");
        }

        #region Thiết lập Data Binding tự động (DataBindings.Add)
        /// <summary>
        /// Sử dụng cơ chế DataBindings.Add của Windows Forms để tự động đồng bộ dữ liệu
        /// giữa BindingSource (quản lý danh sách sinh viên) với các Control nhập liệu.
        /// </summary>
        private void ThietLapDataBinding()
        {
            // Xóa các liên kết binding cũ nếu có
            txtStudentId.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            cboGender.DataBindings.Clear();
            txtAvatarPath.DataBindings.Clear();

            // Ràng buộc tự động đổ dữ liệu từ dòng đang chọn lên TextBox / ComboBox
            txtStudentId.DataBindings.Add("Text", bindingSource, nameof(Student.StudentId), true, DataSourceUpdateMode.Never);
            txtFullName.DataBindings.Add("Text", bindingSource, nameof(Student.FullName), true, DataSourceUpdateMode.Never);
            txtAge.DataBindings.Add("Text", bindingSource, nameof(Student.Age), true, DataSourceUpdateMode.Never);
            cboGender.DataBindings.Add("SelectedItem", bindingSource, nameof(Student.Gender), true, DataSourceUpdateMode.Never);
            txtAvatarPath.DataBindings.Add("Text", bindingSource, nameof(Student.AvatarPath), true, DataSourceUpdateMode.Never);
        }

        private void BindingSource_CurrentChanged(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Student student)
            {
                SafeLoadImage(student.AvatarPath);
                XoaLoiValidation();
                ThongBaoTrangThaiCha($"Đang chọn sinh viên: [{student.StudentId}] {student.FullName}");
            }
        }
        #endregion

        #region Giao tiếp với Form Cha MDI
        private void ThongBaoTrangThaiCha(string thongDiep)
        {
            if (this.MdiParent is frmMain mainForm)
            {
                mainForm.CapNhatTrangThai(thongDiep);
            }
        }
        #endregion

        #region Cấu hình DataGridView bằng Code
        private void CauHinhDataGridView()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.ReadOnly = true;
            dgvStudents.MultiSelect = false;

            // Cột Mã SV
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.StudentId),
                HeaderText = "Mã SV",
                Name = "colStudentId",
                Width = 90
            };

            // Cột Họ và tên
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.FullName),
                HeaderText = "Họ và tên",
                Name = "colFullName",
                Width = 200
            };

            // Cột Tuổi
            DataGridViewTextBoxColumn colAge = new DataGridViewTextBoxColumn
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

            // Cột Giới tính
            DataGridViewTextBoxColumn colGender = new DataGridViewTextBoxColumn
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

            // Cột Đường dẫn ảnh
            DataGridViewTextBoxColumn colAvatar = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.AvatarPath),
                HeaderText = "Đường dẫn ảnh đại diện",
                Name = "colAvatarPath",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgvStudents.Columns.AddRange(new DataGridViewColumn[] {
                colId, colName, colAge, colGender, colAvatar
            });
        }
        #endregion

        #region Dữ liệu mẫu & Sinh mã tự động
        private void ThemDuLieuMau()
        {
            listStudents.Add(new Student("SV01", "Nguyễn Văn An", 20, "Nam", ""));
            listStudents.Add(new Student("SV02", "Trần Thị Mai", 19, "Nữ", ""));
            listStudents.Add(new Student("SV03", "Lê Hoàng Long", 21, "Nam", ""));
            listStudents.Add(new Student("SV04", "Phạm Thu Trang", 20, "Nữ", ""));
            autoIdCounter = 5;
        }

        private void SinhMaTuDong()
        {
            txtStudentId.Text = $"SV{autoIdCounter:D2}";
        }
        #endregion

        #region Safe Image Loading
        private void SafeLoadImage(string? imagePath)
        {
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;

            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
                return;

            try
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (Image img = Image.FromStream(fs))
                {
                    picAvatar.Image = new Bitmap(img);
                }
            }
            catch (Exception ex)
            {
                ThongBaoTrangThaiCha($"Không thể nạp ảnh đại diện: {ex.Message}");
            }
        }
        #endregion

        #region Validation
        private bool ValidateDuLieu(out int age)
        {
            bool hopLe = true;
            age = 0;
            XoaLoiValidation();

            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên không được để trống!");
                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Họ và tên không được để trống!");
                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtAge.Text) || !int.TryParse(txtAge.Text.Trim(), out age) || age < 15 || age > 100)
            {
                errorProvider1.SetError(txtAge, "Tuổi phải là số nguyên từ 15 đến 100!");
                hopLe = false;
            }

            if (cboGender.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboGender, "Vui lòng chọn giới tính!");
                hopLe = false;
            }

            return hopLe;
        }

        private void XoaLoiValidation()
        {
            errorProvider1.SetError(txtStudentId, string.Empty);
            errorProvider1.SetError(txtFullName, string.Empty);
            errorProvider1.SetError(txtAge, string.Empty);
            errorProvider1.SetError(cboGender, string.Empty);
        }
        #endregion

        #region Các nút chức năng CRUD
        private void btnChooseAvatar_Click(object sender, EventArgs e)
        {
            openFileDialogAvatar.Title = "Chọn ảnh đại diện";
            openFileDialogAvatar.Filter = "Ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp|Tất cả tệp (*.*)|*.*";

            if (openFileDialogAvatar.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = openFileDialogAvatar.FileName;
                txtAvatarPath.Text = selectedPath;
                SafeLoadImage(selectedPath);

                if (bindingSource.Current is Student currentStudent)
                {
                    currentStudent.AvatarPath = selectedPath;
                }
                ThongBaoTrangThaiCha($"Đã chọn ảnh cho sinh viên: {Path.GetFileName(selectedPath)}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateDuLieu(out int age))
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtStudentId.Text.Trim();
            if (listStudents.Any(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên đã tồn tại!");
                MessageBox.Show("Mã sinh viên đã tồn tại trong danh sách!", "Trùng lặp mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student newStudent = new Student(
                id,
                txtFullName.Text.Trim(),
                age,
                cboGender.SelectedItem?.ToString() ?? "Nam",
                txtAvatarPath.Text.Trim()
            );

            listStudents.Add(newStudent);
            autoIdCounter++;

            // Đồng bộ lại binding và chọn dòng mới
            ThietLapDataBinding();
            bindingSource.Position = listStudents.IndexOf(newStudent);

            ThongBaoTrangThaiCha($"Thêm sinh viên [{newStudent.StudentId}] thành công!");
            MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student currentStudent)
            {
                if (!ValidateDuLieu(out int age))
                {
                    MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentStudent.FullName = txtFullName.Text.Trim();
                currentStudent.Age = age;
                currentStudent.Gender = cboGender.SelectedItem?.ToString() ?? "Nam";
                currentStudent.AvatarPath = txtAvatarPath.Text.Trim();

                ThongBaoTrangThaiCha($"Cập nhật sinh viên [{currentStudent.StudentId}] thành công!");
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student currentStudent)
            {
                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sinh viên [{currentStudent.StudentId} - {currentStudent.FullName}]?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    string deletedId = currentStudent.StudentId;
                    listStudents.Remove(currentStudent);
                    ThietLapDataBinding();

                    ThongBaoTrangThaiCha($"Đã xóa sinh viên [{deletedId}] thành công!");
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (listStudents.Count == 0)
                    {
                        btnClear.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Tạm thời bỏ chọn và xóa binding để nhập mới mà không ghi đè dòng đang chọn
            txtStudentId.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            cboGender.DataBindings.Clear();
            txtAvatarPath.DataBindings.Clear();
            dgvStudents.ClearSelection();

            XoaLoiValidation();
            SinhMaTuDong();
            txtFullName.Clear();
            txtAge.Clear();
            cboGender.SelectedIndex = 0;
            txtAvatarPath.Clear();
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            txtFullName.Focus();

            ThongBaoTrangThaiCha("Đã làm mới thông tin sinh viên (Sẵn sàng thêm mới).");
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            saveFileDialogCsv.Title = "Xuất file CSV danh sách sinh viên";
            saveFileDialogCsv.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialogCsv.FileName = $"Students_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (saveFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Mã SV,Họ và tên,Tuổi,Giới tính,Đường dẫn ảnh");

                    foreach (var s in listStudents)
                    {
                        string escapedName = s.FullName.Contains(',') ? $"\"{s.FullName}\"" : s.FullName;
                        string escapedAvatar = s.AvatarPath.Contains(',') ? $"\"{s.AvatarPath}\"" : s.AvatarPath;
                        sb.AppendLine($"{s.StudentId},{escapedName},{s.Age},{s.Gender},{escapedAvatar}");
                    }

                    File.WriteAllText(saveFileDialogCsv.FileName, sb.ToString(), new UTF8Encoding(true));
                    ThongBaoTrangThaiCha($"Xuất file CSV thành công: {Path.GetFileName(saveFileDialogCsv.FileName)}");
                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file CSV:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ContextMenuStrip (Menu ngữ cảnh trên DataGridView)
        private void dgvStudents_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvStudents.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvStudents.ClearSelection();
                    dgvStudents.Rows[hit.RowIndex].Selected = true;
                    bindingSource.Position = hit.RowIndex;
                    ThietLapDataBinding();
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                var hit = dgvStudents.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    // Khi nhấp chuột trái chọn dòng, khôi phục lại binding nếu trước đó đang Clear
                    if (txtFullName.DataBindings.Count == 0)
                    {
                        ThietLapDataBinding();
                    }
                }
            }
        }

        private void menuCtxDelete_Click(object sender, EventArgs e)
        {
            btnDelete.PerformClick();
        }

        private void menuCtxRefresh_Click(object sender, EventArgs e)
        {
            ThietLapDataBinding();
            btnClear.PerformClick();
            ThongBaoTrangThaiCha("Đã làm mới dữ liệu lưới sinh viên.");
        }

        private void menuCtxDetails_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student s)
            {
                string info = $"THÔNG TIN CHI TIẾT SINH VIÊN\n" +
                              $"------------------------------------\n" +
                              $"• Mã SV: {s.StudentId}\n" +
                              $"• Họ và tên: {s.FullName}\n" +
                              $"• Tuổi: {s.Age}\n" +
                              $"• Giới tính: {s.Gender}\n" +
                              $"• Ảnh đại diện: {(string.IsNullOrEmpty(s.AvatarPath) ? "(Chưa có)" : s.AvatarPath)}";

                MessageBox.Show(info, "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
