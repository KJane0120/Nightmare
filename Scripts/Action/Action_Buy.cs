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
        public class Action_Buy : ActionBase
        {
            public Action_Buy(int number) : base(number) { }

            public override ActionType Type => ActionType.Buy;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {

            }
        }
    }
}
