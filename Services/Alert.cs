namespace crud_webapp.Services
{
    public class Alert
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Style { get; set; }

        public void SendMessage(string text, int type = 1)
        {
            Message = text;
            switch (type)
            {
                case 2:
                    Title = "Info!";
                    Style = "alert alert-info";
                    break;
                case 3:
                    Title = "Warning!";
                    Style = "alert alert-warning";
                    break;
                case 4:
                    Title = "Error!";
                    Style = "alert alert-danger";
                    break;
                default:
                    Title = "Success!";
                    Style = "alert alert-success";
                    break;
            }
        }


    }
}
