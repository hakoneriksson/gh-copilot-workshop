namespace giturb.Tests;

public class BasketOfUrbsIsReadyToSendTest()
{
    [Fact]
    public void ShouldBeFalse_IfNoUrbs()
    {
        var basket = new BasketOfUrbs { Id = 1 };
        Assert.False(basket.IsReadyToSend(), "Basket is not ready to send");
    }
}