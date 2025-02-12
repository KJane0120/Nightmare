using Nightmare.Data.Quest;

namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_QuestList : ActionBase
        {
            public Action_QuestList(int number) : base(number) { }

            public override ActionType Type => ActionType.QuestList;

            private List<Quest> quests = new();

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
                quests = DataManager.Instance.GetPlayerQuestGroup();

                Console.WriteLine("퀘스트");

                for (int i = 0; i < quests.Count; i++)
                {
                    questDic.Add(i + 1, quests[i]);
                    quests[i].Id = i + 1;
                    quests[i].DisplayQuestTitle();
                }

                Console.WriteLine("\n0. 나가기");
            }

            private void SelectQuest()
            {
                while (true)
                {
                    Console.Write("\n원하는 퀘스트를 선택해주세요\n>>");
                    if (int.TryParse(Console.ReadLine(), out int input))
                    {
                        if (input == 0)
                        {
                            Instance.MoveNextAction(ActionType.Village);
                            break;
                        }
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
                DisplayNextAction(selectedQuest);

                while (true)
                {
                    Console.Write("\n원하는 행동을 입력해주세요\n>>");
                    if (int.TryParse(Console.ReadLine(), out int input))
                    {
                        SelectAction(selectedQuest, input);
                    }
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }

            private void DisplayNextAction(Quest selectedQuest)
            {
                if (!selectedQuest.IsProgress)
                {
                    Console.WriteLine("\n1. 수락");
                    Console.Write("2. 거절\n");
                }
                else
                {
                    Console.WriteLine("\n1. 보상받기");
                    Console.Write("2. 돌아가기\n");
                }
            }

            private void SelectAction(Quest selectedQuest,int input)
            {
                //1번을 입력받았으면
                if (input == 1)
                {
                    // 퀘스트가 진행중이면
                    if(selectedQuest.IsProgress)
                    {
                        //보상받기
                        selectedQuest.ReceiveReward();
                        //완료한 퀘스트는 표시되지않게 리스트에서 삭제
                        quests.Remove(selectedQuest);
                        selectedQuest.IsProgress = false;
                    }
                    //퀘스트가 진행중이지않으면
                    else
                    {
                        // 퀘스트 진행하기
                        selectedQuest.IsProgress = true;
                    }
                }
                Instance.MoveNextAction(ActionType.QuestList);
            }
        }
    }

}
