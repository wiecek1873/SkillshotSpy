﻿namespace SkillshotSpy.Interfaces;

public interface IScraper
{
    Task<string> GetContentAsync(string url);
}
