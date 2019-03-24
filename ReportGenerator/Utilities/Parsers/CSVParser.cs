using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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
                while (csv.Read())
                {
                    try
                    {
                        Order order = csv.GetRecord<Order>();
                        orders.Add(order);
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
            }
            ValidateCsvData();
            return orders;
        }

        private void ValidateCsvData()
        {
            var clientIdRegex = new Regex(@"^[\p{L}0-9]{1,6}$");
            var nameRegex = new Regex(@"^[\p{L}0-9 ]{1,255}$");

            List<Order> ordersToRemove = new List<Order>();

            for (int i = 0; i < orders.Count; i++)
            {
                bool isClientIdValid = clientIdRegex.IsMatch(orders[i].ClientId);
                bool isRequestNameValid = nameRegex.IsMatch(orders[i].Name);

                if (!isClientIdValid || !isRequestNameValid)
                {
                    if(!isClientIdValid)
                        errorMessages.Add("ClientId at position " + i + " with name:'" + orders[i].ClientId + "' is unvalid. Order removed !");
                    else
                        errorMessages.Add("Request name at position " + i + " with name:'" + orders[i].Name + "' is unvalid. Order removed !");

                    ordersToRemove.Add(orders[i]);
                }
            }

            orders.RemoveAll(x => ordersToRemove.Contains(x));
        }
    }
}
