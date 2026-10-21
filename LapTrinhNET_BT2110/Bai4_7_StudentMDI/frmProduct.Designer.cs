namespace Bai4_7_StudentMDI
{
    partial class frmProduct
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
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.cmsProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCtxDeleteProd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCtxRefreshProd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCtxDetailsProd = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);

            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpActions.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.cmsProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // 
            // grpInput
            // 
            this.grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInput.Controls.Add(this.numQuantity);
            this.grpInput.Controls.Add(this.lblQuantity);
            this.grpInput.Controls.Add(this.txtPrice);
            this.grpInput.Controls.Add(this.lblPrice);
            this.grpInput.Controls.Add(this.cboCategory);
            this.grpInput.Controls.Add(this.lblCategory);
            this.grpInput.Controls.Add(this.txtProductName);
            this.grpInput.Controls.Add(this.lblProductName);
            this.grpInput.Controls.Add(this.txtProductId);
            this.grpInput.Controls.Add(this.lblProductId);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(840, 130);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Thông tin sản phẩm";

            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(540, 60);
            this.numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(180, 23);
            this.numQuantity.TabIndex = 9;

            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(445, 63);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(57, 15);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Số lượng:";

            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(540, 25);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(180, 23);
            this.txtPrice.TabIndex = 7;

            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(445, 28);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(83, 15);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Đơn giá (VNĐ):";

            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(115, 93);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(220, 23);
            this.cboCategory.TabIndex = 5;

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 96);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 15);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Danh mục:";

            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(115, 59);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(220, 23);
            this.txtProductName.TabIndex = 3;

            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(20, 62);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(83, 15);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Tên sản phẩm:";

            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(115, 25);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(220, 23);
            this.txtProductId.TabIndex = 1;

            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(20, 28);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(82, 15);
            this.lblProductId.TabIndex = 0;
            this.lblProductId.Text = "Mã sản phẩm:";

            // 
            // grpActions
            // 
            this.grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActions.Controls.Add(this.btnClear);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.btnUpdate);
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Location = new System.Drawing.Point(12, 148);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(840, 58);
            this.grpActions.TabIndex = 1;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Chức năng";

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
            // grpList
            // 
            this.grpList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpList.Controls.Add(this.dgvProducts);
            this.grpList.Location = new System.Drawing.Point(12, 212);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(840, 310);
            this.grpList.TabIndex = 2;
            this.grpList.TabStop = false;
            this.grpList.Text = "Danh sách sản phẩm (Nhấp chuột phải để mở menu ngữ cảnh)";

            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.ContextMenuStrip = this.cmsProducts;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 19);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(834, 288);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvProducts_MouseDown);

            // 
            // cmsProducts
            // 
            this.cmsProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCtxDeleteProd,
            this.menuCtxRefreshProd,
            this.toolStripSeparator1,
            this.menuCtxDetailsProd});
            this.cmsProducts.Name = "cmsProducts";
            this.cmsProducts.Size = new System.Drawing.Size(157, 76);

            // 
            // menuCtxDeleteProd
            // 
            this.menuCtxDeleteProd.Name = "menuCtxDeleteProd";
            this.menuCtxDeleteProd.Size = new System.Drawing.Size(156, 22);
            this.menuCtxDeleteProd.Text = "Xóa dòng";
            this.menuCtxDeleteProd.Click += new System.EventHandler(this.menuCtxDeleteProd_Click);

            // 
            // menuCtxRefreshProd
            // 
            this.menuCtxRefreshProd.Name = "menuCtxRefreshProd";
            this.menuCtxRefreshProd.Size = new System.Drawing.Size(156, 22);
            this.menuCtxRefreshProd.Text = "Làm mới dữ liệu";
            this.menuCtxRefreshProd.Click += new System.EventHandler(this.menuCtxRefreshProd_Click);

            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);

            // 
            // menuCtxDetailsProd
            // 
            this.menuCtxDetailsProd.Name = "menuCtxDetailsProd";
            this.menuCtxDetailsProd.Size = new System.Drawing.Size(156, 22);
            this.menuCtxDetailsProd.Text = "Xem chi tiết";
            this.menuCtxDetailsProd.Click += new System.EventHandler(this.menuCtxDetailsProd_Click);

            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;

            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 534);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpInput);
            this.MinimumSize = new System.Drawing.Size(880, 550);
            this.Name = "frmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Sản phẩm";
            this.Load += new System.EventHandler(this.frmProduct_Load);

            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpActions.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.cmsProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ContextMenuStrip cmsProducts;
        private System.Windows.Forms.ToolStripMenuItem menuCtxDeleteProd;
        private System.Windows.Forms.ToolStripMenuItem menuCtxRefreshProd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuCtxDetailsProd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
