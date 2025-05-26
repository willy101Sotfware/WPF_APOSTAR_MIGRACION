using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_APOSTAR_MIGRACION.Presentation;
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

            // Inicializar el navegador y mostrar la pantalla de inicio
            Navigator.Instance.Init(this);
            Navigator.Instance.NavigateTo(new MainPublicityUC());
        }
    }
}