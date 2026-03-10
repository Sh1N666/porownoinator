namespace ApiInator.Model;

public class HowLongToBeatInfo
{
    public Guid Id { get; set; }
    public string HowLongToBeatId {get; set;}
    public double Completionist { get; set; }
    public double MainStory { get; set; }
    public string MainExtra { get; set; }
    public double Score { get; set; }
    public int Releases { get; set; }
}