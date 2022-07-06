using HappyVacation.DTOs.Orders;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace HappyVacation.Services.XLSX
{
    public class XLSXService : IXLSXService
    {
        private readonly string _reportFolder;
        private const string StorageFolderName = "report";

        public XLSXService(IWebHostEnvironment webHostEnvironment)
        {
            _reportFolder = Path.Combine(webHostEnvironment.WebRootPath, StorageFolderName);
            // create the folder if it does not exist
            Directory.CreateDirectory(_reportFolder);
        }

        public async Task<string> ExportTourOrder(int providerId, string exportFileName, List<OrderManageInfoVm> orders)
        {
            // this provider's own report folder
            var providerReportFolder = Path.Combine(_reportFolder, $"TourProvider{providerId}");
            // create the report folder for this provider, if it does not exist
            Directory.CreateDirectory(providerReportFolder);

            // new workbook
            XSSFWorkbook wb = new XSSFWorkbook();
            // new worksheet
            ISheet sheet = wb.CreateSheet();
            // write to sheet
            // create header row
            var row0 = sheet.CreateRow(0);
            row0.CreateCell(0).SetCellValue("Order ID");
            row0.CreateCell(1).SetCellValue("Tour ID");
            row0.CreateCell(2).SetCellValue("Tour Name");
            row0.CreateCell(3).SetCellValue("Order Date");
            row0.CreateCell(4).SetCellValue("Modified Date");
            row0.CreateCell(5).SetCellValue("State");
            row0.CreateCell(6).SetCellValue("Depature Date");
            row0.CreateCell(7).SetCellValue("Price Per Adult");
            row0.CreateCell(8).SetCellValue("Adults");
            row0.CreateCell(9).SetCellValue("Price Per Child");
            row0.CreateCell(10).SetCellValue("Children");
            row0.CreateCell(11).SetCellValue("Total Price");
            row0.CreateCell(12).SetCellValue("Tourist Name");
            row0.CreateCell(13).SetCellValue("Tourist Phone");
            row0.CreateCell(14).SetCellValue("Tourist Email");
            // write order's information
            int rowIndex = 1;
            foreach (var order in orders)
            {
                var pricePerChild = order.PricePerChild >= 0 ? order.PricePerChild.ToString() : "None";
                // create new row
                var newRow = sheet.CreateRow(rowIndex);
                // write to row
                newRow.CreateCell(0).SetCellValue(order.Id);
                newRow.CreateCell(1).SetCellValue(order.TourId);
                newRow.CreateCell(2).SetCellValue(order.TourName);
                newRow.CreateCell(3).SetCellValue(order.OrderDate);
                newRow.CreateCell(4).SetCellValue(order.ModifiedDate);
                newRow.CreateCell(5).SetCellValue(order.State);
                newRow.CreateCell(6).SetCellValue(order.DepartureDate);
                newRow.CreateCell(7).SetCellValue(order.PricePerAdult);
                newRow.CreateCell(8).SetCellValue(order.Adults);
                newRow.CreateCell(9).SetCellValue(pricePerChild);
                newRow.CreateCell(10).SetCellValue(order.Children);
                newRow.CreateCell(11).SetCellValue(order.TotalPrice);
                newRow.CreateCell(12).SetCellValue(order.TouristName);
                newRow.CreateCell(13).SetCellValue(order.TouristPhone);
                newRow.CreateCell(14).SetCellValue(order.TouristEmail);
                // increase row index
                rowIndex++;
            }
            // save the xlsx file
            var exportFilePath = Path.Combine(providerReportFolder, $"{exportFileName}.xlsx");
            if (File.Exists(exportFilePath))
            {
                File.Delete(exportFilePath);
            }
            FileStream fs = new FileStream(exportFilePath, FileMode.CreateNew);
            wb.Write(fs);

            return $"/report/TourProvider{providerId}/{exportFileName}.xlsx";
        }

        public async Task<string> ExportOrderedTouristCollection(int providerId, string exportFileName, OrderedTouristCollect orderedTouristCollect)
        {
            // this provider's own report folder
            var providerReportFolder = Path.Combine(_reportFolder, $"TourProvider{providerId}");
            // create the report folder for this provider, if it does not exist
            Directory.CreateDirectory(providerReportFolder);

            // new workbook
            XSSFWorkbook wb = new XSSFWorkbook();
            // create bold font style
            var bold_font = wb.CreateFont();
            bold_font.IsBold = true;
            // new worksheet
            ISheet sheet = wb.CreateSheet();
            // write to sheet
            
            // create top rows and write tourId, depature
            sheet.CreateRow(0);
            sheet.CreateRow(1);
            sheet.CreateRow(2);

            var cra0 = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 5);
            var cra1 = new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 5);
            var cra2 = new NPOI.SS.Util.CellRangeAddress(2, 2, 0, 5);
            sheet.AddMergedRegion(cra0);
            sheet.AddMergedRegion(cra1);
            sheet.AddMergedRegion(cra2);

            var mergedCell = sheet.GetRow(0).CreateCell(0);
            mergedCell.SetCellValue($"Tour ID: {orderedTouristCollect.TourId} - {orderedTouristCollect.TourName}");
            mergedCell.CellStyle.Alignment = HorizontalAlignment.Center;

            mergedCell = sheet.GetRow(1).CreateCell(0);
            mergedCell.SetCellValue($"Departure: {orderedTouristCollect.DepartureDate}");
            mergedCell.CellStyle.Alignment = HorizontalAlignment.Center;

            mergedCell = sheet.GetRow(2).CreateCell(0);
            mergedCell.SetCellValue($"Total: {orderedTouristCollect.TotalCount} tourists");
            mergedCell.CellStyle.Alignment = HorizontalAlignment.Center;

            // create header row
            var header_row = sheet.CreateRow(4);
            var header_titles = new List<string>() { "Identity", "Full Name", "Date of Birth", "Adult/Child", "Order ID", "Pick up/Drop off" };
            var cell_index = 0;
            foreach(var title in header_titles)
            {
                var header_cell = header_row.CreateCell(cell_index);
                header_cell.CellStyle.SetFont(bold_font);
                header_cell.SetCellValue(title);
                cell_index++;
            }

            // write tourists
            var row_index = 5;
            foreach(var group in orderedTouristCollect.TouristGroups)
            {
                foreach(var adult in group.AdultsList)
                {
                    // create new row
                    var newRow = sheet.CreateRow(row_index);
                    // write to row
                    newRow.CreateCell(0).SetCellValue(adult.IdentityNumber);
                    newRow.CreateCell(1).SetCellValue(adult.FullName);
                    newRow.CreateCell(2).SetCellValue(adult.Dob);
                    newRow.CreateCell(3).SetCellValue("Adult");
                    newRow.CreateCell(4).SetCellValue(group.OrderId);
                    newRow.CreateCell(5).SetCellValue($"{group.StartPoint.Split('&')[1]}, {group.StartPoint.Split('&')[2]}");
                    // increase row index
                    row_index++;
                }
                foreach (var child in group.ChildrenList)
                {
                    // create new row
                    var newRow = sheet.CreateRow(row_index);
                    // write to row
                    newRow.CreateCell(0).SetCellValue(child.IdentityNumber);
                    newRow.CreateCell(1).SetCellValue(child.FullName);
                    newRow.CreateCell(2).SetCellValue(child.Dob);
                    newRow.CreateCell(3).SetCellValue("Child");
                    newRow.CreateCell(4).SetCellValue(group.OrderId);
                    newRow.CreateCell(5).SetCellValue($"{group.StartPoint.Split('&')[1]}, {group.StartPoint.Split('&')[2]}");
                    // increase row index
                    row_index++;
                }
                //row_index++;    // create a blank row between orders
            }

            // save the xlsx file
            var exportFilePath = Path.Combine(providerReportFolder, $"{exportFileName}.xlsx");
            if (File.Exists(exportFilePath))
            {
                File.Delete(exportFilePath);
            }
            FileStream fs = new FileStream(exportFilePath, FileMode.CreateNew);
            wb.Write(fs);

            return $"/report/TourProvider{providerId}/{exportFileName}.xlsx";
        }
    }
}
