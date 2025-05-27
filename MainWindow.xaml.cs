using DB;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using WPF_APOSTAR_MIGRACION.Domain;
using WPF_APOSTAR_MIGRACION.Presentation.UserControls;


namespace WPF_APOSTAR_MIGRACION;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {

        InitializeComponent();

        this.Height = SystemParameters.PrimaryScreenHeight;
        this.Width = this.Height * 9 / 16;
        this.WindowVB.Height = SystemParameters.PrimaryScreenHeight;
        this.WindowVB.Width = this.Height * 9 / 16;


        // DB Creation
        using (var db = new LocalContext())
        {
            if (!db.Database.EnsureCreated())
            {
                db.Database.Migrate();
            }

        }

        // Navigation creation
        Navigator navigatorSingleton = Navigator.Instance;
        navigatorSingleton.Init(this);
#if NO_PERIPHERALS
#else
            string arduinoPort = AppConfig.Get("arduinoPort");
            string dispenserDenominations = AppConfig.Get("dispenserDenominations");
            bool peripheralsConected = false;
            while (!peripheralsConected)
            {
                try
                {
                    ArduinoController.Initialize(arduinoPort, dispenserDenominations);
                    peripheralsConected = true;
                }
                catch (Exception ex)
                {
                    EventLogger.SaveLog(EventType.Error, $"Ocurrió un error en tiempo de ejecución: {ex.Message}", ex);
                    peripheralsConected = false;
                    navigatorSingleton.ShowModal(Messages.PERIPHERALS_FAILED_CONNECT + " Intente nuevamente por favor.", new InfoModal());
                }
            }
            // Verify dispenser load
            var dispenserOk = false;
            while (!dispenserOk)
            {
                var dispenserMessage = Dispenser.GetLoadMessage();
                if (dispenserMessage == string.Empty)
                {
                    dispenserOk = true;
                    continue;
                }
                navigatorSingleton.ShowModal(dispenserMessage, new InfoModal());
            }
#endif
        navigatorSingleton.NavigateTo(new ConfigUC());

    }
}