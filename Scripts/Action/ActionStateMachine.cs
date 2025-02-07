using System.ComponentModel;

namespace Nightmare
{
    public partial class GameManager
    {
        public enum ActionType
        {
            None,
            [Description("마을")]
            Village,
            [Description("돌아가기")]
            Return,
            [Description("상태보기")]
            State,
            [Description("인벤토리")]
            Inventory,
            [Description("상점")]
            Shop,
            [Description("던전입장")]
            Dungeon,
            [Description("아이템 구매")]
            Buy,
            [Description("장착 관리")]
            Equip,
            [Description("스테이지 목록 보기")]
            StageManager
        }

        public ActionBase CurrentAction
        {
            get => m_CurrentAction;
            set
            {
                OnExitStateEvent();
                m_CurrentAction.OnExit();
                m_CurrentAction = value;
                m_CurrentAction.OnEnter();
                OnEnterStateEvent();
            }
        }

        private ActionBase m_CurrentAction = ActionBase.None;

        public Action OnEnterStateEvent = delegate { };
        public Action OnExitStateEvent = delegate { };

        public IReadOnlyDictionary<ActionType, ActionBase> TypeActionDic;

        private Dictionary<ActionType, ActionBase> CreateTypeActionDic()
        {
            return new Dictionary<ActionType, ActionBase>()
                {
                    { ActionType.Village,  new Action_Village(0) },
                    { ActionType.State,  new Action_State(0) },
                    { ActionType.Inventory,  new Action_Inventory(0) },
                    { ActionType.Shop,  new Action_Shop(0) },
                    { ActionType.Dungeon,  new Action_Return(0) },
                    { ActionType.Return,  new Action_Dungeon(0) },
                     { ActionType.StageManager,  new StageManager(0) }


                };
        }

        public void MoveNextAction(ActionType type)
        {
            TypeActionDic = CreateTypeActionDic();
            CurrentAction = TypeActionDic[type];
        }
    }

}
