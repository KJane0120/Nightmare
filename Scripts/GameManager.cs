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

        private string name;


        public void GameStart()
        {
            Player = new Player();
            Player.Level = new Level();
            Player.Stat = new Stat();
            Player.Gold = new Gold();
            Player.Avd = new Avd();
            Player.Crt = new Crt();

            SetName();
        }

        private void SetName()
        {
            Console.Clear();
            Console.WriteLine("\"늦었다, 늦었어!\"");
            Console.WriteLine("하얀 토끼가 시계를 든 채 어딘가로 달려 갑니다.");
            Console.WriteLine("말을 하는 토끼라니요 ? 어떻게 이런 일이 있을 수 있죠 ?");
            Console.WriteLine("당신은 호기심에 말하는 토끼를 쫓아갑니다.");
            Console.WriteLine("이런, 발 밑을 잘못 디뎌 끝도 없는 굴로 떨어집니다.");
            Console.WriteLine("떨어지고,");
            Console.WriteLine("떨어져서,");
            Console.WriteLine("눈을 뜨면 그곳은…");
            Console.WriteLine("악몽입니다.");
            Console.WriteLine();
            Console.WriteLine("Once Upon a Nightmare");
            Console.WriteLine();
            Console.WriteLine("깜빡, 깜빡.");
            Console.WriteLine("시계 토끼가 당신을 내려다 보고 있습니다.");

            // 이름 설정
            Console.WriteLine();
            Console.WriteLine("시계 토끼: 안녕? 악몽에서 나가고 싶니?");
            Console.WriteLine("시계 토끼: 우선 네 이름을 알려 줘.");
            Console.WriteLine();
            Console.WriteLine("일그러진 동화 속을 유영할 당신의 이름은?");
            name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"안녕하세요, {name}.");
            Console.WriteLine("설정하신 이름으로 주인공이 되시겠습니까?");
            Console.WriteLine();
            Console.WriteLine("1. 저장\n2. 취소");
            Console.Write("\n어느 페이지로 넘어가시겠습니까?\n>>");
            string inputNumber = Console.ReadLine();

            if (int.TryParse(inputNumber, out int number))
            {
                if (number == 1)
                {
                    SaveName(number, name);
                }
                else { SetName(); }
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.");
                SetName();
            }
        }

        private void SetJob() // 직업설정
        {
            Console.WriteLine("");
            Console.WriteLine("어떤 동화를 들어보시겠습니까?\n");
            Console.WriteLine("1. 백설공주와 일곱 번째 난쟁이");
            Console.WriteLine("2. 신데렐라의 새 언니");
            Console.WriteLine("3. 모두가 잠든 성의 하인");
            Console.WriteLine("4. 깊은 바다 속 문어 마녀");
            Console.WriteLine("5. 힘을 잃은 야수");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            string inputNumber = Console.ReadLine();


            // 입력받은 값이 int로 변환이 가능할 때
            if (int.TryParse(inputNumber, out int actionNumber))
            {
                Player.Job = JobChoice(actionNumber);
                MoveNextAction(ActionType.Village);
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.\n다시 직업을 선택해주세요.\n");
                SetJob();
            }
        }

        public Player Player { get; set; }

        private void SaveName(int num, string name)
        {
            switch (num)
            {
                case 1:
                    Player.Name = name;
                    SetJob();
                    break;
                case 2:
                    SetName();
                    break;
            }
        }


        private Job JobChoice(int num)
        {
            var jobStats = new Dictionary<int, (Job job, float BaseAtk, int BaseDef, int Hp, int Mp, int Avd, int Crt)> {
            { 1, (Job.Dwarf,10,5,100,30,10,15) },
            { 2, (Job.NewSister, 15, 5, 70, 30, 10, 15) },
            { 3, (Job.Saison, 12, 7, 100, 20, 10, 15) },
            { 4, (Job.OctopusWitch, 7, 4, 50, 50, 10, 15) },
            { 5, (Job.WildAnimal, 20, 10, 150, 10, 10, 15) }};


            if (jobStats.TryGetValue(num, out var stats))
            {
                Player.Stat.BaseAtk = stats.BaseAtk;
                Player.Stat.BaseDef = stats.BaseDef;
                Player.Stat.Hp = Player.Stat.MaxHp = stats.Hp;
                Player.Stat.Mp = Player.Stat.MaxMp = stats.Mp;
                Player.Avd.PlayerAvd = stats.Avd;
                Player.Crt.PlayerCrt = stats.Crt;
                return stats.job;
            }

            Console.WriteLine("\n잘못된 입력입니다.\n다시 동화를 선택해주세요.\n");
            Console.WriteLine();

            SetJob();
            return Job.None;
        }
    }
}
