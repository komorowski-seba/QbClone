using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using QbCloneApp.ViewModels;
using QbCloneApp.Views;

namespace QbCloneApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var showItem = new NativeMenuItem("Pokaż okno");
            showItem.Click += (_, _) =>
            {
                if (desktop.MainWindow == null)
                    desktop.MainWindow = new MainWindow();

                desktop.MainWindow.Show();
                desktop.MainWindow.Activate();
            };

            var sep = new NativeMenuItemSeparator();

            var exitItem = new NativeMenuItem("Zakończ");
            exitItem.Click += (_, _) => desktop.Shutdown();

            var trayMenu = new NativeMenu
            {
                Items =
                {
                    showItem,
                    sep,
                    exitItem
                }
            };

            var trayIcon = new TrayIcon
            {
                Icon = new WindowIcon(
                    AssetLoader.Open(new Uri("avares://QbCloneApp/Assets/avalonia-logo.ico"))
                ),
                ToolTipText = "Moja aplikacja Avalonia",
                Menu = trayMenu,
                IsVisible = true
            };

                
                
                
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}

/*

2025/12/04 20:40:44 NOTICE: bisync is EXPERIMENTAL. Don't use in production!
2025/12/04 20:40:44 INFO  : Synching Path1 "/home/seba/GoogleD/" with Path2 "googleRemote:/"
2025/12/04 20:40:44 INFO  : Path1 checking for diffs
2025/12/04 20:41:44 NOTICE: 
Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
Elapsed time:       1m1.2s
   
2025/12/04 20:42:44 NOTICE: 
Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
Elapsed time:       2m1.2s
   
2025/12/04 20:43:44 NOTICE: 
Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
Elapsed time:       3m1.2s
   
2025/12/04 20:44:44 NOTICE: 
Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
Elapsed time:       4m1.2s
   
2025/12/04 20:45:03 INFO  : - Path1    File is new                         - Documents/invoices issued/2025-11/FS 306_12_2025.pdf
2025/12/04 20:45:03 INFO  : - Path1    File is new                         - Documents/invoices issued/2025-11/Invoice_INVCZ10372893.pdf
2025/12/04 20:45:03 INFO  : - Path1    File is new                         - Documents/invoices issued/2025-11/LicenseCertificate-R30018462.pdf
2025/12/04 20:45:03 INFO  : Path1:    3 changes:    3 new,    0 newer,    0 older,    0 deleted
2025/12/04 20:45:03 INFO  : Path2 checking for diffs
2025/12/04 20:45:12 INFO  : - Path2    File is new                         - Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf
2025/12/04 20:45:12 INFO  : Path2:    1 changes:    1 new,    0 newer,    0 older,    0 deleted
2025/12/04 20:45:12 INFO  : Applying changes
2025/12/04 20:45:12 INFO  : - Path1    Queue copy to Path2                 - googleRemote:/Documents/invoices issued/2025-11/FS 306_12_2025.pdf
2025/12/04 20:45:12 INFO  : - Path1    Queue copy to Path2                 - googleRemote:/Documents/invoices issued/2025-11/Invoice_INVCZ10372893.pdf
2025/12/04 20:45:12 INFO  : - Path1    Queue copy to Path2                 - googleRemote:/Documents/invoices issued/2025-11/LicenseCertificate-R30018462.pdf
2025/12/04 20:45:12 INFO  : - Path2    Queue copy to Path1                 - /home/seba/GoogleD/Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf
2025/12/04 20:45:12 INFO  : - Path2    Do queued copies to                 - Path1
2025/12/04 20:45:14 NOTICE: Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf: Duplicate object found in source - ignoring
2025/12/04 20:45:14 NOTICE: Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf: Duplicate object found in source - ignoring
2025/12/04 20:45:14 NOTICE: Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf: Skipped copy as --dry-run is set (size 60.617Ki)
2025/12/04 20:45:14 INFO  : - Path1    Do queued copies to                 - Path2
2025/12/04 20:45:16 NOTICE: Documents/invoices issued/2025-11/FS 306_12_2025.pdf: Skipped copy as --dry-run is set (size 49.564Ki)
2025/12/04 20:45:16 NOTICE: Documents/invoices issued/2025-11/Invoice_INVCZ10372893.pdf: Skipped copy as --dry-run is set (size 101.261Ki)
2025/12/04 20:45:16 NOTICE: Documents/invoices issued/2025-11/LicenseCertificate-R30018462.pdf: Skipped copy as --dry-run is set (size 105.508Ki)
2025/12/04 20:45:16 INFO  : Updating listings
2025/12/04 20:45:44 NOTICE: 
Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 8.028 KiB/s, ETA 0s
Transferred:            4 / 4, 100%
Elapsed time:       5m1.2s

2025/12/04 20:46:44 NOTICE: 
Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.235 KiB/s, ETA 0s
Transferred:            4 / 4, 100%
Elapsed time:       6m1.2s

2025/12/04 20:47:44 NOTICE: 
Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.235 KiB/s, ETA 0s
Transferred:            4 / 4, 100%
Elapsed time:       7m1.2s

2025/12/04 20:48:44 NOTICE: 
Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.235 KiB/s, ETA 0s
Transferred:            4 / 4, 100%
Elapsed time:       8m1.2s

2025/12/04 20:49:44 NOTICE: 
Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.235 KiB/s, ETA 0s
Transferred:            4 / 4, 100%
Elapsed time:       9m1.2s

2025/12/04 20:49:57 INFO  : Bisync successful
2025/12/04 20:49:57 NOTICE: 
Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.235 KiB/s, ETA 0s
Transferred:            4 / 4, 100%
Elapsed time:      9m13.9s
   

*/

