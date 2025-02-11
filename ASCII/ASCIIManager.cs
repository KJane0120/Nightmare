namespace Nightmare
{
    public class ASCIIManager
    {
        public static void DisplayASCIIArt(string fileName)
        {
            string path = GetFilePath("Book");
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                int padding = (Console.WindowWidth - line.Length) / 2;
                if (padding < 0) padding = 0;

                Console.WriteLine(new string(' ', padding) + line);
            }
        }

        private static string GetFilePath(string fileName)
        {
            var paths = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            var newPath = "";

            for (int i = 0; i < paths.Length - 4; i++)
            {
                newPath += paths[i] + "\\";
            }

            newPath += $"ASCII\\{fileName}.txt";

            return newPath;
        }
    }
}
