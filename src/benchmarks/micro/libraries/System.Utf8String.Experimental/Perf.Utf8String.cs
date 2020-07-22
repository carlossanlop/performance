// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace System.Text.Experimental
{
    [BenchmarkCategory(Categories.Libraries, Categories.Runtime)]
    public class Perf_Intrinsics
    {
        [Benchmark]
        // The Utf8String constructor called with that argument reaches the
        // intrinsics improvements in System.Text.Unicode.Utf8Utility.TranscodeToUtf8
        public Utf8String Utf8Utility_TranscodeToUtf8()
        {
            return new Utf8String("\u07ff123");
        }
        
        [Benchmark]
        // The GetByteCount method called with that argument reaches the
        // intrinsics improvements in System.Text.Unicode.Utf16Utility.GetPointerToFirstInvalidChar
        public int Utf16Utility_GetPointerToFirstInvalidChar()
        {
            var encoding = new UTF8Encoding();
            return encoding.GetByteCount("\uD800");
        }

        [Benchmark]
        // The ToCharArray method called with that argument reaches the
        // intrinsics improvements in System.Text.Unicode.Utf8Utility.GetPointerToFirstInvalidByte
        public char[] Utf8Utility_GetPointerToFirstInvalidByte()
        {
            byte[] bytes = new byte[] { 0xC3, 0xA9, 0x21, 0x22, 0x23, 0x24, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0xC3, 0xA9, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F };
            Utf8String u = new Utf8String(bytes);
            Utf8Span span = new Utf8Span(u);
            return span.ToCharArray();
        }
    }
}
