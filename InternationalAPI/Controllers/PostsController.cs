using InternationalAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternationalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> _stringLopcalizer;
        private readonly IStringLocalizer<SharedResource> _shareResourceLocalizer;

        public PostsController(IStringLocalizer<PostsController> stringLopcalizer, IStringLocalizer<SharedResource> shareResourceLocalizer)
        {
            _stringLopcalizer = stringLopcalizer;
            _shareResourceLocalizer = shareResourceLocalizer;
        }

        [HttpGet]
        [Route("PostControllerResource")]
        public IActionResult GetUsingPostController() 
        {
            //find text
            var article = _stringLopcalizer["Article"];
            var postName = _stringLopcalizer.GetString("Welcome").Value ?? String.Empty;

            return Ok(new 
            { 
                PostType = article.Value,
                PostName = postName,
            });
        }

        [HttpGet]
        [Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            var article = _stringLopcalizer["Article"];
            var postName = _stringLopcalizer.GetString("Welcome").Value ?? String.Empty;
            var todayIs = string.Format(_shareResourceLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                TodayIs = todayIs,
            });
        }

    }

}
