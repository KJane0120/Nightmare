using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nightmare.Data;

namespace Nightmare
{
    public class Portion : Item
    {
        public long PortionId { get; set; }
        public Item Data => DataManager.Instance.ItemDatas[PortionId];
        public int PortionCount { get; set; }
        public int PortionMaxCount { get; set; }

        //포션을 사용했을 때 이벤트
        public Action OnUsePortionEvent = delegate { };

        

        public void UsePortion()
        {
            var stat = GameManager.Instance.Player.Stat;
            //20, 10같은 회복수치를 숫자로 적는게 아닌 변수값에 저장할 것
            if (PortionCount != 0) // 선택한 아이템의 PortionCount
            {
                Console.WriteLine("회복이 완료되었습니다.");
                PortionCount -= 1;
                if (Data.Type == ItemType.HPPortion)//체력 회복 포션이라면 
                {
                    if((stat.Hp + 20) > stat.MaxHp)
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
                else if(Data.Type == ItemType.MPPortion) //마나 회복 포션이라면
                {
                    if ((stat.Mp + 10) > stat.MaxMp)
                    {
                        stat.Mp = stat.MaxMp;
                    }
                    else
                    {
                        stat.Hp += 10;
                    }

                    //Mp+10이 MaxMp보다 크다면 Mp = MaxMp
                    //아니라면 Mp += 10
                }
                else if(Data.Type == ItemType.Special) //체력+마나회복 포션이라면
                {
                    if ((stat.Hp + 100) > stat.MaxHp && (stat.Mp + 50) > stat.MaxMp)
                    {
                        stat.Hp = stat.MaxHp;
                        stat.Mp = stat.MaxMp;
                    }
                    else if((stat.Hp + 100) > stat.MaxHp && (stat.Mp + 50) <= stat.MaxMp)
                    {
                        stat.Hp = stat.MaxHp;
                        stat.Mp += 50;
                    }
                    else if ((stat.Hp + 100) <= stat.MaxHp && (stat.Mp + 50) > stat.MaxMp)
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
            OnUsePortionEvent();
            
        }

        public void MaximumHavePortion(Portion portion)
        {
            if(portion.PortionCount < portion.PortionMaxCount)
            {
                portion.PortionCount++;
            }
            else
            {
                portion.PortionCount = portion.PortionMaxCount;
                Console.WriteLine("더이상 가질 수 없습니다.");
            }
        }
    }
}
//회복 아이템
//체력회복 아이템 현재소지개수 3(기본값) 최대소지개수 3 
//마나회복 아이템 현재소지개수 3(기본값) 최대소지개수 3
//둘다회복 아이템 현재소지개수 0 최대소지개수 4

//Action_RecoveryItem에서, 회복 아이템 사용을 누를 경우
//현재소지개수가 0이라면 포션이 부족합니다.
//현재소지개수가 0이 아니라면 회복이 완료되었습니다
//+현재소지개수 -1
//+해당하는 스탯 회복 로직

//드랍을 통해 아이템을 얻을 경우
//현재 소지개수 < 최대소지개수라면 
//현재 소지개수+1
//아니라면 
//현재 소지개수 = 최대소지개수
