using Microsoft.AspNetCore.Mvc;
using CMSWebpage.Models;

namespace CMSWebpage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly IEnumerable<Item> test = new[]
        {
            new Item{ItemId = 1, ItemName = "Test1", ItemDescription="item1Desc", CategoryId=1, ImageId=1},
            new Item{ItemId = 2, ItemName = "Test2", ItemDescription="item2Desc", CategoryId=2, ImageId=2},
            new Item{ItemId = 3, ItemName = "Test3", ItemDescription="item3Desc", CategoryId=3, ImageId=3}
        };

        [HttpGet("{id:int}")]
        public Item[] Get(int id)
        {
            Item[] items = test.Where(x => x.ItemId == id).ToArray();
            return items;
        }
    }
}
