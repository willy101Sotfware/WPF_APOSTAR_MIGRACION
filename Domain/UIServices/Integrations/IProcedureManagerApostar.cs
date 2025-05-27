using WPFApostar.Services.ObjectIntegration;

namespace WPF_APOSTAR_MIGRACION.Domain.UIServices.Integrations;

public interface IProcedureManagerApostar
{
    // Métodos generales
    Task<ResponseGeneric> GetData(object requestData, string controller, string BaseAddress);
    Task<ResponseGeneric> GetData(string controller, string BaseAddress);
    
    // Métodos para BetPlay
    Task<ResponseTokenBetplay> GetTokenBetplay(RequesttokenBetplay requesttoken);
    Task<ResponseGetProducts> GetProductsBetPlay(RequestConsultSubproductBetplay request);
    ResponseNotifyBetPlay NotifyPayment(RequestNotifyBetplay Machine);
    
    // Métodos para Chance
    ResponseGetProducts GetProductsChance(RequestSubproducts request);
    ResponseGetLotteries GetLotteries(RequestGetLotteries Machine);
    ResponseTypeChance TypeChance(IdProducto Machine);
    ResponseValidateChance ValidateChance(RequestValidateChance Machine);
    ResponseNotifyChance NotifyChance(RequestNotifyChance Machine);
    
    // Métodos para Recaudo
    ResponseGetRecaudo GetRecaudos(RequestGetRecaudos request);
    ResponseGetParameters GetParameters(RequestGetParameters request);
    ResponseConsultValue ConsultValueRecaudo(RequestConsultValue request);
    ResponseNotifyPayment NotifyPaymentRecaudo(RequestNotifyRecaudo request);
    
    // Métodos para Paquetes
    Task<ResponseConsultSubproductosPaquetes> ConsultSubproductosPaquetes(RequestConsultSubproductosPaquetes request);
    Task<ResponseConsultPaquetes> ConsultPaquetes(RequestConsultPaquetes request);
    Task<ResponseGuardarPaquetes> GuardarPaquetes(RequestGuardarPaquete request);
}

public class ProcedureExceptionInder : Exception
{
    public ProcedureExceptionInder() { }

    public ProcedureExceptionInder(string? message) : base(message)
    {
    }

    public ProcedureExceptionInder(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
