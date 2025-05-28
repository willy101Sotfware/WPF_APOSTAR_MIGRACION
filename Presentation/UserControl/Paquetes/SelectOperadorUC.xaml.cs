using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_APOSTAR_MIGRACION.Presentation.Controls;

namespace WPF_APOSTAR_MIGRACION.Presentation.UserControl.Paquetes;

public partial class SelectOperadorUC : AppUserControl
{
    public SelectOperadorUC()
    {
        InitializeComponent();
    }

    // Evento para el ListViewItem MouseDown (Btn_SelectOperator)
    private void Btn_SelectOperator(object sender, MouseButtonEventArgs e)
    {
        var listViewItem = sender as ListViewItem;
        if (listViewItem != null && listViewItem.Content != null)
        {
            // Aquí puedes obtener el operador seleccionado:
            var operador = listViewItem.Content;
            MessageBox.Show($"Seleccionaste el operador: {operador}");
        }
    }

    // Evento para la selección en ListView
    private void lvOperator_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listView = sender as ListView;
        if (listView != null && listView.SelectedItem != null)
        {
            var operador = listView.SelectedItem;
            MessageBox.Show($"Seleccionaste (listview): {operador}");
        }
    }

    // Evento para el botón cancelar touch down / mouse down
    private void BtnCancelar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("Botón cancelar pulsado (Mouse o Touch)");
    }


    // Si quieres manejar también MouseDown para el botón cancelar, puedes definir:
    private void BtnCancelar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("Cancelar pulsado (MouseDown)");
    }
}
