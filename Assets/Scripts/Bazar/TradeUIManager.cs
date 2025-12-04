using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// Sistema de UI para intercambios comerciales en el Bazar de Nix
/// Maneja el panel de trade con swap offers
/// </summary>
public class TradeUIManager : MonoBehaviour
{
    [Header("Paneles Principales")]
    [SerializeField] private GameObject panelTrade;
    [SerializeField] private GameObject panelConfirmacion;
    
    [Header("Sección del Jugador")]
    [SerializeField] private Transform contenedorOfertaJugador;
    [SerializeField] private TextMeshProUGUI textoTuOferta;
    [SerializeField] private Image[] slotsJugador;
    
    [Header("Sección del Vendedor")]
    [SerializeField] private Transform contenedorOfertaVendedor;
    [SerializeField] private TextMeshProUGUI textoSuOferta;
    [SerializeField] private Image[] slotsVendedor;
    [SerializeField] private TextMeshProUGUI nombreVendedor;
    [SerializeField] private Image retratoVendedor;
    
    [Header("Botones")]
    [SerializeField] private Button botonAceptar;
    [SerializeField] private Button botonRechazar;
    [SerializeField] private Button botonCancelar;
    
    [Header("Información del Trato")]
    [SerializeField] private TextMeshProUGUI textoDescripcionTrato;
    [SerializeField] private TextMeshProUGUI textoAdvertencia;
    [SerializeField] private GameObject iconoAdvertencia;
    
    [Header("Audio")]
    [SerializeField] private AudioClip sonidoMoneda;
    [SerializeField] private AudioClip sonidoExito;
    [SerializeField] private AudioClip sonidoFallo;
    [SerializeField] private AudioSource audioSource;
    
    // Estado actual
    private VendedorBazar vendedorActual;
    private OfertaIntercambio ofertaActual;
    private Inventory inventarioJugador;
    private bool tradeEnProgreso = false;
    
    // Eventos
    public UnityEvent<bool> OnTradeCompleto;
    
    private void Awake()
    {
        // Configurar textos localizados
        if (textoTuOferta != null)
            textoTuOferta.text = LocalizacionEspanol.COMERCIO_TU_OFERTA;
        
        if (textoSuOferta != null)
            textoSuOferta.text = LocalizacionEspanol.COMERCIO_SU_OFERTA;
        
        // Configurar botones
        if (botonAceptar != null)
        {
            botonAceptar.onClick.AddListener(AceptarIntercambio);
            botonAceptar.GetComponentInChildren<TextMeshProUGUI>().text = LocalizacionEspanol.COMERCIO_ACEPTAR;
        }
        
        if (botonRechazar != null)
        {
            botonRechazar.onClick.AddListener(RechazarIntercambio);
            botonRechazar.GetComponentInChildren<TextMeshProUGUI>().text = LocalizacionEspanol.COMERCIO_RECHAZAR;
        }
        
        if (botonCancelar != null)
        {
            botonCancelar.onClick.AddListener(CerrarTrade);
            botonCancelar.GetComponentInChildren<TextMeshProUGUI>().text = LocalizacionEspanol.COMERCIO_CANCELAR;
        }
        
        CerrarTrade();
    }
    
    /// <summary>
    /// Abre el panel de trade con un vendedor específico
    /// </summary>
    public void AbrirTrade(VendedorBazar vendedor, OfertaIntercambio oferta, Inventory inventario)
    {
        vendedorActual = vendedor;
        ofertaActual = oferta;
        inventarioJugador = inventario;
        tradeEnProgreso = true;
        
        // Configurar UI del vendedor
        if (nombreVendedor != null)
            nombreVendedor.text = vendedor.NombreVendedor;
        
        if (retratoVendedor != null && vendedor.Retrato != null)
            retratoVendedor.sprite = vendedor.Retrato;
        
        // Mostrar lo que el vendedor ofrece
        MostrarItemEnSlots(slotsVendedor, oferta.itemOfrecido, oferta.cantidadOfrecida);
        
        // Mostrar lo que el vendedor pide
        MostrarItemEnSlots(slotsJugador, oferta.itemRequerido, oferta.cantidadRequerida);
        
        // Configurar descripción
        if (textoDescripcionTrato != null)
        {
            textoDescripcionTrato.text = oferta.descripcionOferta;
        }
        
        // Verificar si es un mal trato (estafador)
        bool esEstafador = vendedor.Tipo == TipoVendedor.Estafador;
        MostrarAdvertencia(esEstafador);
        
        // Verificar si el jugador tiene los recursos necesarios
        bool tieneRecursos = inventario.HasItem(oferta.itemRequerido, oferta.cantidadRequerida);
        botonAceptar.interactable = tieneRecursos;
        
        if (!tieneRecursos && textoAdvertencia != null)
        {
            textoAdvertencia.text = LocalizacionEspanol.COMERCIO_SIN_RECURSOS;
            textoAdvertencia.gameObject.SetActive(true);
        }
        
        // Mostrar panel
        if (panelTrade != null)
            panelTrade.SetActive(true);
        
        // Reproducir sonido
        if (audioSource != null && sonidoMoneda != null)
            audioSource.PlayOneShot(sonidoMoneda);
    }
    
