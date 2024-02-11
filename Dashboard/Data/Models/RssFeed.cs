using System.Collections.ObjectModel;
using System.ServiceModel.Syndication;

namespace Dashboard.Data.Models;

public class RssFeed
{
#pragma warning disable CS8618 
    public int Id { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public ObservableCollection<RssArticle> Articles { get; set; } = [];

    public RssFeed() { }
#pragma warning restore CS8618
    public RssFeed(SyndicationFeed feed)
    {
        //TODO: 
        Url = feed.BaseUri.ToString();
        Title = feed.Title.Text;
        Description = feed.Description?.Text;

        foreach(var item in feed.Items)
            Articles.Add(new RssArticle(item));
    }
}
