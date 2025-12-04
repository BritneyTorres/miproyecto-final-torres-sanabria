using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del Estafador Ambulante
/// Maneja su comportamiento de aparición, ofertas engañosas y lógica de IA
/// </summary>
public class EstafadorController : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private VendedorBazar datosEstafador;
    [SerializeField] private float intervaloOferta = 45f;
    [SerializeField] private float tiempoVisible = 30f;
    
    [Header("Estado")]
    [SerializeField] private bool estaActivo = false;
    [SerializeField] private float tiempoSiguienteAparicion;
    
    [Header("Recursos del Jugador a Vigilar")]
    [SerializeField] private List<ItemBase> recursosCriticos = new List<ItemBase>();
    
    [Header("Referencias")]
    [SerializeField] private GameObject visualEstafador;
    [SerializeField] private Transform[] posicionesAparicion;
    
    // Estado interno
    private float temporizadorAparicion;
    private float temporizadorOferta;
    private int posicionActual = 0;
    private bool jugadorCerca = false;
    
    // Eventos
    public System.Action<string> OnEstafadorAparece;
    public System.Action<string> OnEstafadorOfreceTrafo;
    public System.Action OnEstafadorDesaparece;
    
    private void Start()
    {
        if (datosEstafador != null)
        {
            tiempoSiguienteAparicion = datosEstafador.TiempoAparicion;
        }
        else
        {
            tiempoSiguienteAparicion = 60f;
        }
        
        temporizadorAparicion = tiempoSiguienteAparicion;
        OcultarEstafador();
    }
    
    private void Update()
    {
        if (!estaActivo)
        {
            // Cuenta regresiva para aparecer
            temporizadorAparicion -= Time.deltaTime;
            
            if (temporizadorAparicion <= 0)
            {
                AparecerEstafador();
            }
        }
        else
        {
            // Cuenta regresiva para desaparecer
            temporizadorOferta -= Time.deltaTime;
            
            if (temporizadorOferta <= 0)
            {
                DesaparecerEstafador();
            }
            
            // Si el jugador está cerca, intenta ofrecer tratos
            if (jugadorCerca)
            {
                IntentarOfrecerTrato();
            }
        }
    }
    
    /// <summary>
    /// Hace aparecer al estafador en una posición aleatoria
    /// </summary>
    public void AparecerEstafador()
    {
        estaActivo = true;
        temporizadorOferta = tiempoVisible;
        
        // Elegir posición aleatoria
        if (posicionesAparicion != null && posicionesAparicion.Length > 0)
        {
            posicionActual = Random.Range(0, posicionesAparicion.Length);
            transform.position = posicionesAparicion[posicionActual].position;
        }
        
        if (visualEstafador != null)
        {
            visualEstafador.SetActive(true);
        }
        
        // Notificar al jugador
        string mensaje = LocalizacionEspanol.ESTAFADOR_APARECE;
        OnEstafadorAparece?.Invoke(mensaje);
        
        Debug.Log($"[Estafador] Ha aparecido en posición {posicionActual}");
    }
    
    /// <summary>
    /// Oculta al estafador
    /// </summary>
    public void DesaparecerEstafador()
    {
        estaActivo = false;
        temporizadorAparicion = tiempoSiguienteAparicion + Random.Range(-10f, 10f);
        
        OcultarEstafador();
        
        OnEstafadorDesaparece?.Invoke();
        
        Debug.Log("[Estafador] Ha desaparecido");
    }
    
    private void OcultarEstafador()
    {
        if (visualEstafador != null)
        {
            visualEstafador.SetActive(false);
        }
    }
    
    /// <summary>
    /// Intenta ofrecer un mal trato al jugador
    /// </summary>
    private void IntentarOfrecerTrato()
    {
        if (datosEstafador == null || datosEstafador.Ofertas.Count == 0)
            return;
        
        // Elegir una oferta aleatoria (mala para el jugador)
        var oferta = datosEstafador.Ofertas[Random.Range(0, datosEstafador.Ofertas.Count)];
        
        string mensajeOferta = $"¡Te ofrezco {oferta.cantidadOfrecida} {oferta.itemOfrecido.Name} por solo {oferta.cantidadRequerida} {oferta.itemRequerido.Name}!";
        
        OnEstafadorOfreceTrafo?.Invoke(mensajeOferta);
    }
    
    /// <summary>
    /// Verifica si el estafador puede comprar un recurso crítico del jugador
    /// </summary>
    public bool PuedeComprarRecursoCritico(Inventory inventarioJugador)
    {
        foreach (var recurso in recursosCriticos)
        {
            if (inventarioJugador.HasItem(recurso, 1))
            {
                return true;
            }
        }
        return false;
    }
    
    /// <summary>
    /// El estafador intenta comprar un recurso crítico a precio muy bajo
    /// </summary>
    public void IntentarComprarRecursoCritico(Inventory inventarioJugador)
    {
        if (!PuedeComprarRecursoCritico(inventarioJugador))
            return;
        
        // Buscar un recurso crítico que el jugador tenga
        foreach (var recurso in recursosCriticos)
        {
            if (inventarioJugador.HasItem(recurso, 1))
            {
                string advertencia = LocalizacionEspanol.Formatear(
                    LocalizacionEspanol.ESTAFADOR_COMPRO, 
                    recurso.Name
                );
                
                Debug.LogWarning($"[Estafador] Intenta comprar {recurso.Name} del jugador");
                break;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
    
    /// <summary>
    /// Calcula un precio muy bajo para comprar del jugador
    /// </summary>
    public int CalcularPrecioCompra(ItemBase item)
    {
        if (item is ItemBazar itemBazar)
        {
            return itemBazar.CalcularPrecioVenta(true); // Precio de estafador
        }
        return 1; // Precio mínimo
    }
    
    /// <summary>
    /// Calcula un precio muy alto para vender al jugador
    /// </summary>
    public int CalcularPrecioVenta(ItemBase item)
    {
        if (item is ItemBazar itemBazar)
        {
            return itemBazar.CalcularPrecioCompra(true); // Precio de estafador
        }
        return 100; // Precio inflado
    }
}
