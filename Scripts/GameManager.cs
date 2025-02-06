namespace Nightmare
{
    public partial class GameManager
    {
        public static GameManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GameManager();
                }
                return _Instance;
            }

        }

        private static GameManager? _Instance = null;


        public void GameStart()
        {
            MoveNextAction(ActionType.Village);
        }
    }
}
