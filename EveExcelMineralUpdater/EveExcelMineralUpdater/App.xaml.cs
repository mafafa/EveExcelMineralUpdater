using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Core;
using Core.Exceptions;
using Data;
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
            XMLCfgFile cfgFile = new XMLCfgFile();
            CfgFileSerializer cfgSerializer = new CfgFileSerializer(cfgFile);

            if (File.Exists(cfgFile.ConfigFilePath))
            {
                try
                {
                    cfgSerializer.LoadFile();
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
            
            // Show main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
