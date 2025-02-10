namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_QuestList : ActionBase
        {
            public Action_QuestList(int number) : base(number) { }

            public override ActionType Type => ActionType.QuestList;

            private Dictionary<int, Quest> questDic = new();

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            public override void OnEnter()
            {
                Console.Clear();
                DisPlay();
                SelectQuest();
            }

            protected override void DisPlay()
            {
                var questList = DataManager.Instance.GetPlayerQuestGroup();

                Console.WriteLine("퀘스트");

                for (int i = 0; i < questList.Count; i++)
                {
                    questDic.Add(i + 1, questList[i]);
                    questList[i].Id = i + 1;
                    questList[i].DisplayQuestTitle();
                }
            }

            private void SelectQuest()
            {
                while (true)
                {
                    Console.Write("\n원하는 퀘스트를 선택해주세요\n>>");
                    if (int.TryParse(Console.ReadLine(), out int input))
                    {
                        DisplayQuestInfo(questDic[input]);
                        break;
                    }
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }

            private void DisplayQuestInfo(Quest selectedQuest)
            {
                Console.Clear();

                selectedQuest.DisplayQuestInfo();
                Console.WriteLine("\n1. 수락");
                Console.Write("2. 거절\n");

                while (true)
                {
                    Console.Write("\n원하는 행동을 입력해주세요\n>>");
                    if (int.TryParse(Console.ReadLine(), out int input))
                    {
                        if (input == 1)
                        {
                            selectedQuest.IsProgress = true;
                        }
                        Instance.MoveNextAction(ActionType.QuestList);
                    }
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }


        }
    }

}
