using Domain.Dtos;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class QuoteController
{
    private QuoteService _quoteService;
    public QuoteController()
    {
        _quoteService = new QuoteService();
    }

    [HttpGet]
    public List<Quote> GetQuotes()
    {
        return _quoteService.GetQuotes();
    }

    [HttpPost]
    public int InsertQuote(Quote quote)
    {
        return _quoteService.InsertQuote(quote);
    }

    [HttpPut]
    public int UpdateQuote(Quote quote)
    {
        return _quoteService.UpdateQuote(quote);
    }

    [HttpDelete]
    public int DeleteQuote(int id)
    {
        return _quoteService.DeleteQuote(id);
    }
    
    [HttpGet("Get Quote by Category(Id)")]
    public List<Quote> GetQuoteByCategory(int id)
    {
        return _quoteService.GetQuoteByCategory(id);
    }

    [HttpGet("Get a Random Quote")]
    public List<Quote> GetRandomQuote()
    {
        return _quoteService.GetRandomQuote();
    }
}
 



 