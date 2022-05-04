using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace HappyVacation.Services.QRCodeGen
{
    public static class QRCodeService
    {
        public static byte[] CreateQRCodeAsBytes(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);

            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(10);

            return qrCodeAsBitmapByteArr;
        }

        public static string CreateQRCodeAsBase64(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);

            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(2);

            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(qrCodeAsBitmapByteArr, 0, qrCodeAsBitmapByteArr.Length));

            // save qr image file
            //File.WriteAllBytes("E:\\QR\\qrCode.png", qrCodeAsBitmapByteArr);

            return QrUri;
        }        

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
