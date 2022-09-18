using System;
using System.Runtime.InteropServices;
using Depra.Text.Encoding.Api;

namespace Depra.Text.Encoding.Spans.Impl
{
    public readonly struct MarshalBasedEncoder : IEncoder
    {
        public byte[] ToBytes(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return MemoryMarshal.Cast<char, byte>(value).ToArray();
        }

        public string ToString(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            return MemoryMarshal.Cast<byte, char>(bytes).ToString();
        }

        public override string ToString() => nameof(MarshalBasedEncoder);
    }
}