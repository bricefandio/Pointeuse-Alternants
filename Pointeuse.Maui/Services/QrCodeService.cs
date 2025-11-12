using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Maui.Controls;
using QRCoder;

namespace Pointeuse.Maui.Services
{
    public static class QrCodeService
    {
        public static ImageSource Generate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Le texte du QR code ne peut pas être vide.", nameof(text));
            }

            using var generator = new QRCodeGenerator();
            using QRCodeData qrCodeData = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qrCode.GetGraphic(pixelsPerModule: 20);

            return ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }
    }
}
