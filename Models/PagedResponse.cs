using Newtonsoft.Json;

namespace hive_admin_web.Models
{



    public class PagedResponse : ApiResponse
    {

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        public PagedResponse(PayloadResponse data, int current_page, int count)
        {
            this.Pagination = new Pagination
            {
                CurrentPage = current_page,
                Count = count,
                Links = new Links()
            };
            this.Data = data;
        }
    }

    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int Count { get; set; }

        public int TotalPages { get; set; }
        public int Total { get; set; }
        public Links? Links { get; set; }
    }

    public class Links
    {
        public Uri? First { get; set; }
        public Uri? Last { get; set; }
        public Uri? Next { get; set; }
        public Uri? Previous { get; set; }
    }
}
