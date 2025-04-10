﻿namespace Nightmare
{
    public class Potion : Item
    {
        public long PotionId { get; set; }
        public Item Data => DataManager.Instance.ItemDatas[PotionId];
        public int PotionCount { get; set; }
        public int PotionMaxCount { get; set; }
        //포션을 사용했을 때 이벤트
        public Action OnUsePotionEvent = delegate { };

        public virtual void UsePotion()
        {
            //첫 포션 사용 퀘스트 플래그
            if (!GameManager.Instance.IsFirstUsePotion)
            {
                GameManager.Instance.IsFirstUsePotion = true;
            }

            var stat = GameManager.Instance.Player.Stat;
            //20, 10같은 회복수치를 숫자로 적는게 아닌 변수값에 저장할 것
            if (this.Type == ItemType.HPPotion)//체력 회복 포션이라면 
            {
                if (stat.Hp + 20 > stat.MaxHp)
                {
                    Console.WriteLine($"체력 회복:{stat.Hp} -> {stat.MaxHp}");
                    
                    stat.Hp = stat.MaxHp;
                }
                else
                {
                    Console.WriteLine($"체력 회복:{stat.Hp} -> {stat.Hp +20}");
                    stat.Hp += 20;
                }
                //Hp+20이 MaxHp보다 크다면 Hp = MaxHp
                //아니라면 Hp += 20
            }
            else if (this.Type == ItemType.MPPotion) //마나 회복 포션이라면
            {

                if (stat.Mp + 10 > stat.MaxMp)
                {
                    Console.WriteLine($"마력 회복:{stat.Mp} -> {stat.MaxMp}");
                    stat.Mp = stat.MaxMp;
                }
                else
                {
                    Console.WriteLine($"마력 회복:{stat.Mp} -> {stat.Mp+10}");
                    stat.Mp += 10;
                }

                //Mp+10이 MaxMp보다 크다면 Mp = MaxMp
                //아니라면 Mp += 10
            }
            else if (this.Type == ItemType.Special) //체력+마나회복 포션이라면
            {

                if (stat.Hp + 100 > stat.MaxHp && stat.Mp + 50 > stat.MaxMp)
                {
                    Console.WriteLine($"체력 회복:{stat.Hp} -> {stat.MaxHp}");
                    Console.WriteLine($"마력 회복:{stat.Mp} -> {stat.MaxMp}");

                    stat.Hp = stat.MaxHp;
                    stat.Mp = stat.MaxMp;
       
                }
                else if (stat.Hp + 100 > stat.MaxHp && stat.Mp + 50 <= stat.MaxMp)
                {
                    Console.WriteLine($"체력 회복:{stat.Hp} -> {stat.MaxHp}");
                    Console.WriteLine($"마력 회복{stat.Mp} -> {stat.Mp + 50}");
                    stat.Hp = stat.MaxHp;
                    stat.Mp += 50;
                    
                }
                else if (stat.Hp + 100 <= stat.MaxHp && stat.Mp + 50 > stat.MaxMp)
                {
                    Console.WriteLine($"체력 회복:{stat.Hp} -> {stat.Hp + 100}");
                    Console.WriteLine($"마력 회복{stat.Mp} -> {stat.MaxMp}");
                    stat.Hp += 100;
                    stat.Mp = stat.MaxMp;
                }
                else
                {
                    Console.WriteLine($"체력 회복:{stat.Hp} -> {stat.Hp + 100}");
                    Console.WriteLine($"마력 회복:{stat.Mp} -> {stat.Mp + 50}");
                    stat.Hp += 100;
                    stat.Mp += 50;
                }
            }
            OnUsePotionEvent();
        }
        public  string ToShow()
        {
            String s = $"{Name}|{GetTypeString()}|{Desc}|";
            return s;
        }
    }
}
