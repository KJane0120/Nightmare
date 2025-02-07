using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nightmare.GameManager;

namespace Nightmare //보안성 측면 / 구분의 용도/ 같은 네임스페이스안의 클래스 사용가능 //네임스페이스를 구분지어서 한정 변수를 만들기 가능
{
    public partial class GameManager
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
                //함수를  따로 뺄 수 있는 것들
              
                //랜덤 함수
                Random Ran = new Random();
                //함수를 사용하기 위한 개체참조
                Monster mon = new Monster();

                //몬스터를 저장할 변수
                monsters = new List<Monster>();


                //몇마리 소환할래
                int SummonCount = Ran.Next(1, 5);

                int ii = 1;
                //리스트에 넣기
                for (int i = 0; i < SummonCount; i++)
                {
                    monsters.Add(mon.Monstersummon());
                }

                while (DeathCount < monsters.Count)
                {
                    
                    //foreach로 넣기
                    foreach (Monster monster in monsters)
                    {
                       
                        Console.WriteLine($"{ii}. {monster.MonsterDIe(ref DeathCount)}");
                        ii++;
                    }
                    
                    
                    ii = 1;

                    //플레이어 상태 띄우기
                    //

                    int Select = InputandReturn(1);
                    if (Select == 1)
                    {
                        //어느 적을 공격하는지
                        while (true)
                        {
                            int AttackSelect = InputandReturn(2);

                            if (AttackSelect < 1 || AttackSelect > monsters.Count)
                            {
                                Console.WriteLine("잘못된 적 선택");
                                continue;
                            }
                            else if (!monsters[AttackSelect - 1].IsLive)
                            {
                                Console.WriteLine("이미 죽었습니다.");
                                continue;
                            }
                            else
                            {
                                mon.AttackedFromPlayer(monsters[AttackSelect-1]);
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

            public int InputandReturn(int i)
            {
                if( i == 1)
                {
                    Console.WriteLine("행동을 골라주세요");
                    Console.WriteLine("1. 공격");
                    Console.WriteLine("2. 스킬");
                    return int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("어느 적을 공격할거니");
                    return int.Parse(Console.ReadLine());
                }

                
            }

        }
    }
}
