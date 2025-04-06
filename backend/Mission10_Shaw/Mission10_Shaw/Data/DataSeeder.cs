using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Mission10_Shaw.Data;

public class DataSeeder
{
    public static void Seed(BowlingLeagueContext context)
    {
        if (!context.SharedArticles.Any())
        {
            using var reader = new StreamReader("shared_articles.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var articles = csv.GetRecords<SharedArticle>().ToList();
            context.SharedArticles.AddRange(articles);
        }

        if (!context.ContentRecommendations.Any())
        {
            using var reader = new StreamReader("content_recommendations_clean.csv");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };
            using var csv = new CsvReader(reader, config);
            var contentRecs = csv.GetRecords<ContentRecommendation>().ToList();
            context.ContentRecommendations.AddRange(contentRecs);
        }

        if (!context.CollaborativeRecommendations.Any())
        {
            using var reader = new StreamReader("collaborative_recommendations_clean.csv");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };
            using var csv = new CsvReader(reader, config);
            var collabRecs = csv.GetRecords<CollaborativeRecommendation>().ToList();
            context.CollaborativeRecommendations.AddRange(collabRecs);
        }

        context.SaveChanges();
    }
}
