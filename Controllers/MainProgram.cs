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
                // Convert JSON data to model class
                var data = JsonSerializer.Deserialize<MeasurementData>(jsonData);

                // Return successfull
                return Ok(new { Message = "JSON başarıyla parse edildi.", Data = data });
            }
            catch (Exception ex)
            {
                // Return error message on error
                return BadRequest(new { Message = "JSON parse edilirken bir hata oluştu.", Error = ex.Message });
            }
        }
    }
}
