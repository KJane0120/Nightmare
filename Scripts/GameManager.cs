using System.Runtime.CompilerServices;

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

        public List<(Monster monster, int remainingTurns, String doco, int howmany)> DebuffedMonsters = new List<(Monster, int, String, int)>();
        public List<(Player player, int remainingTurns, String doco, int howmany)> Buffedplayer = new List<(Player, int, String, int)>();

        private Dictionary<int, int> map = new Dictionary<int, int>();

        public bool IsFirstUsePortion { get; set; } = false;

        public void GameClear()
        {
            DataManager.Instance.CurrentStageClear++;
        }


        public void GameStart()
        {

            DataManager.Initialize();

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
            Console.WriteLine();
            Console.WriteLine("로딩중...");
            Thread.Sleep(5000);

            // 이름 설정
            Console.Clear() ;
            Console.WriteLine("깜빡, 깜빡.");
            Console.WriteLine("시계 토끼가 당신을 내려다 보고 있습니다.");            
            Console.WriteLine();
            Console.WriteLine("시계 토끼: 안녕? 악몽에서 나가고 싶니?");
            Console.WriteLine("시계 토끼: 우선 네 이름을 알려 줘.");
            Console.WriteLine();
            Console.WriteLine("일그러진 동화 속을 유영할 당신의 이름은?");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"안녕하세요, {name}.");
            Console.WriteLine("설정하신 이름으로 주인공이 되시겠습니까?");
            Console.WriteLine();
            Console.WriteLine("1. 저장\n2. 취소");

            UtilityManager.InputNumberInRange(1, 2, SuccessInputNumberInRange, SetName, "어느 페이지로 넘어가시겠습니까?");
        }

        private void SuccessInputNumberInRange(int number)
        {
            if (number == 1)
            {
                SaveName(number, name);
            }
            else
            {
                SetName();
            }
        }

        private void SetJob() // 직업설정
        {
            Console.Clear();
            Console.WriteLine("어떤 동화를 들어보시겠습니까?\n");
            Console.WriteLine("1. 백설공주와 일곱 번째 난쟁이");
            Console.WriteLine("2. 신데렐라의 새 언니");
            Console.WriteLine("3. 모두가 잠든 성의 하인");
            Console.WriteLine("4. 깊은 바다 속 문어 마녀");
            Console.WriteLine("5. 힘을 잃은 야수");

            UtilityManager.InputNumberInRange(1, 5, JobInputNumberInRange, SetJob, "듣고싶은 동화를 선택해주세요.");
        }

        private void JobInputNumberInRange(int number)
        {
            if (number >= 1 && number <= 5)
            {
                Player.Job = JobChoice(number);
                Skill skill = new Skill();
                skill.SkillSet(Player);
                MoveNextAction(ActionType.Village);
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

        public void TakeAction()
        {

            if (DebuffedMonsters != null)
            {
                // 디버프 지속 시간 감소 및 제거
                for (int i = DebuffedMonsters.Count - 1; i >= 0; i--)
                {
                    var (monster, remainingTurns, doco, howmany) = DebuffedMonsters[i];
                    remainingTurns--;

                    if (remainingTurns <= 0)
                    {

                        Console.WriteLine($"{monster.Name}의 디버프가 해제됨!");
                        if (doco.Equals("공격력"))
                        {
                            monster.MonsterAttack += howmany;
                        }
                        else if (doco.Equals("방어력"))
                        {
                            monster.MonsterDefense += howmany;
                        }
                        DebuffedMonsters.RemoveAt(i);
                    }
                    else
                    {
                        DebuffedMonsters[i] = (monster, remainingTurns, doco, howmany); // 값 업데이트
                    }
                }
            }
            if (Buffedplayer != null)
            {
                for (int i = Buffedplayer.Count - 1; i >= 0; i--)
                {
                    var (player, remainingTurns, doco, howmany) = Buffedplayer[i];
                    remainingTurns--;

                    if (remainingTurns <= 0)
                    {

                        Console.WriteLine($"{player.Name}의 버프가 해제됨!");
                        if (doco.Equals("공격력"))
                        {
                            Player.Stat.BaseAtk -= howmany;
                        }
                        else if (doco.Equals("방어력"))
                        {
                            Player.Stat.BaseDef -= howmany;
                        }
                        else if (doco.Equals("회피율"))
                        {
                            player.Avd.PlayerAvd -= howmany;
                        }
                        else if (doco.Equals("치명타율"))
                        {
                            player.Crt.PlayerCrt -= howmany;
                        }
                        Buffedplayer.RemoveAt(i);
                    }
                    else
                    {
                        Buffedplayer[i] = (Player, remainingTurns, doco, howmany); // 값 업데이트
                    }
                }
            }



        }
        private Job JobChoice(int num)
        {
            var jobStats = new Dictionary<int, (Job job, float BaseAtk, int BaseDef, int Hp, int Mp, float Avd, float Crt)> {
            { 1, (Job.Dwarf,10,5,100,30,0.1f,0.15f) },
            { 2, (Job.NewSister, 15, 5, 70, 30, 0.1f, 0.15f) },
            { 3, (Job.Saison, 12, 7, 100, 20, 0.1f, 0.15f) },
            { 4, (Job.OctopusWitch, 7, 4, 50, 50, 0.1f, 0.15f) },
            { 5, (Job.WildAnimal, 20, 10, 150, 10, 0.1f, 0.15f) }};


            if (jobStats.TryGetValue(num, out var stats))
            {
                Player.Stat.BaseAtk = stats.BaseAtk;
                Player.Stat.BaseDef = stats.BaseDef;
                Player.Stat.Hp = Player.Stat.MaxHp = stats.Hp;
                Player.Stat.Mp = Player.Stat.MaxMp = stats.Mp;
                Player.Avd.PlayerAvd = stats.Avd;
                Player.Crt.PlayerCrt = stats.Crt;
                Player.QuestGroupId = num;
                return stats.job;
            }                       

            return Job.None;
        }
    }
}
