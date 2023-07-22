// Copyright © 2022-2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Text.Encoding.Encoders;
using Depra.Text.Encoding.Errors;

namespace Depra.Text.Encoding.Spans
{
    public sealed class SpanBasedEncoder : IEncoder
    {
        private const int CHAR_SIZE = sizeof(char);

        public unsafe byte[] ToBytes(string text)
        {
            Guard.AgainstNull(text);
            
            fixed (char* p = text)
            {
                return new Span<byte>(p, text.Length * CHAR_SIZE).ToArray();
            }
        }

        public unsafe string ToString(byte[] bytes)
        {
            Guard.AgainstNull(bytes);
            
            fixed (byte* pointer = bytes)
            {
                return new string(new Span<char>(pointer, bytes.Length / CHAR_SIZE));
            }
        }

        public override string ToString() => nameof(SpanBasedEncoder);
    }
}