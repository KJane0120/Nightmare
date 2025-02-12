using static System.Net.Mime.MediaTypeNames;

namespace Nightmare
{
    public enum Align
    {
        Left,
        Center,
        Right
    }

    public enum VerticalAlign
    {
        Top,
        Middle,
        Bottom
    }

    public class ASCIIManager
    {
        ///// <summary>
        ///// 아스키 아트를 정렬하고 표시하는 함수
        ///// </summary>
        ///// <param name="fileName">아스키 아트 파일이름</param>
        ///// <param name="hori">가로 정렬</param>
        ///// <param name="verti">수직 정렬</param>
        //static public void DisplayAlignASCIIArt(string fileName, Align hori, VerticalAlign verti)
        //{
        //    string path = GetFilePath(fileName);
        //    string[] lines = File.ReadAllLines(path);

        //    AlignText(lines, hori, verti);
        //}

        ///// <summary>
        ///// 텍스트 정렬 함수
        ///// </summary>
        ///// <param name="lines">정렬할 텍스트</param>
        ///// <param name="hori">가로 정렬</param>
        ///// <param name="verti">수직 정렬</param>
        //static public void AlignText(string[] lines, Align hori, VerticalAlign verti)
        //{
        //    int consoleWidth = Console.WindowWidth;
        //    int consoleHeight = Console.WindowHeight;
        //    int textHeight = lines.Length;

        //    // ✅ 콘솔을 초과하지 않도록 안전한 Y 위치 계산
        //    int startY = verti switch
        //    {
        //        VerticalAlign.Middle => Math.Max((consoleHeight - textHeight) / 2, 0),
        //        VerticalAlign.Bottom => Math.Max(consoleHeight - textHeight - 1, 0),
        //        _ => 0
        //    };

            

        //    // ✅ 텍스트가 콘솔을 초과하지 않도록 보정
        //    if (startY + textHeight >= consoleHeight)
        //    {
        //        startY = Math.Max(consoleHeight - textHeight, 0);  // 🔥 콘솔을 넘지 않도록 보정
        //    }

        //    Console.SetCursorPosition(0, startY);

        //    foreach (string line in lines)
        //    {
        //        int padding = hori switch
        //        {
        //            Align.Center => (consoleWidth - line.Length) / 2,
        //            Align.Right => consoleWidth - line.Length,
        //            _ => 0
        //        };

        //        Console.WriteLine(new string(' ', padding) + line);
        //    }
        //}

        static public void DisplayAlignASCIIArt(string[] art, Align horizontalAlign, VerticalAlign verticalAlign)
        {
            AlignText(art, horizontalAlign, verticalAlign, 0);
        }

        static public void AlignText(string[] text, Align horizontalAlign, VerticalAlign verticalAlign, int reservedHeight)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;
            int textHeight = text.Length;

            // ✅ 콘솔 창을 벗어나지 않도록 Y 위치 보정
            int startY = (verticalAlign == VerticalAlign.Middle) ? (consoleHeight - textHeight) / 2 :
                         (verticalAlign == VerticalAlign.Bottom) ? Math.Max(consoleHeight - textHeight - 1,0) : 0;

            //Console.SetCursorPosition(0, startY);

            foreach (string line in text)
            {
                int padding = (horizontalAlign == Align.Center) ? (consoleWidth - line.Length) / 2 :
                              (horizontalAlign == Align.Right) ? (consoleWidth - line.Length) : 0;

                Console.WriteLine(new string(' ', padding) + line);
            }
        }


        public static string[] Getlines(string fileName)
        {
            string path = GetFilePath(fileName);
            return File.ReadAllLines(path);
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
