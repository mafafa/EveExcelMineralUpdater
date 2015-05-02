using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Core;
using Core.Exceptions;
using Data;
using Data.APIRequests;
using EveExcelMineralUpdater.Views;

namespace EveExcelMineralUpdater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            // We read settings from CfgFile
            XmlCfgFile cfgFile = new XmlCfgFile();
            CfgFileSerializer cfgSerializer = new CfgFileSerializer(cfgFile);

            if (File.Exists(cfgFile.ConfigFilePath))
            {
                try
                {
                    cfgSerializer.Load();
                }
                catch (CfgFileNotWellDefinedException exception)
                {
                    //TODO: Show PopUpWindow with error message
                    cfgSerializer.CreateDefaultConfigFile();
                }
                
            }
            else
            {
                cfgSerializer.CreateDefaultConfigFile();
            }

            List<uint> itemIDs = new List<uint>();
            itemIDs.Add(EveItemIDs.OMBER_MINERAL_ID);
            itemIDs.Add(EveItemIDs.GOLDEN_OMBER_MINERAL_ID);
            itemIDs.Add(EveItemIDs.SILVERY_OMBER_MINERAL_ID);
            itemIDs.Add(EveItemIDs.PLAGIOCLASE_MINERAL_ID);
            itemIDs.Add(EveItemIDs.AZURE_PLAGIOCLASE_MINERAL_ID);
            itemIDs.Add(EveItemIDs.RICH_PLAGIOCLASE_MINERAL_ID);
            itemIDs.Add(EveItemIDs.SCORDITE_MINERAL_ID);
            itemIDs.Add(EveItemIDs.CONDENSED_SCORDITE_MINERAL_ID);
            itemIDs.Add(EveItemIDs.MASSIVE_SCORDITE_MINERAL_ID);
            itemIDs.Add(EveItemIDs.VELDSPAR_MINERAL_ID);
            itemIDs.Add(EveItemIDs.CONCENTRATED_VELDSPAR_MINERAL_ID);
            itemIDs.Add(EveItemIDs.DENSE_VELDSPAR_MINERAL_ID);

            List<float> priceList = new List<float>();
            foreach (uint itemID in itemIDs)
            {
                // We initiate the request from prices
                QuickLookRequest quickLookRequest = (QuickLookRequest)ApiRequestFactory.CreateApiRequest(ApiRequestFactory.ApiRequestType.QuickLook);
                quickLookRequest.UseSystem = EveItemIDs.RENS_SYSTEM_ID;
                quickLookRequest.TypeID = itemID;

                ApiHttpRequestBuilder requestBuilder = new ApiHttpRequestBuilder(quickLookRequest);

                if (requestBuilder.ExecuteRequest())
                {
                    QuickLookResponseParser rawResponseParser = new QuickLookResponseParser(requestBuilder.Response);

                    // We parse the answer and order it
                    rawResponseParser.Parse();
                    IOrderedEnumerable<MarketOrder> priceOrderedMarketOrders = rawResponseParser.ParsedMarketOrders.
                        OrderByDescending(marketOrder => marketOrder.Price).ThenByDescending(marketOrder => marketOrder.VolumeRemaining);

                    // We take the highest priced item
                    if (priceOrderedMarketOrders.Count() != 0)
                    {
                        priceList.Add(priceOrderedMarketOrders.ElementAt(0).Price);
                    }
                    else
                    {
                        priceList.Add(0);
                    }
                }
                else
                {
                    Console.Out.WriteLine("Error in getting request's response from the API web server.");
                }
            }

            // We write the prices in the excel spreadsheet
            XlsxSerializer excelSerializer = new XlsxSerializer(cfgFile.ExcelFilePath, cfgFile.ExcelPriceColumn, 
                (int)cfgFile.ExcelPriceRowStart, (int)cfgFile.ExcelPriceRowEnd, priceList);

            excelSerializer.Save();

            // Show main window
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();

            System.Environment.Exit(0);
        }
    }
}
