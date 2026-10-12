using Bai1.Models;
using ClosedXML.Excel;
using FastReport.Export.PdfSimple;
using Microsoft.EntityFrameworkCore;
using System.Data;
using FastReport.Export.Image;

namespace Bai1
{
    public partial class Form1 : Form
    {
        private List<HangHoa> _dsHienThi = new();
        private bool _dangNap = true;   // chặn tải lặp khi đang khởi tạo

        private static TiemTapHoaContext TaoDb()
        {
            var opt = new DbContextOptionsBuilder<TiemTapHoaContext>()
                .UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=TiemTapHoa;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;
            return new TiemTapHoaContext(opt);
        }

        public Form1()
        {
            InitializeComponent();
            // 2 sự kiện này Designer chưa gắn sẵn
            timerTim.Tick += async (s, e) => { timerTim.Stop(); await TaiDuLieuAsync(); };
            dgvHangHoa.SelectionChanged += dgvHangHoa_SelectionChanged;
        }

        // ================= LOAD =================
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] loai = { "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" };
                cboLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
                cboDonVi.DropDownStyle = ComboBoxStyle.DropDownList;
                cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;

                cboLoaiHang.Items.AddRange(loai);
                cboDonVi.Items.AddRange(new object[] { "Chai", "Gói", "Hộp", "Túi" });
                cboLocLoai.Items.Add("Tất cả");
                cboLocLoai.Items.AddRange(loai);
                cboLocLoai.SelectedIndex = 0;

                nudGiaBan.Minimum = 0;
                nudGiaBan.Maximum = 100000000;
                nudGiaBan.Increment = 500;
                nudGiaBan.ThousandsSeparator = true;
                nudSoLuongTon.Minimum = 0;
                nudSoLuongTon.Maximum = 100000;
                dtpNgayNhap.Format = DateTimePickerFormat.Custom;
                dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
                chkConKinhDoanh.Checked = true;

