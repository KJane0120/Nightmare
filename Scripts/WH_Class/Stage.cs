using System.Collections.Generic;

namespace Nightmare
{
    public partial class GameManager
    {
        internal class Stage
        {
            public int MoneyRange { get; set; }
            public int RandomRange {  get; set; }
            public bool Clear { get; set; }
            public bool IsFinal { get; set; }

            public Stage(int randomRange, int MoneyRange)
            {
                RandomRange = randomRange;
                this.MoneyRange = MoneyRange;
                
            }
            public bool TutorialBattle(Player player)
            {
                List<Monster > monsters = new List<Monster>();
                Monster mon = new Monster();
                for (int i = 0; i < 3; i++)
                {
                    Monster monster = new Monster(1, 10, 3, 1, "연습용 표적", 0, 0);
                    monsters.Add(monster);
                }

                Random ran = new Random();
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
                    if (DeathCount >= monsters.Count)
                    {
                        break;
                    }

                    //플레이어 상태 띄우기
                    Console.WriteLine($"Lv.{player.Level.PlayerLevel} {player.Name} ({player.Job})");
                    Console.WriteLine($"공격력: {player.Stat.BaseAtk + player.Stat.EquipAtk})");
                    Console.WriteLine($"방어력: {player.Stat.BaseDef + player.Stat.EquipDef})");
                    Console.WriteLine($"체력: {player.Stat.Hp}/{player.Stat.MaxHp} 마력: {player.Stat.Mp}/{player.Stat.MaxMp}");
                    Console.WriteLine($"치명타율: {(player.Crt.PlayerCrt + player.Crt.EquipCrt)}");
                    Console.WriteLine($"회피율: {player.Avd.EquipAvd + player.Avd.PlayerAvd})");

                    Console.WriteLine($"현재 DeathCount: {DeathCount}/{monsters.Count}");
                    ii = 1;
                    Console.WriteLine("행동을 선택해주세요(스킬 사용 정지)");
                    Console.WriteLine("1. 공격");
                    int Select = int.Parse( Console.ReadLine() );
                    if (Select == 1)
                    {
                        //어느 적을 공격하는지
                        while (true)
                        {
                            Console.WriteLine("누굴 공격하니");
                            int AttackSelect = int.Parse( Console.ReadLine() );

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
                                mon.AttackedFromPlayer(monsters[AttackSelect - 1], player);
                                foreach (Skill skill in player.Playerskill)
                                {
                                    if (skill.CurrentCoolTime < skill.SkillCoolTime)
                                    {
                                        skill.CurrentCoolTime++;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine("튜토리얼 클리어!");
                return true;

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
                for (int i = 0; i < 3; i++)
                {
                    monsters.Add(mon.Monstersummon(Ran.Next(1 + ( 3*RandomRange), 4 + (3*RandomRange)), MoneyRange));
                }

                BattlePhase(mon,monsters,player);

                //플레이어의 정보를 받아서 일정 확률로 장비 얻기
                //돈 추가

                Console.WriteLine("스테이지 클리어!");
                //일정 확률의 보상 얻기
                GetClearBoSang(monsters,player);
                //다시 돌아가기
            }
            public void BossBattle(Player player) //player
            {
                Boss boss  = new Boss();
                boss = DataManager.Instance.BossDatas[(int)player.Job];
                boss.BossIntroduce((int)player.Job);

                List<Monster> monsters = new List<Monster>();

                monsters.Add(boss);
                BattlePhase(boss, monsters, player);
                //플레이어의 정보를 받아서 일정 확률로 장비 얻기
                //돈 추가

                Console.WriteLine("스테이지 클리어!");
                //일정 확률의 보상 얻기
                GetClearBoSang(monsters, player);
                //다시 돌아가기

            }

            public void BattlePhase(Monster mon, List<Monster> monsters, Player player)
            {
                Random ran = new Random();
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
                    Console.WriteLine($"공격력: {player.Stat.BaseAtk + player.Stat.EquipAtk})");
                    Console.WriteLine($"방어력: {player.Stat.BaseDef + player.Stat.EquipDef})");
                    Console.WriteLine($"체력: {player.Stat.Hp}/{player.Stat.MaxHp} 마력: {player.Stat.Mp}/{player.Stat.MaxMp}");
                    Console.WriteLine($"치명타율: {(player.Crt.PlayerCrt + player.Crt.EquipCrt)}");
                    Console.WriteLine($"회피율: {player.Avd.EquipAvd + player.Avd.PlayerAvd})");

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
                                mon.AttackedFromPlayer(monsters[AttackSelect - 1], player);
                                foreach (Skill skill in player.Playerskill)
                                {
                                    if (skill.CurrentCoolTime < skill.SkillCoolTime)
                                    {
                                        skill.CurrentCoolTime++;                                        
                                    }
                                }
                                Instance.TakeAction();
                                break;
                            }
                        }
                    }
                    else if (Select == 2)
                    {
                        int number = 1;
                        foreach (Skill skill in player.Playerskill)
                        {
                            Console.WriteLine($"{number}. {skill.ToString()}");
                            number++;
                        }

                        while (true)
                        {
                            int str = InputandReturn(3);
                            if (str > player.Playerskill.Count || str == 0)
                            {
                                Console.WriteLine("잘못된 선택입니다.");
                                continue;
                            }
                            if (player.Playerskill[str - 1].SkillMp > player.Stat.Mp)
                            {
                                Console.WriteLine($"마나가  {player.Playerskill[str - 1].SkillMp - player.Stat.Mp}가 부족합니다");
                                BattlePhase(mon, monsters, player);
                                continue;
                            }
                            if (player.Playerskill[str - 1].CurrentCoolTime < player.Playerskill[str - 1].SkillCoolTime)
                            {                                
                                Console.WriteLine("쿨타임입니다.");
                                BattlePhase(mon, monsters, player);
                                continue;
                            }

                            foreach (Skill skill in player.Playerskill)
                            {
                                if(skill.CurrentCoolTime < skill.SkillCoolTime)
                                {
                                    skill.CurrentCoolTime++;
                                }
                            }
                            Instance.TakeAction();
                            player.Playerskill[str - 1].SkillUse(player, monsters, ref DeathCount);
                            player.Playerskill[str - 1].CurrentCoolTime = 0;                            
                            break;
                        }
                    }
                    else if (Select == 3)
                    {
                        

                        Instance.TakeAction();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 선택입니다.");
                    }



                    //몬스터 공격


                    foreach (Monster mons in monsters)
                    {
                        mons.MonsterDIe(ref DeathCount);
                        if (mons.IsLive)
                        {
                            
                            int Damage = mons.MonsterAttackToPlayer();
                            if ((player.Avd.EquipAvd + player.Avd.PlayerAvd) < ran.Next(0, 101))
                            {
                                if (Damage > (player.Stat.BaseDef + player.Stat.EquipDef))
                                {
                                    player.Stat.Hp -= Damage - (player.Stat.BaseDef + player.Stat.EquipDef);
                                    Console.WriteLine($"데미지 {Damage} -플레이어 방어력{player.Stat.BaseDef + player.Stat.EquipDef} =" +
                                        $"{Damage - (player.Stat.BaseDef + player.Stat.EquipDef)} 피해를 입어 {player.Stat.Hp}가 되었습니다");
                                }
                                else
                                {
                                    player.Stat.Hp -= 1;
                                    Console.WriteLine("방어력이 높아서 1만 닳음");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"회피 성공");
                            }
                            

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
                    Console.WriteLine("3. 아이템 사용");
                    return int.Parse(Console.ReadLine());
                }
                else if(i == 2)
                {
                    Console.WriteLine("어느 적을 공격할거니");
                    return int.Parse(Console.ReadLine());
                }
                else  if( i == 3)
                {
                    Console.WriteLine("사용할 스킬을 골라주세요");

                    return int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("사용할 아이템을 골라주세요");
                    Console.WriteLine("1. 앨리스의 쿠키");
                    Console.WriteLine("2. 엘리스의 음료");
                    Console.WriteLine("사용할 아이템을 골라주세요");
                    return int.Parse(Console.ReadLine());
                }



            }

            public void GetClearBoSang(List<Monster> mm, Player player)
            {
                Random random = new Random();
                int AllMoney = 0;
                foreach(Monster m in mm ) 
                {
                    player.Gold.PlayerGold += m.MonsterMoney;
                    AllMoney += m.MonsterMoney;
                }

                Console.WriteLine($"{AllMoney}Gold 획득! 총 골드 {player.Gold.PlayerGold}");

                if(RandomRange > 1 || random.Next(0,11) > 5)
                {
                    //DataManager.Instance.HaveItemDatas.Add(); 일반 아이템
                    if(IsFinal || random.Next(0, 11) > 5)
                    {
                        //DataManager.Instance.HaveItemDatas.Add(); 보스템 떨구기
                    }
                }

            }

            public override string ToString()
            {

                String s = $"적의 수: 3 ";
                return s ;
            }

        }

       

    }
}
