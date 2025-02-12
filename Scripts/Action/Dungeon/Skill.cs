using System.Text;

namespace Nightmare
{
    public partial class GameManager
    {
        public class Skill
        {

            public string SkillName { get; set; }            
            public float SkillDamage { get; set; }
            public float SkillTarget { get; set; }
            public float SkillMp { get; set; }
            public int SkillCoolTime { get; set; }
            public int CurrentCoolTime { get; set; }
            public int SkillInTime { get; set; }            

            public Skill()
            {

            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("스킬명: ").Append(SkillName).Append("\n").Append($"소요마나: {SkillMp}\n").Append($"쿨타임: {SkillCoolTime}턴");
                return sb.ToString();
            }

            public Skill(string n, float damage, int t, int m, int cooltime, int skillInTime)
            {
                SkillName = n;                
                SkillDamage = damage;
                SkillTarget = t;
                SkillMp = m;
                SkillCoolTime = cooltime;
                CurrentCoolTime = cooltime;
                SkillInTime = skillInTime;
            }

            public virtual void SkillUse(Player player, List<Monster> monster, ref int Death)
            {
               
            }


            public void SkillSet(Player player)
            {
                switch ((int)player.Job)
                {
                    case 1:
                        Skill dwarfSkill1 = new AttackSkill("광부의 곡괭이질", (player.Stat.BaseAtk + player.Stat.EquipAtk) * 2, 1, 10, 3,0);
                        Skill dwarfSkill2 = new StatSkill("광물의 공명", 0.05f, 1, 10, 3, "버프", "치명타율",3);
                        player.Playerskill.Add(dwarfSkill1);
                        player.Playerskill.Add(dwarfSkill2);
                        break;
                    case 2:
                        Skill newSisterSkill1 = new AttackSkill("서투른 빗자루질", (player.Stat.BaseAtk + player.Stat.EquipAtk) / 2, 2, 10, 3, 0);
                        Skill newSisterSkill2 = new StatSkill("저주받은 입담", 0.5f, 1, 10, 3, "디버프", "공격력",3);
                        player.Playerskill.Add(newSisterSkill1);
                        player.Playerskill.Add(newSisterSkill2);
                        break;
                    case 3:
                        Skill saisonSkill1 = new AttackSkill("성의 톱니바퀴", (player.Stat.BaseAtk + player.Stat.EquipAtk) / 1.5f, 2, 10, 3,0);
                        Skill saisonSkill2 = new StatSkill("오늘의 일정", 0.05f, 1, 10, 3, "버프", "회피율",3);
                        player.Playerskill.Add(saisonSkill1);
                        player.Playerskill.Add(saisonSkill2);
                        break;
                    case 4:
                        Skill OctopusWitch1 = new AttackSkill("여덟 문어 다리", (player.Stat.BaseAtk + player.Stat.EquipAtk) * 1.5f, 2, 10, 3, 0);
                        Skill OctopusWitch2 = new StatSkill("윤슬", 30, 1, 10, 3, "버프", "체력", 0);
                        Skill OctopusWitch3 = new StatSkill("심해의 냉기", 0.5f, 1, 10, 3, "디버프", "방어력", 3);
                        player.Playerskill.Add(OctopusWitch1);
                        player.Playerskill.Add(OctopusWitch2);
                        player.Playerskill.Add(OctopusWitch3);
                        break;
                    case 5:
                        Skill WildAnimal1 = new AttackSkill("날카로운 발톱", (player.Stat.BaseAtk + player.Stat.EquipAtk) * 1.5f, 1, 10, 3, 0);
                        Skill WildAnimal2 = new AttackSkill("야수의 포효", (player.Stat.BaseAtk + player.Stat.EquipAtk), 2, 10, 3, 0);
                        player.Playerskill.Add(WildAnimal1);
                        player.Playerskill.Add(WildAnimal2);
                        break;
                }
            }
        }
        
    }
}

