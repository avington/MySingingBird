namespace MySingingBird.Core.Services
{
    public class MathService : IMathService
    {
        public decimal CalculatePercent(decimal items, decimal totalTweets)
        {
            decimal percentReplies = (items / totalTweets) ;
            return percentReplies;
        } 
    }
}