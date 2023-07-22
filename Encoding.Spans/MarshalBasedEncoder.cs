// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.InteropServices;
using Depra.Text.Encoding.Encoders;
using Depra.Text.Encoding.Errors;

namespace Depra.Text.Encoding.Spans
{
    public sealed class MarshalBasedEncoder : IEncoder
    {
        public byte[] ToBytes(string value)
        {
            Guard.AgainstNull(value);
            
            return MemoryMarshal.Cast<char, byte>(value).ToArray();
        }

        public string ToString(byte[] bytes)
        {
            Guard.AgainstNull(bytes);

            return MemoryMarshal.Cast<byte, char>(bytes).ToString();
        }

        public override string ToString() => nameof(MarshalBasedEncoder);
    }
}