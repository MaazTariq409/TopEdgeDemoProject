using TopEdgeDemoProject.Data;
using TopEdgeDemoProject.Models;
using TopEdgeDemoProject.Repository.Interfaces;

namespace TopEdgeDemoProject.Repository
{
    public class ScrapRepository : IScrapRepository
    {
        private readonly ScrapingDbContext _context;

        public ScrapRepository(ScrapingDbContext context)
        {
            _context = context;
        }

        public List<ScrapData> GetScrapData()
        {
            return _context.ScrapData.ToList();
        }

        public ScrapData GetScrapDataById(int id)
        {
            try
            {
                var data = _context.ScrapData.FirstOrDefault(x => x.Id == id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get Data", ex);
            }
        }

        public void AddScrapData(ScrapDataDto data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var Entity = new ScrapData();

            try
            {
                Entity.Name = data.Name;
                Entity.ImageUrl = data.ImageUrl;

                _context.ScrapData.Add(Entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Save Scraped Data", ex);
            }
        }

        public void DeleteScrapData(int id)
        {
            try
            {
                var data = _context.ScrapData.Where(x => x.Id == id);
                _context.Remove(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to delete Scraped Data", ex);
            }
            throw new NotImplementedException();
        }

        public void UpdateScrapData(ScrapDataUpdateDto data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var Entity = new ScrapData();

            try
            {
                Entity.Id = data.Id;
                Entity.Name = data.Name;
                Entity.ImageUrl = data.ImageUrl;

                _context.ScrapData.Update(Entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Save Scraped Data", ex);
            }
        }
    }
}
