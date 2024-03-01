using TopEdgeDemoProject.Models;

namespace TopEdgeDemoProject.Services
{
    public interface IScrapperService
    {
        public ScrapDataDto Scrapper(string url);
    }
}
