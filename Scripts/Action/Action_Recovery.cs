
namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_Recovery : ActionBase
        {

            public Action_Recovery(int number) : base(number) { }

            public override ActionType Type => ActionType.Recovery;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }
          
            private void PrintErrorMsg(int number)
            {

                int index = number - 1;
                if(index < 0 || index >= DataManager.Instance.PortionDatas.Count)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }
                var selectPortion = DataManager.Instance.PortionDatas[index];
                selectPortion.OnUsePortionEvent = DisPlay;

                selectPortion.UsePortion();
                

            }
            protected override void DisPlay()
            {
                Thread.Sleep(800);
                Console.Clear();

                OnInputInvalidActionNumber = PrintErrorMsg;
                Console.WriteLine("회복");
                Console.WriteLine("포션을 사용하여 HP나 MP를 회복할 수 있습니다.");

                Console.WriteLine("[포션 목록]");
                Console.WriteLine();

                int i = 0;
                foreach (var portion in DataManager.Instance.PortionDatas)
                {
                    Console.WriteLine($" - {i + 1}. {portion.ShowPortion()}");
                    i++;
                }

                //Console.WriteLine($"앨리스의 쿠키 : HP 20 회복 (소지 개수: )");
                //Console.WriteLine($"앨리스의 음료 : MP 10 회복 (소지 개수: )");
                //Console.WriteLine($"사랑의 정수 : HP 100, Mp 50 회복 (소지 개수: )");


            }
        }
    }
}
