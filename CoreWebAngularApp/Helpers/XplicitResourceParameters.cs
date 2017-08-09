namespace CoreWebAngularApp.Helpers
{
    public class XplicitResourceParameters
    {
        private int _pageSize = 10;
        const int MaxPageSize = 20;
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        // used for filtering 
        public string CompanyName { get; set; }

        // used for searching 
        public string SearchQuery { get; set; }

        // used for sorting
        public string OrderBy { get; set; } = "Name";

        // used for data shaping
        public string Fields { get; set; }

    }
}