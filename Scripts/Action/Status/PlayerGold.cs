namespace Nightmare.Scripts.Action.Status
{
    public class Gold
    {
        public int PlayerGold;
        public Gold()
        {
            PlayerGold = 500;
        }

        public void GoldIncrease(int add) // 골드 증가
        {
            PlayerGold += add;
        }

        public void GoldDecrease(int add) // 골드 감소
        {
            PlayerGold -= add;
        }

    }
}
