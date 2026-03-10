namespace ApiInator.Model;

public class GgDealsInfo
{
    public Guid Id { get; set; }    
    public Price CurrentRetailPrice { get; set; }
    public Price CurrentKeyshopPrice { get; set; }
    public Price HistoricalRetailPrice { get; set; }
    public Price HistoricalKeyshopPrice { get; set; }
    public string Url { get; set; }
}