using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;
using System.Windows.Media;
using WPF_APOSTAR_MIGRACION.Domain;

namespace WPF_APOSTAR_MIGRACION.Presentation;

public partial class MainPublicityUC : UserControl
{
    private readonly string _videoPath;

    public MainPublicityUC()
    {
        InitializeComponent();
        _videoPath = ConfigurationManager.AppSettings["VideoPublish"];
        LoadVideo();
    }
    
    private void InitializeComponent()
    {
        // Este método normalmente es generado por el compilador de WPF
        // Pero lo implementamos manualmente para solucionar el error
        Uri resourceLocater = new Uri("/WPF_APOSTAR_MIGRACION;component/Presentation/MainPublicityUC.xaml", UriKind.Relative);
        System.Windows.Application.LoadComponent(this, resourceLocater);
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
        MessageBox.Show("Aquí iría la navegación al menú principal usando Navigator.Instance.NavigateTo(new OtroUserControl())");
    }
}
