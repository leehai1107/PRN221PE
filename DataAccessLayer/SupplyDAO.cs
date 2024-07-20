using BusinessObjects;

namespace DataAccessLayer
{
    public class SupplyDAO
    {
        private OilPaintingArt2024DbContext dbContex = new OilPaintingArt2024DbContext();

        public List<SupplierCompany> GetSuppliers()
        {
            return dbContex.SupplierCompanies.ToList();
        }
    }
}
