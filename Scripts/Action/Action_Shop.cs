namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Shop : ActionBase
        {
            public Action_Shop(int number) : base(number) { }

            public override ActionType Type => ActionType.Shop;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0, new Action_Return(0) },
                    { 1, new Action_Buy(1) }
                };
            }
            protected override void DisPlay()
            {
            }
        }
    }

}
