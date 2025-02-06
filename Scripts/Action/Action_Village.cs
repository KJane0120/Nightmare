
namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Village : ActionBase
        {
            public Action_Village(int number) : base(number) { }

            public override ActionType Type => ActionType.Village;

            public override Dictionary<int, ActionBase> CreateActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 1,  new Action_State(1) },
                    { 2,  new Action_Inventory(2) },
                    { 3,  new Action_Shop(3) },
                    { 4,  new Action_Dungeon(4) },
                    { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {
                Console.WriteLine("환영합니다");
            }
        }

    }

}
