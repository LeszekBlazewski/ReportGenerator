namespace ReportGenerator.Utilities.Parsers
{
    class ParserFactory
    {
        // based on parameter returns one of the parsers - XML, JSON, CSV

        public enum ParserSort
        {
            XMLParser,
            JSONParser,
            CSVParser
        }

        public virtual IParser CreateParser(ParserSort parserSort)
        {
            IParser parser = null;

            switch (parserSort)
            {
                case ParserSort.XMLParser:
                    parser = new XMLParser();
                    break;
                case ParserSort.JSONParser:
                    parser = new JSONParser();
                    break;
                case ParserSort.CSVParser:
                    parser = new CSVParser();
                    break;
            }

            return parser;
        }
    }
}
