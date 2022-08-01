using OH_MY_GRADE.Other;

namespace OH_MY_GRADE.Tasks
{
    public class Task_5
    {
        public void Example()
        {
            var repo = new Repository();

            //repo.SelectAllUsers();
            //repo.SelectAllAccount();
            //repo.SelectAllHistory();
            // Пункт 1.
            //repo.SelectUserByLoginAndPassword("SomeLogin-21", "SomePassword21");
            // Пункт 2.
            //repo.SelectAllAccountsByUserId(1);
            // Пункт 3.
            repo.SelectUserAllAccountsWithHistoryByUserId(1);
            // Пункт 4.
            //repo.SelectAllInputOpertaionWithUser();
            // Пункт 5. 
            //repo.SelectUserWithAccountAmountGreaterThenValue(25000);
        }
    }
}
