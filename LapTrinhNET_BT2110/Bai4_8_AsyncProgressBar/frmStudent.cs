using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai4_8_AsyncProgressBar
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
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.SelectedIndex = 0;

            CauHinhDataGridView();

            ThemDuLieuMau();

            bindingSource.DataSource = listStudents;
            dgvStudents.DataSource = bindingSource;

            ThietLapDataBinding();

            bindingSource.CurrentChanged += BindingSource_CurrentChanged;

            if (bindingSource.Current is Student firstStudent)
            {
                SafeLoadImage(firstStudent.AvatarPath);
            }

            SinhMaTuDong();
            ThongBaoTrangThaiCha("Đã sẵn sàng trên giao diện Quản lý Sinh viên (Data Binding kích hoạt).");
        }

        #region Thiết lập Data Binding tự động (DataBindings.Add)
        private void ThietLapDataBinding()
        {
            txtStudentId.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            cboGender.DataBindings.Clear();
            txtDept.DataBindings.Clear();
            txtGpa.DataBindings.Clear();
            txtAvatarPath.DataBindings.Clear();

            txtStudentId.DataBindings.Add("Text", bindingSource, nameof(Student.StudentId), true, DataSourceUpdateMode.Never);
            txtFullName.DataBindings.Add("Text", bindingSource, nameof(Student.FullName), true, DataSourceUpdateMode.Never);
            txtAge.DataBindings.Add("Text", bindingSource, nameof(Student.Age), true, DataSourceUpdateMode.Never);
            cboGender.DataBindings.Add("SelectedItem", bindingSource, nameof(Student.Gender), true, DataSourceUpdateMode.Never);
            txtDept.DataBindings.Add("Text", bindingSource, nameof(Student.Department), true, DataSourceUpdateMode.Never);

            var bindingGpa = new Binding("Text", bindingSource, nameof(Student.Gpa), true, DataSourceUpdateMode.Never);
            bindingGpa.Format += (s, ev) =>
            {
                if (ev.Value is double val) ev.Value = val.ToString("0.00");
            };
            txtGpa.DataBindings.Add(bindingGpa);

            txtAvatarPath.DataBindings.Add("Text", bindingSource, nameof(Student.AvatarPath), true, DataSourceUpdateMode.Never);
        }

        private void BindingSource_CurrentChanged(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Student student)
            {
                SafeLoadImage(student.AvatarPath);
                XoaLoiValidation();
                ThongBaoTrangThaiCha($"Đang chọn: [{student.StudentId}] {student.FullName}");
            }
        }
        #endregion

        private void ThongBaoTrangThaiCha(string thongDiep)
        {
            if (this.MdiParent is frmMain mainForm)
            {
                mainForm.CapNhatTrangThai(thongDiep);
            }
        }

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
                Width = 180
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
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var colDept = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.Department),
                HeaderText = "Khoa / Chuyên ngành",
                Name = "colDept",
                Width = 160
            };

            var colGpa = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.Gpa),
                HeaderText = "Điểm GPA",
                Name = "colGpa",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "0.00",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var colAvatar = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.AvatarPath),
                HeaderText = "Đường dẫn ảnh đại diện",
                Name = "colAvatarPath",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgvStudents.Columns.AddRange(new DataGridViewColumn[] {
                colId, colName, colAge, colGender, colDept, colGpa, colAvatar
            });
        }

        private void ThemDuLieuMau()
        {
            listStudents.Add(new Student("SV0001", "Nguyễn Văn An", 20, "Nam", "Công nghệ thông tin", 3.45, ""));
            listStudents.Add(new Student("SV0002", "Trần Thị Mai", 19, "Nữ", "Kỹ thuật phần mềm", 3.82, ""));
            listStudents.Add(new Student("SV0003", "Lê Hoàng Long", 21, "Nam", "An toàn thông tin", 3.20, ""));
            listStudents.Add(new Student("SV0004", "Phạm Thu Trang", 20, "Nữ", "Khoa học máy tính", 3.65, ""));
            autoIdCounter = 5;
        }

        private void SinhMaTuDong()
        {
            txtStudentId.Text = $"SV{autoIdCounter:D4}";
        }

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
                ThongBaoTrangThaiCha($"Không thể nạp ảnh: {ex.Message}");
            }
        }

        private bool ValidateDuLieu(out int age, out double gpa)
        {
            bool hopLe = true;
            age = 0;
            gpa = 0;
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

            string cleanGpa = txtGpa.Text.Trim().Replace(',', '.');
            if (string.IsNullOrWhiteSpace(cleanGpa) || !double.TryParse(cleanGpa, NumberStyles.Any, CultureInfo.InvariantCulture, out gpa) || gpa < 0 || gpa > 4.0)
            {
                errorProvider1.SetError(txtGpa, "Điểm GPA phải nằm trong thang điểm từ 0.00 đến 4.00!");
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
            errorProvider1.SetError(txtGpa, string.Empty);
        }

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
                ThongBaoTrangThaiCha($"Đã chọn ảnh: {Path.GetFileName(selectedPath)}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateDuLieu(out int age, out double gpa))
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtStudentId.Text.Trim();
            if (listStudents.Any(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên đã tồn tại!");
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student newStudent = new Student(
                id,
                txtFullName.Text.Trim(),
                age,
                cboGender.SelectedItem?.ToString() ?? "Nam",
                string.IsNullOrWhiteSpace(txtDept.Text) ? "Công nghệ thông tin" : txtDept.Text.Trim(),
                gpa,
                txtAvatarPath.Text.Trim()
            );

            listStudents.Add(newStudent);
            autoIdCounter++;

            ThietLapDataBinding();
            bindingSource.Position = listStudents.IndexOf(newStudent);

            ThongBaoTrangThaiCha($"Thêm mới sinh viên [{newStudent.StudentId}] thành công!");
            MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student currentStudent)
            {
                if (!ValidateDuLieu(out int age, out double gpa))
                {
                    MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentStudent.FullName = txtFullName.Text.Trim();
                currentStudent.Age = age;
                currentStudent.Gender = cboGender.SelectedItem?.ToString() ?? "Nam";
                currentStudent.Department = string.IsNullOrWhiteSpace(txtDept.Text) ? "Công nghệ thông tin" : txtDept.Text.Trim();
                currentStudent.Gpa = gpa;
                currentStudent.AvatarPath = txtAvatarPath.Text.Trim();

                ThongBaoTrangThaiCha($"Cập nhật sinh viên [{currentStudent.StudentId}] thành công!");
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string delId = currentStudent.StudentId;
                    listStudents.Remove(currentStudent);
                    ThietLapDataBinding();

                    ThongBaoTrangThaiCha($"Đã xóa sinh viên [{delId}] thành công!");
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
            txtStudentId.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            cboGender.DataBindings.Clear();
            txtDept.DataBindings.Clear();
            txtGpa.DataBindings.Clear();
            txtAvatarPath.DataBindings.Clear();
            dgvStudents.ClearSelection();

            XoaLoiValidation();
            SinhMaTuDong();
            txtFullName.Clear();
            txtAge.Clear();
            cboGender.SelectedIndex = 0;
            txtDept.Clear();
            txtGpa.Clear();
            txtAvatarPath.Clear();
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            txtFullName.Focus();
            ThongBaoTrangThaiCha("Đã làm mới thông tin sinh viên (Sẵn sàng thêm mới).");
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            saveFileDialogCsv.Title = "Xuất danh sách sinh viên ra file CSV";
            saveFileDialogCsv.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialogCsv.FileName = $"Students_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (saveFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Mã SV,Họ và tên,Tuổi,Giới tính,Khoa,Điểm GPA,Đường dẫn ảnh");

                    foreach (var s in listStudents)
                    {
                        string escapedName = s.FullName.Contains(',') ? $"\"{s.FullName}\"" : s.FullName;
                        string escapedDept = s.Department.Contains(',') ? $"\"{s.Department}\"" : s.Department;
                        string escapedAvatar = s.AvatarPath.Contains(',') ? $"\"{s.AvatarPath}\"" : s.AvatarPath;
                        sb.AppendLine($"{s.StudentId},{escapedName},{s.Age},{s.Gender},{escapedDept},{s.Gpa:0.00},{escapedAvatar}");
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
            ThongBaoTrangThaiCha("Đã làm mới dữ liệu lưới.");
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
                              $"• Khoa/Ngành: {s.Department}\n" +
                              $"• Điểm GPA: {s.Gpa:0.00}\n" +
                              $"• Ảnh: {(string.IsNullOrEmpty(s.AvatarPath) ? "(Chưa có)" : s.AvatarPath)}";

                MessageBox.Show(info, "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
