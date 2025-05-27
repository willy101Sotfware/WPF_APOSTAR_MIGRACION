namespace WPF_APOSTAR_MIGRACION.Domain.Enumerables;

public enum StateTransaction
{
    Iniciada = 1,
    Aprobada,
    Cancelada,
    AprobadaErrorDevuelta,
    CanceladaErrorDevuelta,
    AprobadaSinNotificar,
    ErrorServicioTercero
}
