// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Depra.Text.Encoding.Encoders;
using Depra.Text.Encoding.Spans;

namespace Depra.Text.Encoding.Benchmarks
{
    public class EncodersBenchmark
    {
        // Base64 encoded class name (for compatibility with Base64BasedByteConverter)
        private const string INPUT = "Qnl0ZUNvbnZlcnRlcnNCZW5jaG1hcms=";

        [ParamsSource(nameof(GetEncoders))] public IEncoder Encoder { get; set; }

        [Benchmark]
        public string EncodeAndDecode()
        {
            var bytes = Encoder.ToBytes(INPUT);
            return Encoder.ToString(bytes);
        }

        public static IEnumerable<IEncoder> GetEncoders()
        {
            yield return new DelimitedEncoder();
            yield return new DelimiterlessEncoder();

            yield return new Base64BasedEncoder();
            yield return new CharacterEncoder(System.Text.Encoding.UTF8);
            yield return new StreamBasedEncoder(System.Text.Encoding.UTF8);

            yield return new SpanBasedEncoder();
            yield return new MarshalBasedEncoder();
            // Add more converters here if needed.
        }
    }
}