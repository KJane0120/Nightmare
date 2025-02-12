using System.Text;
using Nightmare.Scripts.Action.Status;

namespace Nightmare.Scripts.Action.Dungeon
{
    public class Monster
    {
        public long Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public float MonsterHealth { get; set; }
        public int MonsterAttack { get; set; }
        public int MonsterDefense { get; set; }
        public bool IsLive { get; set; } //체력이 0이면 Fales

        public int MonsterMoney { get; set; }
        public int MonsterExp { get; set; }

        public Monster(int Level, float Health, int Attack, int Defense, string name, int MonsterMoney, int MonsterExp)//생성자
        {
            this.Level = Level;
            MonsterHealth = Health;
            MonsterAttack = Attack;
            MonsterDefense = Defense;
            this.MonsterMoney = MonsterMoney;
            this.MonsterExp = MonsterExp;
            Name = name;
            IsLive = true;

        }
        public Monster()
        { }

        //
        public int MonsterAttackToPlayer()
        {
            int EndDamage;

            EndDamage = MonsterAttack;

            return EndDamage;

        }
        public string MonsterDIe(ref int DeathCount)
        {
            StringBuilder sb = new StringBuilder();


            if (MonsterHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                sb.Append("Lv.").Append(Level).Append(" ").Append(Name).Append("Dead");
                Console.ResetColor();
                if (IsLive) // 이미 사망 처리된 몬스터라면 DeathCount 증가 방지
                {
                    IsLive = false;
                    DeathCount++;
                    GameManager.Instance.Player.CurrentExp += MonsterExp;
                    GameManager.Instance.Player.LevelUp();
                }
                return sb.ToString();
            }
            else
            {
                return ToString();
            }
        }


        public Monster Monstersummon(int Level, int Money)
        {
            //몬스터들의 능력치들을 결정해줄 랜덤
            Random MonsterRandom = new Random();
            //잡몹들 이름
            string[] Name = { "첫째 난쟁이", "둘째 난쟁이"," 셋째 난쟁이", "넷째 난쟁이","다섯째 난쟁이", "여섯째 난쟁이","요정 할머니","호박마차",
                "가시덩굴","첫째 언니","둘째 언니","셋째 언니","넷째 언니","다섯째 언니","여섯째 언니","촛대 집사","먼지털이 도우미","작은 컵" };
            Monster mons = new Monster(Level, 10 * Level, Level * 3, Level * 1, Name[MonsterRandom.Next(0, 18)], MonsterRandom.Next(80 * Money, 100 * Money)
                , MonsterRandom.Next(Money * 3, 3 + 3 * Money));

            return mons;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lv.").Append(Level).Append(" ").Append(Name).Append("Hp:").Append(MonsterHealth).Append("\n").Append("공격력").
                Append(MonsterAttack).Append("방어력").Append(MonsterDefense).Append("\n");
            return sb.ToString();
        }

        public void AttackedFromPlayer(Monster monster, Player player) //Player를 받게할 예정
        {
            Random ran = new Random();

            if (monster.MonsterDefense >= player.Stat.BaseDef + player.Stat.EquipDef)
            {
                monster.MonsterHealth -= 1;
                if (monster.MonsterHealth <= 0)
                {
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지{(int)(player.Stat.BaseAtk + player.Stat.EquipAtk - monster.MonsterDefense)}]");
                    Console.WriteLine($"Hp: {monster.MonsterHealth + 1} -> Dead");
                }
                else
                {
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지{(int)(player.Stat.BaseAtk + player.Stat.EquipAtk - monster.MonsterDefense)}]");
                    Console.WriteLine($"Hp: {monster.MonsterHealth + 1} -> {monster.MonsterHealth}"); //여기도
                }
            }
            else
            {
                if ((player.Crt.PlayerCrt + player.Crt.EquipCrt) * 100 < ran.Next(0, 101))
                {
                    monster.MonsterHealth -= (int)(player.Stat.BaseAtk + player.Stat.EquipAtk) - monster.MonsterDefense;
                    if (monster.MonsterHealth <= 0)
                    {
                        Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지{(int)(player.Stat.BaseAtk + player.Stat.EquipAtk - monster.MonsterDefense)}]");
                        Console.WriteLine($"Hp: {monster.MonsterHealth + (int)(player.Stat.BaseAtk + player.Stat.EquipAtk) - monster.MonsterDefense} -> Dead");
                    }
                    else
                    {
                        Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지{(int)(player.Stat.BaseAtk + player.Stat.EquipAtk - monster.MonsterDefense)}]");
                        Console.WriteLine($"Hp: {monster.MonsterHealth + (int)(player.Stat.BaseAtk + player.Stat.EquipAtk) - monster.MonsterDefense} -> {monster.MonsterHealth}"); //여기도
                    }
                }
                else
                {
                    monster.MonsterHealth -= 2 * ((int)(player.Stat.BaseAtk + player.Stat.EquipAtk) - monster.MonsterDefense);

                    if (monster.MonsterHealth <= 0)
                    {
                        Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [크리티컬: {2 * (int)(player.Stat.BaseAtk + player.Stat.EquipAtk) - monster.MonsterDefense}]");
                        Console.WriteLine($"Hp: {monster.MonsterHealth + 2 * (int)(player.Stat.BaseAtk + player.Stat.EquipAtk) - monster.MonsterDefense} -> Dead");
                    }
                    else
                    {
                        Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [크리티컬: {2 * (int)(player.Stat.BaseAtk + player.Stat.EquipAtk) - monster.MonsterDefense}]");
                        Console.WriteLine($"Hp: {monster.MonsterHealth + 2 * (int)(player.Stat.BaseAtk + player.Stat.EquipAtk) - monster.MonsterDefense} -> {monster.MonsterHealth}"); //여기도
                    }
                }
            }

            //if (IsLive)
            //{

            //    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지]");
            //    Console.WriteLine($"Hp: {monster.MonsterHealth} -> {monster.MonsterHealth}"); //여기도
            //}
            //else
            //{
            //    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지]");
            //    Console.WriteLine($"Hp: {monster.MonsterHealth} -> Dead");
            //}




        }
    }
}
