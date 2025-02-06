namespace Nightmare
{
    public partial class GameManager
    {
        public abstract partial class ActionBase
        {
            public abstract ActionType Type { get; }

            public Dictionary<int, ActionBase> ActionDic = new Dictionary<int, ActionBase>();
            public abstract Dictionary<int, ActionBase> CreateActionDic();

            public Action<int> OnInputInvalidActionNumber = delegate { };

            private int actionNumber = 0;

            public ActionBase(int number)
            {
                actionNumber = number;
            }

            public virtual void OnEnter()
            {
                ActionDic = CreateActionDic();
                OnInputInvalidActionNumber = PrintErrorMessage;

                DisPlay();
                InputNextAction();
            }

            public virtual void OnExit() { }

            protected abstract void DisPlay();

            private void PrintInfo()
            {
                Console.WriteLine($"\n{actionNumber}. {UtilityManager.GetDescription(Type)}");
            }

            protected void DisplayNextActions()
            {
                foreach (var action in ActionDic.Values)
                {
                    action.PrintInfo();
                }
            }

            protected void InputNextAction()
            {
                while (true)
                {
                    DisplayNextActions();
                    Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

                    if (int.TryParse(Console.ReadLine(), out int actionNumber))
                    {
                        if (ActionDic.ContainsKey(actionNumber))
                        {
                            Instance.CurrentAction = ActionDic[actionNumber];
                            break;
                        }
                        OnInputInvalidActionNumber?.Invoke(actionNumber);
                    }
                    else
                    {
                        PrintErrorMessage(0);
                    }
                    continue;
                }
            }

            private void PrintErrorMessage(int number)
            {
                Console.WriteLine("\n잘못된 입력입니다.");
            }
        }

        public partial class ActionBase
        {
            public static ActionBase None { get; } = new Action_None();
            private class Action_None
                : ActionBase
            {
                public Action_None() : base(-1) { }
                public override ActionType Type => ActionType.None;
                public override Dictionary<int, ActionBase> CreateActionDic()
                {
                    throw new NotImplementedException();
                }
                protected override void DisPlay()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }


}
