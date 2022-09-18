using System;
using System.IO;
using Depra.Text.Encoding.Api;

namespace Depra.Text.Encoding.Impl
{
    public class StreamBasedEncoder : Encoder
    {
        private readonly System.Text.Encoding _encoding;

        public override byte[] ToBytes(string value) => _encoding.GetBytes(value);

        public override string ToString(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            
            using (var stream = new MemoryStream(bytes, 0, bytes.Length))
            {
                using (var streamReader = new StreamReader(stream, _encoding))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public StreamBasedEncoder() => _encoding = System.Text.Encoding.UTF8;

        public StreamBasedEncoder(System.Text.Encoding encoding) => _encoding = encoding;
    }
}