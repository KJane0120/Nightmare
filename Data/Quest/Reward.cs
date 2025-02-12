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
        public Item ItemData => DataManager.Instance.ItemDatas[RewardId];

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
                    DataManager.Instance.HaveItems.Add(ItemData);
                    break;
            }
        }

        public string GetRewardInfo()
        {
            switch (RewardType)
            {
                case RewardType.Gold:
                    return $"{RewardAmount}G";
                case RewardType.Item:
                    return $"{ItemData.Name} x {RewardAmount}";
            }
            return "";
        }
    }
}
