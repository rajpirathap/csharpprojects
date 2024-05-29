using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class XSSDetector
{
    // Compiled regex patterns for common XSS vectors
    private static readonly List<Regex> XSS_PATTERNS = new List<Regex>
    {
        new Regex("<script>(.*?)</script>", RegexOptions.IgnoreCase),
        new Regex("src[\r\n]*=[\r\n]*\\'(.*?)\\'", RegexOptions.IgnoreCase),
        new Regex("src[\r\n]*=[\r\n]*\\\"(.*?)\\\"", RegexOptions.IgnoreCase),
        new Regex("</script>", RegexOptions.IgnoreCase),
        new Regex("<script(.*?)>", RegexOptions.IgnoreCase),
        new Regex("eval\\((.*?)\\)", RegexOptions.IgnoreCase),
        new Regex("expression\\((.*?)\\)", RegexOptions.IgnoreCase),
        new Regex("javascript:", RegexOptions.IgnoreCase),
        new Regex("vbscript:", RegexOptions.IgnoreCase),
        new Regex("onload(.*?)=", RegexOptions.IgnoreCase),
        new Regex("alert\\((.*?)\\)", RegexOptions.IgnoreCase)
    };

    public static bool ContainsXSS(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        return XSS_PATTERNS.Any(pattern => pattern.IsMatch(input));
    }

    public static void Main(string[] args)
    {
        string input = "<script>alert('XSS');</script>";

        if (ContainsXSS(input))
        {
            Console.WriteLine("The input contains potential XSS attack vectors.");
        }
        else
        {
            Console.WriteLine("The input is clean.");
        }
    }
}
