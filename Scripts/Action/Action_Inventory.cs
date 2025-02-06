namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Inventory : ActionBase
        {
            public Action_Inventory(int number) : base(number) { }

            public override ActionType Type => ActionType.Inventory;

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
