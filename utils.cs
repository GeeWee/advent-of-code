

public static class Utils {
public static string ExtractBetween(string text, string start, string end)
{
  int iStart = text.IndexOf(start);
  iStart = (iStart == -1) ? 0 : iStart + start.Length;
  int iEnd = text.LastIndexOf(end);
  if(iEnd == -1)
        {
            iEnd = text.Length;
        }
        int len = iEnd - iStart;

        return text.Substring(iStart, len);
}
}
