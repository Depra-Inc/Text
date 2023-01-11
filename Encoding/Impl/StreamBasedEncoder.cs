// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;
using System.IO;
using Depra.Text.Encoding.Abstract;

namespace Depra.Text.Encoding.Impl
{
    public sealed class StreamBasedEncoder : Encoder
    {
        private readonly System.Text.Encoding _encoding;

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public StreamBasedEncoder() => _encoding = System.Text.Encoding.UTF8;

        public StreamBasedEncoder(System.Text.Encoding encoding) => _encoding = encoding;
        
        public override byte[] ToBytes(string value) => _encoding.GetBytes(value);
        
        public override string ToString(byte[] bytes)
        {
            EnsureBytes(bytes);

            using var stream = new MemoryStream(bytes, 0, bytes.Length);
            using var streamReader = new StreamReader(stream, _encoding);
            var resultString = streamReader.ReadToEnd();
            
            return resultString;
        }
    }
}