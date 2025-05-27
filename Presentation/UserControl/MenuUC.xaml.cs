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
        
        #region Eventos para BetPlay (Jugar)
        
        // Evento TouchDown para el botón Jugar
        private void Btn_JugarTouchDown(object sender, TouchEventArgs e)
        {
            // Aquí va la lógica para cuando se toca el botón Jugar
            MessageBox.Show("Botón Jugar presionado");
        }
        
        // Evento MouseDown para el botón Jugar (llama al evento TouchDown)
        private void Btn_JugarMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Llamar al evento TouchDown para reutilizar código
            Btn_JugarTouchDown(sender, new TouchEventArgs(TouchDevice.GetTouchDevice(this), 0));
        }
        
        #endregion
        
        #region Eventos para Chance
        
        // Evento TouchDown para el botón Chance
        private void Btn_ChanceTouchDown(object sender, TouchEventArgs e)
        {
            // Aquí va la lógica para cuando se toca el botón Chance
            MessageBox.Show("Botón Chance presionado");
        }
        
        // Evento MouseDown para el botón Chance (llama al evento TouchDown)
        private void Btn_ChanceMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Llamar al evento TouchDown para reutilizar código
            Btn_ChanceTouchDown(sender, new TouchEventArgs(TouchDevice.GetTouchDevice(this), 0));
        }
        
        #endregion
        
        #region Eventos para Recaudo
        
        // Evento TouchDown para el botón Recaudo
        private void Btn_RecaudoTouchDown(object sender, TouchEventArgs e)
        {
            // Aquí va la lógica para cuando se toca el botón Recaudo
            MessageBox.Show("Botón Recaudo presionado");
        }
        
        // Evento MouseDown para el botón Recaudo (llama al evento TouchDown)
        private void Btn_RecaudoMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Llamar al evento TouchDown para reutilizar código
            Btn_RecaudoTouchDown(sender, new TouchEventArgs(TouchDevice.GetTouchDevice(this), 0));
        }
        
        #endregion
        
        #region Eventos para Recharge (Paquetes)
        
        // Evento TouchDown para el botón Recharge
        private void Btn_RechargeTouchDown(object sender, TouchEventArgs e)
        {
            // Aquí va la lógica para cuando se toca el botón Recharge
            MessageBox.Show("Botón Recharge presionado");
        }
        
        // Evento MouseDown para el botón Recharge (llama al evento TouchDown)
        private void Btn_RechargeMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Llamar al evento TouchDown para reutilizar código
            Btn_RechargeTouchDown(sender, new TouchEventArgs(TouchDevice.GetTouchDevice(this), 0));
        }
        
        #endregion
    }
}