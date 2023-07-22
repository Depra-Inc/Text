// Copyright © 2022-2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Diagnostics.CodeAnalysis;

namespace Depra.Text.Encoding.Encoders
{
    public sealed class CharacterEncoder : IEncoder
    {
        private readonly System.Text.Encoding _encoding;

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public CharacterEncoder() : this(System.Text.Encoding.UTF8) { }

        public CharacterEncoder(System.Text.Encoding encoding) =>
            _encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));

        public byte[] ToBytes(string value) => _encoding.GetBytes(value);

        public string ToString(byte[] bytes) => _encoding.GetString(bytes);
    }
}