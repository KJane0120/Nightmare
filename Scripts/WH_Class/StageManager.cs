namespace Nightmare
{
    public partial class GameManager
    {
        internal class StageManager : ActionBase
        {
            public StageManager(int number) : base(number) { }
            public override ActionType Type => ActionType.StageManager;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                           { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {
                SelectStage(Instance.Player);
            }
            public void SelectStage(Player player) //플레이어 레벨 들어갈거임
            {
                int numbers = 1;
                Random random = new Random();
                List<Stage> stages = new List<Stage>();
                stages.Add(new Stage(2, 1));
                if(player.Level.PlayerLevel > 2) 
                {
                    Stage stage = new Stage(3, 2);
                }
                else if(player.Level.PlayerLevel > 4)
                {
                    Stage stage = new Stage(4, 3);
                }
                else if(player.Level.PlayerLevel > 5)//플레이어가 아이템을 가지고있는지 검사
                {
                    Stage Boss = new Stage(0 ,0);
                    Boss.BossBattle(player);
                }

                foreach(Stage stage in stages) 
                {
                    Console.WriteLine($"{numbers}. Stage{numbers} {stage.ToString()}");
                }

                Console.WriteLine();
                Console.WriteLine("스테이지를 골라주십시오");
                int StageNumber = int.Parse(Console.ReadLine());

                stages[StageNumber-1].Battle(player);



            }
        }
    }
}
