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
            dgvThongKe.Columns[4].HeaderText = "Tổng Tiền Hàng (VNĐ)";
            dgvThongKe.Columns[5].HeaderText = "Thuế (%)";
            dgvThongKe.Columns[6].HeaderText = "Tổng Thanh Toán (VNĐ)";
            dgvThongKe.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

        }

        private void frmThongKe_Load(object sender, EventArgs e)
        { 
            ResetValue();
            LoadThongKe();
            TongDoanhThu();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = bus_thongke.TimHoaDon(dtNgayBatDau.Value, dtNgayKetThuc.Value);
            dgvThongKe.Columns[0].HeaderText = "Mã Hoá Đơn";
            dgvThongKe.Columns[1].HeaderText = "Ngày Tạo";
            dgvThongKe.Columns[2].HeaderText = "Nhân Viên Lập";
            dgvThongKe.Columns[3].HeaderText = "Tên Khách Hàng";
            dgvThongKe.Columns[4].HeaderText = "Tổng Tiền Hàng (VNĐ)";
            dgvThongKe.Columns[5].HeaderText = "Thuế(%)";
            dgvThongKe.Columns[6].HeaderText = "Tổng Thanh Toán(VNĐ)";
            TongDoanhThu();
        }

        private void dgvThongKe_DoubleClick(object sender, EventArgs e)
        {
            frmChiTietHoaDon cthd = new frmChiTietHoaDon();
            cthd.lbCTHD.Text = this.dgvThongKe.CurrentRow.Cells[0].Value.ToString();
            cthd.ShowDialog();
        }

        private void btTimKiemNV_Click(object sender, EventArgs e)
        {
            DataTable dt = bus_thongke.TimHDTheoTenNV(txtTimKiem.Text);
            if (dt.Rows.Count > 0)
            {
                dgvThongKe.DataSource = dt;
                dgvThongKe.Columns[0].HeaderText = "Mã Hoá Đơn";
                dgvThongKe.Columns[1].HeaderText = "Ngày Tạo";
                dgvThongKe.Columns[2].HeaderText = "Nhân Viên Lập";
                dgvThongKe.Columns[3].HeaderText = "Tên Khách Hàng";
                dgvThongKe.Columns[4].HeaderText = "Tổng Tiền Hàng (VNĐ)";
                dgvThongKe.Columns[5].HeaderText = "Thuế(%)";
                dgvThongKe.Columns[6].HeaderText = "Tổng Thanh Toán(VNĐ)";
                TongDoanhThu();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tên nhân viên");
                LoadThongKe();
            }
            ResetValue();
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

                // Kẻ viền

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
            //exportgridtopdf(dgvThongKe, "text");
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
                            //PDFTable Tiêu Đề
                            PdfPTable pdfTable1 = new PdfPTable(1);
                            pdfTable1.DefaultCell.Padding = 5;
                            pdfTable1.WidthPercentage = 30;
                            pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                            //pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
                            pdfTable1.DefaultCell.BorderWidth = 0;
                            pdfTable1.DefaultCell.BorderWidthBottom = 0.1F;


                            // Tiêu Đề
                            Chunk c1 = new Chunk(" Thống Kê Doanh Thu", FontFactory.GetFont("Times New Roman"));
                            c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                            c1.Font.SetStyle(0);
                            c1.Font.Size = 25;
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
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            // DataGridView
                            foreach (DataGridViewColumn column in dgvThongKe.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvThongKe.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            //-------------------------------------------------------------
                            // PDFTable Tổng Doanh Thu
                            PdfPTable pdfTable3 = new PdfPTable(1);
                            pdfTable3.DefaultCell.Padding = 5;
                            pdfTable3.WidthPercentage = 30;
                            pdfTable3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfTable3.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;

                            // Tổng Doanh Thu
                            Chunk c3 = new Chunk(" Tổng Doanh Thu:", FontFactory.GetFont("Times New Roman"));
                            c3.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                            c3.Font.SetStyle(0);
                            c3.Font.Size = 20;

                            Chunk c4 = new iTextSharp.text.Chunk(txtTongDoanhThu.Text);
                            c4.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                            c4.Font.SetStyle(0);
                            c4.Font.Size = 20;

                            Phrase p3 = new Phrase();
                            p3.Add(c3);
                            p3.Add(c4);
                            pdfTable3.AddCell(p3);

                            //-------------------------------------------------------------
                            // Tạo File PDF
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A3, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable1);
                                pdfDoc.Add(pdfTable2);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Add(pdfTable3);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
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
        public void exportgridtopdf(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            foreach (DataGridViewColumn colomn in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(colomn.HeaderText, text));
                //   cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdftable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dgvThongKe.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(),text));
                }
            }
            var savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = filename;
            savefiledialog.DefaultExt = ".pdf";
            if (savefiledialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4,10f,10f,10f,0f);
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    doc.Add(pdftable);
                    doc.Close();
                    stream.Close();
                }
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
