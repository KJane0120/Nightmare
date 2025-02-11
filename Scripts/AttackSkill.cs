﻿using System;
using System.Text;

namespace Nightmare
{
    public partial class GameManager
    {
        public class AttackSkill : Skill
        {
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                base.ToString();
                sb.Append(base.ToString()).Append("\n스킬데미지: ").Append(SkillDamage).Append("\n스킬 범위: ").Append($"{SkillTarget}명\n");
                return sb.ToString();
            }

            public override void SkillUse(Player player, List<Monster> monster, ref int D) // 공격형 스킬 사용
            {
                if (SkillTarget == 1) // 단일 공격형 스킬
                {
                    Console.WriteLine("어떤 적을 공격하십니까");
                    int num = int.Parse(Console.ReadLine());
                    player.Stat.Mp -= SkillMp;
                    monster[num - 1].MonsterHealth -= (int)(player.Stat.BaseAtk + player.Stat.EquipAtk) * 2;
                    Console.WriteLine($"{SkillName}로 {monster[num - 1].Name}에게 {(int)(player.Stat.BaseAtk + player.Stat.EquipAtk) * 2}의 피해를 입혔습니다.");
                    monster[num - 1].MonsterDIe(ref D);
                }
                else
                {
                    foreach (Monster monster1 in monster) // 다중 공격형 스킬
                    {
                        player.Stat.Mp -= SkillMp;
                        monster1.MonsterHealth -= (int)((player.Stat.BaseAtk + player.Stat.EquipAtk) * 1.5f);
                        Console.WriteLine($"{SkillName}로 {monster1.Name}에게 {(int)(player.Stat.BaseAtk + player.Stat.EquipAtk) * 1.5f}의 피해를 입혔습니다.");
                        monster1.MonsterDIe(ref D);
                    }
                }
            }

            public AttackSkill(string n, string d, int damage, int t, int m, int cooltime) : base(n, d, damage, t, m, cooltime)
            {

            }
        }
    }
}
