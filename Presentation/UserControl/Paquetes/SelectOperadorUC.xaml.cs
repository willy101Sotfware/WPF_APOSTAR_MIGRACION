using System.Windows;
using WPF_APOSTAR_MIGRACION.Domain;
using WPF_APOSTAR_MIGRACION.Presentation.UserControls;

namespace WPF_APOSTAR_MIGRACION.Presentation.UserControl.Paquetes
{
    /// <summary>
    /// Lógica de interacción para SelectOperadorUC.xaml
    /// </summary>
    public partial class SelectOperadorUC : System.Windows.Controls.UserControl
    {
        // Instancia del navegador para la navegación
        protected Navigator _nav = Navigator.Instance;
        
        // Método para navegar a otra vista
        protected void GoTo(System.Windows.Controls.UserControl view)
        {
            _nav.NavigateTo(view);
        }
        
        public SelectOperadorUC()
        {
            InitializeComponent();
        }

        private void OperadorButton_Click(object sender, RoutedEventArgs e)
        {
            var control = sender as FrameworkElement;
            if (control == null || control.Tag == null)
            {
                return;
            }
            
            // Obtener el tag del control para identificar qué operador se seleccionó
            string operador = control.Tag.ToString();
            
            // Mostrar mensaje de selección (esto se puede cambiar por la navegación a otra vista)
            MessageBox.Show($"Seleccionaste el {operador}", "Operador Seleccionado", MessageBoxButton.OK, MessageBoxImage.Information);
            
            // Aquí puedes agregar la lógica para navegar a otra vista según el operador seleccionado
            // Por ejemplo:
            // var nuevaVista = new OtraVista(operador);
            // GoTo(nuevaVista);
        }

        private void VolverButton_Click(object sender, RoutedEventArgs e)
        {
            // Navegar de vuelta al menú principal
            try
            {
                var menuUC = new MenuUC();
                GoTo(menuUC);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
