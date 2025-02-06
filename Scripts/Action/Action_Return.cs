namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Return : ActionBase
        {
            public Action_Return(int number) : base(number) { }

            public override ActionType Type => ActionType.Return;

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
