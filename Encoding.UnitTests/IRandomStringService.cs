namespace Depra.Text.Encoding.UnitTests
{
    public interface IRandomStringService
    {
        string GetRandomString(int count, bool includeLowerCase);
    }
}