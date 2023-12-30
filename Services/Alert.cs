using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crud_webapp.Services
{
    public class Alert
    {
        private PageModel page;

        public Alert(PageModel page)
        {
            this.page = page;
        }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Style { get; set; }

        public void ShowMessage(string text, int type = 1)
        {
            page.TempData["Message"] = text;
            switch (type)
            {
                case 2:
                    page.TempData["Title"] = "Info!";
                    page.TempData["Style"] = "alert alert-info alert-dismissible";
                    break;
                case 3:
                    page.TempData["Title"] = "Warning!";
                    page.TempData["Style"] = "alert alert-warning alert-dismissible";
                    break;
                case 4:
                    page.TempData["Title"] = "Error!";
                    page.TempData["Style"] = "alert alert-danger alert-dismissible";
                    break;
                default:
                    page.TempData["Title"] = "Success!"; ;
                    page.TempData["Style"] = "alert alert-success alert-dismissible";
                    break;
            }
        }


    }
}
