namespace Depra.Text.Encoding.Api
{
    public abstract class Encoder : IEncoder
    {
        public abstract byte[] ToBytes(string text);

        public abstract string ToString(byte[] bytes);
        
        public override string ToString() => GetType().Name;
    }
}