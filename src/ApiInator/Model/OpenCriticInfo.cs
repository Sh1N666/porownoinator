namespace ApiInator.Model;

public class OpenCriticInfo
{
    public Guid Id { get; set; }
    public string OpenCriticId { get; set; }
    public double MedianScore { get; set; }
    public double PercentRecomended { get; set; }
    public bool HasLootboxes { get; set; }
}