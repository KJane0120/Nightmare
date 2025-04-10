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
                SoundManager.PlayBGM("HappyEnding");
                Console.Clear();
                //클리어 수 증가
                DisPlay();
            }

            protected override void DisPlay()
            {
                ASCIIManager.DisplayAlignASCIIArt("Heart", Align.Center, VerticalAlign.Top);

                var quest = DataManager.Instance.QuestDatas.FirstOrDefault(x => x.QuestGroupId == Instance.Player.QuestGroupId);

                if (quest == null)
                {
                    Console.WriteLine("퀘스트를 찾을 수 없습니다.");
                }

                var boss = DataManager.Instance.BossDatas[quest.Condition.ConditionValue];

                var clearTexts = new List<string>();
                clearTexts.Add($"{boss.Name}은(는) 끝내 쓰러지고,");
                clearTexts.Add("당신은 이야기를 원래대로 돌려놓는 데에 성공했습니다.");
                clearTexts.Add($"{quest.Title} 클리어.");
                clearTexts.Add("-보상-");

                foreach (var reward in quest.Rewards)
                {
                    reward.ReceiveReward();
                    clearTexts.Add($"{reward.GetRewardInfo()} ");
                }

                ASCIIManager.AlignText(clearTexts.ToArray(), Align.Center, VerticalAlign.Bottom,15);

                Thread.Sleep(5000);
                Console.Clear();

                ASCIIManager.DisplayAlignASCIIArt("HappyEnd", Align.Center, VerticalAlign.Top);
                var endTexts = new List<string>();
                endTexts.Add("다른 동화를 읽어보시겠습니까?");
                endTexts.Add("1. 네");
                endTexts.Add("2. 아니오");

                ASCIIManager.AlignText(endTexts.ToArray(), Align.Center, VerticalAlign.Bottom,10);
                UtilityManager.InputNumberInRange(1, 2, ReStart, null, "");
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