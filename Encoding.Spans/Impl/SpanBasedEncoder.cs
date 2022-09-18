// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Text.Encoding.Api;

namespace Depra.Text.Encoding.Spans.Impl
{
    public readonly struct SpanBasedEncoder : IEncoder
    {
        private const int CHAR_SIZE = sizeof(char);

        public unsafe byte[] ToBytes(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            
            fixed (char* p = text)
            {
                return new Span<byte>(p, text.Length * CHAR_SIZE).ToArray();
            }
        }

        public unsafe string ToString(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            
            fixed (byte* pointer = bytes)
            {
                return new string(new Span<char>(pointer, bytes.Length / CHAR_SIZE));
            }
        }

        public override string ToString() => nameof(SpanBasedEncoder);
    }
}