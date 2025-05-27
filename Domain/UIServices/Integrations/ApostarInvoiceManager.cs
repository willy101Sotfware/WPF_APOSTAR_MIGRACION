using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Reflection;
using System.Text;
using WPFApostar.Services.ObjectIntegration;

namespace WPF_APOSTAR_MIGRACION.Domain.UIServices.Integrations;

public class ApostarInvoiceManager : IProcedureManagerApostar
{
    private HttpClient client;
    private string basseAddress;

    private static string Aplicacion;
    private static string Dispositivo;
    private static string Token;
    private static string KeyIntegration;

    public ApostarInvoiceManager(string dispositivo)
    {
        Aplicacion = Assembly.GetCallingAssembly().GetName().Name;
        Dispositivo = dispositivo;
    }

    public async Task<ResponseGeneric> GetData(object requestData, string controller, string BaseAddress)
    {
        try
        {
            HttpResponseMessage response = new HttpResponseMessage();

            client = new HttpClient();
            var request = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(request, Encoding.UTF8, "Application/json");
            client.BaseAddress = new Uri(basseAddress);

            response = client.PostAsync(controller, content).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                // Manejar error de servicio
                // AdminPayPlus.SaveErrorControl("Error en el servicio del cliente", response.RequestMessage.ToString(), EError.Customer, ELevelError.Medium);
                return null;
            }

            var result = await response.Content.ReadAsStringAsync();

            var ResponseData = JsonConvert.DeserializeObject<ResponseGeneric>(result);

            return ResponseData;
        }
        catch (Exception ex)
        {
            // Manejar excepción
            // AdminPayPlus.SaveLog("ApiIntegration", "entrando a la ejecucion GetData Catch", "Fail", ex.Message, null);
            Console.WriteLine($"Error en GetData: {ex.Message}");
        }
        return null;
    }

    public async Task<ResponseGeneric> GetData(string controller, string BaseAddress)
    {
        try
        {
            HttpResponseMessage response = new HttpResponseMessage();

            client = new HttpClient();
            var content = new StringContent("dato", Encoding.UTF8, "Application/json");
            client.BaseAddress = new Uri(basseAddress);
          
            response = client.PostAsync(controller, content).GetAwaiter().GetResult();
           
            if (!response.IsSuccessStatusCode)
            {
                // Manejar error de servicio
                // AdminPayPlus.SaveErrorControl("Error en el servicio del cliente", response.RequestMessage.ToString(), EError.Customer, ELevelError.Medium);
                return null;
            }

            var result = await response.Content.ReadAsStringAsync();

            var requestData = JsonConvert.DeserializeObject<ResponseGeneric>(result);

            return requestData;
        }
        catch (Exception ex)
        {
            // Manejar excepción
            // AdminPayPlus.SaveLog("ApiIntegration", "entrando a la ejecucion GetData Catch", "Fail", ex.Message, null);
            Console.WriteLine($"Error en GetData: {ex.Message}");
        }
        return null;
    }

    #region ApiBetPlay

    public async Task<ResponseTokenBetplay> GetTokenBetplay(RequesttokenBetplay requesttoken)
    {
        try
        {
            string controller = ConfigurationManager.AppSettings["GetTokenBetplay"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = await GetData(requesttoken, controller, basseAddress);

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var ResponseData = JsonConvert.DeserializeObject<ResponseTokenBetplay>(x);

                EventLogger.SaveLog(EventType.Info, "Respuesta al metodo GetConsultBetplay", x);

                if (ResponseData.Token != null)
                {
                    return ResponseData;
                }
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en GetTokenBetplay: {ex.Message}");
        }
        return null;
    }

    public async Task<ResponseGetProducts> GetProductsBetPlay(RequestConsultSubproductBetplay request)
    {
        try
        {
            string controller = ConfigurationManager.AppSettings["GetProductsBetPlay"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = await GetData(request, controller, basseAddress);

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var ResponseData = JsonConvert.DeserializeObject<ResponseGetProducts>(x);

                EventLogger.SaveLog(EventType.Info, "Respuesta a la ejecucion GetProductsBetPlay Response", x);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en GetProductsBetPlay: {ex.Message}");
        }
        return null;
    }

    public ResponseNotifyBetPlay NotifyPayment(RequestNotifyBetplay Machine)
    {
        try
        {
            string controller = ConfigurationManager.AppSettings["NotifyRecharge"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(Machine, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                string jsonLimpio = System.Text.RegularExpressions.Regex.Unescape(x).Trim('"');

                jsonLimpio = jsonLimpio.Replace(@"\\", "");

                var requestData = JsonConvert.DeserializeObject<ResponseNotifyBetPlay>(jsonLimpio);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion NotifyPayment Response", x);

                return requestData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en NotifyPayment: {ex.Message}");
        }
        return null;
    }

    #endregion

    #region ApiChance

    public ResponseGetProducts GetProductsChance(RequestSubproducts request)
    {
        try
        {
            string controller = ConfigurationManager.AppSettings["GetProductsChance"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(request, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var ResponseData = JsonConvert.DeserializeObject<ResponseGetProducts>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion GetProductsChance Response", x);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en GetProductsChance: {ex.Message}");
        }
        return null;
    }

    public ResponseGetLotteries GetLotteries(RequestGetLotteries Machine)
    {
        try
        {
            var y = JsonConvert.SerializeObject(Machine);

            EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion GetLotteries Request", y);

            string controller = ConfigurationManager.AppSettings["GetLotteries"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(Machine, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var requestData = JsonConvert.DeserializeObject<ResponseGetLotteries>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion GetLotteries Response", x);

                return requestData; 
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en GetLotteries: {ex.Message}");
        }
        return null;
    }

    public ResponseTypeChance TypeChance(IdProducto Machine)
    {
        try
        {
            var y = JsonConvert.SerializeObject(Machine);

            EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion TypeChance Request", y);

            string controller = ConfigurationManager.AppSettings["TypeChance"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(Machine, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var requestData = JsonConvert.DeserializeObject<ResponseTypeChance>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion TypeChance Response", x);

                return requestData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en TypeChance: {ex.Message}");
        }
        return null;
    }

    public ResponseValidateChance ValidateChance(RequestValidateChance Machine)
    {
        try
        {
            var y = JsonConvert.SerializeObject(Machine);

            EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion ValidateChance Request", y);

            string controller = ConfigurationManager.AppSettings["ValidateChance"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(Machine, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var requestData = JsonConvert.DeserializeObject<ResponseValidateChance>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion ValidateChance Response", x);

                return requestData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en ValidateChance: {ex.Message}");
        }
        return null;
    }

    public ResponseNotifyChance NotifyChance(RequestNotifyChance Machine)
    {
        try
        {
            var y = JsonConvert.SerializeObject(Machine);

            EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion NotifyChance Request", y);

            string controller = ConfigurationManager.AppSettings["NotifyChance"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(Machine, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var requestData = JsonConvert.DeserializeObject<ResponseNotifyChance>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion NotifyChance Response", x);

                return requestData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en NotifyChance: {ex.Message}");
        }
        return null;
    }

    #endregion

    #region ApiRecaudo

    public ResponseGetRecaudo GetRecaudos(RequestGetRecaudos request)
    {
        try
        {
            string controller = ConfigurationManager.AppSettings["GetRecaudo"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(request, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var ResponseData = JsonConvert.DeserializeObject<ResponseGetRecaudo>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion GetRecaudos Response", x);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en GetRecaudos: {ex.Message}");
        }
        return null;
    }

    public ResponseGetParameters GetParameters(RequestGetParameters request)
    {
        try
        {
            string controller = ConfigurationManager.AppSettings["GetParameters"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(request, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var ResponseData = JsonConvert.DeserializeObject<ResponseGetParameters>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion GetParameters Response", x);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en GetParameters: {ex.Message}");
        }
        return null;
    }

    public ResponseConsultValue ConsultValueRecaudo(RequestConsultValue request)
    {
        try
        {
            string controller = ConfigurationManager.AppSettings["ConsultRecaudo"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(request, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var ResponseData = JsonConvert.DeserializeObject<ResponseConsultValue>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion ConsultValueRecaudo Response", x);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en ConsultValueRecaudo: {ex.Message}");
        }
        return null;
    }

    public ResponseNotifyPayment NotifyPaymentRecaudo(RequestNotifyRecaudo request)
    {
        try
        {
            var y = JsonConvert.SerializeObject(request);

            EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion NotifyPaymentRecaudo Request", y);

            string controller = ConfigurationManager.AppSettings["NotifyPay"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = GetData(request, controller, basseAddress).GetAwaiter().GetResult();

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                var ResponseData = JsonConvert.DeserializeObject<ResponseNotifyPayment>(x);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion NotifyPaymentRecaudo Response", x);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en NotifyPaymentRecaudo: {ex.Message}");
        }
        return null;
    }

    #endregion

    #region ApiPaquetes

    public async Task<ResponseConsultSubproductosPaquetes> ConsultSubproductosPaquetes(RequestConsultSubproductosPaquetes request)
    {
        try
        {
            var y = JsonConvert.SerializeObject(request);

            EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion ConsultSubproductosPaquetes Request", y);

            string controller = ConfigurationManager.AppSettings["ConsultSubproductosPaquetes"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = await GetData(request, controller, basseAddress);

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion ConsultSubproductosPaquetes Response", x);

                string jsonLimpio = System.Text.RegularExpressions.Regex.Unescape(x).Trim('"');

                jsonLimpio = jsonLimpio.Replace(@"\\", "");

                var ResponseData = JsonConvert.DeserializeObject<ResponseConsultSubproductosPaquetes>(jsonLimpio);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en ConsultSubproductosPaquetes: {ex.Message}");
        }
        return null;
    }

    public async Task<ResponseConsultPaquetes> ConsultPaquetes(RequestConsultPaquetes request)
    {
        try
        {
            var y = JsonConvert.SerializeObject(request);

            EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion ConsultPaquetes Request", y);

            string controller = ConfigurationManager.AppSettings["ConsultarPaquetes"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = await GetData(request, controller, basseAddress);

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion ConsultPaquetes Response", x);

                string jsonLimpio = System.Text.RegularExpressions.Regex.Unescape(x).Trim('"');

                jsonLimpio = jsonLimpio.Replace(@"\\", "");

                var ResponseData = JsonConvert.DeserializeObject<ResponseConsultPaquetes>(jsonLimpio);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en ConsultPaquetes: {ex.Message}");
        }
        return null;
    }

    public async Task<ResponseGuardarPaquetes> GuardarPaquetes(RequestGuardarPaquete request)
    {
        try
        {
            var y = JsonConvert.SerializeObject(request);

            EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion GuardarPaquetes Request", y);

            string controller = ConfigurationManager.AppSettings["GuardarPaquetes"];

            basseAddress = ConfigurationManager.AppSettings["basseAddressIntegration"];

            var response = await GetData(request, controller, basseAddress);

            if (response != null)
            {
                var x = JsonConvert.SerializeObject(response.ResponseData);

                EventLogger.SaveLog(EventType.Info, "entrando a la ejecucion GuardarPaquetes Response", x);

                string jsonLimpio = System.Text.RegularExpressions.Regex.Unescape(x).Trim('"');

                jsonLimpio = jsonLimpio.Replace(@"\\", "");

                var ResponseData = JsonConvert.DeserializeObject<ResponseGuardarPaquetes>(jsonLimpio);

                return ResponseData;
            }
        }
        catch (Exception ex)
        {
            EventLogger.SaveLog(EventType.Info, $"Error en GuardarPaquetes: {ex.Message}");
        }
        return null;
    }

    #endregion


}
