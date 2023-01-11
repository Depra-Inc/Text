// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Runtime.CompilerServices;

namespace Depra.Text.Encoding.Abstract
{
    public abstract class Encoder : IEncoder
    {
        public abstract byte[] ToBytes(string text);

        public abstract string ToString(byte[] bytes);
        
        public override string ToString() => GetType().Name;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static void EnsureString(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static void EnsureBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
        }
    }
}