using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace ReportGenerator.Utilities.Parsers
{
    class CSVParser : Parser
    {
        public override List<Order> GetOrdersFromFile(string filePath)
        {
            using (TextReader reader = File.OpenText(filePath))
            using (CsvReader csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;     // TODO: MAYBE FIX 
                try
                {
                    orders = csv.GetRecords<Order>().ToList();
                }
                catch (HeaderValidationException ex)
                {
                    errorMessages.Add(ex.Message.Remove(39));
                }
                catch (CsvHelper.TypeConversion.TypeConverterException e)
                {
                    errorMessages.Add(e.Message.Remove(58));
                }
            }
            ValidateCsvData();
            return orders;
        }

        public void ValidateCsvData()
        {
            var clientIdRegex = new Regex(@"^[\\p{L}0-9]{1,6}$");       //TODO: CHECK IF THIS IS EVEN FINISHED
            var nameRegex = new Regex(@"^[\\p{L}0-9 ]{1,255}$");

            for (int i = 0; i < orders.Count; i++)
            {
                if (!clientIdRegex.IsMatch(orders[i].ClientId))
                    orders.RemoveAt(i);
                if (!nameRegex.IsMatch(orders[i].Name))
                    orders.RemoveAt(i);
            }
        }
    }
}
