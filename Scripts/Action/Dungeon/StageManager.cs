
﻿namespace Nightmare
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
                Console.Clear();
                var CastleAline = ASCIIManager.Getlines("Castle");

                ASCIIManager.DisplayAlignASCIIArt(CastleAline, Align.Center, VerticalAlign.Top);
                Console.WriteLine();
                Console.WriteLine();
                SelectStage(Instance.Player);
            }
            public void SelectStage(Player player) //플레이어 레벨 들어갈거임
            {
                Item item = new Item();

                item = DataManager.Instance.ItemDatas[18 + (int)player.Job];

                if (Instance.TutorialOk)
                {
                    Stage Tuto = new Stage(0, 0);
                    Console.WriteLine("시계 토끼: 정화 작업을 체험해보자.");
                    Console.WriteLine();
                    Console.WriteLine("1. 튜토리얼 챕터 입장");
                    Console.WriteLine("0. 돌아가기");
                    int select = int.Parse(Console.ReadLine());
                    if (select == 1)
                    {
                        Instance.TutorialOk = Tuto.TutorialBattle(player);
                    }
                    else if(select == 0)
                    {
                        Instance.MoveNextAction(ActionType.Dungeon);
                    }
                    else
                    {
                        UtilityManager.PrintErrorMessage();
                    }
                    
                }
                else
                {
                 
                    Random random = new Random();
                    List<Stage> stages = new List<Stage>();

                 
                    stages.Add(new Stage(0, 1));

                    
                    if (player.Level.PlayerLevel >= 3)
                    {
                        Stage stage = new Stage(0, 1);
                        stages.Add(stage);
                     
                    }

                    if (player.Level.PlayerLevel >= 4)
                    {
                        Stage stage = new Stage(1, 2);
                        stages.Add(stage);
                        
                    }

                    if (player.Level.PlayerLevel >= 5)
                    {
                        Stage stage = new Stage(1, 2);
                        stages.Add(stage);
                        
                    }

                    if (player.Level.PlayerLevel >= 6)
                    {
                        Stage stage = new Stage(2, 3);
                        stages.Add(stage);
                        
                    }

                    if (player.Level.PlayerLevel >= 7)
                    {
                        Stage stage = new Stage(2, 3);
                        stage.IsFinal = true;
                        stages.Add(stage);
                       
                    }

                  
                    if (player.Level.PlayerLevel >= 8 && DataManager.Instance.BossConsumableItems.Contains(item))
                    {
                        Stage Boss = new Stage(0, 0);
                        stages.Add(Boss);
                        Boss.BossBattle(player);
                    }

                   
                    for (int i = 0; i < stages.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Stage {i + 1} {stages[i].ToString()}");
                    }

                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("정화할 챕터를 선택해주세요.");
                    Console.Write(">> ");
                    
                    int StageNumber = int.Parse(Console.ReadLine());
                    if (StageNumber > 0&&  StageNumber <= stages.Count)
                    {
                        stages[StageNumber - 1].Battle(player);
                    }
                    else if (StageNumber == 0) 
                    {
                        Instance.MoveNextAction(ActionType.Village);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Instance.MoveNextAction(ActionType.Dungeon);
                    }
                }
            }




        }
    }
}
