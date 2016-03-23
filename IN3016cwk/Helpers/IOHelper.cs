using System.IO;

namespace IN3016cwk.Helpers
{
    public class IoHelper
    {
        private const string InputFilename = "input.txt";

        public static string GetInput()
        {
            return File.ReadAllText(InputFilename);
        }

        public static void OuputText(string text, string filename)
        {
            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(text);
                }
            }
        }
    }
}
