using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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

            protected override void DisPlay()
            {
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
                
                


            }
        }
    }
}
