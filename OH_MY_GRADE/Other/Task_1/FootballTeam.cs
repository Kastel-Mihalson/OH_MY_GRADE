namespace OH_MY_GRADE
{
    public class FootballTeam
    {
        private Footballer[] _team { get; set; }
        public Footballer this[int index]
        {
            get => _team[index];
            set
            {
                if (index > _team.Length)
                {
                    var tempTeam = new Footballer[index * 2];
                    _team.CopyTo(tempTeam, 0);
                    tempTeam[index] = value;
                    _team = tempTeam;
                } else
                {
                    _team[index] = value;
                }
            }
        }

        public FootballTeam(int count)
        {
            _team = new Footballer[count];
        }
    }
}
