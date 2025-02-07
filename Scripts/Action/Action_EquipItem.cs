
namespace Nightmare
{
    public partial class GameManager
    {
        public class Action_EquipItem : ActionBase
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
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
            }

            //public void EquipItem(Item item)
            //{
            //    if (item.IsEquip) //장착 중인 아이템 선택시 해제
            //    {
            //        UnEquip(item);
            //    }
            //    else //아이템 착용
            //    {
            //        item.IsEquip = true;

            //        if (item.Type == ItemType.Weapon) //타입이 무기일 경우 공격력 증가 
            //            EquipAtk += item.Value;
            //        else                              //타입이 갑옷일 경우 방어력 증가
            //            EquipDef += item.Value;
            //    }
            //}

            //public void UnEquip(Item item)
            //{
            //    item.IsEquip = false;

            //    if (item.Type == ItemType.Weapon)
            //        EquipAtk -= item.Value;
            //    else
            //        EquipDef -= item.Value;
            //}
        }
    }
}
