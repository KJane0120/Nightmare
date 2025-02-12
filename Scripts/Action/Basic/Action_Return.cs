namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Return : ActionBase
        {
            public Action_Return(int number) : base(number) { }

            public override ActionType Type => ActionType.Return;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Village(0) },
                };
            }

            public override void OnEnter()
            {
                Console.Clear();
                Instance.MoveNextAction(ActionType.Village);
            }

            protected override void DisPlay(){}
        }
    }
}
