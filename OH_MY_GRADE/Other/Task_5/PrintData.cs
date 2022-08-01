namespace OH_MY_GRADE.Other
{
    public class PrintData
    {
        public void ShowUsersTableTitle()
        {
            Console.WriteLine("-- TABLE USERS --");
            Console.WriteLine(new string('-', 4 + 15 + 12 + 15 + 8 + 7 + 7 + 11 + 12 + 15 + 11));
            Console.WriteLine("|{0,4}|{1,15}|{2,12}|{3,15}|{4,8}|{5,7}|{6,7}|{7,11}|{8,12}|{9,15}|",
                "Id", "Middle name", "First name", "Last name", "Phone", "Serial", "Number", "RegDate", "Login", "Password");
            Console.WriteLine(new string('-', 4 + 15 + 12 + 15 + 8 + 7 + 7 + 11 + 12 + 15 + 11));
        }

        public void ShowUserTableData(List<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine("|{0,4}|{1,15}|{2,12}|{3,15}|{4,8}|{5,7}|{6,7}|{7,11}|{8,12}|{9,15}|",
                item.Id,
                item.MiddleName,
                item.FirstName,
                item.LastName,
                item.Phone,
                item.PassportData.Serial,
                item.PassportData.Number,
                item.RegistrationDate.ToShortDateString(),
                item.Login,
                item.Password);
            }
        }

        public void ShowAccountTableTitle()
        {
            Console.WriteLine("-- TABLE ACCOUNTS --");
            Console.WriteLine(new string('-', 4 + 15 + 15 + 15 + 5));
            Console.WriteLine("|{0,4}|{1,15}|{2,15}|{3,15}|",
                "Id", "AccountOpenDate", "Amount", "UserId");
            Console.WriteLine(new string('-', 4 + 15 + 15 + 15 + 5));
        }

        public void ShowAccountTableData(List<Account> accounts)
        {
            foreach (var item in accounts)
            {
                Console.WriteLine("|{0,4}|{1,15}|{2,15}|{3,15}|",
                    item.Id,
                    item.AccountOpenDate.ToShortDateString(), 
                    item.Amount, 
                    item.UserId);
            }
        }

        public void ShowHistoryTableTitle()
        {
            Console.WriteLine("-- TABLE HISTORY --");
            Console.WriteLine(new string('-', 4 + 20 + 15 + 10 + 10 + 6));
            Console.WriteLine("|{0,4}|{1,20}|{2,15}|{3,10}|{4,10}|",
                "Id", "OperationDate", "OpertationType", "Amount", "AccountId");
            Console.WriteLine(new string('-', 4 + 20 + 15 + 10 + 10 + 6));
        }

        public void ShowHistoryTableData(List<History> histories)
        {
            foreach (var item in histories)
            {
                Console.WriteLine("|{0,4}|{1,20}|{2,15}|{3,10}|{4,10}|",
                item.Id, 
                item.OperationDate.ToShortDateString(), 
                item.OpertationType, 
                item.Amount, 
                item.AccountId);
            }
        }
    }
}
