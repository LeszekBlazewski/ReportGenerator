using System.Collections.Generic;

namespace ReportGenerator.Utilities
{
    /// <summary>
    /// Contains the list of orders read from json file.
    /// </summary>
    public class Request
    {
        public List<Order> requests { get; set; }
    }
}
