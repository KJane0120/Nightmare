using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Nightmare.Data;
using static Nightmare.GameManager;

namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Buy : ActionBase
        {
            public Action_Buy(int number) : base(number) { }

            public override ActionType Type => ActionType.Buy;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            public void Buy(Item item)//아이템 구매 
            {
                ////골드가 충분할 때 
                //if (player.Gold >= item.Cost)
                //{
                //    player.Gold -= item.Cost;
                //    item.IsPurchase = true;
                //    Action_Inventory.Add(item);
                //    DisPlay();

                //}
                ////골드가 부족할 때 
                //else
                //{
                //    //골드가 부족하다는 메시지 출력

                //}
            }
            private void PrintErrorMsg(int number)
            {
                Item selectItem = DataManager.Instance.ShopItems[number];

                if(player.gold >= selectItem.Cost)
                {
                    Console.WriteLine("구매가 완료되었습니다.");
                    selectItem.IsPurchase = true;
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다 !! ");
                }
                
                //아이템이 구매한 적이 있다면 
                if (selectItem.IsPurchase)
                {
                    Console.WriteLine("이미 보유한 아이템입니다.");
                }
                else
                {
                    Buy(selectItem);
                    selectItem.IsPurchase = true;
                }
                
            }
            protected override void DisPlay()
            {
                OnInputInvalidActionNumber = PrintErrorMsg;
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                //Console.WriteLine($"{player.Gold} G");

                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 1; i < DataManager.Instance.ShopItems.Count; i++)
                {
                    Console.WriteLine($"- {i}. {DataManager.Instance.ShopItems[i].ShowShopItem()}");
                }

                Console.WriteLine();
                //if(needGold)
                //{
                //    Console.WriteLine("골드가 부족합니다.");
                //}
                //else if(hasItem)
                //{
                //    Console.WriteLine("이미 보유한 아이템입니다.");
                //}

                



            }
        }
    }
}
