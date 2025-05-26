﻿using System.Windows.Controls;
using System.Windows.Threading;
using WPF_APOSTAR_MIGRACION.Domain;

namespace WPF_APOSTAR_MIGRACION.Presentation.AppUserControl;

public class AppUserControl : UserControl
{
    protected Navigator _nav = Navigator.Instance;
    protected void GoTo(UserControl view)
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