using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai4_6_StudentManager
{
    public partial class frmStudentManager : Form
    {
        private BindingList<Student> listStudents = new BindingList<Student>();
        private BindingSource bindingSource = new BindingSource();
        private int autoIdCounter = 1;
        private bool isClosingConfirmed = false;

        public frmStudentManager()
        {
            InitializeComponent();
        }

        private void frmStudentManager_Load(object sender, EventArgs e)
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

            // 5. Cấu hình Data Binding 2 chiều tự động (DataBindings.Add)
            ThietLapDataBinding();

            // 6. Lắng nghe thay đổi danh sách để cập nhật thanh trạng thái
            listStudents.ListChanged += (s, ev) => CapNhatThongKe();

            // 7. Lắng nghe sự kiện chuyển dòng của BindingSource để nạp ảnh đại diện
            bindingSource.CurrentChanged += BindingSource_CurrentChanged;
            dgvStudents.SelectionChanged += dgvStudents_SelectionChanged;

            // Nạp ảnh ban đầu cho sinh viên đang chọn
            if (bindingSource.Current is Student firstStudent)
            {
                SafeLoadImage(firstStudent.AvatarPath);
            }

            // Cập nhật giao diện ban đầu
            CapNhatThongKe();
            CapNhatDongHo();
            SinhMaTuDong();
        }

        #region Thiết lập Data Binding tự động (DataBindings.Add - 2 Chiều)
        /// <summary>
        /// Ràng buộc dữ liệu 2 chiều tự động bằng DataBindings.Add giữa BindingSource và các Control nhập liệu.
        /// Khi người dùng chọn bất kỳ dòng nào trên DataGridView, BindingSource.Current thay đổi
        /// và các TextBox/ComboBox tự động hiển thị dữ liệu tương ứng.
        /// Khi chỉnh sửa trên Control, dữ liệu tự động đồng bộ ngược lại đối tượng và lưới.
        /// </summary>
        private void ThietLapDataBinding()
        {
            txtStudentId.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            cboGender.DataBindings.Clear();
            txtAvatarPath.DataBindings.Clear();

            txtStudentId.DataBindings.Add("Text", bindingSource, nameof(Student.StudentId), true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bindingSource, nameof(Student.FullName), true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bindingSource, nameof(Student.Age), true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender.DataBindings.Add("Text", bindingSource, nameof(Student.Gender), true, DataSourceUpdateMode.OnPropertyChanged);
            txtAvatarPath.DataBindings.Add("Text", bindingSource, nameof(Student.AvatarPath), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BindingSource_CurrentChanged(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Student student)
            {
                SafeLoadImage(student.AvatarPath);
                XoaLoiValidation();
                sslStatus.Text = $"Đang chọn sinh viên: [{student.StudentId}] {student.FullName}";
            }
        }

        private void dgvStudents_SelectionChanged(object? sender, EventArgs e)
        {
            if (txtFullName.DataBindings.Count == 0 && bindingSource.Current != null)
            {
                ThietLapDataBinding();
            }
        }
        #endregion

        #region Cấu hình DataGridView hoàn toàn bằng Code
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
                Width = 100
            };

            // Cột Họ và tên
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.FullName),
                HeaderText = "Họ và tên",
                Name = "colFullName",
                Width = 220
            };

            // Cột Tuổi
            DataGridViewTextBoxColumn colAge = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Student.Age),
                HeaderText = "Tuổi",
                Name = "colAge",
                Width = 80,
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
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            // Cột Đường dẫn ảnh đại diện
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

            dgvStudents.MouseDown += dgvStudents_MouseDown;
        }

        private void dgvStudents_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                var hit = dgvStudents.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    if (txtFullName.DataBindings.Count == 0)
                    {
                        ThietLapDataBinding();
                    }
                    bindingSource.Position = hit.RowIndex;
                }
            }
        }
        #endregion

        #region Dữ liệu mẫu & Mã tự sinh
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

        #region Safe Image Loading (Đọc ảnh an toàn không khóa file)
        private void SafeLoadImage(string? imagePath)
        {
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;

            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
            {
                return;
            }

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
                sslStatus.Text = $"Không thể tải ảnh: {ex.Message}";
            }
        }
        #endregion

        #region Kiểm tra hợp lệ dữ liệu (Validation)
        private bool ValidateDuLieu(out int age)
        {
            bool hopLe = true;
            age = 0;
            XoaLoiValidation();

            // 1. Kiểm tra Mã sinh viên
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên không được để trống!");
                hopLe = false;
            }

            // 2. Kiểm tra Họ tên
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Họ và tên không được để trống!");
                hopLe = false;
            }

            // 3. Kiểm tra Tuổi
            if (string.IsNullOrWhiteSpace(txtAge.Text) || !int.TryParse(txtAge.Text.Trim(), out age) || age < 15 || age > 100)
            {
                errorProvider1.SetError(txtAge, "Tuổi phải là số nguyên hợp lệ trong khoảng từ 15 đến 100!");
                hopLe = false;
            }

            // 4. Kiểm tra Giới tính
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

        #region Các sự kiện Thao tác CRUD
        // Chọn ảnh đại diện qua OpenFileDialog
        private void btnChooseAvatar_Click(object sender, EventArgs e)
        {
            openFileDialogAvatar.Title = "Chọn hình ảnh đại diện sinh viên";
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
                sslStatus.Text = $"Đã chọn ảnh: {Path.GetFileName(selectedPath)}";
            }
        }

        // Thêm sinh viên mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateDuLieu(out int age))
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ, vui lòng kiểm tra lại các ô báo lỗi!", "Cảnh báo lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtStudentId.Text.Trim();

            // Kiểm tra trùng mã sinh viên
            if (listStudents.Any(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên này đã tồn tại, vui lòng chọn mã khác!");
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

            // Tái thiết lập binding và chuyển vị trí đến sinh viên mới
            ThietLapDataBinding();
            bindingSource.Position = listStudents.IndexOf(newStudent);

            sslStatus.Text = $"Thêm mới sinh viên [{newStudent.StudentId}] thành công!";
            MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Cập nhật thông tin sinh viên
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student currentStudent)
            {
                if (!ValidateDuLieu(out int age))
                {
                    MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ, vui lòng kiểm tra lại các ô báo lỗi!", "Cảnh báo lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentStudent.FullName = txtFullName.Text.Trim();
                currentStudent.Age = age;
                currentStudent.Gender = cboGender.SelectedItem?.ToString() ?? "Nam";
                currentStudent.AvatarPath = txtAvatarPath.Text.Trim();

                bindingSource.EndEdit();
                sslStatus.Text = $"Đã cập nhật sinh viên [{currentStudent.StudentId}] thành công!";
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên từ bảng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xóa sinh viên có xác nhận MessageBox
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

                    sslStatus.Text = $"Đã xóa sinh viên [{deletedId}] thành công!";
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (listStudents.Count == 0)
                    {
                        btnClear.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Làm mới form nhập liệu
        private void btnClear_Click(object sender, EventArgs e)
        {
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
            sslStatus.Text = "Đã làm mới form nhập liệu. Sẵn sàng thêm mới.";
        }
        #endregion

        #region Thao tác Đọc / Ghi File CSV (UTF-8)
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            saveFileDialogCsv.Title = "Xuất danh sách sinh viên ra file CSV";
            saveFileDialogCsv.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialogCsv.FileName = $"DanhSachSinhVien_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

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
                    sslStatus.Text = $"Xuất CSV thành công vào {Path.GetFileName(saveFileDialogCsv.FileName)}";
                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi ghi file CSV:\n{ex.Message}", "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            openFileDialogCsv.Title = "Chọn file CSV cần nhập";
            openFileDialogCsv.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (openFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialogCsv.FileName, Encoding.UTF8);
                    if (lines.Length <= 1)
                    {
                        MessageBox.Show("File CSV không có dữ liệu hoặc chỉ có dòng tiêu đề!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int demThem = 0;
                    int demCapNhat = 0;

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string line = lines[i].Trim();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Split(',');
                        if (parts.Length >= 4)
                        {
                            string id = parts[0].Trim().Trim('"');
                            string name = parts[1].Trim().Trim('"');
                            int.TryParse(parts[2].Trim(), out int age);
                            string gender = parts[3].Trim().Trim('"');
                            string avatar = parts.Length >= 5 ? parts[4].Trim().Trim('"') : "";

                            var existing = listStudents.FirstOrDefault(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase));
                            if (existing != null)
                            {
                                existing.FullName = name;
                                existing.Age = age;
                                existing.Gender = gender;
                                existing.AvatarPath = avatar;
                                demCapNhat++;
                            }
                            else
                            {
                                listStudents.Add(new Student(id, name, age, gender, avatar));
                                demThem++;
                            }
                        }
                    }

                    ThietLapDataBinding();
                    CapNhatThongKe();
                    sslStatus.Text = $"Nhập CSV hoàn tất: Thêm {demThem}, Cập nhật {demCapNhat}.";
                    MessageBox.Show($"Nhập dữ liệu hoàn tất!\n- Đã thêm mới: {demThem} sinh viên\n- Đã cập nhật: {demCapNhat} sinh viên", "Nhập CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file CSV:\n{ex.Message}", "Lỗi nhập file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Thống kê & Đồng hồ thời gian thực
        private void CapNhatThongKe()
        {
            sslTotalStudents.Text = $"Tổng số sinh viên: {listStudents.Count}";
        }

        private void CapNhatDongHo()
        {
            sslTime.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo();
        }
        #endregion

        #region Xác nhận khi đóng Form
        private void frmStudentManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosingConfirmed) return;

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng ứng dụng Quản lý Sinh viên?",
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
    }
}
