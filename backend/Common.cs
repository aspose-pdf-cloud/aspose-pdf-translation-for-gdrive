using System;

namespace Aspose.PDF.Translator.GDrive {

  internal static class Common {

    internal static string AsposeSID;
    internal static string AsposeKey;
    internal static string GroupDocsSID;
    internal static string GroupDocsKey;

    internal static void Init() {
      AsposeSID = _GetEnvVar("ASPOSE_SID");
      AsposeKey = _GetEnvVar("ASPOSE_KEY");
      GroupDocsSID = _GetEnvVar("GROUPDOCS_SID");
      GroupDocsKey = _GetEnvVar("GROUPDOCS_KEY");
    }

    private static string _GetEnvVar(string name) {
      string r = Environment.GetEnvironmentVariable(name);
      if (string.IsNullOrWhiteSpace(r))
        throw new Exception($"no {name}");
      return r;
    }
  }
}
