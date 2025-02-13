namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_AllClear : ActionBase
        {
            public Action_AllClear(int number) : base(number) { }
            public override ActionType Type => ActionType.AllClear;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            public override void OnEnter()
            {
                SoundManager.PlayBGM("TrueEnding");
                Console.Clear();
                DisPlay();
            }

            protected override void DisPlay()
            {
                ASCIIManager.DisplayAlignASCIIArt("TrueEnd", Align.Center, VerticalAlign.Top);

                var clearTexts = new List<string>();
                clearTexts.Add($"당신은 모든 이야기를 되돌렸습니다.");
                clearTexts.Add("책을 덮을 시간입니다.");
                clearTexts.Add($"“옛날 옛적에….”");
                clearTexts.Add($"1.다시하기");
                clearTexts.Add($"2.나가기");

                ASCIIManager.AlignText(clearTexts.ToArray(), Align.Center, VerticalAlign.Bottom, 8);

                UtilityManager.InputNumberInRange(1, 2, ReStart, null, "");
            }

            private void ReStart(int num)
            {
                if (num == 1)
                {
                    Console.WriteLine("업데이트 예정입니다! 다음 시즌을 기대해주세요 찡긋><");
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
