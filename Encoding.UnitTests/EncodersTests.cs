// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Text.Encoding.Api;
using Depra.Text.Encoding.Enums;
using Depra.Text.Encoding.Impl;
using Depra.Text.Encoding.Spans.Impl;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Text.Encoding.UnitTests
{
    [TestFixture]
    public class EncodersTests
    {
        private const int INPUT_LENGHT = 8;

        private string _randomInputString;

        [OneTimeSetUp]
        public void Setup()
        {
            var randomStringService = new RandomStringGenerator();
            _randomInputString = randomStringService.GetRandomString(INPUT_LENGHT, true);
        }

        [Test]
        public void WhenEncodingStringToBytes_AndStringIsRandom_ThenByteArrayIsNotNullOrEmpty(
            [ValueSource(nameof(GetEncoders))] IEncoder encoder)
        {
            // Arrange.
            var input = _randomInputString;

            // Act.
            var bytes = encoder.ToBytes(input);

            // Assert.
            bytes.Should().NotBeNullOrEmpty();

            Console.WriteLine($"Input text: {input}\n" +
                              $"Result bytes: {BitConverter.ToString(bytes)}");
        }

        [Test]
        public void WhenEncodingStringToBytes_AndStringIsEmpty_ThenByteArrayIsEmpty(
            [ValueSource(nameof(GetEncoders))] IEncoder encoder)
        {
            // Arrange.
            var input = string.Empty;

            // Act.
            var bytes = encoder.ToBytes(input);

            // Assert.
            bytes.Should().BeEmpty();
        }

        [Test]
        public void WhenEncodingStringToBytes_AndStringIsNull_ThenThrowArgumentNullException(
            [ValueSource(nameof(GetEncoders))] IEncoder encoder)
        {
            // Arrange.
            string input = null;

            // Act.
            void Act() => encoder.ToBytes(input);

            // Assert.
            Assert.Throws<ArgumentNullException>(Act);
        }

        [Test]
        public void WhenEncodingBytesToString_AndArrayIsRandom_ThenStringIsNotNullOrEmpty(
            [ValueSource(nameof(GetEncoders))] IEncoder encoder)
        {
            // Arrange.
            var random = new Random();
            var bytes = new byte[INPUT_LENGHT];
            random.NextBytes(bytes);

            // Act.
            var text = encoder.ToString(bytes);

            // Assert.
            text.Should().NotBeNullOrEmpty();

            Console.WriteLine($"Input bytes: {BitConverter.ToString(bytes)}\n" +
                              $"Result text: {text}");
        }

        [Test]
        public void WhenEncodingBytesToString_AndArrayIsEmpty_ThenStringIsEmpty(
            [ValueSource(nameof(GetEncoders))] IEncoder encoder)
        {
            // Arrange.
            var bytes = Array.Empty<byte>();

            // Act.
            var text = encoder.ToString(bytes);

            // Assert.
            text.Should().BeEmpty();

            Console.WriteLine($"Input bytes: {BitConverter.ToString(bytes)}\n" +
                              $"Result text: {text}");
        }

        [Test]
        public void WhenEncodingBytesToString_AndInputIsNull_ThenThrowArgumentNullException(
            [ValueSource(nameof(GetEncoders))] IEncoder encoder)
        {
            // Arrange.
            byte[] bytes = null;

            // Act.
            void Act() => encoder.ToString(bytes);

            // Assert.
            Assert.Throws<ArgumentNullException>(Act);
        }

        public static IEnumerable<IEncoder> GetEncoders()
        {
            yield return new DelimitedEncoder();
            yield return new DelimiterlessEncoder(EBase.Hexa);

            // Not sure if they should be used.
            yield return new Base64BasedEncoder();
            yield return new CharacterEncoder(System.Text.Encoding.UTF8);
            yield return new StreamBasedEncoder(System.Text.Encoding.UTF8);

            // For C# 7.0 and later.
            yield return new SpanBasedEncoder();
            yield return new MarshalBasedEncoder();

            // Add more converters here if needed.
        }
    }
}