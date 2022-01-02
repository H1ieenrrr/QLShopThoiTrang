using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLShopThoiTrang;
using BUS_QLShopThoiTrang;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable; 
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Meet_QuanLyShopThoiTrang
{
    
    public partial class frmThongKe : Form
    {
        
        public frmThongKe()
        {
            InitializeComponent();
            
        }
        BUS_ThongKe bus_thongke = new BUS_ThongKe();
        private void TongDoanhThu()
        { 
            float DemDoanhThu = 0;
            for (int i = 0; i < dgvThongKe.Rows.Count; i++)
            {
                DemDoanhThu += float.Parse(dgvThongKe.Rows[i].Cells[6].Value.ToString());
            }
            txtTongDoanhThu.Text = DemDoanhThu.ToString();
            double temp = Convert.ToDouble(txtTongDoanhThu.Text);
            txtTongDoanhThu.Text = temp.ToString("###,###,###");
        }
        private void ResetValue()
        {
            dtNgayBatDau.Value = dtNgayKetThuc.Value.AddDays(-7);
            txtTongDoanhThu.Enabled = false;
            txtTimKiem.Text = "Nhập tên nhân viên";           
        }
        private void LoadThongKe()
        {
            dgvThongKe.DataSource = bus_thongke.DanhSachHoaDon();
            dgvThongKe.Columns[0].HeaderText = "Mã Hoá Đơn";
            dgvThongKe.Columns[1].HeaderText = "Ngày Tạo";
            dgvThongKe.Columns[2].HeaderText = "Nhân Viên Lập";
            dgvThongKe.Columns[3].HeaderText = "Tên Khách Hàng";
            dgvThongKe.Columns[4].HeaderText = "Tổng Tiền Hàng ";
            dgvThongKe.Columns[5].HeaderText = "Thuế (%)";
            dgvThongKe.Columns[6].HeaderText = "Tổng Thanh Toán ";
            dgvThongKe.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            

            //dgvThongKe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvThongKe.Columns[4].DefaultCellStyle.Format = "###,###,###";
            dgvThongKe.Columns[6].DefaultCellStyle.Format = "###,###,###";

            dgvThongKe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtNgayBatDau.Value = DateTime.Now;
            dtNgayKetThuc.Value = DateTime.Now;

        }

        private void frmThongKe_Load(object sender, EventArgs e)
        { 
            ResetValue();
            LoadThongKe();
            TongDoanhThu();
            txtMaHD.Visible = false;
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            if(dtNgayBatDau.Value.Ticks > dtNgayKetThuc.Value.Ticks)
            {
                MessageBox.Show("Ngày Bắt Đầu Phải Nhỏ Hơn Ngày Kết Thúc !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvThongKe.DataSource = bus_thongke.TimHoaDon(dtNgayBatDau.Value, dtNgayKetThuc.Value, txtTimKiem.Text);
            dgvThongKe.Columns[0].HeaderText = "Mã Hoá Đơn";
            dgvThongKe.Columns[1].HeaderText = "Ngày Tạo";
            dgvThongKe.Columns[2].HeaderText = "Nhân Viên Lập";
            dgvThongKe.Columns[3].HeaderText = "Tên Khách Hàng";
            dgvThongKe.Columns[4].HeaderText = "Tổng Tiền Hàng ";
            dgvThongKe.Columns[5].HeaderText = "Thuế(%)";
            dgvThongKe.Columns[6].HeaderText = "Tổng Thanh Toán";

            //dgvThongKe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvThongKe.Columns[4].DefaultCellStyle.Format = "###,###,###";
            dgvThongKe.Columns[6].DefaultCellStyle.Format = "###,###,###";

            dgvThongKe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            btXuatThongKeExcel.Enabled = true;
            TongDoanhThu();
        }

        private void dgvThongKe_DoubleClick(object sender, EventArgs e)
        {
            frmChiTietHoaDon cthd = new frmChiTietHoaDon();
            cthd.lbCTHD.Text = this.dgvThongKe.CurrentRow.Cells[0].Value.ToString();
            cthd.ShowDialog();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }    
        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            try
            {
                //Tạo các đối tượng Excel

                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbooks oBooks;

                Microsoft.Office.Interop.Excel.Sheets oSheets;

                Microsoft.Office.Interop.Excel.Workbook oBook;

                Microsoft.Office.Interop.Excel.Worksheet oSheet;

                //Tạo mới một Excel WorkBook 

                oExcel.Visible = true;

                oExcel.DisplayAlerts = false;

                oExcel.Application.SheetsInNewWorkbook = 1;

                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

                oSheets = oBook.Worksheets;

                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                oSheet.Name = sheetName;

                



                // Tạo phần Tiêu đề
                Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

                head.MergeCells = true;

                head.Value2 = title;

                head.Font.Bold = true;

                head.Font.Name = "Times New Roman";

                head.Font.Size = "20";

                head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                // Tạo tiêu đề cột 

                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

                cl1.Value2 = "Mã Hoá Đơn";

                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

                cl2.Value2 = "Ngày tạo";

                cl2.ColumnWidth = 30.0;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

                cl3.Value2 = "Nhân Viên Lập";
                cl3.ColumnWidth = 25.0;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

                cl4.Value2 = "Tên Khách Hàng";

                cl4.ColumnWidth = 25.0;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

                cl5.Value2 = "Tổng Tiền Hàng";

                cl5.ColumnWidth = 20.5;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

                cl6.Value2 = "Thuế";

                cl6.ColumnWidth = 12.5;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

                cl7.Value2 = "Tổng Thanh Toán";

                cl7.ColumnWidth = 25.0;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "G3");

                rowHead.Font.Bold = true;


                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Thiết lập màu nền

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                // Tạo mảng theo datatable

                object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng

                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    DataRow dataRow = dataTable.Rows[row];

                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        arr[row, col] = dataRow[col];
                    }
                }
                //Thiết lập vùng điền dữ liệu

                int rowStart = 4;

                int columnStart = 1;

                int rowEnd = rowStart + dataTable.Rows.Count - 2;

                int columnEnd = dataTable.Columns.Count;

                // Ô bắt đầu điền dữ liệu

                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

                // Ô kết thúc điền dữ liệu

                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

                // Lấy về vùng điền dữ liệu

                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                //Điền dữ liệu vào vùng đã thiết lập

                range.Value2 = arr;

                // Kẻ viền

                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Căn giữa cột mã nhân viên

                //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

                //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

                //Căn giữa cả bảng 
                oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            catch (Exception)
            {


            }

        }

        private void btXuatThongKe_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn("Mã Hoá đơn");
            DataColumn col2 = new DataColumn("Ngày Tạo");
            DataColumn col3 = new DataColumn("Nhân Viên Nhập");
            DataColumn col4 = new DataColumn("Tên Khách Hàng");
            DataColumn col5 = new DataColumn("Tổng Tiền Hàng (VNĐ)");
            DataColumn col6 = new DataColumn("Thuế (%)");
            DataColumn col7 = new DataColumn("Tổng Thanh Toán(VNĐ)");
            
            

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);
            dt.Columns.Add(col5);
            dt.Columns.Add(col6);
            dt.Columns.Add(col7);
            

            foreach (DataGridViewRow dtgvRow in dgvThongKe.Rows)
            {
                DataRow dtrow = dt.NewRow();

                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;
                dtrow[5] = dtgvRow.Cells[5].Value;
                dtrow[6] = dtgvRow.Cells[6].Value;
                dt.Rows.Add(dtrow);
            }
            ExportFile(dt, "DanhSach", "Danh Sách Hoá Đơn");
        }

        private void btXuatThongKePDF_Click(object sender, EventArgs e)
        {
           
            if (dgvThongKe.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "ThongKeHoaDon.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            //Full path to the Unicode Arial file
                            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");

                            //Create a base font object making sure to specify IDENTITY-H
                            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                            //Create a specific font object
                            iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                            iTextSharp.text.Font f1 = new iTextSharp.text.Font(bf, 50, iTextSharp.text.Font.NORMAL);

                            //Image
                            
                            string imageURL = @"C:\Users\Tan Hien\OneDrive\Documents\Kỳ_4\Dự Án 1\Hình\Logo1.jpg";
                            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                            jpg.ScaleToFit(140f, 120f);
                            jpg.SpacingBefore = 10f;
                            jpg.SpacingAfter = 1f;
                            jpg.Alignment = Element.ALIGN_LEFT;

                            //PDFTable Tiêu Đề
                            PdfPTable pdfTable1 = new PdfPTable(1);
                            pdfTable1.DefaultCell.Padding = 5;
                            pdfTable1.WidthPercentage = 30;
                            pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                            pdfTable1.DefaultCell.BorderWidth = 0;
                            pdfTable1.DefaultCell.BorderWidthBottom = 0.1F;


                            // Tiêu Đề
                            Chunk c1 = new Chunk(" Thống Kê Doanh Thu");
                            c1.Font = f1;
                            c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                            c1.Font.SetStyle(0);
                            c1.Font.Size = 30;
                            Phrase p1 = new Phrase();
                            p1.Add(c1);
                            pdfTable1.AddCell(p1);
                            //---------------------------------------------------------

                            // PDFTable tên nhóm
                            PdfPTable pdfTable2 = new PdfPTable(1);
                            pdfTable2.DefaultCell.Padding = 5;
                            pdfTable2.WidthPercentage = 30;
                            pdfTable2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable2.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                            //pdfTable2.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
                            pdfTable2.DefaultCell.BorderWidth = 0;

                            // Tên Nhóm
                            Chunk c2 = new Chunk(" Meet Clothing Store", FontFactory.GetFont("Times New Roman"));
                            c2.Font = f;
                            c2.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                            c2.Font.SetStyle(0);
                            c2.Font.Size = 15;
                            Phrase p2 = new Phrase();
                            p2.Add(c2);
                            pdfTable2.AddCell(p2);
                            //---------------------------------------------------------

                            //PDFTable DataGridView                       
                            PdfPTable pdfTable = new PdfPTable(dgvThongKe.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                         
                            // DataGridView
                            foreach (DataGridViewColumn column in dgvThongKe.Columns)
                            {                          
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, f));
                                cell.BackgroundColor = BaseColor.YELLOW;                             
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvThongKe.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {                                    
                                    pdfTable.AddCell(new Phrase(cell.FormattedValue.ToString(),f));                                
                                }
                            }

                            //-------------------------------------------------------------
                            // PDFTable Tổng Doanh Thu
                            PdfPTable pdfTable3 = new PdfPTable(1);
                            pdfTable3.DefaultCell.Padding = 5;
                            pdfTable3.WidthPercentage = 40;
                            pdfTable3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfTable3.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                            pdfTable3.DefaultCell.BackgroundColor = BaseColor.ORANGE;
                            

                            // Tổng Doanh Thu
                            Chunk c3 = new Chunk(" Tổng Doanh Thu:   ", FontFactory.GetFont("Times New Roman"));
                            c3.Font = f;
                            c3.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                            c3.Font.SetStyle(0);
                            c3.Font.Size = 20;

                            Chunk c4 = new iTextSharp.text.Chunk(txtTongDoanhThu.Text);
                            c4.Font = f;
                            c4.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                            c4.Font.SetStyle(0);
                            c4.Font.Size = 20;

                            Chunk c5 = new Chunk(" VNĐ", FontFactory.GetFont("Times New Roman"));
                            c5.Font = f;
                            c5.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                            c5.Font.SetStyle(0);
                            c5.Font.Size = 20;

                            Phrase p3 = new Phrase();
                            p3.Add(c3);
                            p3.Add(c4);
                            p3.Add(c5);
                            pdfTable3.AddCell(p3);

                            //-------------------------------------------------------------
                            // Tạo File PDF
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A2, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                //pdfDoc.Add(jpg);
                                pdfDoc.Add(pdfTable1);
                                pdfDoc.Add(pdfTable2);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Add(pdfTable3);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Thông Báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }
        
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKeTongHop_Click(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = bus_thongke.ThongKeTongHop(dtNgayBatDau.Value,dtNgayKetThuc.Value);
            dgvThongKe.Columns[0].HeaderText = "STT";
            dgvThongKe.Columns[1].HeaderText = "Ngày Lập Hóa Đơn";
            dgvThongKe.Columns[2].HeaderText = "Tổng Số Hóa Đơn";
            dgvThongKe.Columns[3].HeaderText = "Tổng Tiền Không VAT";
            dgvThongKe.Columns[4].HeaderText = "Tổng VAT";
            dgvThongKe.Columns[5].HeaderText = "Tổng Tiền Có VAT";
            dgvThongKe.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

       

            dgvThongKe.Columns[3].DefaultCellStyle.Format = "###,###,###";
            dgvThongKe.Columns[4].DefaultCellStyle.Format = "###,###,###";
            dgvThongKe.Columns[5].DefaultCellStyle.Format = "###,###,###";

            dgvThongKe.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            btXuatThongKeExcel.Enabled = false;
        }

        private void btnThongKeKHThang_Click(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = bus_thongke.ThongKeKhachHangTheoThang();
        }

        private void btnThongKeKHNam_Click(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = bus_thongke.ThongKeKhachHangTheoNam();
        }

        private void btnThongKeKhachHang_Click(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = bus_thongke.ThongKeKhachHang();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            string mahd = txtMaHD.Text;
            if (MessageBox.Show("Bạn Có Chắc Muốn Xóa Dữ Liệu ", "ConFirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bus_thongke.XoaHD(mahd))
                {
                    MessageBox.Show("Xóa Dữ Liệu Thành Công");
                    ResetValue();
                    LoadThongKe();
                    TongDoanhThu();
                }
                else
                {
                    MessageBox.Show("Xóa Không Thành Công");
                }
            }
            else
            {
                ResetValue();
            }
        }

        private void dgvThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThongKe.Rows.Count > 1)
            {
                try
                {
                    txtMaHD.Text = dgvThongKe.CurrentRow.Cells["MaHD"].Value?.ToString();                   
                }
                catch (Exception )
                {
                    
                }
            }
        }
    }
}
