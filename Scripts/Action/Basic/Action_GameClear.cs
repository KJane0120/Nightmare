namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_GameClear : ActionBase
        {
            public Action_GameClear(int number) : base(number) { }
            public override ActionType Type => ActionType.GameClear;

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
                var quest = DataManager.Instance.QuestDatas.FirstOrDefault(x => x.QuestGroupId == Instance.Player.QuestGroupId);

                if (quest == null)
                {
                    Console.WriteLine("퀘스트를 찾을수 없습니다");
                }

                var lines = new List<string>();
                lines.Add($"{Instance.name}은(는) 끝내 쓰러지고,");
                lines.Add("당신은 이야기를 원래대로 돌려놓는 데에 성공했습니다.");
                lines.Add($"{quest.Title}클리어.");
                lines.Add("-보상-");

                foreach (var reward in quest.Rewards)
                {
                    reward.ReceiveReward();
                    lines.Add($"{reward.GetRewardInfo()} ");
                }

                ASCIIManager.AlignText(lines, Align.Center, VerticalAlign.Bottom, 130);
                UtilityManager.InputNumberInRange(1, 2, ReStart, null, "다른동화를 읽어 보시겠습니까? 1. 네 2. 아니오");
            }

            private void ReStart(int num)
            {
                if (num == 1)
                {
                    Instance.GameDataReset();
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