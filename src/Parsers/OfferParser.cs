using HtmlAgilityPack;
using SkillshotSpy.Entities;
using SkillshotSpy.Interfaces;

namespace SkillshotSpy.Parsers;

public class OfferParser : IParser<Offer>
{
    public Offer Parse(string html)
    {
        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);

        var companyDto = new Offer()
        {
            Title = ParseTitle(htmlDocument),
            CompanyName = ParseCompanyName(htmlDocument),
            LocationName = ParseLocationName(htmlDocument),
            CategoryName = ParseCategoryName(htmlDocument),
            WorkingTimeName = ParseWorkingTimeName(htmlDocument),
            SeniorityName = ParseSeniorityName(htmlDocument),
            SalaryMin = ParseSalaryMin(htmlDocument),
            SalaryMax = ParseSalaryMax(htmlDocument),
            Date = ParseDate(htmlDocument),
            Views = ParseViews(htmlDocument),
        };

        return companyDto;
    }

    private static string ParseTitle(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/h1").InnerText.Replace("\n", string.Empty);
    }

    private static string ParseCompanyName(HtmlDocument htmlDocument)
    {
        if (htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/span[3]")?.InnerText == "opublikowane przez")
            return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/b[1]").InnerText.Replace("\n", string.Empty);
        else
            return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/b/a").InnerText.Replace("\n", string.Empty);
    }

    private static string ParseLocationName(HtmlDocument htmlDocument)
    {
        if (htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/span[3]")?.InnerText == "opublikowane przez")
            return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/b[2]").InnerText.Replace("\n", string.Empty);
        else
            return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/span[2]").NextSibling.InnerText;
    }

    private static string ParseCategoryName(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[2]/span[2]").InnerText.Replace("\n", string.Empty);
    }

    private static string ParseWorkingTimeName(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[2]/span[1]").InnerText.Replace("\n", string.Empty);
    }

    private static string? ParseSeniorityName(HtmlDocument htmlDocument)
    {
        return string.Empty;
        //return htmlDocument.DocumentNode.SelectSingleNode("")?.InnerText;
    }

    private static int? ParseSalaryMin(HtmlDocument htmlDocument)
    {
        return 0;
        //return int.Parse(htmlDocument.DocumentNode.SelectSingleNode("")?.InnerText);
    }

    private static int? ParseSalaryMax(HtmlDocument htmlDocument)
    {
        return 0;
        //return int.Parse(htmlDocument.DocumentNode.SelectSingleNode("")?.InnerText);
    }

    private static DateOnly ParseDate(HtmlDocument htmlDocument)
    {
        return DateOnly.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[3]/strong").InnerText);
    }

    private static int ParseViews(HtmlDocument htmlDocument)
    {
        return int.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[4]/strong").InnerText);
    }
}
