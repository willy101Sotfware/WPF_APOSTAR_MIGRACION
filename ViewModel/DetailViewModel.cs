using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Data;
using WPF_APOSTAR_MIGRACION.Models;
using WPF_APOSTAR_MIGRACION.Domain;

namespace WPF_APOSTAR_MIGRACION.ViewModel;

public class DetailViewModel
{

    public event PropertyChangedEventHandler PropertyChanged;

    public string Title { get; set; }
    public string TasaCambio { get; set; }
    public string ImgIngresas { get; set; }
    public string ImgRetiras { get; set; }

    private List<MockupsModel> _DocumentList;

    public List<MockupsModel> DocumentList
    {
        get { return _DocumentList; }
        set
        {
            _DocumentList = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DocumentList)));
        }
    }

    private CollectionViewSource _DocumentEntries;

    public CollectionViewSource DocumentEntries
    {
        get
        {
            return _DocumentEntries;
        }
        set
        {
            _DocumentEntries = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DocumentEntries)));
        }
    }

    public void LoadListDocuments(List<MockupsModel> ResponseTypeDocuments)
    {
        try
        {
            if (ResponseTypeDocuments != null && ResponseTypeDocuments.Count > 0)
            {
                DocumentList.Clear();
                DocumentList = ResponseTypeDocuments;
                DocumentEntries.Source = DocumentList;

            }
        }
        catch (Exception ex)
        {

            // Nuevo con EventLogger:
            EventLogger.SaveLog(
                EventType.Error,
                $"Error en {MethodBase.GetCurrentMethod().Name} de {this.GetType().Name}: {ex.Message}"
            );

        }
    }

}