                dgvHangHoa.AutoGenerateColumns = false;
                dgvHangHoa.ReadOnly = true;
                dgvHangHoa.AllowUserToAddRows = false;
                dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvHangHoa.Columns.Clear();
                dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã", DataPropertyName = "MaHang", Width = 50 });
                dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên hàng", DataPropertyName = "TenHang", Width = 200 });
                dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại hàng", DataPropertyName = "LoaiHang", Width = 110 });
                dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn vị", DataPropertyName = "DonVi", Width = 70 });
                dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Giá bán",
                    DataPropertyName = "GiaBan",
                    Width = 90,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
                });
                dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tồn", DataPropertyName = "SoLuongTon", Width = 60 });
                dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Ngày nhập",
                    DataPropertyName = "NgayNhap",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                });
                dgvHangHoa.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Kinh doanh", DataPropertyName = "ConKinhDoanh", Width = 80 });

                timerTim.Interval = 350;
                _dangNap = false;
                await TaiDuLieuAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khởi tạo: " + ex.Message); }
        }

        // ================= TẢI DỮ LIỆU + TÌM + LỌC =================
        private async Task TaiDuLieuAsync()
        {
            if (_dangNap) return;
            try
            {
                using var db = TaoDb();
                var q = db.HangHoas.AsNoTracking().AsQueryable();

                var tuKhoa = txtTim.Text.Trim();
                if (tuKhoa != "") q = q.Where(h => h.TenHang.Contains(tuKhoa));

                if (cboLocLoai.SelectedIndex > 0)
                {
                    var loai = cboLocLoai.SelectedItem!.ToString()!;
                    q = q.Where(h => h.LoaiHang == loai);
                }
                if (chkChiConKD.Checked) q = q.Where(h => h.ConKinhDoanh);

                _dsHienThi = await q.OrderBy(h => h.MaHang).ToListAsync();
                dgvHangHoa.DataSource = _dsHienThi;
                lblTrangThai.Text = $"Tìm thấy {_dsHienThi.Count} mặt hàng";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // Bấm dòng -> đổ lên các control
        private void dgvHangHoa_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvHangHoa.CurrentRow?.DataBoundItem is not HangHoa h) return;
            txtTenHang.Text = h.TenHang;
            cboLoaiHang.SelectedItem = h.LoaiHang;
            cboDonVi.SelectedItem = h.DonVi;
            nudGiaBan.Value = Math.Min(h.GiaBan, nudGiaBan.Maximum);
            nudSoLuongTon.Value = Math.Min(h.SoLuongTon, (int)nudSoLuongTon.Maximum);
            dtpNgayNhap.Value = h.NgayNhap;
            chkConKinhDoanh.Checked = h.ConKinhDoanh;
        }

        // ================= TÌM KIẾM =================
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            timerTim.Stop();
            timerTim.Start();       // chờ 350ms sau khi ngừng gõ
        }

        private async void cboLocLoai_SelectedIndexChanged(object sender, EventArgs e) => await TaiDuLieuAsync();
        private async void chkChiConKD_CheckedChanged(object sender, EventArgs e) => await TaiDuLieuAsync();

        // ================= KIỂM TRA + GÁN DỮ LIỆU =================
        private bool HopLe()
        {
            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            { MessageBox.Show("Tên hàng không được để trống."); txtTenHang.Focus(); return false; }
            if (nudGiaBan.Value <= 0)
            { MessageBox.Show("Giá bán phải lớn hơn 0."); nudGiaBan.Focus(); return false; }
            if (cboLoaiHang.SelectedItem == null || cboDonVi.SelectedItem == null)
            { MessageBox.Show("Hãy chọn loại hàng và đơn vị."); return false; }
            return true;
        }

        private void GanTuForm(HangHoa h)
        {
            h.TenHang = txtTenHang.Text.Trim();
            h.LoaiHang = cboLoaiHang.SelectedItem!.ToString()!;
            h.DonVi = cboDonVi.SelectedItem!.ToString()!;
            h.GiaBan = nudGiaBan.Value;
            h.SoLuongTon = (int)nudSoLuongTon.Value;
            h.NgayNhap = dtpNgayNhap.Value;
            h.ConKinhDoanh = chkConKinhDoanh.Checked;
        }

        // ================= THÊM / SỬA / XÓA / LÀM MỚI =================
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!HopLe()) return;
            try
            {
                using var db = TaoDb();
                var h = new HangHoa();
                GanTuForm(h);
                db.HangHoas.Add(h);
                await db.SaveChangesAsync();
                await TaiDuLieuAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.CurrentRow?.DataBoundItem is not HangHoa chon)
            { MessageBox.Show("Hãy chọn một dòng để sửa."); return; }
            if (!HopLe()) return;
            try
            {
                using var db = TaoDb();
                var h = await db.HangHoas.FindAsync(chon.MaHang);
                if (h == null) { MessageBox.Show("Không tìm thấy hàng."); return; }
                GanTuForm(h);
                await db.SaveChangesAsync();
                await TaiDuLieuAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.CurrentRow?.DataBoundItem is not HangHoa chon)
            { MessageBox.Show("Hãy chọn một dòng để xóa."); return; }
            if (MessageBox.Show($"Xóa \"{chon.TenHang}\"?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                using var db = TaoDb();
                var h = await db.HangHoas.FindAsync(chon.MaHang);
                if (h != null) { db.HangHoas.Remove(h); await db.SaveChangesAsync(); }
                await TaiDuLieuAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                _dangNap = true;                       // tránh tải nhiều lần khi reset control
                txtTenHang.Clear();
                cboLoaiHang.SelectedIndex = -1;
                cboDonVi.SelectedIndex = -1;
                nudGiaBan.Value = 0;
                nudSoLuongTon.Value = 0;
                dtpNgayNhap.Value = DateTime.Now;
                chkConKinhDoanh.Checked = true;
                txtTim.Clear();
                cboLocLoai.SelectedIndex = 0;
                chkChiConKD.Checked = false;
                timerTim.Stop();
            }
            finally { _dangNap = false; }
            await TaiDuLieuAsync();
        }

        // ================= REPORT =================
        private async Task<DataTable> LayDuLieuBangGiaAsync()
        {
            using var db = TaoDb();
            var ds = await db.HangHoas.AsNoTracking()
                        .Where(h => h.ConKinhDoanh).OrderBy(h => h.MaHang).ToListAsync();

            var dt = new DataTable("HangHoa");
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("DonVi", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));
            foreach (var h in ds) dt.Rows.Add(h.TenHang, h.DonVi, h.GiaBan);
            return dt;
        }

        private async Task<FastReport.Report> TaoReportAsync()
        {
            var dt = await LayDuLieuBangGiaAsync();
            var report = new FastReport.Report();
            report.Load(Path.Combine(Application.StartupPath, "Reports", "BangGia.frx"));
            report.RegisterData(dt, "HangHoa");
            report.GetDataSource("HangHoa").Enabled = true;
            report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
            report.DoublePass = true;      // để [TotalPages#] đúng
            report.Prepare();
            return report;
        }

        private async void btnXemBangGia_Click(object sender, EventArgs e)
        {
            try
            {
                using var report = await TaoReportAsync();

                // Xuất mỗi trang ra 1 file PNG trong thư mục tạm
                string dir = Path.Combine(Path.GetTempPath(), "BangGiaPreview_" + Guid.NewGuid());
                Directory.CreateDirectory(dir);
                var img = new ImageExport
                {
                    ImageFormat = ImageExportFormat.Png,
                    SeparateFiles = true,
                    ResolutionX = 110,
                    ResolutionY = 110
                };
                img.Export(report, Path.Combine(dir, "trang.png"));

                var files = Directory.GetFiles(dir, "*.png").OrderBy(f => f).ToArray();
                if (files.Length == 0) { MessageBox.Show("Report không có trang nào."); return; }

                // Form xem trước
                var frm = new Form
                {
                    Text = "Xem trước - Bảng giá",
                    Width = 900,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterParent
                };
                var flow = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    BackColor = Color.Gray
                };
                foreach (var f in files)
                {
                    // đọc qua MemoryStream để không bị khóa file
                    var bmp = Image.FromStream(new MemoryStream(File.ReadAllBytes(f)));
                    flow.Controls.Add(new PictureBox { Image = bmp, SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(10) });
                }
                frm.Controls.Add(flow);
                frm.FormClosed += (s, ev) => { try { Directory.Delete(dir, true); } catch { } };
                frm.Show(this);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xem bảng giá: " + ex.Message); }
        }

        private async void btnXuatPDF_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog { Filter = "PDF (*.pdf)|*.pdf", FileName = "BangGia.pdf" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var report = await TaoReportAsync();
                report.Export(new PDFSimpleExport(), sfd.FileName);

                if (MessageBox.Show("Xuất xong. Mở file không?", "Xuất PDF", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
            catch (IOException) { MessageBox.Show("Không ghi được file. Hãy đóng file PDF đang mở rồi thử lại."); }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất PDF: " + ex.Message); }
        }

        // ================= EXCEL =================
        private async void btnXuatExcelLuoi_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx", FileName = "HangHoa_Luoi.xlsx" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                var ds = _dsHienThi.ToList();      // đúng các dòng đang hiển thị
                await Task.Run(() =>
                {
                    using var wb = new XLWorkbook();
                    var ws = wb.Worksheets.Add("HangHoa");
                    string[] tieuDe = { "Mã", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Tồn", "Ngày nhập", "Kinh doanh" };
                    for (int c = 0; c < tieuDe.Length; c++) ws.Cell(1, c + 1).Value = tieuDe[c];
                    ws.Row(1).Style.Font.Bold = true;

                    int r = 2;
                    foreach (var h in ds)
                    {
                        ws.Cell(r, 1).Value = h.MaHang;
                        ws.Cell(r, 2).Value = h.TenHang;
                        ws.Cell(r, 3).Value = h.LoaiHang;
                        ws.Cell(r, 4).Value = h.DonVi;
                        ws.Cell(r, 5).Value = h.GiaBan;
                        ws.Cell(r, 6).Value = h.SoLuongTon;
                        ws.Cell(r, 7).Value = h.NgayNhap;
                        ws.Cell(r, 8).Value = h.ConKinhDoanh ? "Có" : "Không";
                        r++;
                    }
                    ws.Column(5).Style.NumberFormat.Format = "#,##0";
                    ws.Column(7).Style.NumberFormat.Format = "dd/MM/yyyy";
                    ws.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                });
                MessageBox.Show("Xuất Excel thành công.");
            }
            catch (IOException) { MessageBox.Show("File đang được mở. Hãy đóng file Excel rồi thử lại."); }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
        }

        private async void btnXuatExcelTonKho_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx", FileName = "TonKho.xlsx" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var db = TaoDb();
                var ds = await db.HangHoas.AsNoTracking()
                            .Where(h => h.ConKinhDoanh).OrderBy(h => h.MaHang).ToListAsync();

                await Task.Run(() =>
                {
                    using var wb = new XLWorkbook();
                    var ws = wb.Worksheets.Add("TonKho");
                    string[] tieuDe = { "Mã", "Tên hàng", "Đơn vị", "Giá bán", "Tồn", "Ngày nhập", "Giá trị tồn" };
                    for (int c = 0; c < tieuDe.Length; c++) ws.Cell(1, c + 1).Value = tieuDe[c];
                    ws.Row(1).Style.Font.Bold = true;

                    int r = 2;
                    foreach (var h in ds)
                    {
                        ws.Cell(r, 1).Value = h.MaHang;
                        ws.Cell(r, 2).Value = h.TenHang;
                        ws.Cell(r, 3).Value = h.DonVi;
                        ws.Cell(r, 4).Value = h.GiaBan;
                        ws.Cell(r, 5).Value = h.SoLuongTon;
                        ws.Cell(r, 6).Value = h.NgayNhap;
                        ws.Cell(r, 7).FormulaA1 = $"D{r}*E{r}";
                        r++;
                    }
                    int cuoi = r - 1;
                    ws.Cell(r, 2).Value = "Tổng";
                    ws.Cell(r, 7).FormulaA1 = $"SUM(G2:G{cuoi})";
                    ws.Row(r).Style.Font.Bold = true;

                    ws.Range(1, 1, cuoi, 7).SetAutoFilter();
                    ws.SheetView.FreezeRows(1);

                    ws.Column(4).Style.NumberFormat.Format = "#,##0";
                    ws.Column(7).Style.NumberFormat.Format = "#,##0";
                    ws.Column(6).Style.NumberFormat.Format = "dd/MM/yyyy";
                    ws.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                });
                MessageBox.Show("Xuất Excel tồn kho thành công.");
            }
            catch (IOException) { MessageBox.Show("File đang được mở. Hãy đóng file Excel rồi thử lại."); }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
        }

        // ===== Các hàm Designer đã tạo sẵn, để trống (xóa sẽ làm lỗi Designer) =====
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtTenHang_TextChanged(object sender, EventArgs e) { }
        private void cboLoaiHang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboDonVi_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nudGiaBan_ValueChanged(object sender, EventArgs e) { }
        private void nudSoLuongTon_ValueChanged(object sender, EventArgs e) { }
        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e) { }
        private void chkConKinhDoanh_CheckedChanged(object sender, EventArgs e) { }
        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}