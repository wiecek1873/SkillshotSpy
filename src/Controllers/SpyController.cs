using Microsoft.AspNetCore.Mvc;
using SkillshotSpy.Entities;
using SkillshotSpy.Interfaces;

namespace SkillshotSpy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpyController : ControllerBase
{
    private readonly IScraper _scraper;
    private readonly IParser<Company> _companyParser;
    private readonly IParser<Offer> _offerParser;

    public SpyController(IScraper scraperService, IParser<Offer> offerParser, IParser<Company> companyParser)
    {
        _scraper = scraperService;
        _companyParser = companyParser;
        _offerParser = offerParser;
    }

    [HttpGet]
    [Route("company/{url}")]
    public async Task<IActionResult> GetParsedCompany([FromRoute] string url)
    {
        var unescapedUrl = Uri.UnescapeDataString(url);
        var content = await _scraper.GetContentAsync(unescapedUrl);

        var company = _companyParser.Parse(content);

        return Ok(company);
    }

    [HttpGet]
    [Route("offer/{url}")]
    public async Task<IActionResult> GetParsedOffer([FromRoute] string url)
    {
        var unescapedUrl = Uri.UnescapeDataString(url);
        var content = await _scraper.GetContentAsync(unescapedUrl);

        var offer = _offerParser.Parse(content);
        offer.Url = unescapedUrl;

        return Ok(offer);
    }
}
