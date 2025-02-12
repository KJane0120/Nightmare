using Nightmare.Data;

namespace Nightmare
{
    public class SaveGameData
    {
        public List<Item> HaveItems { get; set; }

        public long GoldAmount { get; set; }

        public int GameClearCount { get; set; }

        public Dictionary<long,Player> CanSelectPlayers { get; set; }
    }
}
