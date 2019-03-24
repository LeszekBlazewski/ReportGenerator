using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ReportGenerator.Utilities.Parsers
{
    class XMLParser : Parser
    {
        public override List<Order> GetOrdersFromFile(string filePath)
        {
            // create new serializer of ordere type
            XmlSerializer ser = new XmlSerializer(typeof(Order));
            XmlReaderSettings settings = GetReaderSettings();

            // Create the XmlReader object.
            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                while (reader.Read())
                {
                    if (reader.Name == "request")
                    {
                        // Try to deserialize object
                        int currentErrorsNumber = errorMessages.Count;  // save current number of errors
                        Order order = (Order)ser.Deserialize(reader);   // errors are automaticaly handled by ValidationEventHandlers
                        if (errorMessages.Count > currentErrorsNumber)  // check if error occured, if yes don't add serialized object
                            continue;

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }

        private XmlReaderSettings GetReaderSettings()
        {
            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, Directory.GetCurrentDirectory() + "\\Properties\\xml_Schema.xsd");
            settings.Schemas = schemas;
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            // capture errors while parsing
            settings.ValidationEventHandler +=
               delegate (object sender, ValidationEventArgs args)
               {
                   errorMessages.Add(args.Message);
               };

            return settings;
        }
    }
}
