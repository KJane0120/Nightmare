using System.Text;


namespace Nightmare
{
    public partial class GameManager
    {
        public class Skill
        {
            public string SkillName { get; set; }
            public string SkillDst { get; set; }
            public int SkillDamage { get; set; }
            public int SkillTarget { get; set; }
            public int SkillMp { get; set; }
            public int SkillCoolTime { get; set; }


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
            }

            public virtual void SkillUse(Player player, List<Monster> monster)
            {

            }
            //public void SkillSet(Player player)
            //{
            //    switch ((int)player.Job)
            //    {
            //        case 1:
            //            Skill skill1 = new Skill("난쟁이의 포효", "난쟁이가 화났음", 10, 3, 5, 3);
            //            player.Playerskill.Add(skill1);
            //            break;
            //        case 2:
            //            Skill skill2 = new Skill("난쟁이의 포효", "난쟁이가 화났음", 10, 3, 5, 3);
            //            player.Playerskill.Add(skill2);
            //            break;
            //        case 3:
            //            Skill skill3 = new Skill("난쟁이의 포효", "난쟁이가 화났음", 10, 3, 5, 3);
            //            player.Playerskill.Add(skill3);
            //            break;
            //        case 4:
            //            Skill skill4 = new Skill("난쟁이의 포효", "난쟁이가 화났음", 10, 3, 5, 3);
            //            player.Playerskill.Add(skill4);
            //            break;
            //        case 5:
            //            Skill skill5 = new Skill("난쟁이의 포효", "난쟁이가 화났음", 10, 3, 5, 3);
            //            player.Playerskill.Add(skill5);
            //            break;
            //    }
            //}





        }
    }
}
