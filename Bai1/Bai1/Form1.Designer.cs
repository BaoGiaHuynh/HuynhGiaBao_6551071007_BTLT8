namespace Bai1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            nudSoLuongTon = new NumericUpDown();
            nudGiaBan = new NumericUpDown();
            cboDonVi = new ComboBox();
            cboLoaiHang = new ComboBox();
            txtTenHang = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label5 = new Label();
            label6 = new Label();
            dtpNgayNhap = new DateTimePicker();
            chkConKinhDoanh = new CheckBox();
            dgvHangHoa = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnXemBangGia = new Button();
            btnXuatPDF = new Button();
            btnXuatExcelLuoi = new Button();
            btnXuatExcelTonKho = new Button();
            txtTim = new TextBox();
            cboLocLoai = new ComboBox();
            chkChiConKD = new CheckBox();
            lblTrangThai = new Label();
            timerTim = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkConKinhDoanh);
            groupBox1.Controls.Add(dtpNgayNhap);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(nudSoLuongTon);
            groupBox1.Controls.Add(nudGiaBan);
            groupBox1.Controls.Add(cboDonVi);
            groupBox1.Controls.Add(cboLoaiHang);
            groupBox1.Controls.Add(txtTenHang);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(478, 191);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hàng hóa";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // nudSoLuongTon
            // 
            nudSoLuongTon.Location = new Point(340, 77);
            nudSoLuongTon.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudSoLuongTon.Name = "nudSoLuongTon";
            nudSoLuongTon.Size = new Size(150, 27);
            nudSoLuongTon.TabIndex = 9;
            nudSoLuongTon.ValueChanged += nudSoLuongTon_ValueChanged;
            // 
            // nudGiaBan
            // 
            nudGiaBan.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            nudGiaBan.Location = new Point(101, 145);
            nudGiaBan.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudGiaBan.Name = "nudGiaBan";
            nudGiaBan.Size = new Size(129, 27);
            nudGiaBan.TabIndex = 8;
            nudGiaBan.ThousandsSeparator = true;
            nudGiaBan.ValueChanged += nudGiaBan_ValueChanged;
            // 
            // cboDonVi
            // 
            cboDonVi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDonVi.FormattingEnabled = true;
            cboDonVi.Location = new Point(101, 109);
            cboDonVi.Name = "cboDonVi";
            cboDonVi.Size = new Size(129, 28);
            cboDonVi.TabIndex = 6;
            cboDonVi.SelectedIndexChanged += cboDonVi_SelectedIndexChanged;
            // 
            // cboLoaiHang
            // 
            cboLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiHang.FormattingEnabled = true;
            cboLoaiHang.Location = new Point(101, 75);
            cboLoaiHang.Name = "cboLoaiHang";
            cboLoaiHang.Size = new Size(129, 28);
            cboLoaiHang.TabIndex = 5;
            cboLoaiHang.SelectedIndexChanged += cboLoaiHang_SelectedIndexChanged;
            // 
            // txtTenHang
            // 
            txtTenHang.Location = new Point(101, 42);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new Size(340, 27);
            txtTenHang.TabIndex = 4;
            txtTenHang.TextChanged += txtTenHang_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 147);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 3;
            label4.Text = "Giá bán:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 116);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "Đơn vị:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 84);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Loại hàng:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 49);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên hàng:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkChiConKD);
            groupBox2.Controls.Add(cboLocLoai);
            groupBox2.Controls.Add(txtTim);
            groupBox2.Location = new Point(530, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(246, 191);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(236, 84);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 10;
            label5.Text = "Số lượng tồn:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(236, 117);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 11;
            label6.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(340, 111);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(129, 27);
            dtpNgayNhap.TabIndex = 1;
            dtpNgayNhap.ValueChanged += dtpNgayNhap_ValueChanged;
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Location = new Point(338, 148);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new Size(134, 24);
            chkConKinhDoanh.TabIndex = 0;
            chkConKinhDoanh.Text = "Còn kinh doanh";
            chkConKinhDoanh.UseVisualStyleBackColor = true;
            chkConKinhDoanh.CheckedChanged += chkConKinhDoanh_CheckedChanged;
            // 
            // dgvHangHoa
            // 
            dgvHangHoa.AllowUserToResizeRows = false;
            dgvHangHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHangHoa.Location = new Point(0, 197);
            dgvHangHoa.Name = "dgvHangHoa";
            dgvHangHoa.RowHeadersWidth = 51;
            dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHangHoa.Size = new Size(804, 187);
            dgvHangHoa.TabIndex = 12;
            dgvHangHoa.CellContentClick += dgvHangHoa_CellContentClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(0, 415);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(78, 29);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(84, 415);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(72, 29);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(166, 415);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(64, 29);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(236, 415);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(82, 29);
            btnLamMoi.TabIndex = 16;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXemBangGia
            // 
            btnXemBangGia.Location = new Point(324, 415);
            btnXemBangGia.Name = "btnXemBangGia";
            btnXemBangGia.Size = new Size(116, 29);
            btnXemBangGia.TabIndex = 17;
            btnXemBangGia.Text = "Xem bảng giá";
            btnXemBangGia.UseVisualStyleBackColor = true;
            btnXemBangGia.Click += btnXemBangGia_Click;
            // 
            // btnXuatPDF
            // 
            btnXuatPDF.Location = new Point(446, 415);
            btnXuatPDF.Name = "btnXuatPDF";
            btnXuatPDF.Size = new Size(77, 29);
            btnXuatPDF.TabIndex = 18;
            btnXuatPDF.Text = "Xuất PDF";
            btnXuatPDF.UseVisualStyleBackColor = true;
            btnXuatPDF.Click += btnXuatPDF_Click;
            // 
            // btnXuatExcelLuoi
            // 
            btnXuatExcelLuoi.Location = new Point(531, 415);
            btnXuatExcelLuoi.Name = "btnXuatExcelLuoi";
            btnXuatExcelLuoi.Size = new Size(118, 29);
            btnXuatExcelLuoi.TabIndex = 19;
            btnXuatExcelLuoi.Text = "Xuất Exel (lưới)";
            btnXuatExcelLuoi.UseVisualStyleBackColor = true;
            btnXuatExcelLuoi.Click += btnXuatExcelLuoi_Click;
            // 
            // btnXuatExcelTonKho
            // 
            btnXuatExcelTonKho.Location = new Point(655, 415);
            btnXuatExcelTonKho.Name = "btnXuatExcelTonKho";
            btnXuatExcelTonKho.Size = new Size(149, 29);
            btnXuatExcelTonKho.TabIndex = 20;
            btnXuatExcelTonKho.Text = "Xuất Excel tồn kho";
            btnXuatExcelTonKho.UseVisualStyleBackColor = true;
            btnXuatExcelTonKho.Click += btnXuatExcelTonKho_Click;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(24, 42);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(222, 27);
            txtTim.TabIndex = 12;
            txtTim.TextChanged += txtTim_TextChanged;
            // 
            // cboLocLoai
            // 
            cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoai.FormattingEnabled = true;
            cboLocLoai.Location = new Point(24, 75);
            cboLocLoai.Name = "cboLocLoai";
            cboLocLoai.Size = new Size(222, 28);
            cboLocLoai.TabIndex = 12;
            cboLocLoai.SelectedIndexChanged += cboLocLoai_SelectedIndexChanged;
            // 
            // chkChiConKD
            // 
            chkChiConKD.AutoSize = true;
            chkChiConKD.Location = new Point(24, 113);
            chkChiConKD.Name = "chkChiConKD";
            chkChiConKD.Size = new Size(226, 24);
            chkChiConKD.TabIndex = 12;
            chkChiConKD.Text = "Chỉ hiện hàng còn kinh doanh";
            chkChiConKD.UseVisualStyleBackColor = true;
            chkChiConKD.CheckedChanged += chkChiConKD_CheckedChanged;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(6, 387);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(0, 20);
            lblTrangThai.TabIndex = 12;
            // 
            // timerTim
            // 
            timerTim.Interval = 350;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTrangThai);
            Controls.Add(btnXuatExcelTonKho);
            Controls.Add(btnXuatExcelLuoi);
            Controls.Add(btnXuatPDF);
            Controls.Add(btnXemBangGia);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvHangHoa);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private NumericUpDown nudGiaBan;
        private ComboBox cboDonVi;
        private ComboBox cboLoaiHang;
        private TextBox txtTenHang;
        private NumericUpDown nudSoLuongTon;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpNgayNhap;
        private CheckBox chkConKinhDoanh;
        private DataGridView dgvHangHoa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnXemBangGia;
        private Button btnXuatPDF;
        private Button btnXuatExcelLuoi;
        private Button btnXuatExcelTonKho;
        private CheckBox chkChiConKD;
        private ComboBox cboLocLoai;
        private TextBox txtTim;
        private Label lblTrangThai;
        private System.Windows.Forms.Timer timerTim;
    }
}
