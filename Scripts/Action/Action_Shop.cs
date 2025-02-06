namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Shop : ActionBase
        {
            public Action_Shop(int number) : base(number) { }

            public override ActionType Type => ActionType.Shop;

            public override Dictionary<int, ActionBase> CreateActionDic()
            {
                throw new NotImplementedException();
            }
            protected override void DisPlay()
            {
                throw new NotImplementedException();
            }
        }
    }

}
