using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace System.Text.Tests
{
    [BenchmarkCategory(Categories.Libraries)]
    public class Perf_Utf8Span
    {
        private byte[] _bytes;

        [GlobalSetup]
        public void Setup()
        {
            _bytes = Encoding.UTF8.GetBytes("\u00E921222324303132333435363738393A3B3C3D3E3F3031323334353637\u00E938393A3B3C3D3E3F");
        }

        private Utf8Span utf8Span => Utf8Span.UnsafeCreateWithoutValidation(_bytes);

        [Benchmark]
        public char[] ToCharArray() => utf8Span.ToCharArray();
    }
}
