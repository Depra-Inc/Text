// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Text.Encoding.Abstract;

namespace Depra.Text.Encoding.Impl
{
    public sealed class Base64BasedEncoder : Encoder
    {
        public override byte[] ToBytes(string text) => Convert.FromBase64String(text);

        public override string ToString(byte[] bytes) => Convert.ToBase64String(bytes);

        public override string ToString() => nameof(Base64BasedEncoder);
    }
}