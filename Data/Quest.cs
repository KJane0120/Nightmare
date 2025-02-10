using Newtonsoft.Json;
using Nightmare.Data;

namespace Nightmare
{
    public enum QuestType
    {
        ChapterClear = 0,
        Equip = 1,
        UseItem = 2,
        KillBoss = 3,
        AllClear=4,
    }

    public class Quest
    {
        public long Id { get; set; }
        public long QuestGroupId { get; set; }
        public string? Title { get; set; } // 퀘스트 제목
        public string? Desc { get; set; } // 퀘스트 내용
        public Condition Condition { get; set; } // 퀘스트 클리어 조건
        public Reward[] Rewards { get; set; } //퀘스트 보상
        public bool IsProgress { get; set; } //퀘스트 진행중인지

        [JsonIgnore]
        public bool IsClear
        {
            get => isClear;
            set
            {
                isClear = value;
            }
        }

        [JsonProperty]
        private bool isClear = false;

        public void DisplayQuestInfo()
        {
            Console.WriteLine($"{Title}\n");
            Console.WriteLine(Desc);
        }
    }


    public class Condition
    {
        public QuestType QuestType { get; set; }

        public long ConditionValue { get; set; }

        public bool IsClear(QuestType questType)
        {
            switch (questType)
            {
                case QuestType.ChapterClear:
                // 스테이지 클리어
                case QuestType.KillBoss:
                    //보스 처치
                    return DataManager.Instance.BossDatas[ConditionValue].IsLive;
                case QuestType.Equip:
                    //첫 아이템 장착
                    return false;
                case QuestType.UseItem:
                    //첫 아이템 장착 
                    return false;
                default:
                    return false;
            }
        }
    }


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

        public void ReceiveReward()
        {
            switch (RewardType)
            {
                case RewardType.Gold:
                    GameManager.Instance.Player.Gold.PlayerGold += (int)RewardAmount;
                    break;
                case RewardType.Item:
                    Item RewardItem = DataManager.Instance.ItemDatas[RewardId];
                    DataManager.Instance.HaveItems.Add((int)RewardId, RewardItem);
                    break;
            }
        }
    }
}
