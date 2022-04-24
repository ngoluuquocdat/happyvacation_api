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
                newRow.CreateCell(9).SetCellValue(order.PricePerChild);
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
    }
}
