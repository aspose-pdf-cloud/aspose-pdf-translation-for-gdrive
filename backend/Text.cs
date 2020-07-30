using System;
using System.IO;
using System.Linq;
using Aspose.Pdf.Cloud.Sdk.Api;
using Aspose.Pdf.Cloud.Sdk.Client;
using Aspose.Pdf.Cloud.Sdk.Model;
using Microsoft.AspNetCore.Http;

namespace Aspose.PDF.Translator.GDrive {

  internal static class Text {

    internal static (string txt, string err) ExtractTextFromPdfStream(Stream pdfStream) {
      Console.WriteLine("ExtractTextFromPdfStream");
      Configuration cfg = new Configuration(Common.AsposeKey, Common.AsposeSID);
      PdfApi api = new PdfApi(cfg);
      string path = Path.GetRandomFileName();
      try {
        FilesUploadResult filesUploadResult = api.UploadFile(path, pdfStream);
        if (filesUploadResult.Errors != null && filesUploadResult.Errors.Count > 0)
          return ("", string.Join(Environment.NewLine, filesUploadResult.Errors.Select(error => error.ToString())));
        TextRectsResponse textRectsResponse = api.GetText(path, 0, 0, 0, 0);
        if (textRectsResponse.Code != StatusCodes.Status200OK)
          return ("", textRectsResponse.ToString());
        return (string.Concat(textRectsResponse.TextOccurrences.List.Select(textRect => textRect.Text)), "");
      }
      finally {
        ApiResponse<object> apiResponse = api.DeleteFileWithHttpInfo(path);
      }
    }
  }
}
