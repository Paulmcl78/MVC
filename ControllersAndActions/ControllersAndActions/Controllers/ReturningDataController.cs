using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class ReturningDataController : Controller
    {


        /// <summary>
        /// Causes the browser to prompt the user to save the file. There are three parameters to the over load of the file
        /// method, filename (required), contenttype (required) and fileDownloadName (optional)
        /// </summary>
        /// <returns></returns>
        public FileResult AnnualReport()
        {
            string filename = @"c:\AnnualReport.pdf";
            string contentType = "application/pdf";
            string downloadname = "AnnualReport2011.pdf";

            return File(filename, contentType, downloadname);

        }


        /// <summary>
        /// We do not need to manipulate the data since the serialization is taken care of by JsonResult class
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonData()
        {
            StoryLink[] stories = GetAllStories();

            return Json(stories);

        }


        /// <summary>
        /// Returning XML data from an action method is very simple, especially when you are using
        /// LINQ to XML and the XDocument API to generate XML from objects.
        /// </summary>
        /// <returns></returns>
        public ContentResult XMLData()
        {
            StoryLink[] stories = GetAllStories();

            XElement data = new XElement("StoryList", stories.Select(e =>
            {
                return new XElement("Story",
                    new XAttribute("title", e.Title),
                    new XAttribute("description", e.Description),
                    new XAttribute("link", e.Url));
            }));

            return Content(data.ToString(), "text/xml");
        }

        

        /// <summary>
        /// Used for general purpose data type to return text data
        /// </summary>
        /// <returns></returns>
        public ContentResult Index()
        {
            string message = "This is plain text";

            return Content(message, "text/plain", Encoding.Default);
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
