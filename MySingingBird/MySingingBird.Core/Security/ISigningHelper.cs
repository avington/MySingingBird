namespace MySingingBird.Core.Security
{
    public interface ISigningHelper
    {
        string SignKey(string signingKey);
    }
}