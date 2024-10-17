public class BasketOfUrbs 
{
    public required int Id { get; set; }
    public List<Urb> Urbs { get; set; } = new();

    public bool IsReadyToSend()
    {
        if (Urbs.Count == 0)
        {
            return false;
        }
        if (Urbs.Count == 7)
        {
            throw new Exception("Basket cannot have 7 Urbs");
        }
        if (Urbs.Count >= 10)
        {
            throw new Exception("Basket cannot have more than 10 urbs");
        }
        return true;
    }
}
