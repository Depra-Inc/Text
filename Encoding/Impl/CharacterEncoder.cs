// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Text.Encoding.Api;

namespace Depra.Text.Encoding.Impl
{
    public class CharacterEncoder : Encoder
    {
        private readonly System.Text.Encoding _encoding;

        public override byte[] ToBytes(string value) => _encoding.GetBytes(value);

        public override string ToString(byte[] bytes) => _encoding.GetString(bytes);

        public CharacterEncoder() => _encoding = System.Text.Encoding.UTF8;
        
        public CharacterEncoder(System.Text.Encoding encoding) => _encoding = encoding;
    }
}