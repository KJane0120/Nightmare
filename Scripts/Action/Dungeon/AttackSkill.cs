﻿using System.Text;

namespace Nightmare
{
    public partial class GameManager
    {
        public class AttackSkill : Skill
        {
            public  int HowManyAttack {  get; set; } 
            public AttackSkill(string n, float damage, int t, int m, int cooltime, int st, int whos, int howManyAttack) : base(n, damage, t, m, cooltime, st, whos)
            {
                HowManyAttack = howManyAttack;
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                base.ToString();
                sb.Append(base.ToString()).Append("\n스킬데미지: ").Append(SkillDamage).Append("\n스킬 범위: ").Append($"{SkillTarget}명\n");
                return sb.ToString();
            }

            public override void SkillUse(Player player, List<Monster> monster, ref int D) // 공격형 스킬 사용
            {
                if (WhosSkill == 1)
                {
                    if (SkillTarget == 1) // 단일 공격형 스킬
                    {
                        Console.WriteLine("어느 대상을 공격하시겠습니까?");
                        int num = int.Parse(Console.ReadLine());
                        player.Stat.Mp -= SkillMp;
                        for (int i = 0; i < HowManyAttack; i++)
                        {
                            monster[num - 1].MonsterHealth -= SkillDamage;
                            Console.WriteLine($"{SkillName}로 {monster[num - 1].Name}에게 {(int)(player.Stat.BaseAtk + player.Stat.EquipAtk) * 2}의 피해를 입혔습니다.");
                            monster[num - 1].MonsterDIe(ref D);
                        }
                    }
                    else
                    {
                        foreach (Monster monster1 in monster) // 다중 공격형 스킬
                        {
                            player.Stat.Mp -= SkillMp;
                            for (int i = 0; i < HowManyAttack; i++)
                            {
                                monster1.MonsterHealth -= SkillDamage;
                                Console.WriteLine($"{SkillName}로 {monster1.Name}에게 {(int)(player.Stat.BaseAtk + player.Stat.EquipAtk) * 1.5f}의 피해를 입혔습니다.");
                                monster1.MonsterDIe(ref D);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < HowManyAttack; i++)
                    {
                        player.Stat.Hp -= SkillDamage;
                        Console.WriteLine($"{SkillName}로 {player.Name}에게 {SkillDamage}의 피해를 입혔습니다.");
                    }
                   
                }
            }

 
        }
    }
}
