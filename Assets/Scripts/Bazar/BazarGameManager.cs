using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gestor principal del Bazar de Nix
/// Controla el estado del juego, misiones y economía
/// </summary>
public class BazarGameManager : MonoBehaviour
{
    public static BazarGameManager Instance { get; private set; }
    
    [Header("Configuración del Bazar")]
    [SerializeField] private string nombreJugador = "Nix";
    [SerializeField] private int monedasIniciales = 50;
    
    [Header("Vendedores")]
    [SerializeField] private List<VendedorBazar> vendedoresDelBazar = new List<VendedorBazar>();
    [SerializeField] private EstafadorController estafadorController;
    
    [Header("Misión Principal")]
    [SerializeField] private MisionBazar misionAmuleto;
    [SerializeField] private bool misionActiva = false;
    [SerializeField] private bool misionCompletada = false;
    
    [Header("Materiales de Misión")]
    [SerializeField] private bool tieneAzafranDorado = false;
    [SerializeField] private bool tieneTelaDeLAlba = false;
    [SerializeField] private bool tieneMartilloAncestral = false;
    
    [Header("Estado del Juego")]
    [SerializeField] private int monedasActuales;
    [SerializeField] private int intercambiosRealizados = 0;
    [SerializeField] private int vecesEstafado = 0;
    
    [Header("Referencias")]
    [SerializeField] private Inventory inventarioJugador;
    [SerializeField] private TradeUIManager tradeUI;
    
