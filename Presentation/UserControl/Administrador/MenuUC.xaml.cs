using System;
using System.Windows;
using System.Windows.Input;
using WPF_APOSTAR_MIGRACION.Domain;
using WPF_APOSTAR_MIGRACION.Presentation.UserControl.Paquetes;

namespace WPF_APOSTAR_MIGRACION.Presentation.UserControls
{
    /// <summary>
    /// Lógica de interacción para MenuUC.xaml
    /// </summary>
    public partial class MenuUC : System.Windows.Controls.UserControl
    {
        // Instancia del navegador para la navegación
        protected Navigator _nav = Navigator.Instance;
        
        // Método para navegar a otra vista
        protected void GoTo(System.Windows.Controls.UserControl view)
        {
            _nav.NavigateTo(view);
        }
        
        public MenuUC()
        {
            InitializeComponent();
        }
        
      
        private void OpcionButton_Click(object sender, EventArgs e)
        {
            var control = sender as FrameworkElement;
            if (control == null || control.Tag == null)
            {
                return;
            }
            
            // Obtener el tag del control para identificar qué botón se presionó
            string tag = control.Tag.ToString();
            
            // Ejecutar la acción correspondiente según el botón presionado
            switch (tag)
            {
                case "BetPlay":
                    // Aquí va la lógica para el botón BetPlay
                    MessageBox.Show("Botón BetPlay presionado");
                    break;
                    
                case "Chance":
                    // Aquí va la lógica para el botón Chance
                    MessageBox.Show("Botón Chance presionado");
                    break;
                    
                case "Recaudo":
                    // Aquí va la lógica para el botón Recaudo
                    MessageBox.Show("Botón Recaudo presionado");
                    break;
                    
                case "Paquetes":
                  
                    try
                    {
                        GC.Collect();

                        // Navegar a la pantalla de selección de operador
                        var selectOperadorUC = new SelectOperadorUC();
                        GoTo(selectOperadorUC);
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