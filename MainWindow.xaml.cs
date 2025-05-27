using System.Windows;
using WPF_APOSTAR_MIGRACION.Domain;

namespace WPF_APOSTAR_MIGRACION
{
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

            // Inicializar el navegador y mostrar la pantalla de carga
            Navigator.Instance.Init(this);
            Navigator.Instance.NavigateTo(new Presentation.Administrator.ConfigUC());
        }
    }
}