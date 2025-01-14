using Microsoft.AspNetCore.Mvc;
//using JsonParserAPI.Models;
using System.Text.Json;
using BeeVision_Integration.Models;

namespace JsonParserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JsonParserController : ControllerBase
    {
        [HttpPost("ParseJson")]
        public IActionResult ParseJson([FromBody] string jsonData)
        {
            try
            {
                // JSON verisini model sınıfına dönüştür
                var data = JsonSerializer.Deserialize<MeasurementData>(jsonData);

                // Başarılı durum döndür
                return Ok(new { Message = "JSON başarıyla parse edildi.", Data = data });
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajı döndür
                return BadRequest(new { Message = "JSON parse edilirken bir hata oluştu.", Error = ex.Message });
            }
        }
    }
}
