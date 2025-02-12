﻿using Nightmare.Data;
using static Nightmare.GameManager;

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
                if (!Instance.TutorialOk)
                {
                    Stage Tuto = new Stage(0, 0);
                    Console.WriteLine("튜토리얼 스테이지를 클리어해야 합니다.");
                    Console.WriteLine("1. 튜토리얼 스테이지 입장");
                    int select = int.Parse(Console.ReadLine());
                    if (select == 1)
                    {
                        Instance.TutorialOk = Tuto.TutorialBattle(player);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 선택입니다.");
                    }
                    
                }
                else
                {
                    int numbers = 1;
                    Random random = new Random();
                    List<Stage> stages = new List<Stage>();
                    stages.Add(new Stage(0, 1));
                    if (player.Level.PlayerLevel >= 3)
                    {
                        Stage stage = new Stage(0, 1);
                        stages.Add(stage);
                    }
                    else if (player.Level.PlayerLevel >= 4)
                    {
                        Stage stage = new Stage(1, 2);
                        stages.Add(stage);
                    }
                    else if (player.Level.PlayerLevel >= 5)
                    {
                        Stage stage = new Stage(1, 2);
                        stages.Add(stage);
                    }
                    else if (player.Level.PlayerLevel >= 6)
                    {
                        Stage stage = new Stage(2, 3);
                        stages.Add(stage);
                    }
                    else if (player.Level.PlayerLevel >= 7)
                    {
                        Stage stage = new Stage(2, 3);
                        stage.IsFinal = true;
                        stages.Add(stage);

                    }
                    else if (player.Level.PlayerLevel >= 8 && DataManager.Instance.ConsumableItems.Any(d => d.Id == (int)Instance.Player.Job + 17))//플레이어가 아이템을 가지고있는지 검사 DataManager.Instance.HaveItemDatas.Contains();
                    {

                        Stage Boss = new Stage(0, 0);
                        stages.Add(Boss);
                        Boss.BossBattle(player);
                    }

                    foreach (Stage stage in stages)
                    {
                        Console.WriteLine($"{numbers}. Stage{numbers} {stage.ToString()}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("스테이지를 골라주십시오");
                    int StageNumber = int.Parse(Console.ReadLine());

                    stages[StageNumber - 1].Battle(player);
                }
            }




        }
    }
}
