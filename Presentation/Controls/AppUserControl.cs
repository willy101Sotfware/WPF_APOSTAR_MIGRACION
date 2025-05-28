using WPF_APOSTAR_MIGRACION.Domain;

namespace WPF_APOSTAR_MIGRACION.Presentation.Controls;

public class AppUserControl : System.Windows.Controls.UserControl
{
    protected Navigator _nav = Navigator.Instance;
    
    protected void GoTo(System.Windows.Controls.UserControl view)
    {
        _nav.NavigateTo(view);
    }
}
