using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class PaintingDAO
    {
        private OilPaintingArt2024DbContext dbContex = new OilPaintingArt2024DbContext();

        public List<OilPaintingArt> GetOilPaintingArts()
        {
            return dbContex.OilPaintingArts.Include(o => o.Supplier).ToList();
        }

        public void DeleteOilPaintingArt(int id)
        {
            dbContex.OilPaintingArts.Remove(dbContex.OilPaintingArts.Find(id));
            dbContex.SaveChanges();
        }
        public void AddOilPaintingArt(OilPaintingArt oilPaintingArt)
        {
            dbContex.OilPaintingArts.Add(oilPaintingArt);
            dbContex.SaveChanges();
        }
        public void UpdateOilPaintingArt(OilPaintingArt oilPaintingArt)
        {
            dbContex.Entry(oilPaintingArt).State = EntityState.Modified;
            dbContex.OilPaintingArts.Update(oilPaintingArt);
            dbContex.SaveChanges();
        }

        public OilPaintingArt GetOilPaintingArtById(int id)
        {
            return dbContex.OilPaintingArts.Include(o => o.Supplier).Where(o => o.OilPaintingArtId == id).FirstOrDefault();
        }
    }
}
