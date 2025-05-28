using System.Windows;
using WPF_APOSTAR_MIGRACION.Domain;
using WPF_APOSTAR_MIGRACION.Presentation.Controls;
using WPF_APOSTAR_MIGRACION.Presentation.UserControls;

namespace WPF_APOSTAR_MIGRACION.Presentation.UserControl.Paquetes
{
    /// <summary>
    /// Lógica de interacción para SelectOperadorUC.xaml
    /// </summary>
    public partial class SelectOperadorUC : AppUserControl 
    {
        public SelectOperadorUC()
        {
            InitializeComponent();
        }

        private void OperadorButton_Click(object sender, RoutedEventArgs e)
        {
            var control = sender as FrameworkElement;
            if (control == null || control.Tag == null)
                return;

            string operador = control.Tag.ToString();
            MessageBox.Show($"Seleccionaste el {operador}", "Operador Seleccionado", MessageBoxButton.OK, MessageBoxImage.Information);

            // Aquí puedes usar GoTo directamente
            // GoTo(new OtraVista(operador));
        }

        private void VolverButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GoTo(new MenuUC());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
