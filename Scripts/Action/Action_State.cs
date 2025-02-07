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
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();

                Instance.Player.StatusDisplay();
            }
        }
    }
}
