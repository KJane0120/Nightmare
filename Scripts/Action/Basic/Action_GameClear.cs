namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_GameClear : ActionBase
        {
            public Action_GameClear(int number) : base(number) { }

            public override ActionType Type => ActionType.QuestList;

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
                //플레이한 직업 삭제
                DataManager.Instance.CanSelectPlayerDatas.Remove((int)Instance.Player.Job);
                //클리어 수 증가
                Instance.GameClearCount++;
                DisPlay();
            }

            protected override void DisPlay()
            {
                Console.WriteLine("게임 클리어!");

                var quest = DataManager.Instance.QuestDatas.FirstOrDefault(x => x.QuestGroupId == Instance.Player.QuestGroupId);

                foreach (var reward in quest.Rewards)
                {
                    reward.DisplayRewardInfo();
                    Console.Write("을(를)획득하였습니다!");
                }

                Console.WriteLine("1.다시하기");
                Console.WriteLine("2.게임 종료");

                UtilityManager.InputNumberInRange(1, 2, ReStart, null, "원하시는 행동을 입력해주세요");
            }

            private void ReStart(int num)
            {
                if (num == 1)
                {
                    Instance.GameStart();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }

}