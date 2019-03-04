using System;
using FileDetailsReporter;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string result = Reporter.GetDetails(args);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
