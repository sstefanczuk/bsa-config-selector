namespace BSA.ConfigSelector.Domain
{
    public class ApiUrl
    {
        private readonly string _value;

        public ApiUrl(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
