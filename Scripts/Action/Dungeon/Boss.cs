using System.Text;
using static Nightmare.GameManager;


namespace Nightmare
{
    public partial class GameManager
    {
        public class Boss : Monster
        {
            public int MissRate { get; set; }

            public int Crtical { get; set; }

            public int SkillCount { get; set; }

            public List<Skill> BossSkill { get; set; }
            public Boss(int MissRate, int skillCount, int Health, int Attack, int Defense, String name, int MonsterMoney, int MonsterExp, int level, int Crtical) :
                base(level, Health, Attack, Defense, name, MonsterMoney, MonsterExp)
            {
                this.MissRate = MissRate;
                this.Crtical = Crtical;

                this.SkillCount = skillCount;
                BossSkill = new List<Skill>();
            }
            public Boss()
            {
                BossSkill = new List<Skill>(); // 리스트 초기화
            }

            public override string ToString()
            {


                StringBuilder sb = new StringBuilder();
                sb.Append("Lv.").Append(Level).Append(" ").Append(Name).Append("Hp:").Append(MonsterHealth).Append("\n").Append("공격력:").
                    Append(MonsterAttack).Append("방어력:").Append(MonsterDefense).Append("회피 확률:").Append(MissRate).Append("\n");
                return sb.ToString();

            }

            public void Skill()
            {

            }


            public void BossIntroduce(int num)
            {
                switch (num)
                {
                    case 0:
                        Console.WriteLine("주변의 강물은 전부 독이다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("당신은 독내음이 가장 짙은 곳으로 향한다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("기절할 것 같은 향기 안에서 사람의 형체가 보인다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("백설공주 발견~! 미정임");
                        break;
                    case 1:
                        Console.WriteLine("당신은 웅장한 성안에 들어간다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("그 순간 12시가 울린다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("이 시간을 넘어서면 그녀의 시간이다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("신데렐라 발견~! 미정임");
                        break;
                    case 2:
                        Console.WriteLine("당신을 막는 가시 덤불을 넘고");
                        Thread.Sleep(1000);
                        Console.WriteLine("잠들어 있는 사람들을 넘는다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("혼자 잠들지 못하는 공주는 미쳐버렸다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("오로라 발견~! 미정임");
                        break;
                    case 3:
                        Console.WriteLine("자연을 소중히 하지 않은 당신");
                        Thread.Sleep(1000);
                        Console.WriteLine("이제 문명은 자연에 섭리에 의해 사라질 것이다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("당신은 지금 문명의 수호자다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("에리엘 발견~! 미정임");
                        break;
                    default:
                        Console.WriteLine("야수 상태로 본 그녀는 무척이나 연약했다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("나는 맹수고 그녀는 사냥감이었다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("하지만 이제는 내가 사냥 당할 차례다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("벨 발견~");
                        break;
                }

            }



        }

    }

}
