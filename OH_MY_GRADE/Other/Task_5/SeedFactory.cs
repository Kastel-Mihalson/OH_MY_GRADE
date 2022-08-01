namespace OH_MY_GRADE.Other
{
    public class SeedFactory
    {
        public List<User> Users = new List<User>();
        public List<Account> Accounts = new List<Account>();
        public List<History> Histories = new List<History>();

        public SeedFactory()
        {
            SeedUserData();
            SeedAccountData();
            SeedHistoryData();
        }

        private void SeedUserData()
        {
            int usersCount = Constants.FirstNameList.Count;

            for (int i = 0; i < usersCount; i++)
            {
                Users.Add(new User
                {
                    Id = i + 1,
                    FirstName = Constants.FirstNameList[new Random().Next(0, usersCount)],
                    MiddleName = Constants.MiddleNameList[new Random().Next(0, usersCount)],
                    LastName = Constants.LastNameList[new Random().Next(0, usersCount)],
                    Phone = string.Format("{0:###-###}", new Random().Next(111111, 999999)),
                    PassportData = new Passport
                    {
                        Serial = string.Format("{0:####}", new Random().Next(1111, 9999)),
                        Number = string.Format("{0:######}", new Random().Next(111111, 999999)),
                    },
                    RegistrationDate = new DateTime(
                            new Random().Next(2000, 2022),
                            new Random().Next(1, 12),
                            new Random().Next(1, 31)),
                    Login = $"SomeLogin-{i + 1}",
                    Password = $"SomePassword{i + 1}"
                });
            }
        }
        private void SeedAccountData()
        {
            int accountCount = new Random().Next(Users.Count, Users.Count * 2);

            for (int i = 0; i < accountCount; i++)
            {
                var user = Users[new Random().Next(0, Users.Count)];

                Accounts.Add(new Account
                {
                    Id = i + 1,
                    AccountOpenDate = user.RegistrationDate.AddDays(new Random().Next(30, 90)),
                    Amount = new Random().Next(10_000, 100_000),
                    UserId = user.Id
                });
            }
        }
        private void SeedHistoryData()
        {
            int historyCount = new Random().Next(Accounts.Count * 2, Accounts.Count * 5);

            for (int i = 0; i < historyCount; i++)
            {
                var account = Accounts[new Random().Next(0, Accounts.Count)];

                Histories.Add(new History
                {
                    Id = i + 1,
                    OperationDate = account.AccountOpenDate.AddDays(new Random().Next(1, 366)),
                    OpertationType = new Random().Next(0, 2) == 0 ? OpertationType.Input : OpertationType.Output,
                    Amount = new Random().Next(100, 10000),
                    AccountId = account.Id
                });
            }
        }
    }
}
