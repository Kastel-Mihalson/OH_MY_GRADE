namespace OH_MY_GRADE.Other
{
    public class Repository
    {
        private List<User> _users;
        private List<Account> _accounts;
        private List<History> _histories;
        private PrintData _printData;

        public Repository()
        {
            var seedFactory = new SeedFactory();
            _users = seedFactory.Users;
            _accounts = seedFactory.Accounts;
            _histories = seedFactory.Histories;
            _printData = new PrintData();
        }

        /// <summary>
        /// Метод получения всех записей пользователей
        /// </summary>
        public void SelectAllUsers()
        {
            _printData.ShowUsersTableTitle();
            _printData.ShowUserTableData(_users);
        }

        /// <summary>
        /// Метод получения всех записей счетов
        /// </summary>
        public void SelectAllAccount()
        {
            _printData.ShowAccountTableTitle();
            _printData.ShowAccountTableData(_accounts);
        }

        /// <summary>
        /// Метод получения всех записей истории операций
        /// </summary>
        public void SelectAllHistory()
        {
            _printData.ShowHistoryTableTitle();
            _printData.ShowHistoryTableData(_histories);
        }

        /// <summary>
        /// Получение данных пользователя по логину и паролю
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <returns></returns>
        public void SelectUserByLoginAndPassword(string login, string password)
        {
            var user = _users.Where(i => i.Login == login && i.Password == password).FirstOrDefault();

            _printData.ShowUsersTableTitle();

            if (user == null)
            {
                Console.WriteLine("Not found data...");
            } else
            {
                _printData.ShowUserTableData(new List<User> { user });
            }
        }

        /// <summary>
        /// Метод получения всех счетов пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        public void SelectAllAccountsByUserId(int userId)
        {
            var accounts = _accounts.Where(i => i.UserId == userId).ToList();

            _printData.ShowAccountTableTitle();

            if (accounts == null)
            {
                Console.WriteLine("Not found data...");
            } else
            {
                _printData.ShowAccountTableData(accounts);
            }
        }

        /// <summary>
        /// Метод получения всех счетов пользователя с историей операций по ним
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        public void SelectUserAllAccountsWithHistoryByUserId(int userId)
        {
            var accounts = _accounts.Where(i => i.UserId == userId).ToList();

            if (accounts == null)
            {
                Console.WriteLine("Not found data...");
            } else
            {
                foreach (var account in accounts)
                {
                    _printData.ShowAccountTableTitle();
                    _printData.ShowAccountTableData(new List<Account> { account });

                    Console.WriteLine();
                    var histories = _histories
                        .Where(i => i.AccountId == account.Id)
                        .OrderByDescending(o => o.OperationDate)
                        .ToList();

                    _printData.ShowHistoryTableTitle();

                    if (histories == null)
                    {
                        Console.WriteLine("Not found data...");
                    } else
                    {
                        _printData.ShowHistoryTableData(histories);
                        Console.WriteLine();
                    }
                }
            }
        }

        /// <summary>
        /// Метод получения данных о всех операциях счета с указанием владельца каждого счета
        /// </summary>
        public void SelectAllInputOpertaionWithUser()
        {
            var data = _histories
                .Where(i => i.OpertationType == OpertationType.Input)
                .Join(_accounts, h => h.AccountId, a => a.Id, (h, a) => new
                {
                    OperationId = h.Id,
                    OperationType = h.OpertationType,
                    OperationDate = h.OperationDate,
                    OperationAmount = h.Amount,
                    TotalAmount = a.Amount,
                    AccountId = a.Id,
                    UserId = a.UserId
                })
                .OrderBy(o => o.UserId)
                .Join(_users, ha => ha.UserId, u => u.Id, (ha, u) => new
                {
                    OperationDate = ha.OperationDate,
                    OperationAmount = ha.OperationAmount,
                    TotalAmount = ha.TotalAmount,
                    AccountId = ha.AccountId,
                    UserName = u.MiddleName + " " + u.FirstName
                })
                .ToList();

            if (data == null)
            {
                Console.WriteLine("Not found data...");
            } else
            {
                Console.WriteLine(new string('-', 20 + 20 + 15 + 10 + 25 + 6));
                Console.WriteLine("|{0,20}|{1,20}|{2,15}|{3,10}|{4,25}|",
                    "OperationDate", "OperationAmount", "TotalAmount", "AccountId", "UserName");
                Console.WriteLine(new string('-', 20 + 20 + 15 + 10 + 25 + 6));

                foreach (var item in data)
                {
                    Console.WriteLine("|{0,20}|{1,20}|{2,15}|{3,10}|{4,25}|",
                    item.OperationDate.ToShortDateString(),
                    item.OperationAmount,
                    item.TotalAmount,
                    item.AccountId,
                    item.UserName);
                }
            }
        }

        public void SelectUserWithAccountAmountGreaterThenValue(decimal amount)
        {
            var data = _accounts
                .Where(i => i.Amount > amount)
                .Join(_users, a => a.UserId, u => u.Id, (a, u) => new
                {
                    UserName = u.FirstName + " " + u.LastName,
                    RegDate = u.RegistrationDate,
                    Phone = u.Phone,
                    Serial = u.PassportData.Serial,
                    Number = u.PassportData.Number,
                    Login = u.Login,
                    Pass = u.Password,
                    AccId = a.Id,
                    AccAmount = a.Amount
                })
                .OrderByDescending(o => o.UserName)
                .ToList();

            if (data == null)
            {
                Console.WriteLine("Not found data...");
            } else
            {
                Console.WriteLine(new string('-', 24 + 15 + 8 + 8 + 8 + 12 + 15 + 8 + 12 + 10));
                Console.WriteLine("|{0,24}|{1,15}|{2,8}|{3,8}|{4,8}|{5,12}|{6,15}|{7,8}|{8,12}|",
                    "UserName", "RegDate", "Phone", "Serial", "Number", "Login", "Pass", "AccId", "AccAmount");
                Console.WriteLine(new string('-', 24 + 15 + 8 + 8 + 8 + 12 + 15 + 8 + 12 + 10));

                foreach (var item in data)
                {
                    Console.WriteLine("|{0,24}|{1,15}|{2,8}|{3,8}|{4,8}|{5,12}|{6,15}|{7,8}|{8,12}|",
                    item.UserName,
                    item.RegDate.ToShortDateString(),
                    item.Phone,
                    item.Serial,
                    item.Number,
                    item.Login,
                    item.Pass,
                    item.AccId,
                    item.AccAmount);
                }
            }
        }
    }
}
