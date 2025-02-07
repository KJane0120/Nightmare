namespace Nightmare
{
    internal class DataManager
    {
        public static DataManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataManager();
                }
                return _Instance;
            }

        }

        private static DataManager? _Instance = null;

        //아이템 리스트
        //싱점 아이템 리스트  
        //장착된 아이템 리스트
        //가지고 있는 아이템 리스트
    }
}
