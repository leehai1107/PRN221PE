using BusinessObjects;

namespace DataAccessLayer
{
    public class SystemAccountDAO
    {
        private OilPaintingArt2024DbContext dbContext;
        public SystemAccountDAO()
        {
            dbContext = new OilPaintingArt2024DbContext();
        }

        public SystemAccount GetSystemAccountByAccountEmail(string email)
        {
            return dbContext.SystemAccounts
                .Where(s => s.AccountEmail == email)
                .FirstOrDefault();
        }

    }
}
