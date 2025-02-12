using System;
using System.Diagnostics;

namespace Nightmare
{
    internal class Game
    {
        static void Main(string[] args)
        {
            

            var titlelines = ASCIIManager.Getlines("Title");
            var booklines = ASCIIManager.Getlines("Book");

            ASCIIManager.DisplayAlignASCIIArt(titlelines, Align.Center, VerticalAlign.Top);
            ASCIIManager.DisplayAlignASCIIArt(booklines, Align.Center, VerticalAlign.Middle);

            var lines = new string[] { "1. 악몽속으로 들어가기", "2. 게임종료" };
            ASCIIManager.AlignText(lines, Align.Left, VerticalAlign.Bottom, titlelines.Length + booklines.Length);

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input == 1)
                {
                    GameManager.Instance.GameStart();
                }
                else if (input == 2)
                {
                    Console.WriteLine("진짜 종료할거야?");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}
