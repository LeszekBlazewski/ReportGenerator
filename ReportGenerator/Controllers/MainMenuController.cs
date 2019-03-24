using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ReportGenerator.Utilities;
using ReportGenerator.Utilities.Parsers;
using ReportGenerator.ViewModel;

namespace ReportGenerator
{
    class MainMenuController
    {
        private readonly MainView view;
       
        private OrderViewModel viewModel;

        private List<IParser> parsers = new List<IParser>();

        public MainMenuController(MainView view, OrderViewModel viewModel)
        {
            this.view = view;
            this.viewModel = viewModel;
        }

        public void RunMainMenuView()
        {
            Application.Run(view);
        }

        public void InitializeController()
        {
            // assign methods which are run durning interaction with GUI
            view.GetButtonLoadFile().Click += LoadOrdersFromFiles;
            view.GetButtonGenerateReport().Click += GenerateReport;
            view.GetButtonClearOrdersInDatabase().Click += ClearDataBase;

            // Initialize parsers
            ParserFactory parserFactory = new ParserFactory();
            parsers.Add(parserFactory.CreateParser(ParserFactory.ParserSort.CSVParser));
            parsers.Add(parserFactory.CreateParser(ParserFactory.ParserSort.JSONParser));
            parsers.Add(parserFactory.CreateParser(ParserFactory.ParserSort.XMLParser));
        }

        private void LoadOrdersFromFiles(object sender, EventArgs e)
        {
            string[] filenames = view.GetFilenamesOfOrdersToOpen();

            if (filenames == null)
                return;

            List<Order> ordersFromFile = new List<Order>();
            List<string> errorMessages = new List<string>();

            foreach (var file in filenames)
            {
                // get extension of the file, to use proper parser
                string fileExtension = Path.GetExtension(file);

                // try to parse the extension to the predefined enum
                Enum.TryParse(fileExtension.Remove(0, 1).ToUpper(), out FileType fileType);

                //based on the extension of the file, use correct parser to get data and errors regarding parsing
                switch (fileType)
                {
                    case FileType.CSV:
                        ordersFromFile = parsers[0].GetOrdersFromFile(file);
                        errorMessages = ((Parser)parsers[0]).GetErrorMessages();
                        break; 
                    case FileType.JSON:
                        ordersFromFile = parsers[1].GetOrdersFromFile(file);
                        errorMessages = ((Parser)parsers[1]).GetErrorMessages();
                        break;
                    case FileType.XML:
                        ordersFromFile = parsers[2].GetOrdersFromFile(file);
                        errorMessages = ((Parser)parsers[2]).GetErrorMessages();
                        break;
                    default:
                        view.AppendErrorToLogs("Unsupported file extension, please check inserted files !");
                        break;
                }

                // insert read orders into database
                viewModel.AddNewOrders(ordersFromFile);

                // append errors about data which was incorrect during parsing
                view.AppendErrorsToLogs(errorMessages);

                // fetch all inserted orders into database
                List<Order> orders = viewModel.GetAllRequests();

                // update view
                view.UpdateDataGriedView(orders);
            }
        }

        private void GenerateReport(object sender, EventArgs e)
        {
            // get report type from view
            ReportType reportType = view.GetReportTypeToGenerate();
            // get clientID from view
            string clientId = view.GetClientID();

            ReportResult result = ReportResult.Operation_successful;

            switch (reportType)
            {
                case ReportType.Number_of_orders:
                    result = GenerateReportNumberOfOrders();
                    break;
                case ReportType.Number_of_orders_for_client:
                    result = GenerateReportsNumberOfOrdersForClient(clientId);
                    break;
                case ReportType.Total_cost_of_orders:
                    result = GenerateReportTotalCostOfOrders();
                    break;
                case ReportType.Total_cost_of_orders_for_client:
                    result = GenerateReportTotalCostOfOrdersForCLient(clientId);
                    break;
                case ReportType.List_of_all_orders:
                    result = GenerateReportListOfAllReports();
                    break;
                case ReportType.List_of_orders_for_client:
                    result = GenerateReportListOfOrdersForCLient(clientId);
                    break;
                case ReportType.Average_order_price:
                    result = GenerateReportAverageOrderdPrice();
                    break;
                case ReportType.Average_order_price_for_client:
                    result = GenerateReportAverageOrderdPriceForClient(clientId);
                    break;
                case ReportType.Number_of_orders_grouped_by_name:
                    result = GenerateReportOrdersGroupedByName();
                    break;
                case ReportType.Number_of_orders_grouped_by_name_for_client:
                    result = GenerateReportOrdersGroupedByNameForCLient(clientId);
                    break;
                case ReportType.Orders_in_specified_price_range:
                    result = GenerateReportOrderInSpecificPriceRange();
                    break;
                case ReportType.Show_raw_orders_in_database:
                    result = PullRawRequestsFromDatabase();
                    break;
            }

            switch (result)
            {
                case ReportResult.Operation_successful:
                    view.AppendErrorToLogs("Report generated successfuly !");
                    break;
                case ReportResult.Client_Id_wrong:
                    view.AppendErrorToLogs("Please check provided clientId !");
                    break;
                case ReportResult.Price_Bounds_incorrect:
                    view.AppendErrorToLogs("Please check provided price bounds !");
                    break;
            }
        }

