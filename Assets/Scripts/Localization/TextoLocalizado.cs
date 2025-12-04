using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Componente para aplicar textos localizados a elementos de UI
/// Adjuntar a GameObjects con Text o TextMeshPro
/// </summary>
public class TextoLocalizado : MonoBehaviour
{
    public enum TipoTexto
    {
        // Menú
        MenuJugar,
        MenuContinuar,
        MenuOpciones,
        MenuSalir,
        MenuCreditos,
        
        // Inventario
        InventarioTitulo,
        InventarioVacio,
        InventarioLleno,
        
        // Comercio
        ComercioTitulo,
        ComercioTuOferta,
        ComercioSuOferta,
        ComercioAceptar,
        ComercioRechazar,
        ComercioCancelar,
        
        // Misiones
        MisionNueva,
        MisionCompletada,
        MisionEnProgreso,
        MisionAmuletoNombre,
        
        // Diálogo
        DialogoContinuar,
        DialogoOpcion,
        DialogoSaltar,
        
        // Tutorial
        TutorialBienvenida,
        TutorialMovimiento,
        TutorialInteraccion,
        TutorialInventario,
        TutorialComercio,
        
        // Ubicaciones
        UbicacionBazar,
        UbicacionEspecias,
        UbicacionTelas,
        UbicacionHerramientas,
        UbicacionAlimentos,
        UbicacionArtesanias,
        UbicacionMisterioso,
        
        // Notificaciones
        NotifGuardado,
        NotifCargado,
        NotifNuevoObjeto,
        
        // Carga
        Cargando
    }
    
    [SerializeField] private TipoTexto tipoTexto;
    
    private TextMeshProUGUI tmpText;
    private Text uiText;
    
    private void Awake()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        uiText = GetComponent<Text>();
    }
    
    private void Start()
    {
        AplicarTexto();
    }
    
    public void AplicarTexto()
    {
        string texto = ObtenerTextoLocalizado(tipoTexto);
        
        if (tmpText != null)
        {
            tmpText.text = texto;
        }
        else if (uiText != null)
        {
            uiText.text = texto;
        }
    }
    
    public static string ObtenerTextoLocalizado(TipoTexto tipo)
    {
        switch (tipo)
        {
            // Menú
            case TipoTexto.MenuJugar: return LocalizacionEspanol.MENU_JUGAR;
            case TipoTexto.MenuContinuar: return LocalizacionEspanol.MENU_CONTINUAR;
            case TipoTexto.MenuOpciones: return LocalizacionEspanol.MENU_OPCIONES;
            case TipoTexto.MenuSalir: return LocalizacionEspanol.MENU_SALIR;
            case TipoTexto.MenuCreditos: return LocalizacionEspanol.MENU_CREDITOS;
            
            // Inventario
            case TipoTexto.InventarioTitulo: return LocalizacionEspanol.INVENTARIO_TITULO;
            case TipoTexto.InventarioVacio: return LocalizacionEspanol.INVENTARIO_VACIO;
            case TipoTexto.InventarioLleno: return LocalizacionEspanol.INVENTARIO_LLENO;
            
            // Comercio
            case TipoTexto.ComercioTitulo: return LocalizacionEspanol.COMERCIO_TITULO;
            case TipoTexto.ComercioTuOferta: return LocalizacionEspanol.COMERCIO_TU_OFERTA;
            case TipoTexto.ComercioSuOferta: return LocalizacionEspanol.COMERCIO_SU_OFERTA;
            case TipoTexto.ComercioAceptar: return LocalizacionEspanol.COMERCIO_ACEPTAR;
            case TipoTexto.ComercioRechazar: return LocalizacionEspanol.COMERCIO_RECHAZAR;
            case TipoTexto.ComercioCancelar: return LocalizacionEspanol.COMERCIO_CANCELAR;
            
            // Misiones
            case TipoTexto.MisionNueva: return LocalizacionEspanol.MISION_NUEVA;
            case TipoTexto.MisionCompletada: return LocalizacionEspanol.MISION_COMPLETADA;
            case TipoTexto.MisionEnProgreso: return LocalizacionEspanol.MISION_EN_PROGRESO;
            case TipoTexto.MisionAmuletoNombre: return LocalizacionEspanol.MISION_AMULETO_NOMBRE;
            
            // Diálogo
            case TipoTexto.DialogoContinuar: return LocalizacionEspanol.DIALOGO_CONTINUAR;
            case TipoTexto.DialogoOpcion: return LocalizacionEspanol.DIALOGO_OPCION;
            case TipoTexto.DialogoSaltar: return LocalizacionEspanol.DIALOGO_SALTAR;
            
            // Tutorial
            case TipoTexto.TutorialBienvenida: return LocalizacionEspanol.TUTORIAL_BIENVENIDA;
            case TipoTexto.TutorialMovimiento: return LocalizacionEspanol.TUTORIAL_MOVIMIENTO;
            case TipoTexto.TutorialInteraccion: return LocalizacionEspanol.TUTORIAL_INTERACCION;
            case TipoTexto.TutorialInventario: return LocalizacionEspanol.TUTORIAL_INVENTARIO;
            case TipoTexto.TutorialComercio: return LocalizacionEspanol.TUTORIAL_COMERCIO;
            
            // Ubicaciones
            case TipoTexto.UbicacionBazar: return LocalizacionEspanol.UBICACION_BAZAR;
            case TipoTexto.UbicacionEspecias: return LocalizacionEspanol.UBICACION_ESPECIAS;
            case TipoTexto.UbicacionTelas: return LocalizacionEspanol.UBICACION_TELAS;
            case TipoTexto.UbicacionHerramientas: return LocalizacionEspanol.UBICACION_HERRAMIENTAS;
            case TipoTexto.UbicacionAlimentos: return LocalizacionEspanol.UBICACION_ALIMENTOS;
            case TipoTexto.UbicacionArtesanias: return LocalizacionEspanol.UBICACION_ARTESANIAS;
            case TipoTexto.UbicacionMisterioso: return LocalizacionEspanol.UBICACION_MISTERIOSO;
            
            // Notificaciones
            case TipoTexto.NotifGuardado: return LocalizacionEspanol.NOTIF_GUARDADO;
            case TipoTexto.NotifCargado: return LocalizacionEspanol.NOTIF_CARGADO;
            case TipoTexto.NotifNuevoObjeto: return LocalizacionEspanol.NOTIF_NUEVO_OBJETO;
            
            // Carga
            case TipoTexto.Cargando: return LocalizacionEspanol.CARGANDO;
            
            default: return "TEXTO_NO_DEFINIDO";
        }
    }
}
