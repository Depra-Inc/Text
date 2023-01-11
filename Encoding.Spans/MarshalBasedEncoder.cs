// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.InteropServices;
using Depra.Text.Encoding.Abstract;

namespace Depra.Text.Encoding.Spans
{
    public sealed class MarshalBasedEncoder : Encoder
    {
        public override byte[] ToBytes(string value)
        {
            EnsureString(value);
            
            return MemoryMarshal.Cast<char, byte>(value).ToArray();
        }

        public override string ToString(byte[] bytes)
        {
            EnsureBytes(bytes);

            return MemoryMarshal.Cast<byte, char>(bytes).ToString();
        }

        public override string ToString() => nameof(MarshalBasedEncoder);
    }
}