// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Linq;

namespace Depra.Text.Encoding.UnitTests
{
    public class RandomStringGenerator : IRandomStringService
    {
        public string GetRandomString(int count, bool includeLowerCase) =>
            new(GetRandomCharacters(count, includeLowerCase).ToArray());

        public static IEnumerable<char> GetRandomCharacters(int count, bool includeLowerCase)
        {
            var characters = GetAvailableRandomCharacters(includeLowerCase);
            var random = new Random();
            var result = Enumerable.Range(0, count)
                .Select(_ => characters[random.Next(characters.Count)]);

            return result;
        }

        private static List<char> GetAvailableRandomCharacters(bool includeLowerCase)
        {
            var integers = Enumerable.Empty<int>();
            integers = integers.Concat(Enumerable.Range('A', 26));
            integers = integers.Concat(Enumerable.Range('0', 10));

            if (includeLowerCase)
            {
                integers = integers.Concat(Enumerable.Range('a', 26));
            }

            return integers.Select(i => (char)i).ToList();
        }
    }
}