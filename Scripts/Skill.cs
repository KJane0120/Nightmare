using System.Text;


namespace Nightmare
{
    public partial class GameManager
    {
        public class Skill
        {
            public string SkillName { get; set; }
            public string SkillDst { get; set; }
            public float SkillDamage { get; set; }
            public float SkillTarget { get; set; }
            public float SkillMp { get; set; }
            public int SkillCoolTime { get; set; }
            //public int CurrentCoolTime { get; set; }

            public Skill()
            {

            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("스킬명 ").Append(SkillName).Append("\n").Append(SkillDst).Append("\n").Append($"소요마나: {SkillMp}").Append($"쿨타임: {SkillCoolTime}");
                return sb.ToString();
            }

            public Skill(string n, string d, int damage, int t, int m, int cooltime)
            {
                SkillName = n;
                SkillDst = d;
                SkillDamage = damage;
                SkillTarget = t;
                SkillMp = m;
                SkillCoolTime = cooltime;
                //CurrentCoolTime = 0;
            }

            public virtual void SkillUse(Player player, List<Monster> monster)
            {
                // 스킬 쿨타임
                //if (CurrentCoolTime > 0)
                //{
                //    Console.WriteLine($"{SkillName}은(는) 아직 쿨타임입니다. (남은 쿨타임: {CurrentCoolTime})");
                //    return;
                //}
                //else
                //{
                //    Console.WriteLine($"{player.Name}이(가) {SkillName}을(를) 사용합니다!");
                //    CurrentCoolTime = SkillCoolTime;
                //}
            }

            //public void ReduceCooldown() // 쿨타임 감소
            //{
            //    if (CurrentCoolTime > 0)
            //    {
            //        CurrentCoolTime--;
            //    }
            //}

        }
        public void SkillSet(Player player)
        {
            switch ((int)player.Job)
            {
                case 1:
                    Skill dwarfSkill1 = new AttackSkill("난쟁이의 몸통박치기", "난쟁이가 화났습니다.", 20, 1, 10, 3);
                    Skill dwarfSkill2 = new StatSkill("난쟁이의 포효", "난쟁이가 울부짖습니다.", 5, 1, 10, 3);
                    player.Playerskill.Add(dwarfSkill1);
                    player.Playerskill.Add(dwarfSkill2);
                    break;
                case 2:
                    Skill newSisterSkill1 = new AttackSkill("새언니의 손톱할퀴기", "새언니가 손톱을 꺼내어 할큅니다.", 8, 2, 10, 3);
                    Skill newSisterSkill2 = new StatSkill("새언니의 울음", "새언니가 울부짖습니다.", 3, 1, 10, 3);
                    player.Playerskill.Add(newSisterSkill1);
                    player.Playerskill.Add(newSisterSkill2);
                    break;
                case 3:
                    Skill saisonSkill1 = new Skill("하인의 빗자루 쓸기", "하인이 빗자루로 후려칩니다.", 10, 2, 10, 3);
                    Skill saisonSkill2 = new Skill("하인의 청소", "하인이 깔끔하게 청소합니다.", 5, 1, 10, 3);
                    player.Playerskill.Add(saisonSkill1);
                    player.Playerskill.Add(saisonSkill2);
                    break;
                case 4:
                    Skill OctopusWitch1 = new Skill("마녀의 불마법", "마녀가 불을 쏩니다.", 12, 2, 10, 3);
                    Skill OctopusWitch2 = new Skill("마녀의 회복마법", "마녀가 체력을 회복합니다.", 30, 1, 10, 3);
                    Skill OctopusWitch3 = new Skill("마녀의 저주", "마녀가 저주를 겁니다.", 3, 1, 10, 3);
                    player.Playerskill.Add(OctopusWitch1);
                    player.Playerskill.Add(OctopusWitch2);
                    player.Playerskill.Add(OctopusWitch3);
                    break;
                case 5:
                    Skill WildAnimal1 = new Skill("\"야수\"", "야수는 사람을 찢습니다.", 30, 1, 10, 3);
                    Skill WildAnimal2 = new Skill("야수의 울음", "야수가 울부짖습니다.", 15, 2, 10, 3);
                    player.Playerskill.Add(WildAnimal1);
                    player.Playerskill.Add(WildAnimal2);
                    break;
            }
        }
    }
}
}
