﻿using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Nightmare
{
    public partial class GameManager
    {
        public static GameManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GameManager();
                }
                return _Instance;
            }

        }

        private static GameManager? _Instance = null;

        private string name;


        public void GameStart()
        {
            Player = new Player();
            // 닉네임 설정
            SetName();


            // 직업 설정


            Player.Level = new Level();
            Player.Name = name;
            Player.Stat = new Stat();
            Player.Gold = new Gold();
            //Player.Job = JobChoice();



            MoveNextAction(ActionType.Village);
        }

        private void SetName()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"입력하신 이름은 {name} 입니다.\n");
            Console.WriteLine("1. 저장\n2. 취소");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
            string inputNumber = Console.ReadLine();
            int number = int.Parse(inputNumber);
            SaveName(number, name);
        }

        private void SetJob() // 직업설정
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 직업을 선택해주세요.\n");
            Console.WriteLine("1. 일곱번째 난쟁이\n2. 새언니\n3. 시종\n4. 문어 마녀\n5. 인간버전 야수");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");
            string inputNumber = Console.ReadLine();


            // 입력받은 값이 int로 변환이 가능할 때
            if (int.TryParse(inputNumber, out int actionNumber))
            {
                Player.Job = JobChoice(actionNumber);
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.\n다시 직업을 선택해주세요.\n");
                SetJob();
            }
        }

        public Player Player { get; set; }

        private void SaveName(int num, string name)
        {
            switch (num)
            {
                case 1:
                    SetJob();
                    break;
                case 2:
                    SetName();
                    break;
            }
        }

        private Job JobChoice(int num)
        {
            switch (num)
            {
                case 1:
                    return Job.Dwarf;
                case 2:
                    return Job.NewSister;
                case 3:
                    return Job.Saison;
                case 4:
                    return Job.OctopusWitch;
                case 5:
                    return Job.WildAnimal;
            }
            Console.WriteLine("\n잘못된 입력입니다.\n다시 직업을 선택해주세요.\n");
            Console.WriteLine();

            SetJob();
            return Job.None;
        }
    }
}
