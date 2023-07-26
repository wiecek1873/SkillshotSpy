using HtmlAgilityPack;
using SkillshotSpy.Entities;
using SkillshotSpy.Interfaces;

namespace SkillshotSpy.Parsers;

public class CompanyParser : Parser, IParser<Company>
{
    public Company Parse(string html)
    {
        var htmlDocument = LoadHtml(html);

        var company = new Company
        {
            Name = ParseName(htmlDocument),
            Description = ParseDescription(htmlDocument),
            Website = ParseWebsite(htmlDocument)
        };

        return company;
    }

    private static string ParseName(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/h1[1]").InnerText.Replace("\n", string.Empty);
    }

    private static string? ParseDescription(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/div/p/text()")?.InnerText;
    }

    private static string? ParseWebsite(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/p[2]/b/a")?.InnerText;
    }
}
