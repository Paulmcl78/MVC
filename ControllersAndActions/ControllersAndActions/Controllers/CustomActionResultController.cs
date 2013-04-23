using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using ControllersAndActions.CustomActionResult;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class CustomActionResultController : Controller
    {

        /// <summary>
        /// To use out custom action result we simply create a new instance of the strongly typed
        /// class and pass in the required parameters.
        /// </summary>
        /// <returns></returns>
        public RssActionResult RSS()
        {
            StoryLink[] stories = GetAllStories();

            return new RssActionResult<StoryLink>("My Stories", stories, e =>
            {
                return new XElement("item",
                    new XAttribute("title", e.Title),
                    new XAttribute("description", e.Description),
                    new XAttribute("link", e.Url));
            });
        }


        #region private methods
        private StoryLink[] GetAllStories()
        {
            return new StoryLink[] { 
                new StoryLink { Title = "First example story", Description = "This is the first example story", Url = "/story/1" }, 
                new StoryLink { Title = "Second example story", Description = "This is the second example story", Url = "/story/2" } ,
                new StoryLink { Title = "Thrid example story", Description = "This is the third example story", Url = "/story/3" } 
            };

        }

        #endregion

    }
}
