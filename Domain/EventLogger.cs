using Newtonsoft.Json;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using WPF_APOSTAR_MIGRACION.Domain.Variables;

namespace WPF_APOSTAR_MIGRACION.Domain
{
    public static class EventLogger
    {
        public static void SaveLog(EventType type, string msg, object? obj = null,
            [CallerMemberName] string method = "", [CallerFilePath] string callerPath = "")
        {
            // TODO: poner error de cierre de aplicación en caso de que falle el log de eventos
            var _class = Path.GetFileNameWithoutExtension(callerPath);
            var _event = new Event
            {
                Time = DateTime.Now.ToString("hh:mm:ss.fff tt"),
                IdTransaction = 0,
                Type = type.ToString(),
                Class = $"{_class}",
                Method = method,
                Message = msg,
                Obj = obj,
            };

            // Todos los logs van a la misma carpeta
            WriteFile(_event, "");
        }


        private static void WriteFile(Event evt, string folder)
        {
            try
            {
                var json = JsonConvert.SerializeObject(evt, Formatting.Indented);


                // Obtener la ruta de logs desde AppConfig
                string logPath = ConfigurationManager.AppSettings["PathLog"];
                if (string.IsNullOrEmpty(logPath))
                {
                    // Si no está definido en AppConfig, usar la ruta por defecto
                    logPath = Path.Combine(AppInfo.APP_DIR, "Log");
                }
                
                // Crear la carpeta si no existe
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                var fileName = "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".json";
                var filePath = Path.Combine(logPath, fileName);

                if (!File.Exists(filePath))
                {
                    var archivo = File.CreateText(filePath);
                    archivo.Close();
                }

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(json);
                }
            }
            catch (Exception ex)
            {

            }

        }
    }

    public class Event
    {
        public string Time { get; set; }
        public int IdTransaction { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public object? Obj { get; set; }
    }

    public enum EventType
    {
        FatalError,
        Error,
        Warning,
        Info,
        P_Acceptor,
        P_Arduino,
        Integration,
        P_Dispenser

    }

    public enum EResponseCode
    {
        Error = 300,
        NotFound = 404,
        OK = 200
    }

    public enum ETypeTramites
    {

        [Description("Recarga BetPlay")]
        BetPlay = 56,
        [Description("SuperChance")]
        SuperChance = 57,
        [Description("Recarga Celular")]
        RecargasCel = 58,
        [Description("Paquetes Celular")]
        PaquetesCel = 59,
        [Description("Recaudos")]
        Recaudos = 72,
        [Description("Chance")]
        Chance = 73
    }


}
