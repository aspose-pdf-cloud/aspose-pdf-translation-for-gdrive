using System;
using GroupDocs.Translation.Cloud.SDK.NET;
using GroupDocs.Translation.Cloud.SDK.NET.Model;
using GroupDocs.Translation.Cloud.SDK.NET.Model.Requests;
using Newtonsoft.Json;

namespace Aspose.PDF.Translator.GDrive {

  internal static class Translate {

    internal static (string txt, string err) TranslateText(string text, string pair) {
      Console.WriteLine("TranslateText");
      if (string.IsNullOrWhiteSpace(pair))
        return ("", "No language pair provided");
      Configuration cfg = new Configuration {
        AppKey = Common.GroupDocsKey,
        AppSid = Common.GroupDocsSID
      };
      TranslationApi api = new TranslationApi(cfg);
      TextInfo textInfo = new TextInfo {
        Pair = pair,
        Text = text
      };
      string userRequest = $"'[{JsonConvert.SerializeObject(textInfo)}]'";
      TranslateTextRequest request = new TranslateTextRequest(userRequest);
      TextResponse textResponse = api.RunTranslationTextTask(request);
      if (textResponse.Status != "ok")
        return ("", textResponse.ToString());
      return (textResponse.Translation, "");
    }
  }
}
