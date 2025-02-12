namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_RecoveryItem : ActionBase
        {
            public Action_RecoveryItem(int number) : base(number) { }


            public override ActionType Type => ActionType.RecoveryItem;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                    {1, new Action_Recovery(1) },

                };
            }
            //private void PrintErrorMsg(int number)
            //{
            //    Item selectItem = DataManager.Instance.ItemDatas[number];

            //}

            protected override void DisPlay()
            {
                Console.Clear();
              //  OnInputInvalidActionNumber = PrintErrorMsg;
                Console.WriteLine("회복");
                Console.WriteLine("포션을 사용하여 HP나 MP를 회복할 수 있습니다.");

                Console.WriteLine("[포션 목록]");
                Console.WriteLine();

                foreach (var portion in DataManager.Instance.PortionDatas)
                {
                    Console.WriteLine($" - {portion.ShowPotion()}");
                }
            }
        }
    }
}
