using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Aspose.PDF.Translator.GDrive.Controllers {

  [Route("[controller]")]
  [ApiController]
  public class TranslatePDFController : ControllerBase {

    private string _GetPair() {
      StringValues pairHeaders = Request.Headers["X-Aspose-Marketplace-GDrive-Backend-Pair"];
      string pair = pairHeaders.Count == 0 ? "en-ru" : pairHeaders[0];
      return pair;
    }

    //private (string, string) _GetLanguages(string pair) {
    //  string[] ww = pair.Split('-');
    //  return ww.Length > 1 ? (ww[0], ww[1]) : ("en", "ru");
    //}

    private string _Error500(string err) {
      Console.WriteLine(err);
      Response.StatusCode = StatusCodes.Status500InternalServerError;
      return err;
    }

    [HttpPost]
    public string Post() {
      Console.WriteLine("TranslatePDF/Post");
      try {
        string pair = _GetPair();
        MemoryStream msPdf = new MemoryStream();
        using (Stream pdfBody = Request.Body)
          pdfBody.CopyTo(msPdf);
        //string now = DateTime.UtcNow.ToString("HHmmssfff");
        //msPdf.Position = 0;
        //System.IO.File.WriteAllBytes($"{now}.pdf", msPdf.ToArray());
        msPdf.Position = 0;
        (string fromText, string err1) = Text.ExtractTextFromPdfStream(msPdf);
        if (!string.IsNullOrWhiteSpace(err1))
          return _Error500(err1);
        //(string fromLanguage, string toLanguage) = _GetLanguages(pair);
        //System.IO.File.WriteAllText($"{now}.{fromLanguage}", fromText);
        (string toText, string err2) = Translate.TranslateText(fromText, pair);
        if (!string.IsNullOrWhiteSpace(err2))
          return _Error500(err2);
        //System.IO.File.WriteAllText($"{now}.{toLanguage}", toText);
        return toText;
      }
      catch (Exception e) {
        return _Error500(e.ToString());
      }
    }
  }
}
