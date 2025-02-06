namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_State : ActionBase
        {
            public Action_State(int number) : base(number) { }

            public override ActionType Type => ActionType.State;

            public override Dictionary<int, ActionBase> CreateActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {
                throw new NotImplementedException();
            }
        }
    }
}
