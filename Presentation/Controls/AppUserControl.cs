using WPF_APOSTAR_MIGRACION.Domain;

namespace WPF_APOSTAR_MIGRACION.Presentation.Controls;

public class AppUserControl : System.Windows.Controls.UserControl
{
    protected Navigator _nav = Navigator.Instance;
    
    protected void GoTo(System.Windows.Controls.UserControl view)
    {
        _nav.NavigateTo(view);
    }

    protected void EnableView()
    {
        Dispatcher.Invoke((Action)delegate
        {
            this.IsEnabled = true;
            this.Opacity = 1;
        });


    }

    protected void DisableView()
    {
        Dispatcher.Invoke((Action)delegate
        {
            this.IsEnabled = false;
            this.Opacity = 0.3;
        });


    }
}
