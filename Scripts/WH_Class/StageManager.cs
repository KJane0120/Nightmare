using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                SelectStage(0);
            }
            public void SelectStage(int number) //플레이어 레벨 들어갈거임
            {
                int numbers = 1;
                Random random = new Random();
                List<Stage> stages = new List<Stage>();
                stages.Add(new Stage(2, 1));
                if(number > 2) 
                {
                    Stage stage = new Stage(3, 2);
                }
                else if( number > 4)
                {
                    Stage stage = new Stage(4, 3);
                }

                foreach(Stage stage in stages) 
                {
                    Console.WriteLine($"{numbers}. Stage{numbers} {stage.ToString()}");
                }

                Console.WriteLine();
                Console.WriteLine("스테이지를 골라주십시오");
                int StageNumber = int.Parse(Console.ReadLine());

                stages[StageNumber].Battle();



            }
        }
    }
}
