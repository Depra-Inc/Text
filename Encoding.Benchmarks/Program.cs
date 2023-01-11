﻿// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using BenchmarkDotNet.Validators;

namespace Depra.Text.Encoding.Benchmarks
{
    public static class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run(typeof(Program).Assembly, DefaultConfig.Instance
                .AddValidator(JitOptimizationsValidator.FailOnError)
                .AddJob(Job.Default.WithToolchain(InProcessNoEmitToolchain.Instance))
                .AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig()))
                .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest)));
        }
    }
}