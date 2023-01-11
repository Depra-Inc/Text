// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Text.Encoding.Abstract
{
    public interface IEncoder
    {
        byte[] ToBytes(string text);
        
        string ToString(byte[] bytes);
    }
}