namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Sell : ActionBase
        {
            public Action_Sell(int number) : base(number) { }


            public override ActionType Type => ActionType.Sell;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {
               // OnInputInvalidActionNumber = PrintErrorMsg; 
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("이 곳에서는 보유한 아이템을 판매할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{GameManager.Instance.Player.Gold.PlayerGold} G");

                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < DataManager.Instance.HaveItems.Count; i++)
                {
                    Console.WriteLine($"-  {DataManager.Instance.HaveItems[i].ShowSellItem()}");
                }

                Console.WriteLine();


            }
        }
    }

}