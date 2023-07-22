// Copyright © 2022-2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Depra.Text.Encoding.Errors;

namespace Depra.Text.Encoding.Encoders
{
    public sealed class StreamBasedEncoder : IEncoder
    {
        private readonly System.Text.Encoding _encoding;

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public StreamBasedEncoder() => _encoding = System.Text.Encoding.UTF8;

        public StreamBasedEncoder(System.Text.Encoding encoding) =>
            _encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));

        public byte[] ToBytes(string value) => _encoding.GetBytes(value);

        public string ToString(byte[] bytes)
        {
            Guard.AgainstNull(bytes);

            using var stream = new MemoryStream(bytes, 0, bytes.Length);
            using var streamReader = new StreamReader(stream, _encoding);
            var resultString = streamReader.ReadToEnd();

            return resultString;
        }
    }
}