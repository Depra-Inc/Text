// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Text.Encoding.Abstract;

namespace Depra.Text.Encoding.Impl
{
    public sealed class DelimitedEncoder : Encoder
    {
        public override byte[] ToBytes(string value)
        {
            EnsureString(value);
            
            var array = new byte[value.Length];
            for (var i = 0; i < array.Length; i++)
            {
                var symbol = value[i];
                array[i] = Convert.ToByte(symbol);
            }

            return array;
        }

        public override string ToString(byte[] bytes) => BitConverter.ToString(bytes);

        public override string ToString() => nameof(DelimitedEncoder);
    }
}