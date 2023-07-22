// Copyright © 2022-2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;

namespace Depra.Text.Encoding.Encoders
{
    public sealed class Base64BasedEncoder : IEncoder
    {
        public byte[] ToBytes(string text) => Convert.FromBase64String(text);

        public string ToString(byte[] bytes) => Convert.ToBase64String(bytes);

        public override string ToString() => nameof(Base64BasedEncoder);
    }
}