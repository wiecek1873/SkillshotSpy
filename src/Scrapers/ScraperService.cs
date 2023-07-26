using SkillshotSpy.Interfaces;

namespace SkillshotSpy.Scrapers;

public class ScraperService : IScraper
{
    private readonly HttpClient _httpClient;

    public ScraperService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<string> GetContentAsync(string url)
    {
        using var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
