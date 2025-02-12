namespace Nightmare.Data.Item
{
    public class Potion : Item
    {
        public long PotionId { get; set; }
        public Item Data => DataManager.Instance.ItemDatas[PotionId];
        public int PotionCount { get; set; }
        public int PotionMaxCount { get; set; }

        //포션을 사용했을 때 이벤트
        public Action OnUsePotionEvent = delegate { };


        public override void UseItem(Item i)
        {
            if (i.Type == ItemType.HPPotion || i.Type == ItemType.MPPotion || i.Type == ItemType.Special)
            {
                UsePotion();
            }
            else if (i.Type == ItemType.Accessory)
            {

            }
        }

        public void UsePotion()
        {
            //첫 포션 사용 퀘스트 플래그
            if (!GameManager.Instance.IsFirstUsePotion)
            {
                GameManager.Instance.IsFirstUsePotion = true;
            }

            var stat = GameManager.Instance.Player.Stat;
            //20, 10같은 회복수치를 숫자로 적는게 아닌 변수값에 저장할 것
            if (PotionCount != 0) // 선택한 아이템의 PotionCount
            {
                Console.WriteLine("회복이 완료되었습니다.");
                PortionCount -= 1;
                DataManager.Instance.HaveItems.Remove(Data);
                if (Data.Type == ItemType.HPPortion)//체력 회복 포션이라면 
                {
                    if (stat.Hp + 20 > stat.MaxHp)
                    {
                        stat.Hp = stat.MaxHp;
                    }
                    else
                    {
                        stat.Hp += 20;
                    }
                    //Hp+20이 MaxHp보다 크다면 Hp = MaxHp
                    //아니라면 Hp += 20
                }
                else if (Data.Type == ItemType.MPPotion) //마나 회복 포션이라면
                {
                    if (stat.Mp + 10 > stat.MaxMp)
                    {
                        stat.Mp = stat.MaxMp;
                    }
                    else
                    {
                        stat.Mp += 10;
                    }

                    //Mp+10이 MaxMp보다 크다면 Mp = MaxMp
                    //아니라면 Mp += 10
                }
                else if (Data.Type == ItemType.Special) //체력+마나회복 포션이라면
                {
                    if (stat.Hp + 100 > stat.MaxHp && stat.Mp + 50 > stat.MaxMp)
                    {
                        stat.Hp = stat.MaxHp;
                        stat.Mp = stat.MaxMp;
                    }
                    else if (stat.Hp + 100 > stat.MaxHp && stat.Mp + 50 <= stat.MaxMp)
                    {
                        stat.Hp = stat.MaxHp;
                        stat.Mp += 50;
                    }
                    else if (stat.Hp + 100 <= stat.MaxHp && stat.Mp + 50 > stat.MaxMp)
                    {
                        stat.Hp += 100;
                        stat.Mp = stat.MaxMp;
                    }
                    else
                    {
                        stat.Hp += 100;
                        stat.Mp += 50;
                    }
                }

            }
            else
            {
                Console.WriteLine("포션이 부족합니다!");
            }
            OnUsePotionEvent();


        }
        //보상이 포션일 때 이 함수 사용
        public void PickUpPotion(Potion portion)
        {
            if (portion.PotionCount < portion.PotionMaxCount)
            {
                portion.PotionCount++;
                DataManager.Instance.ConsumableItems.Add(portion);
                Console.WriteLine($"{portion.Name}을(를) 획득했습니다! ");
            }
            else
            {
                portion.PotionCount = portion.PotionMaxCount;
                Console.WriteLine("더이상 가질 수 없습니다.");
            }
        }
        public string ShowPotion()
        {
            string str = $"{Data.Name} | {Data.GetTypeString()} | {Data.Desc} | (개수 : {PotionCount} / {PotionMaxCount} )";
            return str;
        }
    }
}
