using System.Numerics;
using System.Text;

namespace Nightmare
{
    public partial class GameManager
    {
        public class StatSkill : Skill
        {
            public string Buffskill { get; set; }
            public string SkillType { get; set; }
            

            public StatSkill(string n, string d, int damage, int t, int m, int cooltime, string buff, string sType, int st) : base(n, d, damage, t, m, cooltime, st)
            {
                Buffskill = buff;
                SkillType = sType;
                //SkillInTime = time;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                base.ToString();
                sb.Append(base.ToString()).Append("\n증감효과: ").Append($"{SkillType} + {SkillDamage}").Append("\n스킬대상: ").Append($"{SkillTarget}명\n");
                return sb.ToString();
            }

            //public void UnUse(Player player, List<Monster> monster, int num)
            //{
            //    if (Buffskill.Equals("버프")) // 버프형 스킬 사용
            //    {
            //        if (SkillType.Equals("공격력"))
            //        {
            //            player.Stat.BaseAtk -= SkillDamage;
            //        }
            //        else if (SkillType.Equals("방어력"))
            //        {
            //            player.Stat.BaseDef -= SkillDamage;
            //        }
            //        else if (SkillType.Equals("체력"))
            //        {
                        
            //        }
            //        else if (SkillType.Equals("회피율"))
            //        {
            //            player.Avd.PlayerAvd -= SkillDamage;
            //        }
            //        else
            //        {
            //            player.Crt.PlayerCrt -= SkillDamage;
            //        }
            //    }
            //    else // 디버프형 스킬 사용
            //    {
            //        if (SkillType.Equals("공격력"))
            //        {
            //            monster[num - 1].MonsterAttack += (int)SkillDamage;
            //        }
            //        else if (SkillType.Equals("방어력"))
            //        {
            //            monster[num - 1].MonsterDefense += (int)SkillDamage;
            //        }
            //    }
            //}

            public override void SkillUse(Player player, List<Monster> monster, ref int D)
            {
                if (Buffskill.Equals("버프")) // 버프형 스킬 사용
                {
                    if (SkillType.Equals("공격력"))
                    {
                        player.Stat.Mp -= SkillMp;
                        player.Stat.BaseAtk += SkillDamage;
                        Instance.Buffedplayer.Add(((Player player, int remainingTurns, string doco, int howmany))(player, SkillInTime, SkillType, SkillDamage));
                        Console.WriteLine($"{SkillName}(으)로 공격력이 {SkillDamage}만큼 올랐습니다.");
                    }
                    else if (SkillType.Equals("방어력"))
                    {
                        player.Stat.Mp -= SkillMp;
                        player.Stat.BaseDef += SkillDamage;
                        Instance.Buffedplayer.Add(((Player player, int remainingTurns, string doco, int howmany))(player, SkillInTime, SkillType, SkillDamage));
                        Console.WriteLine($"{SkillName}(으)로 방어력이 {SkillDamage}만큼 올랐습니다.");
                    }
                    else if (SkillType.Equals("체력"))
                    {
                        player.Stat.Mp -= SkillMp;
                        player.Stat.Hp += SkillDamage;
                        if (player.Stat.Hp > 100) { player.Stat.Hp = 100; }
                        Console.WriteLine($"{SkillName}(으)로 체력이 {SkillDamage}만큼 올랐습니다.");
                    }
                    else if (SkillType.Equals("회피율"))
                    {
                        player.Stat.Mp -= SkillMp;
                        player.Avd.PlayerAvd += SkillDamage;
                        Instance.Buffedplayer.Add(((Player player, int remainingTurns, string doco, int howmany))(player, SkillInTime, SkillType, SkillDamage));
                        Console.WriteLine($"{SkillName}(으)로 회피율이 {SkillDamage}만큼 올랐습니다.");
                    }
                    else
                    {
                        player.Stat.Mp -= SkillMp;
                        player.Crt.PlayerCrt += SkillDamage;
                        Instance.Buffedplayer.Add(((Player player, int remainingTurns, string doco, int howmany))(player, SkillInTime, SkillType, SkillDamage));
                        Console.WriteLine($"{SkillName}(으)로 치명타율이 {SkillDamage}만큼 올랐습니다.");
                    }
                }
                else // 디버프형 스킬 사용
                {
                    if (SkillType.Equals("공격력"))
                    {
                        player.Stat.Mp -= SkillMp;
                        int num = int.Parse(Console.ReadLine());
                        monster[num - 1].MonsterAttack -= (int)SkillDamage;
                        Instance.DebuffedMonsters.Add(((Monster monster, int remainingTurns, string doco, int howmany))(monster[num - 1], SkillInTime, SkillType, SkillDamage));
                        Console.WriteLine($"{SkillName}(으)로 {monster[num - 1].Name}의 공격력이 {SkillDamage}만큼 내렸습니다.");
                    }
                    else if (SkillType.Equals("방어력"))
                    {
                        player.Stat.Mp -= SkillMp;
                        int num = int.Parse(Console.ReadLine());
                        monster[num - 1].MonsterDefense -= (int)SkillDamage;
                        Instance.DebuffedMonsters.Add(((Monster monster, int remainingTurns, string doco, int howmany))(monster[num - 1], SkillInTime, SkillType, SkillDamage));
                        Console.WriteLine($"{SkillName}(으)로 {monster[num - 1].Name}의 방어력이 {SkillDamage}만큼 내렸습니다.");
                    }
                }
            }
        }
    }
}

