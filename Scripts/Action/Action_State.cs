namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_State : ActionBase
        {
            public Action_State(int number) : base(number) { }

            public override ActionType Type => ActionType.State;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {
            }
        }
    }
}
