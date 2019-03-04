using ThirdPartyTools;

namespace FileDetailsReporter
{
    public static class Reporter
    {
        /// <summary>
        /// Gets the version or size of the file specified in the command line arguments.
        /// </summary>
        /// <remarks>
        /// If the first argument is anyone of –v, --v, /v, --version then return the version of the file.
        /// If the first argument is anyone of –s, --s, /s, --size then return the size of the file.
        /// </remarks>
        /// <param name="args">The command line arguments.</param>
        /// <returns>
        /// File version or size or a message informing the user of invalid arguments.
        /// </returns>
        public static string GetDetails(string[] args)
        {
            string result = string.Empty;

            var fileDetails = new FileDetails();

            if (args.Length != 2)
            {
                result = "Error: Wrong number of arguments, expected a version or size followed by filename.";
            }
            else
            {
                // Remove any spurious white-space
                string fileAttribute = args[0].Trim();
                string filePath = args[1].Trim();

                switch (fileAttribute)
                {
                    case "-v":
                    case "--v":
                    case "/v":
                    case "--version":
                        result = $"Version = {fileDetails.Version(filePath)}.";
                        break;

                    case "-s":
                    case "--s":
                    case "/s":
                    case "--size":
                        result = $"Size = {fileDetails.Size(filePath)}.";
                        break;

                    default:
                        result = $"Error: Invalid argument {fileAttribute}.";
                        break;
                }
            }

            return result;
        }
    }
}