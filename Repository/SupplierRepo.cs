using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class SupplierRepo
    {
        private SupplyDAO _supplierDAO = new SupplyDAO();
        public List<SupplierCompany> GetSuppliers()
        {
            return _supplierDAO.GetSuppliers();
        }

    }
}
