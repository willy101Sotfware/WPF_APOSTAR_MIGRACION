using System.Configuration;
using System.Windows;
using System.Windows.Input;
using WPF_APOSTAR_MIGRACION.Domain;
using WPF_APOSTAR_MIGRACION.Presentation.Controls;

namespace WPF_APOSTAR_MIGRACION.Presentation.UserControls.Administrador
{
    public partial class MainPublicityUC : AppUserControl
    {
        protected Navigator _nav = Navigator.Instance;
        private readonly string _videoPath;

        public MainPublicityUC()
        {
            InitializeComponent();
            _videoPath = ConfigurationManager.AppSettings["VideoPublish"];
            LoadVideo();
        }

        protected void GoTo(System.Windows.Controls.UserControl view)
        {
            _nav.NavigateTo(view);
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
            ContinueButton_Click(sender, new RoutedEventArgs());
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SplashVideo.Stop();
                SplashVideo.Close();
                GC.Collect();

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
