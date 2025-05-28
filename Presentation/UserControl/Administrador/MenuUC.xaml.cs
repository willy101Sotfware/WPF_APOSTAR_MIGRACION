using System;
using System.Windows;
using System.Windows.Input;
using WPF_APOSTAR_MIGRACION.Presentation.Controls;

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

                        // Por ahora solo mostramos un mensaje
                        MessageBox.Show("Navegación a Paquetes en desarrollo", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                        // Cuando tengas la pantalla de Paquetes lista, puedes descomentar esto:
                        // var paquetesUC = new PaquetesUC();
                        // _nav.NavigateTo(paquetesUC);
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