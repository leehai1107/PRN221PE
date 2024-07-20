using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class SystemAccountRepo
    {
        private SystemAccountDAO _systemAccountDAO = new SystemAccountDAO();
        public SystemAccount GetSystemAccountByAccountEmail(string email)
        {
            return _systemAccountDAO.GetSystemAccountByAccountEmail(email);
        }
    }
}
