
namespace Nightmare
{
    public class KillBossItem : Item
    {
        public long KillBossId { get; set; }
        public Item Data => DataManager.Instance.ItemDatas[KillBossId];

        //보상이 스페셜 드랍아이템일때 이함수 사용
        public void PickUpItem(Item item)
        {
            DataManager.Instance.HaveItemDatas.Add(item);
            DataManager.Instance.ConsumableItems.Add(item);
        }

        //스페셜 드랍아이템 사용 구현
        public void UseKillBossItem(Item item)
        {
            //Console.WriteLine("사용 조건 구현 시 변경부탁드립니다. ");
            //if(사용조건) {}
            DataManager.Instance.HaveItemDatas.Remove(item);
            DataManager.Instance.ConsumableItems.Remove(item);
        }

        public override void UseItem(Item item)
        {
            if (item.Type == ItemType.HPPortion || item.Type == ItemType.MPPortion || item.Type == ItemType.Special)
            {
                
            }
            else if (item.Type == ItemType.Accessory)
            {
                UseKillBossItem(item);
            }
        }


        public String ShowBossItem()
        {
            string str = $"{Data.Name} | {Data.GetTypeString()} | {Data.Desc} | (효과가 들어갈듯 )";
            return str;
        }
    }
}
