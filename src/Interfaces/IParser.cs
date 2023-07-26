namespace SkillshotSpy.Interfaces;

public interface IParser<T>
{
    T Parse(string html);
}
