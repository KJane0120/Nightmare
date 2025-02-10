﻿namespace Nightmare
{
    public partial class GameManager
    {
        internal class Stage
        {


       
            public int MonsterCount { get; set; }
            public int weight { get; set; }
            public Stage(int monsterCount, int weight)
            {
                this.MonsterCount = monsterCount;
                this.weight = weight;
            }
            public void Battle(Player player)
            {
                List<Monster> monsters = new List<Monster>();
                //랜덤 함수
                Random Ran = new Random();
                //함수를 사용하기 위한 개체참조
                Monster mon = new Monster();
                //몬스터를 저장할 변수
                int ii = 1;
                //리스트에 넣기
                for (int i = 0; i < MonsterCount + Ran.Next(-1,2); i++)
                {
                    monsters.Add(mon.Monstersummon(weight));
                }

                BattlePhase(mon,monsters,player);

                //플레이어의 정보를 받아서 일정 확률로 장비 얻기
                //돈 추가

                Console.WriteLine("스테이지 클리어!");
                //일정 확률의 보상 얻기

                //다시 돌아가기
            }
            public void BossBattle(Player player) //player
            {
                Boss boss  = new Boss();
                boss = boss.BossSummon((int)player.Job);
                boss.BossIntroduce((int)player.Job);

                List<Monster> monsters = new List<Monster>();

                monsters.Add(boss);
                BattlePhase(boss, monsters, player);
                //플레이어의 정보를 받아서 일정 확률로 장비 얻기
                //돈 추가

                Console.WriteLine("스테이지 클리어!");
                //일정 확률의 보상 얻기

                //다시 돌아가기

            }

            public void BattlePhase(Monster mon, List<Monster> monsters, Player player)
            {
                int ii = 1;
                int DeathCount = 0;
                while (DeathCount < monsters.Count)
                {
                    //foreach로 넣기
                    foreach (Monster monster in monsters)
                    {
                        Console.WriteLine($"{ii}. {monster.MonsterDIe(ref DeathCount)}");
                        ii++;
                    }
                    //플레이어 상태 띄우기
                    Console.WriteLine($"Lv.{player.Level.PlayerLevel} {player.Name} ({player.Job})");
                    Console.WriteLine($"공격력: {player.Stat.Atk + player.Stat.EquipAtk})");
                    Console.WriteLine($"공격력: {player.Stat.Def + player.Stat.EquipDef})");
                    Console.WriteLine($"마력: {player.Stat.Hp}/{player.Stat.MaxHp} 마력: {player.Stat.Mp}/{player.Stat.MaxMp}");
                    //Console.WriteLine($"공격력: {player.Stat.)");
                    //Console.WriteLine($"공격력: {player.Stat.Atk})");




                    ii = 1;
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
                                mon.AttackedFromPlayer(monsters[AttackSelect - 1]);
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
                            int Damage = mons.MonsterAttackToPlayer();
                            player.Stat.Hp -= Damage;
                            Console.WriteLine($"{Damage}만큼 피해를 입어 {player.Stat.Hp - Damage}가 되었습니다");
                            if(player.Stat.Hp < 0)
                            {
                                Instance.MoveNextAction(ActionType.Village);
                            }
                            
                            
                        }
                    }
                }
            }
            public int InputandReturn(int i)
            {
                if (i == 1)
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

            public override string ToString()
            {

                String s = $"적의 수: {MonsterCount-1} ~ {MonsterCount + 1}, 적들 능력치 {5*weight} 상승 ";
                return s ;
            }

        }

       

    }
}
