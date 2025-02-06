namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Inventory : ActionBase
        {
            public Action_Inventory(int number) : base(number) { }

            public override ActionType Type => ActionType.Inventory;

            public override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {
                //throw new NotImplementedException();
            }
        }

    }

}
