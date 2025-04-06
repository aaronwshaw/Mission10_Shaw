using Microsoft.AspNetCore.Mvc;

namespace Mission10_Shaw.Data
{
    public class SharedArticle
    {
        public long ContentId { get; set; }
        public string Title { get; set; }
    }

    public class ContentRecommendation
    {
        public int Id { get; set; }
        public long SourceContentId { get; set; }
        public long RecommendedContentId { get; set; }
        public int Rank { get; set; }
    }

    public class CollaborativeRecommendation
    {
        public int Id { get; set; }
        public long SourceContentId { get; set; }
        public long RecommendedContentId { get; set; }
        public int Rank { get; set; }
    }

}
