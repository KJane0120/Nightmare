
namespace Nightmare
{
    internal class KillBossItem : Item
    {
        public long KillBossId { get; set; }
        public Item Data => DataManager.Instance.ItemDatas[KillBossId];


        


    }

    
}
