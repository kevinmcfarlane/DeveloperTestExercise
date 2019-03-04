using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileDetailsReporter;

namespace FileData.Tests
{
    [TestClass]
    public class FileDataTests
    {
        [TestMethod]
        [DataRow(" -v", "c:/test.txt")]
        [DataRow("--v", "c:/test.txt")]
        [DataRow("/v ", "c:/test.txt")]
        [DataRow("--version", "c:/test.txt")]
        public void FileDetails_WithVersionArgument_ReturnsVersion(string fileAttribute, string fileName)
        {
            // Arrange
            string[] args = { fileAttribute, fileName };

            // Act
            string result = Reporter.GetDetails(args);

            // Assert
            Assert.IsTrue(result.StartsWith("Version = "));
        }

        [TestMethod]
        [DataRow("-s", "c:/test.txt")]
        [DataRow("--s", "c:/test.txt")]
        [DataRow("/s ", "c:/test.txt")]
        [DataRow("--size", "c:/test.txt")]
        public void FileDetails_WithSizeArgument_ReturnsSize(string fileAttribute, string fileName)
        {
            // Arrange
            string[] args = { fileAttribute, fileName };

            // Act
            string result = Reporter.GetDetails(args);

            // Assert
            Assert.IsTrue(result.StartsWith("Size = "));
        }

        [TestMethod]
        public void FileDetails_WithWrongNumberOfArguments_ReturnsArgumentCountError()
        {
            // Arrange
            string[] args = { "c:/test.txt" };

            // Act
            string result = Reporter.GetDetails(args);

            // Assert
            Assert.IsTrue(result.StartsWith("Error: Wrong number of arguments"), $"Unexpected result: {result}.");
        }

        [TestMethod]
        public void FileDetails_WithInvalidArgument_ReturnsInvalidArgumentError()
        {
            // Arrange
            string[] args = { "-x", "c:/test.txt" };

            // Act
            string result = Reporter.GetDetails(args);

            // Assert
            Assert.IsTrue(result.StartsWith("Error: Invalid argument"), $"Unexpected result: {result}.");
        }
    }
}