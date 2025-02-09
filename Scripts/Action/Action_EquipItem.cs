using System.Xml.Linq;
using Nightmare.Data;
using static Nightmare.Data.Item;

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
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                DisPlayInventory();
                OnInputInvalidActionNumber = EquipItem;
            }

            private void EquipItem(int num)
            {
                Item selectItem = DataManager.Instance.HaveItems[num];

                if (selectItem.IsEquip)
                {
                    selectItem.IsEquip = false;

                    if (selectItem.Type == ItemType.Weapon)
                    {
                        // 공격력 증가
                        //EquipAtk -= item.Value;
                    }
                    // 방어력 증가
                    //else EquipDef -= item.Value;
                }
                else
                {
                    selectItem.IsEquip = true;

                    if (selectItem.Type == ItemType.Weapon)
                    {
                        // 공격력 증가
                        //EquipAtk += item.Value;
                    }
                    // 방어력 증가
                    //else EquipDef += item.Value;
                }
            }
        }
    }
}
