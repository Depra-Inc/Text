// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Text.Encoding.Abstract;

namespace Depra.Text.Encoding.Spans
{
    public sealed class SpanBasedEncoder : Encoder
    {
        private const int CHAR_SIZE = sizeof(char);

        public override unsafe byte[] ToBytes(string text)
        {
            EnsureString(text);
            
            fixed (char* p = text)
            {
                return new Span<byte>(p, text.Length * CHAR_SIZE).ToArray();
            }
        }

        public override unsafe string ToString(byte[] bytes)
        {
            EnsureBytes(bytes);
            
            fixed (byte* pointer = bytes)
            {
                return new string(new Span<char>(pointer, bytes.Length / CHAR_SIZE));
            }
        }

        public override string ToString() => nameof(SpanBasedEncoder);
    }
}