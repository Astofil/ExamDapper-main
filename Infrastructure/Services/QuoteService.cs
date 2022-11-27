// namespace Infrastructure.Services;
// using Domain.Dtos;

using Domain.Dtos;
using Dapper;
using Npgsql;
public class QuoteService
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Quotes;User Id=postgres;Password=151204;";

    //Get All Quotes
    public List<Quote> GetQuotes()
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Select * from Quotes";
            var result = conn.Query<Quote>(sql).ToList();
            return result;
        }
    }

    public int InsertQuote(Quote quote)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql =
                $"Insert Into Quotes(Author,QuoteText,Category_Id) VALUES" +
                $"('{quote.Author}', " +
                $"'{quote.QuoteText}', " +
                $"'{quote.Category_Id}')";
            var result = conn.Execute(sql);
            return result;
        }
        
    }
    public int UpdateQuote(Quote quote)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = 
                $"Update Quotes SET" +
                $"('{quote.Author}', " +
                $"'{quote.QuoteText}', " +
                $"'{quote.Equals}')";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public int DeleteQuote(int id)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = $"delete * from Quotes WHERE id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public List<Quote> GetQuoteByCategory(int id)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = $"SELECT * FROM Quotes Full Outer Join Categories ON Quotes.id = Categories.Id ";
            var result = conn.Query<Quote>(sql).ToList();
            return result;
        }
    }

        public List<Quote> GetRandomQuote()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"Select QuoteText From Quotes ORDER BY RAND() LIMIT 1";
                var result = conn.Query<Quote>(sql).ToList();
                return result;
            }
        }
}