using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class PaintingRepo
    {
        private PaintingDAO _paintingDAO = new PaintingDAO();
        public List<OilPaintingArt> GetPaintings()
        {
            return _paintingDAO.GetOilPaintingArts();
        }
        public void DeletePainting(int id)
        {
            _paintingDAO.DeleteOilPaintingArt(id);
        }
        public void UpdatePainting(OilPaintingArt painting)
        {
            _paintingDAO.UpdateOilPaintingArt(painting);
        }
        public void AddPainting(OilPaintingArt painting)
        {
            _paintingDAO.AddOilPaintingArt(painting);
        }
        public OilPaintingArt GetPaintingById(int id)
        {
            return _paintingDAO.GetOilPaintingArtById(id);
        }
    }
}
