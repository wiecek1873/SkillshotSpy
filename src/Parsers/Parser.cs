using HtmlAgilityPack;

namespace SkillshotSpy.Parsers;

public class Parser
{
    protected static HtmlDocument LoadHtml(string html)
    {
        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);
        return htmlDocument;
    }
}
