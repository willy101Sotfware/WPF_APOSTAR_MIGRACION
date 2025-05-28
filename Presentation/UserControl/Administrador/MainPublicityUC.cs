using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_APOSTAR_MIGRACION.Presentation.Controls;
using WPF_APOSTAR_MIGRACION.Presentation.UserControls;

namespace WPF_APOSTAR_MIGRACION.Presentation;

public partial class MainPublicityUC :AppUserControl
{
    private readonly string _videoPath;

    public MainPublicityUC()
    {
        InitializeComponent();
        _videoPath = ConfigurationManager.AppSettings["VideoPublish"];
        LoadVideo();
    }



    private void LoadVideo()
    {
        if (!string.IsNullOrEmpty(_videoPath))
        {
            var videoUri = new Uri(_videoPath);
            SplashVideo.Source = videoUri;
            SplashVideo.Volume = 0;
            SplashVideo.Play();
        }
        else
        {
            MessageBox.Show("No se encontró la ruta del video en la configuración", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SplashVideo_MediaEnded(object sender, RoutedEventArgs e)
    {
        SplashVideo.Position = TimeSpan.Zero;
        SplashVideo.Play();
    }

    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        // Cuando el usuario toca la pantalla, navegar a MenuUC
        ContinueButton_Click(sender, new RoutedEventArgs());
    }

    private void ContinueButton_Click(object sender, RoutedEventArgs e)
    {
        // Navegar a MenuUC cuando el usuario toca el botón
        try
        {
            // Detener el video
            if (SplashVideo != null)
            {
                SplashVideo.Stop();
                SplashVideo.Close();
            }
            
            // Limpiar memoria
            GC.Collect();
            
            // Navegar a MenuUC
            var menuUC = new MenuUC();
            _nav.NavigateTo(menuUC);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al navegar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
