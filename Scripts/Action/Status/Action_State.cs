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
                Console.Clear();
                //Console.WriteLine("상태 보기");
                Console.WriteLine("악몽을 물리칠 당신의 현재 상태는...");
                Console.WriteLine();

                Instance.Player.StatusDisplay();
            }
        }
    }
}
