using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WPF_APOSTAR_MIGRACION.Domain.ApiService.IntegrationModels;



#region Apostar












#endregion





public class ResponseGeneric
{
    public int ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public object ResponseData { get; set; }
}



public class TokenData
{
    public string Token { get; set; }
}


public class RequestDataPay
{
    public int ClienteId { get; set; }
    public int NumeroProceso { get; set; }
    public int TipoPago { get; set; }
    public string Token { get; set; }
}

public class InvoicePay
{

    [JsonProperty(PropertyName = "$id")]
    public object id { get; set; }
    public long lngClienteId { get; set; }
    public int lngNumeroProceso { get; set; }
    public long lngCupon { get; set; }
    public int intTipoPago { get; set; }
    public int lngValorPago { get; set; }
    public long lngCodigoIac { get; set; }
    public int intCiclo { get; set; }
    public string strNombre { get; set; }
    public string strFechaFacturacion { get; set; }
    public string strFechaVencimiento { get; set; }
    public string strNumeroFactura { get; set; }
    public int intCodAceptacion { get; set; }
    public string strMensjAceptacion { get; set; }
}


public class RequestNotifyPay
{
    public int lngCupon { get; set; }
    public int intTipoPago { get; set; }
    public int intValor { get; set; }
    public string Token { get; set; }
}


public class ResponseNotifyPay
{
    public string strHora { get; set; }
    public int intCodError { get; set; }
    public string strMensjError { get; set; }
}



#region Request Inder



public class RequestValidarcupoDisponibleInder
{
    public int idDisponibilidad { get; set; }
    public DateTime fecha { get; set; }
    public string tipoEspacio { get; set; }
}




#endregion



public class InvoiceCore
{
    public string BillPayerName { get; set; }
    public string BillPayerDocument { get; set; }
    public string InvoiceId { get; set; }
    public long ValueToPay { get; set; }
    public string PeriodBill { get; set; }
    public string IssueDate { get; set; }
    public string SuspensionDate { get; set; }
}
public class Invoice : InvoiceCore
{
    public long? Id { get; set; }
    public bool? IsPaid { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int CreatedBy { get; set; }
}
public class NotifyPay
{
    public string InvoiceId { get; set; }
    public int PaypadId { get; set; }
}