    // Eventos
    public System.Action<int> OnMonedasCambiadas;
    public System.Action<string> OnMisionActualizada;
    public System.Action OnMisionCompletada;
    public System.Action<string> OnNotificacion;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        InicializarJuego();
    }
    
    /// <summary>
    /// Inicializa el estado del juego
    /// </summary>
    private void InicializarJuego()
    {
        monedasActuales = monedasIniciales;
        OnMonedasCambiadas?.Invoke(monedasActuales);
        
        // Notificar inicio
        OnNotificacion?.Invoke(LocalizacionEspanol.TUTORIAL_BIENVENIDA);
        
        Debug.Log($"[Bazar] Juego iniciado. Jugador: {nombreJugador}, Monedas: {monedasActuales}");
    }
    
    /// <summary>
    /// Activa la misión principal del Amuleto
    /// </summary>
    public void ActivarMisionAmuleto()
    {
        if (misionActiva) return;
        
        misionActiva = true;
        OnNotificacion?.Invoke(LocalizacionEspanol.MISION_NUEVA);
        OnMisionActualizada?.Invoke(LocalizacionEspanol.MISION_AMULETO_NOMBRE);
        
        Debug.Log("[Bazar] Misión del Amuleto activada");
    }
    
    /// <summary>
    /// Registra la obtención de un material de misión
    /// </summary>
    public void ObtenerMaterialMision(string nombreMaterial)
    {
        switch (nombreMaterial.ToLower())
        {
            case "azafran":
            case "azafran_dorado":
                tieneAzafranDorado = true;
                OnMisionActualizada?.Invoke(LocalizacionEspanol.MISION_AMULETO_OBJ1 + " ✓");
                break;
            case "tela":
            case "tela_alba":
                tieneTelaDeLAlba = true;
                OnMisionActualizada?.Invoke(LocalizacionEspanol.MISION_AMULETO_OBJ2 + " ✓");
                break;
            case "martillo":
            case "martillo_ancestral":
                tieneMartilloAncestral = true;
                OnMisionActualizada?.Invoke(LocalizacionEspanol.MISION_AMULETO_OBJ3 + " ✓");
                break;
        }
        
        VerificarMisionCompleta();
    }
    
    /// <summary>
    /// Verifica si todos los materiales han sido recolectados
    /// </summary>
    private void VerificarMisionCompleta()
    {
        if (tieneAzafranDorado && tieneTelaDeLAlba && tieneMartilloAncestral)
        {
            OnNotificacion?.Invoke(LocalizacionEspanol.MISION_COMPLETADA);
            Debug.Log("[Bazar] ¡Todos los materiales recolectados!");
        }
    }
    
    /// <summary>
    /// Completa la misión y entrega el Amuleto
    /// </summary>
    public void CompletarMision()
    {
        if (!tieneAzafranDorado || !tieneTelaDeLAlba || !tieneMartilloAncestral)
        {
            Debug.LogWarning("[Bazar] No se tienen todos los materiales");
            return;
        }
        
        misionCompletada = true;
        OnMisionCompletada?.Invoke();
        OnNotificacion?.Invoke("¡Has obtenido el " + LocalizacionEspanol.ITEM_AMULETO + "!");
        
        Debug.Log("[Bazar] ¡Misión completada! Amuleto obtenido.");
    }
    
    /// <summary>
    /// Modifica las monedas del jugador
    /// </summary>
    public void ModificarMonedas(int cantidad)
    {
        monedasActuales += cantidad;
        if (monedasActuales < 0) monedasActuales = 0;
        
        OnMonedasCambiadas?.Invoke(monedasActuales);
    }
    
    /// <summary>
    /// Registra un intercambio realizado
    /// </summary>
    public void RegistrarIntercambio(bool conEstafador = false)
    {
        intercambiosRealizados++;
        
        if (conEstafador)
        {
            vecesEstafado++;
            Debug.LogWarning($"[Bazar] ¡El jugador fue estafado! Total: {vecesEstafado}");
        }
    }
    
    /// <summary>
    /// Obtiene el estado actual de la misión
    /// </summary>
    public string ObtenerEstadoMision()
    {
        if (!misionActiva)
            return "Misión no iniciada. Habla con el Maestro Artesano.";
        
        if (misionCompletada)
            return "¡Misión completada! Tienes el Amuleto del Comerciante Legendario.";
        
        string estado = $"{LocalizacionEspanol.MISION_EN_PROGRESO}\n";
        estado += $"• Azafrán Dorado: {(tieneAzafranDorado ? "✓" : "○")}\n";
        estado += $"• Tela del Alba: {(tieneTelaDeLAlba ? "✓" : "○")}\n";
        estado += $"• Martillo Ancestral: {(tieneMartilloAncestral ? "✓" : "○")}";
        
        return estado;
    }
    
    /// <summary>
    /// Guarda el estado del juego
    /// </summary>
    public Dictionary<string, object> GuardarEstado()
    {
        return new Dictionary<string, object>
        {
            { "monedas", monedasActuales },
            { "misionActiva", misionActiva },
            { "misionCompletada", misionCompletada },
            { "tieneAzafran", tieneAzafranDorado },
            { "tieneTela", tieneTelaDeLAlba },
            { "tieneMartillo", tieneMartilloAncestral },
            { "intercambios", intercambiosRealizados },
            { "vecesEstafado", vecesEstafado }
        };
    }
    
    /// <summary>
    /// Carga el estado del juego
    /// </summary>
    public void CargarEstado(Dictionary<string, object> estado)
    {
        if (estado == null) return;
        
        if (estado.ContainsKey("monedas"))
            monedasActuales = (int)estado["monedas"];
        
        if (estado.ContainsKey("misionActiva"))
            misionActiva = (bool)estado["misionActiva"];
        
        if (estado.ContainsKey("misionCompletada"))
            misionCompletada = (bool)estado["misionCompletada"];
        
        if (estado.ContainsKey("tieneAzafran"))
            tieneAzafranDorado = (bool)estado["tieneAzafran"];
        
        if (estado.ContainsKey("tieneTela"))
            tieneTelaDeLAlba = (bool)estado["tieneTela"];
        
        if (estado.ContainsKey("tieneMartillo"))
            tieneMartilloAncestral = (bool)estado["tieneMartillo"];
        
        if (estado.ContainsKey("intercambios"))
            intercambiosRealizados = (int)estado["intercambios"];
        
        if (estado.ContainsKey("vecesEstafado"))
            vecesEstafado = (int)estado["vecesEstafado"];
        
        OnMonedasCambiadas?.Invoke(monedasActuales);
        OnNotificacion?.Invoke(LocalizacionEspanol.NOTIF_CARGADO);
    }
    
    // Propiedades públicas
    public int MonedasActuales => monedasActuales;
    public bool MisionActiva => misionActiva;
    public bool MisionCompletada => misionCompletada;
    public int IntercambiosRealizados => intercambiosRealizados;
    public int VecesEstafado => vecesEstafado;
    public string NombreJugador => nombreJugador;
}
