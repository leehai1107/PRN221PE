using BusinessObjects;
using Repository;

namespace Services
{
    public class SystemAccountSvc
    {
        private SystemAccountRepo repo;
        public SystemAccountSvc()
        {
            repo = new SystemAccountRepo();
        }

        public SystemAccount GetSystemAccountByEmail(string email)
        {
            return repo.GetSystemAccountByAccountEmail(email);
        }
    }
}
