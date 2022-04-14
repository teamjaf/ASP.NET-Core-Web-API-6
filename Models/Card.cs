namespace Card_Api.Models;

public class Card
{
    public Guid id { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public int CVC { get; set; }
}