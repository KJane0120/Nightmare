using System.Text.Json.Serialization;

namespace Nightmare
{
    public enum RewardType
    {
        Gold = 0,
        Item = 1,
    }

    public class Reward
    {
        public long RewardId { get; set; }
        public RewardType RewardType { get; set; }
        public long RewardAmount { get; set; }

        [JsonIgnore]
        public Item ItemData => DataManager.Instance.ItemDatas[RewardId];

        public void ReceiveReward()
        {
            switch (RewardType)
            {
                case RewardType.Gold:
                    GameManager.Instance.Player.Gold.GoldIncrease((int)RewardAmount);
                    break;
                case RewardType.Item:
                    Item RewardItem = DataManager.Instance.ItemDatas[RewardId];
                    DataManager.Instance.HaveItems.Add(ItemData);
                    break;
            }
        }

        public void DisplayRewardInfo()
        {
            switch (RewardType)
            {
                case RewardType.Gold:
                    Console.WriteLine($"{RewardAmount}G");
                    break;
                case RewardType.Item:
                    Item item = DataManager.Instance.ItemDatas[RewardId];
                    Console.WriteLine($"{DataManager.Instance.ItemDatas[RewardId].Name} x 1");
                    break;
            }
        }
    }
}
