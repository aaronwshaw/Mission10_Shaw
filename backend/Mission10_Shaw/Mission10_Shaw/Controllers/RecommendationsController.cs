using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Shaw.Data;

namespace Mission10_Shaw.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecommendationsController : ControllerBase
{
    private readonly BowlingLeagueContext _context;

    public RecommendationsController(BowlingLeagueContext context)
    {
        _context = context;
    }

    [HttpGet("all-articles")]
    public ActionResult<IEnumerable<object>> GetAllArticles()
    {
        var articles = _context.SharedArticles
            .OrderBy(a => a.Title)
            .Select(a => new
            {
                ContentId = a.ContentId.ToString(),
                a.Title
            })
            .ToList();

        return Ok(articles);
    }


    // GET: api/recommendations/articles
    [HttpGet("articles")]
    public ActionResult<IEnumerable<object>> GetArticles()
    {
        // Get all sourceContentIds that have content-based or collaborative recs
        var contentSourceIds = _context.ContentRecommendations.Select(r => r.SourceContentId);
        var collabSourceIds = _context.CollaborativeRecommendations.Select(r => r.SourceContentId);

        // Combine them into one set
        var allWithRecs = contentSourceIds.Intersect(collabSourceIds).Distinct();

        // Only return articles that are in that set
        var articles = _context.SharedArticles
            .Where(a => allWithRecs.Contains(a.ContentId))
            .OrderBy(a => a.Title)
            .Select(a => new
            {
                ContentId = a.ContentId.ToString(), // ← force string!
                a.Title
            })
            .ToList();


        return Ok(articles);
    }


    // GET: api/recommendations/{contentId}
    [HttpGet("{contentId}")]
    public ActionResult<object> GetRecommendations(long contentId)
    {
        var contentRecs = _context.ContentRecommendations
            .Where(r => r.SourceContentId == contentId)
            .OrderBy(r => r.Rank)
            .Select(r => r.RecommendedContentId)
            .ToList();

        var collabRecs = _context.CollaborativeRecommendations
            .Where(r => r.SourceContentId == contentId)
            .OrderBy(r => r.Rank)
            .Select(r => r.RecommendedContentId)
            .ToList();

        Console.WriteLine($"ContentId = {contentId}");
        Console.WriteLine($"Content-Based Found = {contentRecs.Count}");
        Console.WriteLine($"Collaborative Found = {collabRecs.Count}");

        return Ok(new
        {
            ContentBased = contentRecs.Select(id => id.ToString()).ToList(),
            Collaborative = collabRecs.Select(id => id.ToString()).ToList()
        });

    }

}
