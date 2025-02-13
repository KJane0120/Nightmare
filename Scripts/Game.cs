﻿using Nightmare;
using System;

namespace Nightmare
{
    internal class Game
    {
        static void Main(string[] args)
        {
            // 게임 강제 종료시에도 게임 저장
            AppDomain.CurrentDomain.ProcessExit += GameManager.Instance.GameSave;

            SoundManager.PlayBGM("Intro");

            Console.SetWindowSize(60, 20);

            var lines = new string[] { "1. 악몽 속으로 들어가기", "2. 게임 종료" };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(lines[0]);
            Console.WriteLine();
            Console.WriteLine(lines[1]);
            Console.WriteLine();
            Console.WriteLine();

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input == 1)
                {
                    GameManager.Instance.GameStart();
                }
                else if (input == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("진짜 종료할 거야?");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}
