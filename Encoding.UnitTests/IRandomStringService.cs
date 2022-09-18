// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Text.Encoding.UnitTests
{
    public interface IRandomStringService
    {
        string GetRandomString(int count, bool includeLowerCase);
    }
}