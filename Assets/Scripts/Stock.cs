public struct Stock
{
    public string name;
    private int minimumPrice;
    private bool reverseIndex;
    private int indexMultiplier;

    public Stock(string name, int minimumPrice, int indexMultiplier, bool reverseIndex = false)
    {
        this.name = name;
        this.minimumPrice = minimumPrice;
        this.reverseIndex = reverseIndex;
        this.indexMultiplier = indexMultiplier;
    }

    public int GetLowestPrice()
    {
        return minimumPrice;
    }

    public int GetCurrentPrice(int marketIndex, int maximumMarketIndex)
    {
        return minimumPrice + (indexMultiplier * (reverseIndex ? maximumMarketIndex - marketIndex : marketIndex));
    }
}



