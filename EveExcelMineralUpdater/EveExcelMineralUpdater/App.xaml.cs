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
                }
                finally
                {
                    cfgSerializer.CreateDefaultConfigFile();
                }
                
            }
            else
            {
                cfgSerializer.CreateDefaultConfigFile();
            }

            // We initiate the request from prices
            QuickLookRequest quickLookRequest = (QuickLookRequest)ApiRequestFactory.CreateApiRequest(ApiRequestFactory.ApiRequestType.QuickLook);
            quickLookRequest.UseSystem = EveItemIDs.JITA_SYSTEM_ID;
            quickLookRequest.TypeID = EveItemIDs.VELDSPAR_MINERAL_ID;

            ApiHttpRequestBuilder requestBuilder = new ApiHttpRequestBuilder(quickLookRequest);

            if (requestBuilder.ExecuteRequest())
            {
                Console.Out.WriteLine(requestBuilder.Response);
            }
            else
            {
                Console.Out.WriteLine("Error in getting request's response from the API web server.");
            }

            // Show main window
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();

            System.Environment.Exit(0);
        }
    }
}