/*

2025/12/04 20:55:00 NOTICE: bisync is EXPERIMENTAL. Don't use in production!
   2025/12/04 20:55:00 INFO  : Synching Path1 "/home/seba/GoogleD/" with Path2 "googleRemote:/"
   2025/12/04 20:55:00 INFO  : Path1 checking for diffs
   2025/12/04 20:56:00 INFO  : 
   Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
   Elapsed time:       1m0.6s
   
   2025/12/04 20:57:00 INFO  : 
   Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
   Elapsed time:       2m0.6s
   
   2025/12/04 20:58:00 INFO  : 
   Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
   Elapsed time:       3m0.6s
   
   2025/12/04 20:59:00 INFO  : 
   Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
   Elapsed time:       4m0.6s
   
   2025/12/04 20:59:52 INFO  : - Path1    File is new                         - Documents/invoices issued/2025-11/FS 306_12_2025.pdf
   2025/12/04 20:59:52 INFO  : - Path1    File is new                         - Documents/invoices issued/2025-11/Invoice_INVCZ10372893.pdf
   2025/12/04 20:59:52 INFO  : - Path1    File is new                         - Documents/invoices issued/2025-11/LicenseCertificate-R30018462.pdf
   2025/12/04 20:59:52 INFO  : Path1:    3 changes:    3 new,    0 newer,    0 older,    0 deleted
   2025/12/04 20:59:52 INFO  : Path2 checking for diffs
   2025/12/04 20:59:59 INFO  : - Path2    File is new                         - Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf
   2025/12/04 20:59:59 INFO  : Path2:    1 changes:    1 new,    0 newer,    0 older,    0 deleted
   2025/12/04 20:59:59 INFO  : Applying changes
   2025/12/04 20:59:59 INFO  : - Path1    Queue copy to Path2                 - googleRemote:/Documents/invoices issued/2025-11/FS 306_12_2025.pdf
   2025/12/04 20:59:59 INFO  : - Path1    Queue copy to Path2                 - googleRemote:/Documents/invoices issued/2025-11/Invoice_INVCZ10372893.pdf
   2025/12/04 20:59:59 INFO  : - Path1    Queue copy to Path2                 - googleRemote:/Documents/invoices issued/2025-11/LicenseCertificate-R30018462.pdf
   2025/12/04 20:59:59 INFO  : - Path2    Queue copy to Path1                 - /home/seba/GoogleD/Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf
   2025/12/04 20:59:59 INFO  : - Path2    Do queued copies to                 - Path1
   2025/12/04 21:00:00 INFO  : 
   Transferred:   	          0 B / 0 B, -, 0 B/s, ETA -
   Elapsed time:       5m0.6s
   
   2025/12/04 21:00:01 NOTICE: Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf: Duplicate object found in source - ignoring
   2025/12/04 21:00:01 NOTICE: Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf: Duplicate object found in source - ignoring
   2025/12/04 21:00:03 INFO  : Documents/invoices issued/2025-11/Potwierdzenie_operacji_2025.11.17.pdf: Copied (new)
   2025/12/04 21:00:03 INFO  : - Path1    Do queued copies to                 - Path2
   2025/12/04 21:00:07 INFO  : Documents/invoices issued/2025-11/FS 306_12_2025.pdf: Copied (new)
   2025/12/04 21:00:08 INFO  : Documents/invoices issued/2025-11/LicenseCertificate-R30018462.pdf: Copied (new)
   2025/12/04 21:00:08 INFO  : Documents/invoices issued/2025-11/Invoice_INVCZ10372893.pdf: Copied (new)
   2025/12/04 21:00:08 INFO  : Updating listings
   2025/12/04 21:01:00 INFO  : 
   Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.315 KiB/s, ETA 0s
   Transferred:            4 / 4, 100%
   Elapsed time:       6m0.6s
   
   2025/12/04 21:02:00 INFO  : 
   Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.017 KiB/s, ETA 0s
   Transferred:            4 / 4, 100%
   Elapsed time:       7m0.6s
   
   2025/12/04 21:03:00 INFO  : 
   Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.017 KiB/s, ETA 0s
   Transferred:            4 / 4, 100%
   Elapsed time:       8m0.6s
   
   2025/12/04 21:04:00 INFO  : 
   Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.017 KiB/s, ETA 0s
   Transferred:            4 / 4, 100%
   Elapsed time:       9m0.6s
   
   2025/12/04 21:05:00 INFO  : 
   Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.017 KiB/s, ETA 0s
   Transferred:            4 / 4, 100%
   Elapsed time:      10m0.6s
   
   2025/12/04 21:05:24 INFO  : Validating listings for Path1 "/home/seba/GoogleD/" vs Path2 "googleRemote:/"
   2025/12/04 21:05:24 INFO  : Bisync successful
   2025/12/04 21:05:24 INFO  : 
   Transferred:   	  316.950 KiB / 316.950 KiB, 100%, 1.017 KiB/s, ETA 0s
   Transferred:            4 / 4, 100%
   Elapsed time:     10m24.3s
   

*/