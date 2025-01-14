using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Drawing;
using System.IO;

namespace Base64DecoderWebServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JsonDecodeController : ControllerBase
    {
        [HttpPost]
        public IActionResult DecodeJson([FromBody] JsonInput input)
        {
            try
            {
                // Base64 string'i decode et
                byte[] imageBytes = Convert.FromBase64String(input.ImageBase64);

                // Resmi geçici bir dosyaya kaydet
                string imagePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
                System.IO.File.WriteAllBytes(imagePath, imageBytes);

                // JSON verilerini ve resmi döndür
                return Ok(new
                {
                    Message = "Data processed successfully",
                    DecodedImagePath = imagePath,
                    ParsedData = input
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occurred", Error = ex.Message });
            }
        }

        [HttpGet("image/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            // Geçici klasörde dosya yolunu oluştur
            string imagePath = Path.Combine(Path.GetTempPath(), fileName);

            // Dosya mevcutsa byte dizisini döndür
            if (System.IO.File.Exists(imagePath))
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                return File(imageBytes, "image/png");
            }

            // Dosya yoksa 404 döndür
            return NotFound(new { Message = "Image not found" });
        }

    }

    public class JsonInput
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string DimWt { get; set; }
        public string RealVolume { get; set; }
        public string Weight { get; set; }
        public string UnitID { get; set; }
        public string BranchID { get; set; }
        public string Barcode { get; set; }
        public string BarcodeType { get; set; }
        public string BarcodeSource { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string MeasurementID { get; set; }
        public string SerialNumber { get; set; }
        public string DimUnit { get; set; }
        public string WeightUnit { get; set; }
        public int IsRegular { get; set; }
        public string ObjectRGBCoordinates { get; set; }
        public string Operator { get; set; }
        public string BatchName { get; set; }
        public string ImageBase64 { get; set; }
        public string CRC { get; set; }
    }


}
