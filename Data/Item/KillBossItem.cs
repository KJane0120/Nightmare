namespace Nightmare
{
    public class KillBossItem : Potion
    {
        public long KillBossId { get; set; }
        public Item Data => DataManager.Instance.ItemDatas[KillBossId];
    }
}
