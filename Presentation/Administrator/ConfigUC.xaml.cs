using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using WPF_APOSTAR_MIGRACION.Domain;

namespace WPF_APOSTAR_MIGRACION.Presentation.Administrator
{
    /// <summary>
    /// Lógica de interacción para ConfigUC.xaml
    /// </summary>
    public partial class ConfigUC : UserControl
    {
        private AdminPayPlus init;

        public ConfigUC()
        {
            try
            {
                InitializeComponent();

                if (init == null)
                {
                    init = new AdminPayPlus();
                }

                txtMs.DataContext = init;

                Initial();
            }
            catch (Exception ex)
            {
                LogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private async void Initial()
        {
            try
            {
                init.callbackResult = result =>
                {
                    ProccesResult(result);
                };

                init.Start();
            }
            catch (Exception ex)
            {
                LogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void ProccesResult(bool result)
        {
            try
            {
                // Navegar a la pantalla principal
                Navigator.Instance.NavigateTo(new MainPublicityUC());
            }
            catch (Exception ex)
            {
                LogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
                Initial();
            }
        }

        // Métodos auxiliares para logging
        private void LogError(string methodName, string className, Exception ex, string message)
        {
            Console.WriteLine($"ERROR: {className}.{methodName}: {message}");
        }
    }

    // Clase auxiliar para la simulación de carga
    public class AdminPayPlus : INotifyPropertyChanged
    {
        public static DataPayPlus DataPayPlus { get; } = new DataPayPlus();
        
        private string _descriptionStatusPayPlus = "Inicializando...";
        public string DescriptionStatusPayPlus 
        { 
            get { return _descriptionStatusPayPlus; }
            set 
            { 
                _descriptionStatusPayPlus = value;
                OnPropertyChanged(nameof(DescriptionStatusPayPlus));
            }
        }
        
        public Action<bool> callbackResult { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }

        public void Start()
        {
            // Simulación del proceso de inicialización
            Task.Run(async () =>
            {
                try
                {
                    // Aquí iría la lógica real de inicialización
                    await Task.Delay(3000); // Simulación de proceso
                    DescriptionStatusPayPlus = "Conectando con el servidor...";
                    await Task.Delay(3000); // Simulación de proceso
                    DescriptionStatusPayPlus = "Verificando configuración...";
                    await Task.Delay(3000); // Simulación de proceso

                    // Llamar al callback con el resultado (true para éxito)
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        callbackResult?.Invoke(true);
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en Start: {ex.Message}");
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        callbackResult?.Invoke(false);
                    });
                }
            });
        }
    }

    public class DataPayPlus
    {
        public bool StateUpdate { get; set; } = false;
        public bool StateBalanece { get; set; } = false;
        public bool StateUpload { get; set; } = false;
        public string Message { get; set; } = "";
    }
}
