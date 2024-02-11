using Dashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Dashboard.Data.Services
{
    public class RssService
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public RssService(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<RssFeed?> GetFeedFromUrl(string url)
        {
            var feed = await GetSyndicationFeed(url);
            return feed == null ? null : new RssFeed(feed);
        }
        public async Task<List<RssArticle>?> GetRssFeedArticles(RssFeed rssFeed)
        {
            var feed = await GetSyndicationFeed(rssFeed.Url);
            return feed?.Items.Select(x => new RssArticle(x)).ToList();
        }
        public async Task<SyndicationFeed?> GetSyndicationFeed(string url)
        {
            using XmlReader reader = XmlReader.Create(url);
            return await Task.Run(() => SyndicationFeed.Load(reader));
        }
    }
}
