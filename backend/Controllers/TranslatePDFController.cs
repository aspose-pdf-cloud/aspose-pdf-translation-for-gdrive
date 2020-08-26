using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Aspose.PDF.Translator.GDrive.Controllers {

  [Route("[controller]")]
  [ApiController]
  public class TranslatePDFController : ControllerBase {

    private string _Error500(string err) {
      Console.WriteLine(err);
      Response.StatusCode = StatusCodes.Status500InternalServerError;
      return err;
    }

    private string _GetPair() {
      StringValues pairHeaders = Request.Headers["X-Aspose-PDF-Translator-GDrive-Pair"];
      return pairHeaders.Count == 0 || string.IsNullOrWhiteSpace(pairHeaders[0])
        ? "en-ru"
        : pairHeaders[0];
    }

    [HttpPost]
    public string Post() {
      Console.WriteLine("TranslatePDF/POST");
      try {
        MemoryStream msPdf = new MemoryStream();
        using (Stream pdfBody = Request.Body)
          pdfBody.CopyTo(msPdf);
        msPdf.Position = 0;
        (string fromText, string err1) = Text.ExtractTextFromPdfStream(msPdf);
        if (!string.IsNullOrWhiteSpace(err1))
          return _Error500(err1);
        (string toText, string err2) = Translate.TranslateText(fromText, _GetPair());
        if (!string.IsNullOrWhiteSpace(err2))
          return _Error500(err2);
        return toText;
      }
      catch (Exception e) {
        return _Error500(e.ToString());
      }
    }
  }
}
