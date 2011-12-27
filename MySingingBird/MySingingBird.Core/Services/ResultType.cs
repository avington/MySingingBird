namespace MySingingBird.Core.Services
{
    public class ResultType
    {
        public string TypeName { get; set; }

        public static ResultType Recent
        {
            get { return new ResultType {TypeName = "recent"}; }
        }
    }
}