// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;
using Depra.Text.Encoding.Abstract;

namespace Depra.Text.Encoding.Impl
{
    public sealed class CharacterEncoder : Encoder
    {
        private readonly System.Text.Encoding _encoding;
        
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public CharacterEncoder() => _encoding = System.Text.Encoding.UTF8;
        
        public CharacterEncoder(System.Text.Encoding encoding) => _encoding = encoding;
        
        public override byte[] ToBytes(string value) => _encoding.GetBytes(value);

        public override string ToString(byte[] bytes) => _encoding.GetString(bytes);
    }
}