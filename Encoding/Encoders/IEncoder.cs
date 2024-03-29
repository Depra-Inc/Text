﻿// Copyright © 2022-2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Text.Encoding.Encoders
{
    public interface IEncoder
    {
        byte[] ToBytes(string text);
        
        string ToString(byte[] bytes);
    }
}