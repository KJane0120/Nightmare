using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nightmare.GameManager;

namespace Nightmare.Scripts.WH_Class
{
    internal class NormalStage : ActionBase
    {

        public List<Monster> monsters;
        public int DeathCount = 0;
        public NormalStage(int number) : base(number) { }

        public override ActionType Type => ActionType.NormalStage;

        protected override Dictionary<int, ActionBase> CreateNextActionDic()
        {
            return new Dictionary<int, ActionBase>()
                {
                    //
                };
        }



        protected override void DisPlay()
        {
            Battle();
        }



        public void Battle()
        {


            //
            int number = 1;
            //랜덤 함수
            Random Ran = new Random();
            //함수를 사용하기 위한 개체참조
            Monster mon = new Monster();

            //몬스터를 저장할 변수
            monsters = new List<Monster>();


            //몇마리 소환할래
            int SummonCount = Ran.Next(1, 5);


            //리스트에 넣기
            for (int i = 0; i < SummonCount; i++)
            {
                monsters.Add(mon.Monstersummon());
            }

            while (DeathCount < monsters.Count)
            {

                //foreach로 넣기
                foreach (Monster mons in monsters)
                {
                    Console.WriteLine($"{number}. {mons.MonsterDIe(DeathCount)}");
                }

                //플레이어 상태 띄우기
                //
                Console.WriteLine("행동을 골라주세요");
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");
                int Select = int.Parse(Console.ReadLine());
                if (Select == 1)
                {

                    //어느 적을 공격하는지
                    while (true)
                    {
                        Console.WriteLine("어느 적을 공격할거니");
                        int AttackSelect = int.Parse(Console.ReadLine());

                        if (AttackSelect > monsters.Count && AttackSelect < 0)
                        {
                            Console.WriteLine("잘못된 적 선택");
                        }
                        if (!monsters[AttackSelect - 1].IsLive)
                        {
                            Console.WriteLine("이미 죽었습니다.");
                        }
                        if (monsters[AttackSelect].MonsterDefense > 10) //플레이어의 공격력
                        {
                            monsters[AttackSelect - 1].MonsterHealth -= 1;
                            monsters[AttackSelect - 1].AttackedFromPlayer();
                            break;
                        }
                        else
                        {
                            monsters[AttackSelect - 1].MonsterHealth -= 10 - monsters[AttackSelect - 1].MonsterDefense;
                            monsters[AttackSelect - 1].AttackedFromPlayer();
                            break;
                        }
                    }
                }
                else if (Select == 2)
                { }
                else
                {
                    Console.WriteLine("잘못된 선택입니다.");
                }

                foreach (Monster mons in monsters)
                {
                    if (mons.IsLive)
                    {
                        mons.MonsterAttackToPlayer();
                        //만약 플레이어가 죽었다면 초기로 돌아가기
                    }
                }

            }

            //플레이어의 정보를 받아서 일정 확률로 장비 얻기
            //돈 추가




        }

    }
}
