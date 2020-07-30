using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspose.PDF.Translator.GDrive.Controllers {

  public class About {
    [JsonPropertyName("name")]
    public string Name => Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    [JsonPropertyName("version")]
    public string Ver => "v0.1.0";
    [JsonPropertyName("framework")]
    public string Fw => RuntimeInformation.FrameworkDescription;
    [JsonPropertyName("os")]
    public string Os => RuntimeInformation.OSDescription;
    [JsonPropertyName("timestamp")]
    public string Ts => DateTime.Now.ToUniversalTime().ToString("R");
  }

  [Route("[controller]")]
  [ApiController]
  public class AboutController : ControllerBase {

    [HttpGet]
    public JsonResult Get() {
      Console.WriteLine("About");
      JsonSerializerOptions jso = new JsonSerializerOptions { WriteIndented = true };
      JsonResult jr = new JsonResult(new About(), jso) { StatusCode = StatusCodes.Status200OK };
      return jr;
    }
  }
}
