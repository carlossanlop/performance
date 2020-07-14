using BenchmarkDotNet.Attributes;
using MicroBenchmarks;
using System.Buffers;

namespace System.Text.Unicode.Tests
{
    [BenchmarkCategory(Categories.Libraries)]
    public class Perf_Utf8
    {
        [Benchmark]
        public OperationStatus FromUtf16()
        {
            Span<byte> destination = stackalloc byte[6];
            return Utf8.FromUtf16("\u00E9\u00E9XX", destination, out _, out _, false, false);
        }
    }
}