    /// <summary>
    /// Muestra un ítem en los slots de UI
    /// </summary>
    private void MostrarItemEnSlots(Image[] slots, ItemBase item, int cantidad)
    {
        if (slots == null || item == null) return;
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < cantidad && item.Icon != null)
            {
                slots[i].sprite = item.Icon;
                slots[i].enabled = true;
                slots[i].color = Color.white;
            }
            else
            {
                slots[i].enabled = false;
            }
        }
    }
    
    /// <summary>
    /// Muestra advertencia para tratos sospechosos
    /// </summary>
    private void MostrarAdvertencia(bool mostrar)
    {
        if (iconoAdvertencia != null)
            iconoAdvertencia.SetActive(mostrar);
        
        if (textoAdvertencia != null && mostrar)
        {
            textoAdvertencia.text = LocalizacionEspanol.COMERCIO_TRATO_MALO;
            textoAdvertencia.gameObject.SetActive(true);
            textoAdvertencia.color = Color.red;
        }
        else if (textoAdvertencia != null)
        {
            textoAdvertencia.gameObject.SetActive(false);
        }
    }
    
    /// <summary>
    /// Acepta el intercambio actual
    /// </summary>
    public void AceptarIntercambio()
    {
        if (!tradeEnProgreso || ofertaActual == null || inventarioJugador == null)
            return;
        
        // Verificar recursos
        if (!inventarioJugador.HasItem(ofertaActual.itemRequerido, ofertaActual.cantidadRequerida))
        {
            MostrarMensaje(LocalizacionEspanol.COMERCIO_SIN_RECURSOS);
            return;
        }
        
        // Realizar intercambio
        inventarioJugador.RemoveItem(ofertaActual.itemRequerido, ofertaActual.cantidadRequerida);
        inventarioJugador.AddItem(ofertaActual.itemOfrecido, ofertaActual.cantidadOfrecida);
        
        // Efectos
        if (audioSource != null && sonidoExito != null)
            audioSource.PlayOneShot(sonidoExito);
        
        MostrarMensaje(LocalizacionEspanol.COMERCIO_EXITO);
        
        OnTradeCompleto?.Invoke(true);
        
        StartCoroutine(CerrarTradeDespuesDeDelay(1.5f));
    }
    
    /// <summary>
    /// Rechaza el intercambio actual
    /// </summary>
    public void RechazarIntercambio()
    {
        if (audioSource != null && sonidoFallo != null)
            audioSource.PlayOneShot(sonidoFallo);
        
        MostrarMensaje(LocalizacionEspanol.COMERCIO_FALLIDO);
        
        OnTradeCompleto?.Invoke(false);
        
        CerrarTrade();
    }
    
    /// <summary>
    /// Cierra el panel de trade
    /// </summary>
    public void CerrarTrade()
    {
        tradeEnProgreso = false;
        vendedorActual = null;
        ofertaActual = null;
        
        if (panelTrade != null)
            panelTrade.SetActive(false);
        
        if (panelConfirmacion != null)
            panelConfirmacion.SetActive(false);
    }
    
    private IEnumerator CerrarTradeDespuesDeDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        CerrarTrade();
    }
    
    private void MostrarMensaje(string mensaje)
    {
        if (textoDescripcionTrato != null)
        {
            textoDescripcionTrato.text = mensaje;
        }
        
        Debug.Log($"[Trade] {mensaje}");
    }
    
    /// <summary>
    /// Verifica si el panel de trade está abierto
    /// </summary>
    public bool EstaAbierto()
    {
        return panelTrade != null && panelTrade.activeSelf;
    }
}
