
using Nightmare.Data;


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

            private void PrintErrorMsg(int number)
            {
                Item selectItem = DataManager.Instance.ShopItems[number];

                //아이템이 구매한 적이 있다면 
                if (selectItem.IsPurchase == false)
                {
                    if (GameManager.Instance.Player.Gold.PlayerGold >= selectItem.Cost)
                    {
                        Console.WriteLine("구매가 완료되었습니다.");
                        selectItem.IsPurchase = true;
                        GameManager.Instance.Player.Gold.PlayerGold -= selectItem.Cost;
                        DataManager.Instance.HaveItems.Add(selectItem.Id, selectItem);
                        DisPlay();
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다 !! ");
                    }
                }
                else
                {
                    Console.WriteLine("이미 보유한 아이템입니다.");
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
                Console.WriteLine($"{GameManager.Instance.Player.Gold.PlayerGold} G");

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
