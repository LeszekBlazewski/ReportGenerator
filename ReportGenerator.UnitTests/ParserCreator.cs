using ReportGenerator.Utilities.Parsers;
using static ReportGenerator.Utilities.Parsers.ParserFactory;

namespace ReportGenerator.UnitTests
{
    /// <summary>
    /// Responsible for creating parsers used in tests
    /// Reduces code needed to obtain a parser.
    /// </summary>
    class ParserCreator
    {
        private static ParserFactory parserFactory = new ParserFactory();

        public static IParser GetParser(ParserSort parserSort)
        {
            return parserFactory.CreateParser(parserSort);
        }
    }
}
