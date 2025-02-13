namespace Nightmare
{
    public class SaveGameData
    {
        public List<Item> HaveItems { get; set; }
        public long GoldAmount { get; set; }
        public int GameClearCount { get; set; }

        public Dictionary<long, Item> ItemDatas = new() { };

        public List<Quest> QuestDatas = new();
        public Player Player { get; set; }

        public List<Item> EquippedItems = new();
    }
}