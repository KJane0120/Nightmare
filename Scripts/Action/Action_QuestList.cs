namespace Nightmare 
{ 
    public partial class GameManager
    {
        public class Action_QuestList : ActionBase
        {
            public Action_QuestList(int number) : base(number) { }

            public override ActionType Type => ActionType.QuestList;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {
                // 퀘스트 리스트 표시
            }

            private void SelectQuest(int num)
            {
                //선택한 퀘스트 표시
            }
        }
    }

}
