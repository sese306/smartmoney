using SmartMoney.Models;

namespace SmartMoney.Messages
{
    public class ShowAccountDetailsMessage
    {
        public Account Account { get; set; }

        public ShowAccountDetailsMessage(Account account)
        {
            Account = account;
        }
    }
}