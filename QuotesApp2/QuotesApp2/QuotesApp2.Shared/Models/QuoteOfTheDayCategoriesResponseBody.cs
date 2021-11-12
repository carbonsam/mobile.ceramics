using System.Collections.Generic;

namespace QuotesApp2.Shared.Models
{
    public class QuoteOfTheDayCategoriesResponseBody
    {
        public CategoryContentResponseBody Contents { get; set; }
    }

    public class CategoryContentResponseBody
    {
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public string Inspire { get; set; }

        public string Management { get; set; }

        public string Sports { get; set; }

        public string Life { get; set; }

        public string Funny { get; set; }

        public string Love { get; set; }

        public string Art { get; set; }

        public string Students { get; set; }
    }
}
