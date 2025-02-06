namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Dungeon : ActionBase
        {
            public Action_Dungeon(int number) : base(number) { }


            public override ActionType Type => ActionType.Dungeon;

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
