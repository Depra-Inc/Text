// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Text.Encoding.Errors;

namespace Depra.Text.Encoding.Encoders
{
    public sealed class DelimitedEncoder : IEncoder
    {
        public byte[] ToBytes(string value)
        {
            Guard.AgainstNull(value);
            
            var array = new byte[value.Length];
            for (var i = 0; i < array.Length; i++)
            {
                var symbol = value[i];
                array[i] = Convert.ToByte(symbol);
            }

            return array;
        }

        public string ToString(byte[] bytes) => BitConverter.ToString(bytes);

        public override string ToString() => nameof(DelimitedEncoder);
    }
}