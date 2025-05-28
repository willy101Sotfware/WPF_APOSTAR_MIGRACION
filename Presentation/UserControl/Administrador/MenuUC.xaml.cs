using System.Windows;
using WPF_APOSTAR_MIGRACION.Presentation.Controls;
using WPF_APOSTAR_MIGRACION.Presentation.UserControl.Paquetes;

namespace WPF_APOSTAR_MIGRACION.Presentation.UserControls
{
    /// <summary>
    /// Lógica de interacción para MenuUC.xaml
    /// </summary>
    public partial class MenuUC : AppUserControl
    {
        public MenuUC()
        {
            InitializeComponent();
        }

        private void OpcionButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement control && control.Tag is string tag)
            {
                switch (tag)
                {
                    case "BetPlay":
                        MessageBox.Show("Botón BetPlay presionado");
                        break;

                    case "Chance":
                        MessageBox.Show("Botón Chance presionado");
                        break;

                    case "Recaudo":
                        MessageBox.Show("Botón Recaudo presionado");
                        break;

                    case "Paquetes":
                        try
                        {
                            GC.Collect(); // Solo si es necesario
                            GoTo(new SelectOperadorUC());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al navegar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    default:
                        MessageBox.Show($"Botón desconocido: {tag}");
                        break;
                }
            }
        }
    }
}
