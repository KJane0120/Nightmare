namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Dungeon : ActionBase
        {
            public Action_Dungeon(int number) : base(number) { }


            public override ActionType Type => ActionType.Dungeon;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    
                    {1, new StageManager(1) },
                    {2, new Action_RecoveryItem(2) },
                    { 0,  new Action_Return(0) },



                };
            }

            protected override void DisPlay()
            {
                var CastleAline = ASCIIManager.Getlines("CastleA");

                ASCIIManager.DisplayAlignASCIIArt(CastleAline, Align.Center, VerticalAlign.Top);

                Console.WriteLine("던전에 어서오세요");
            }
        }
    }

}
