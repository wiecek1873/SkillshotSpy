using System.ComponentModel.DataAnnotations;

namespace SkillshotSpy.Entities;

public class Offer
{
    public string Title { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string LocationName { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string WorkingTimeName { get; set; } = null!;

    public string? SeniorityName { get; set; }

    public int? SalaryMin { get; set; }

    public int? SalaryMax { get; set; }

    public DateOnly Date { get; set; }

    public int Views { get; set; }

    [Url]
    public string Url { get; set; } = null!;
}
