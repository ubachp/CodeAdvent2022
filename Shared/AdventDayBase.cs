namespace CodeAdvent2022.Shared
{
    public class AdventDayBase
    {
        public AdventDayBase(string cookie)
        {
            Console.WriteLine(GetType().Name);
            Cookie = cookie;
        }

        protected string Cookie { get; }
    }
}