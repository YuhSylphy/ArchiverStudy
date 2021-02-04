using Livet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using static ArchiverStudy.Common.MyExtensions;

namespace ArchiverStudy
{
    using Views;
    using CommandLine;
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DispatcherHelper.UIDispatcher = Dispatcher;

            Parser.Default.ParseArguments<MenuOptions, BrowseOptions>(e.Args)
                .MapResult<MenuOptions, BrowseOptions, object?>(
                (MenuOptions o) =>
                {
                    MainWindow = new MainMenu();
                    return null;
                }, 
                (BrowseOptions o) =>
                {
                    MainWindow = new MainWindow();
                    MainWindow.Show();
                    return null;
                },
                err =>
                {
                    return null;
                });
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        [Verb("menu", isDefault: true, HelpText = "shows root context menu")]
        class MenuOptions
        {
            [Value(0, HelpText = "specify target paths", MetaName = "target paths", Required = true)]
            public IEnumerable<string> TargetPaths { get; set; } = Array.Empty<string>();
        }

        [Verb("browse", HelpText = "shows archive browser")]
        class BrowseOptions
        {
            [Value(0, HelpText = "specify target paths", MetaName = "target paths")]
            public string? TargetPath { get; set; }
        }

        // Application level error handling
        //private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    //TODO: Logging
        //    MessageBox.Show(
        //        "Something errors were occurred.",
        //        "Error",
        //        MessageBoxButton.OK,
        //        MessageBoxImage.Error);
        //
        //    Environment.Exit(1);
        //}
    }
}
