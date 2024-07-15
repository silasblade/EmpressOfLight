using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmpressOfLight.Services;
using System.Collections.Generic;
using System.Linq;
using EmpressOfLight.Models; 

namespace EmpressOfLight.Controllers
{
    public class RSSFeedController : Controller
    {
        private readonly RSSFeedService _rssFeedService;
        private const int PageSize = 10; 

        public RSSFeedController(RSSFeedService rssFeedService)
        {
            _rssFeedService = rssFeedService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var rssUrl = "https://vnexpress.net/rss/kinh-doanh.rss";
            var allRssFeedItems = await _rssFeedService.GetRssFeedAsync(rssUrl);

            var paginatedRssFeedItems = allRssFeedItems.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            int totalRssFeedItemCount = allRssFeedItems.Count();
            int totalPages = (int)Math.Ceiling((double)totalRssFeedItemCount / PageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedRssFeedItems);
        }
    }
}
