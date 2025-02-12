namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_EquipItem : Action_Inventory
        {
            public Action_EquipItem(int number) : base(number) { }
            public override ActionType Type => ActionType.Equip;

            protected override Dictionary<int, ActionBase> CreateNextActionDic()
            {
                return new Dictionary<int, ActionBase>()
                {
                    { 0,  new Action_Return(0) },
                };
            }

            protected override void DisPlay()
            {
                UtilityManager.ColorWriteLine("인벤토리 - 장착 관리", ConsoleColor.Green);
                DisPlayInventory();
                OnInputInvalidActionNumber = EquipItem;
            }

            private void EquipItem(int num)
            {
                Item selectItem = DataManager.Instance.HaveItems[num];
                //Stat equipStat;

                if (selectItem.IsEquip)
                {
                    selectItem.IsEquip = false;

                    if (selectItem.Type == ItemType.Weapon)
                    {
                        //equipStat.EquipAtk -= Item.item.Value;
                    }
                    //else equipStat.EquipDef -= item.Value;
                }
                else
                {
                    selectItem.IsEquip = true;

                    if (selectItem.Type == ItemType.Weapon)
                    {
                        //EquipAtk += item.Value;
                    }
                    //else EquipDef += item.Value;
                }
            }
        }
    }
}