        private ReportResult GenerateReportNumberOfOrders()
        {
            int ordersQuantity = viewModel.GetNumberOfOrders();
            view.AppendReportResultToLog("Number of orders for current data set in database: " + ordersQuantity);
            return ReportResult.Operation_successful;
        }

        private ReportResult GenerateReportsNumberOfOrdersForClient(string clientId)
        {
            // validate clientID
            bool isClientIdValid = view.ValidateClientID(clientId);

            if(isClientIdValid)
            {
                int ordersQuantity = viewModel.GetNumberOfOrdersForSpecificClient(clientId);
                view.AppendReportResultToLog("Number of orders for client with id: " + clientId + " equals: " + ordersQuantity);
                return ReportResult.Operation_successful;
            }
            return ReportResult.Client_Id_wrong;
        }

        private ReportResult GenerateReportTotalCostOfOrders()
        {
            decimal totalPriceOfOrders = viewModel.GetTotalPriceOfOrders();
            view.AppendReportResultToLog("Total price of orders stored in database: " + totalPriceOfOrders);
            return ReportResult.Operation_successful;
        }

        private ReportResult GenerateReportTotalCostOfOrdersForCLient(string clientId)
        {
            // validate clientID
            bool isClientIdValid = view.ValidateClientID(clientId);

            if(isClientIdValid)
            {
                decimal totalPriceOfOrdersForCLient = viewModel.GetTotalPriceOfOrdersForSpecificClient(clientId);
                view.AppendReportResultToLog("Total price of orders for client with id: " + clientId + " equals: " + totalPriceOfOrdersForCLient);
                return ReportResult.Operation_successful;
            }
            return ReportResult.Client_Id_wrong;
        }

        private ReportResult GenerateReportListOfAllReports()
        {
            List<Order> orders = viewModel.GetAllOrders();
            view.UpdateDataGriedView(orders);
            view.AppendReportResultToLog("List of all orders for current loaded files has been displayed in the table above");
            return ReportResult.Operation_successful;
        }

        private ReportResult GenerateReportListOfOrdersForCLient(string clientId)
        {
            bool isClientIdValid = view.ValidateClientID(clientId);

            if (isClientIdValid)
            {
                List<Order> orders = viewModel.GetAllOrdersForSpecificClient(clientId);
                view.UpdateDataGriedView(orders);
                view.AppendReportResultToLog("List of all orders for client with id: " + clientId + " for current loaded files has been displayed in the table above");
                return ReportResult.Operation_successful;
            }
            return ReportResult.Client_Id_wrong;
        }

        private ReportResult GenerateReportAverageOrderdPrice()
        {
            decimal averageOrderPrice = viewModel.GetAveragePriceOfOrder();
            view.AppendReportResultToLog("Average price of order stored in database: " + averageOrderPrice);
            return ReportResult.Operation_successful;
        }

        private ReportResult GenerateReportAverageOrderdPriceForClient(string clientId)
        {
            bool isClientIdValid = view.ValidateClientID(clientId);

            if (isClientIdValid)
            {
                decimal averageOrderPriceForCLient = viewModel.GetAveragePriceOfOrderOfSpecificClient(clientId);
                view.AppendReportResultToLog("Average price of order for client with id: " + clientId + " equals " + averageOrderPriceForCLient);
                return ReportResult.Operation_successful;
            }
            return ReportResult.Client_Id_wrong;
        }

        private ReportResult GenerateReportOrdersGroupedByName()
        {
            List<Order> orders = viewModel.GetNumberOfOrdersGroupedByName();
            view.UpdateDataGriedView(orders);
            view.AppendReportResultToLog("List of orders grouped by name for current loaded files has been displayed in the table above");
            return ReportResult.Operation_successful;
        }

        private ReportResult GenerateReportOrdersGroupedByNameForCLient(string clientId)
        {
            bool isClientIdValid = view.ValidateClientID(clientId);

            if (isClientIdValid)
            {
                List<Order> orders = viewModel.GetNumberOfOrdersGroupedByNameForSpecificClient(clientId);
                view.UpdateDataGriedView(orders);
                view.AppendReportResultToLog("List of orders grouped by name for client with id: " + clientId + "has been displayed in the table above");
                return ReportResult.Operation_successful;
            }
            return ReportResult.Client_Id_wrong;
        }

        private ReportResult GenerateReportOrderInSpecificPriceRange()
        {
            bool arePriceBoundsCorrect = view.ValidateDecimalBounds();

            if(arePriceBoundsCorrect)
            {
                decimal lowerBound = view.GetLowerBound();
                decimal upperBound = view.GetUpperBound();

                List<Order> orders = viewModel.GetOrdersInGivenRange(lowerBound, upperBound);

                view.UpdateDataGriedView(orders);
                view.AppendReportResultToLog("List of orders in price range: " + lowerBound + "-" + upperBound + " has been displayed in the table above");
                return ReportResult.Operation_successful;
            }
            return ReportResult.Price_Bounds_incorrect;
        }

        private ReportResult PullRawRequestsFromDatabase()
        {
            List<Order> orders = viewModel.GetAllRequests();

            view.UpdateDataGriedView(orders);
            view.AppendReportResultToLog("Request list of current files has been displayed in the table above");
            return ReportResult.Operation_successful;
        }

        private void ClearDataBase(object sender, EventArgs e)
        {
            // delete all records from database 
            viewModel.EmptyDatabase();
            // update view with empty list to display
            List<Order> emptyOrderList = new List<Order>();
            view.UpdateDataGriedView(emptyOrderList);
        }

    }
}
