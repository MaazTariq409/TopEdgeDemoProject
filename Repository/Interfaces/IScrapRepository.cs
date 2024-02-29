using Microsoft.EntityFrameworkCore.Diagnostics;
using TopEdgeDemoProject.Models;

namespace TopEdgeDemoProject.Repository.Interfaces
{
    public interface IScrapRepository
    {
        public List<ScrapData> GetScrapData();
        public ScrapData GetScrapDataById(int id);
        public void AddScrapData(ScrapDataDto data);
        public void UpdateScrapData(ScrapDataUpdateDto data);
        public void DeleteScrapData(int id);

    }
}
