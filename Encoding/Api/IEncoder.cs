namespace Depra.Text.Encoding.Api
{
    public interface IEncoder
    {
        byte[] ToBytes(string text);
        
        string ToString(byte[] bytes);
    }
}