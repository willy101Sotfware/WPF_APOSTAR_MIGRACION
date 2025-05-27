using WPF_APOSTAR_MIGRACION.ApiService.Models;
using WPF_APOSTAR_MIGRACION.Domain.ApiService.IntegrationModels;
using WPF_APOSTAR_MIGRACION.Domain.Enumerables;

namespace WPF_APOSTAR_MIGRACION.Domain.UIServices;

public class Transaction
{
    // Patron de Diseño Singleton
    private static Transaction? _instance;
    public static Transaction Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Transaction();
            return _instance;
        }
    }

    public static void Reset()
    {
        _instance = null;
    }

    private Transaction() { }

    public TransactionDto ApiDto { get; set; }
    public int IdTransaccionApi { get; set; }

    public int IdPaypad { get; set; } = 3;
    public string? TipoRecaudo { get; set; }
    public string? TipoOperacion { get; set; }
    public TypeTransaction TipoTransaccion { get; set; }
    public TypePayment TipoPago { get; set; }
    public StateTransaction EstadoTransaccion { get; set; }
    public string EstadoTransaccionVerb { get; set; }
    public string? Referencia { get; set; }
    public string? Documento { get; set; }
    public string? Descripcion { get; set; }
    public string? FechaVencimiento { get; set; }
    public decimal TotalSinRedondear { get; set; }
    public decimal Total { get; set; }
    public decimal TotalDevuelta { get; set; }
    public decimal TotalIngresado { get; set; }

    public bool DevueltaCorrecta { get; set; }
    //public PaymentViewModel DatosPago { get; set; }
    public string Calificacion { get; set; }


    // Propiedades para el formulario de colegio
    public string? Colegio { get; set; }
    public int NumeroDePeronas { get; set; }

    //Integración

    public string Token { get; set; }

    public decimal ValueScan { get; set; }

    public string ReferenciaExc { get; set; }

    public int ExcPagos { get; set; }

    public string IdTipoPago { get; set; }

    public InvoicePay DataInvoice { get; set; }

    public List<InvoicePay> ListInvoices { get; set; } = new List<InvoicePay>();

    public List<Invoice> ListaFacturas { get; set; } = new List<Invoice>();

    public ResponseNotifyPay NotifyPay { get; set; }

    public ResponseNotifyPay NotifyPayExc { get; set; }













}




