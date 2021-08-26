using System;
using System.IO;
using Xunit;
using static KodtestAntura.Program;

namespace KodtestAntura.Tests
{
    public class TestOccurences
    {
        [Fact]
        public void GetFileNameOccurrence_FaultyUrl_FileNotFoundException()
        {
            var filePath = "asda";

            Assert.Throws<FileNotFoundException>(() => GetFileNameOccurrence(filePath).ToString());
        }

        [Fact]
        public void GetFileNameOccurrence_NoFile_UnauthorizedAccessException()
        {
            var filePath = @"C:\";

            Assert.Throws<UnauthorizedAccessException>(() => GetFileNameOccurrence(filePath).ToString());
        }

        [Fact]
        public void GetFileNameOccurrence_TestOccurences_ArgumentNullException()
        {
            var expected = 3;
            var current = Directory.GetCurrentDirectory() + @"\TestOccurence.txt";

            var actual = GetFileNameOccurrence(current);

            Assert.Equal(expected, actual);
        }
    }
}