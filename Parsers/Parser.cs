namespace Parsers
{
    /// <summary>
    /// Generic Parser class
    /// </summary>
    public class Parser
    {
        public IParseLogic ParseLogic { get; set; }
        private string Data { get; set; }
        public Parser(string _Data)
        {
            Data = _Data;
        }
        public object Parse()
        {
            return ParseLogic.Parse(Data);
        }
    }
}