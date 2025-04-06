import React, { useEffect, useState } from 'react';

interface Article {
  contentId: string;
  title: string;
}

const Recommendations = () => {
  const [articles, setArticles] = useState<Article[]>([]);
  const [selectedArticle, setSelectedArticle] = useState<Article | null>(null);
  const [allArticles, setAllArticles] = useState<Article[]>([]);

  const [recs, setRecs] = useState<{
    contentBased: string[];
    collaborative: string[];
  } | null>(null);

  useEffect(() => {
    // Fetch filtered list for dropdown
    fetch('http://localhost:4000/api/recommendations/articles')
      .then((res) => res.json())
      .then((data) => setArticles(data));

    // Fetch full list for lookup/display
    fetch('http://localhost:4000/api/recommendations/all-articles')
      .then((res) => res.json())
      .then((data) => setAllArticles(data));
  }, []);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!selectedArticle) return;

    console.log('📤 Fetching recs for:', selectedArticle.contentId);

    fetch(
      `http://localhost:4000/api/recommendations/${selectedArticle.contentId}`
    )
      .then((res) => res.json())
      .then((data) => setRecs(data));
  };

  // Map contentId to title for displaying rec titles
  const articleMap = Object.fromEntries(
    allArticles.map((a) => [a.contentId, a.title])
  );

  return (
    <div className="p-4 max-w-xl mx-auto">
      <form onSubmit={handleSubmit}>
        <label htmlFor="article" className="block mb-2 text-lg font-semibold">
          Select an Article:
        </label>
        <select
          id="article"
          className="w-full p-2 border rounded mb-4"
          value={selectedArticle?.contentId.toString() || ''}
          onChange={(e) => {
            const selected = articles.find(
              (a) => a.contentId.toString() === e.target.value
            );
            console.log('🔽 Selected:', e.target.value, selected);
            setSelectedArticle(selected ?? null);
          }}
        >
          <option value="">-- Choose an article --</option>
          {articles.map((article) => (
            <option key={article.contentId} value={String(article.contentId)}>
              {article.title}
            </option>
          ))}
        </select>
        <button
          type="submit"
          className="bg-blue-600 text-white px-4 py-2 rounded"
        >
          Get Recommendations
        </button>
      </form>

      {recs && (
        <div className="mt-6">
          <h2 className="text-xl font-bold mb-2">
            Content-Based Recommendations:
          </h2>
          <ul className="list-disc ml-5">
            {recs.contentBased.map((id, index) => (
              <li key={index}>{articleMap[id] ?? id}</li>
            ))}
          </ul>

          <h2 className="text-xl font-bold mt-4 mb-2">
            Collaborative Recommendations:
          </h2>
          <ul className="list-disc ml-5">
            {recs.collaborative.map((id, index) => (
              <li key={index}>{articleMap[id] ?? id}</li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
};

export default Recommendations;
