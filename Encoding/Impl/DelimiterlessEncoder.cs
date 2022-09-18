// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text;
using Depra.Text.Encoding.Enums;
using Encoder = Depra.Text.Encoding.Api.Encoder;

namespace Depra.Text.Encoding.Impl
{
    public class DelimiterlessEncoder : Text.Encoding.Api.Encoder
    {
        private readonly int _toBase;
        private readonly int _padLength;
        private readonly StringBuilder _stringBuilder;

        public override byte[] ToBytes(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            
            var charArray = value.ToCharArray();
            var bytes = new byte[charArray.Length];
            for (var i = 0; i < charArray.Length; i++)
            {
                var current = Convert.ToByte(charArray[i]);
                bytes[i] = current;
            }

            return bytes;
        }

        public override string ToString(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (var i = 0; i < bytes.Length; i++)
            {
                _stringBuilder.Append(Convert
                    .ToString(bytes[i], _toBase)
                    .PadLeft(_padLength, '0'));
            }

            var result = _stringBuilder.ToString();
            _stringBuilder.Clear();

            return result;
        }

        public DelimiterlessEncoder(EBase toBase = EBase.Hexa)
        {
            _stringBuilder = new StringBuilder();
            _toBase = (int)toBase;

            _padLength =
                toBase == EBase.Binary ? 8 : // 8 for binary
                toBase == EBase.Hexa ? 2 : // 2 for hexadecimal
                3; // 3 for other
        }
    }
}