using Newtonsoft.Json;
using Nightmare.Data;
using System.Text;

namespace Nightmare
{
    public enum QuestType
    {
        ChapterClear = 0,
        Equip = 1,
        UseItem = 2,
        KillBoss = 3,
        AllClear = 4,
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
        public bool IsClear => Condition.IsClear();
        public void DisplayQuestTitle()
        {
            Console.WriteLine($"\n{Id}.{Title}");
        }

        public void DisplayQuestInfo()
        {
            Console.WriteLine($"{Title}");
            Console.WriteLine($"\n{Desc}\n");

            Console.Write($"{Condition.GetConditionText()}\n");

            Console.WriteLine($"\n-보상-");

            foreach (var reward in Rewards)
            {
                reward.DisplayRewardInfo();
            }
        }
    }


    public class Condition
    {
        public QuestType QuestType { get; set; }

        public long ConditionValue { get; set; }

        public string GetConditionText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("-");

            switch(QuestType)
            {
                case QuestType.ChapterClear:
                    sb.Append($"{ConditionValue}챕터 클리어");
                    break;
                case QuestType.Equip:
                    sb.Append($"장비 착용해보기");
                    break;
                case QuestType.UseItem:
                    sb.Append($"포션 사용해보기");
                    break;
                case QuestType.KillBoss:
                    sb.Append($"{DataManager.Instance.BossDatas[ConditionValue].Name}처치");
                    break;
            }

            if(IsClear())
            {
                sb.Append(" 완료!");
            }

            return sb.ToString();
        }

        public bool IsClear()
        {
            switch (QuestType)
            {
                case QuestType.ChapterClear:
                    // 스테이지 클리어
                    return false;
                case QuestType.KillBoss:
                    //보스 처치
                    return !DataManager.Instance.BossDatas[ConditionValue].IsLive;
                case QuestType.Equip:
                    //첫 아이템 장착
                    return false;
                case QuestType.UseItem:
                    //첫 아이템 사용 
                    return false;
                default:
                    return false;
            }
        }
    }
}
