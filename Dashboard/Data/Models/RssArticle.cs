using System.ServiceModel.Syndication;

namespace Dashboard.Data.Models
{
    public class RssArticle
    {
#pragma warning disable CS8618 
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedDate { get; set; }

        public RssArticle() { }
#pragma warning restore CS8618
        public RssArticle(SyndicationItem item)
        {
            Url = item.BaseUri.ToString();
            Title = item.Title.Text;

            Summary = item.Summary?.Text;
            Author = item.Authors.FirstOrDefault()?.Name;
            PublishedDate = item.PublishDate.DateTime;
        }
    }
}
