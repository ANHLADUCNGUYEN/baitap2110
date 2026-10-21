using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Bai4_7_StudentMDI
{
    public partial class frmProduct : Form
    {
        private BindingList<Product> listProducts = new BindingList<Product>();
        private BindingSource bindingSource = new BindingSource();
        private int autoIdCounter = 1;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            // 1. Nạp danh mục sản phẩm
            cboCategory.Items.AddRange(new object[] {
                "Điện thoại",
                "Laptop",
                "Máy tính bảng",
                "Phụ kiện",
                "Màn hình"
            });
            cboCategory.SelectedIndex = 0;

            // 2. Cấu hình DataGridView bằng code
            CauHinhDataGridView();

            // 3. Nạp dữ liệu mẫu
            ThemDuLieuMau();

            // 4. Gắn BindingSource
            bindingSource.DataSource = listProducts;
            dgvProducts.DataSource = bindingSource;

            // 5. Thiết lập Data Binding tự động với DataBindings.Add
            ThietLapDataBinding();

            bindingSource.CurrentChanged += BindingSource_CurrentChanged;

            ThongBaoTrangThaiCha("Đã sẵn sàng trên giao diện Quản lý Sản phẩm (Data Binding kích hoạt).");
        }

        #region Thiết lập Data Binding tự động
        private void ThietLapDataBinding()
        {
            txtProductId.DataBindings.Clear();
            txtProductName.DataBindings.Clear();
            cboCategory.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            numQuantity.DataBindings.Clear();

            txtProductId.DataBindings.Add("Text", bindingSource, nameof(Product.ProductId), true, DataSourceUpdateMode.Never);
            txtProductName.DataBindings.Add("Text", bindingSource, nameof(Product.ProductName), true, DataSourceUpdateMode.Never);
            cboCategory.DataBindings.Add("SelectedItem", bindingSource, nameof(Product.Category), true, DataSourceUpdateMode.Never);

            var bindingPrice = new Binding("Text", bindingSource, nameof(Product.Price), true, DataSourceUpdateMode.Never);
            bindingPrice.Format += (s, ev) =>
            {
                if (ev.Value is decimal val) ev.Value = val.ToString("N0");
            };
            txtPrice.DataBindings.Add(bindingPrice);

            numQuantity.DataBindings.Add("Value", bindingSource, nameof(Product.Quantity), true, DataSourceUpdateMode.Never);
        }

        private void BindingSource_CurrentChanged(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Product p)
            {
                XoaLoiValidation();
                ThongBaoTrangThaiCha($"Đang chọn sản phẩm: [{p.ProductId}] {p.ProductName}");
            }
        }
        #endregion

        #region Giao tiếp với Form cha MDI
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
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.ReadOnly = true;
            dgvProducts.MultiSelect = false;

            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ProductId),
                HeaderText = "Mã SP",
                Name = "colProductId",
                Width = 90
            };

            var colName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ProductName),
                HeaderText = "Tên sản phẩm",
                Name = "colProductName",
                Width = 200
            };

            var colCat = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Category),
                HeaderText = "Loại sản phẩm",
                Name = "colCategory",
                Width = 120
            };

            var colPrice = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Price),
                HeaderText = "Đơn giá",
                Name = "colPrice",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            var colQty = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Quantity),
                HeaderText = "Số lượng",
                Name = "colQuantity",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var colTotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.TotalValue),
                HeaderText = "Thành tiền",
                Name = "colTotalValue",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
                colId, colName, colCat, colPrice, colQty, colTotal
            });
        }
        #endregion

        #region Dữ liệu mẫu & Sinh mã tự động
        private void ThemDuLieuMau()
        {
            listProducts.Add(new Product("SP01", "iPhone 15 Pro Max", "Điện thoại", 29500000m, 12));
            listProducts.Add(new Product("SP02", "Dell XPS 13 Plus", "Laptop", 34000000m, 6));
            listProducts.Add(new Product("SP03", "iPad Air 5 M1", "Máy tính bảng", 14500000m, 15));
            listProducts.Add(new Product("SP04", "Chuột Logitech MX Master 3S", "Phụ kiện", 2200000m, 30));
            autoIdCounter = 5;
        }

        private void SinhMaTuDong()
        {
            txtProductId.Text = $"SP{autoIdCounter:D2}";
        }
        #endregion

        #region Validation
        private bool ValidateDuLieu(out decimal price)
        {
            bool hopLe = true;
            price = 0;
            XoaLoiValidation();

            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                errorProvider1.SetError(txtProductId, "Mã sản phẩm không được để trống!");
                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                hopLe = false;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn danh mục!");
                hopLe = false;
            }

            string cleanPrice = txtPrice.Text.Replace(",", "").Replace(".", "").Trim();
            if (string.IsNullOrWhiteSpace(cleanPrice) || !decimal.TryParse(cleanPrice, NumberStyles.Any, CultureInfo.InvariantCulture, out price) || price < 0)
            {
                errorProvider1.SetError(txtPrice, "Đơn giá phải là số hợp lệ >= 0!");
                hopLe = false;
            }

            return hopLe;
        }

        private void XoaLoiValidation()
        {
            errorProvider1.SetError(txtProductId, string.Empty);
            errorProvider1.SetError(txtProductName, string.Empty);
            errorProvider1.SetError(cboCategory, string.Empty);
            errorProvider1.SetError(txtPrice, string.Empty);
        }
        #endregion

        #region Các nút chức năng CRUD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateDuLieu(out decimal price))
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtProductId.Text.Trim();
            if (listProducts.Any(p => p.ProductId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtProductId, "Mã sản phẩm đã tồn tại!");
                MessageBox.Show("Mã sản phẩm đã tồn tại trong hệ thống!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product newProd = new Product(
                id,
                txtProductName.Text.Trim(),
                cboCategory.SelectedItem?.ToString() ?? "Khác",
                price,
                (int)numQuantity.Value
            );

            listProducts.Add(newProd);
            autoIdCounter++;

            ThietLapDataBinding();
            bindingSource.Position = listProducts.IndexOf(newProd);

            ThongBaoTrangThaiCha($"Thêm mới sản phẩm [{newProd.ProductId}] thành công!");
            MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Product p)
            {
                if (!ValidateDuLieu(out decimal price))
                {
                    MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                p.ProductName = txtProductName.Text.Trim();
                p.Category = cboCategory.SelectedItem?.ToString() ?? "Khác";
                p.Price = price;
                p.Quantity = (int)numQuantity.Value;

                ThongBaoTrangThaiCha($"Cập nhật sản phẩm [{p.ProductId}] thành công!");
                MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Product p)
            {
                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm [{p.ProductId} - {p.ProductName}]?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    string delId = p.ProductId;
                    listProducts.Remove(p);
                    ThietLapDataBinding();

                    ThongBaoTrangThaiCha($"Đã xóa sản phẩm [{delId}] thành công!");
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (listProducts.Count == 0)
                    {
                        btnClear.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductId.DataBindings.Clear();
            txtProductName.DataBindings.Clear();
            cboCategory.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            numQuantity.DataBindings.Clear();
            dgvProducts.ClearSelection();

            XoaLoiValidation();
            SinhMaTuDong();
            txtProductName.Clear();
            cboCategory.SelectedIndex = 0;
            txtPrice.Clear();
            numQuantity.Value = 0;
            txtProductName.Focus();

            ThongBaoTrangThaiCha("Đã làm mới thông tin sản phẩm (Sẵn sàng thêm mới).");
        }
        #endregion

        #region ContextMenuStrip
        private void dgvProducts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvProducts.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvProducts.ClearSelection();
                    dgvProducts.Rows[hit.RowIndex].Selected = true;
                    bindingSource.Position = hit.RowIndex;
                    ThietLapDataBinding();
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                var hit = dgvProducts.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    if (txtProductName.DataBindings.Count == 0)
                    {
                        ThietLapDataBinding();
                    }
                }
            }
        }

        private void menuCtxDeleteProd_Click(object sender, EventArgs e)
        {
            btnDelete.PerformClick();
        }

        private void menuCtxRefreshProd_Click(object sender, EventArgs e)
        {
            ThietLapDataBinding();
            btnClear.PerformClick();
            ThongBaoTrangThaiCha("Đã làm mới danh sách sản phẩm.");
        }

        private void menuCtxDetailsProd_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Product p)
            {
                string info = $"THÔNG TIN CHI TIẾT SẢN PHẨM\n" +
                              $"------------------------------------\n" +
                              $"• Mã SP: {p.ProductId}\n" +
                              $"• Tên SP: {p.ProductName}\n" +
                              $"• Phân loại: {p.Category}\n" +
                              $"• Đơn giá: {p.Price:N0} VNĐ\n" +
                              $"• Số lượng tồn: {p.Quantity}\n" +
                              $"• Thành tiền: {p.TotalValue:N0} VNĐ";

                MessageBox.Show(info, "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
