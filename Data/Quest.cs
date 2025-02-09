using Newtonsoft.Json;
using Nightmare.Data;

namespace Nightmare
{
    public enum QuestType
    {
        //퀘스트 타입
    }

    public class Quest
    {
        public long Id { get; set; }
        public string? Title { get; set; } // 퀘스트 제목
        public string? Desc { get; set; } // 퀘스트 내용
        public QuestCondition QuestCondition { get; set; } // 퀘스트 타입
        public Reward[] Rewards { get; set; } //퀘스트 보상
        public bool IsProgress { get; set; } //퀘스트 진행중인지

        [JsonIgnore]
        public bool IsClear
        {
            get => isClear;
            set {
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


    public class QuestCondition
    {
        // 몬스터 처치?
        // 장비장착
        // 능력치 상승

        // 
        //public int ConditionValue;

        //public bool IsClear(QuestType questType)
        //{
        //    switch(questType)
        //    {
        //        default:
        //            return false;
        //    }
        //}
    }

    public class Reward
    {
        public long ItemId {get; set;}
        public int ItemCount { get; set; }
        public long GoldAmount { get; set; }

        [JsonIgnore]
        public Item RewardItem => DataManager.Instance.ItemDatas[ItemId];
    }
}
