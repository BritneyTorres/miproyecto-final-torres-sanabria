using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject para vendedores del Bazar
/// Define ofertas y comportamiento de cada NPC vendedor
/// </summary>
[CreateAssetMenu(menuName = "Bazar/Crear Vendedor")]
public class VendedorBazar : ScriptableObject
{
    [Header("Información del Vendedor")]
    [SerializeField] private string nombreVendedor = "";
    [SerializeField] private string titulo = "";
    [SerializeField] [TextArea(2, 4)] private string descripcion = "";
    [SerializeField] private Sprite retrato;
    [SerializeField] private TipoVendedor tipoVendedor = TipoVendedor.Normal;
    
    [Header("Diálogos")]
    [SerializeField] private TextAsset dialogoPrincipal;
    [SerializeField] private List<string> frasesAleatorias = new List<string>();
    
    [Header("Ofertas de Intercambio")]
    [SerializeField] private List<OfertaIntercambio> ofertas = new List<OfertaIntercambio>();
    
    [Header("Ítems Especiales")]
    [SerializeField] private ItemBase itemEspecialMision;
    [SerializeField] private string requisitoParaItemEspecial = "";
    
    [Header("Comportamiento (Solo para Estafador)")]
    [SerializeField] private float multiplicadorPrecioCompra = 1.0f;
    [SerializeField] private float multiplicadorPrecioVenta = 1.0f;
    [SerializeField] private float tiempoAparicion = 30f;
    [SerializeField] private float tiempoDesaparicion = 60f;
    
    // Propiedades públicas
    public string NombreVendedor => nombreVendedor;
    public string Titulo => titulo;
    public string Descripcion => descripcion;
    public Sprite Retrato => retrato;
    public TipoVendedor Tipo => tipoVendedor;
    public TextAsset DialogoPrincipal => dialogoPrincipal;
    public List<string> FrasesAleatorias => frasesAleatorias;
    public List<OfertaIntercambio> Ofertas => ofertas;
    public ItemBase ItemEspecialMision => itemEspecialMision;
    public string RequisitoParaItemEspecial => requisitoParaItemEspecial;
    public float MultiplicadorPrecioCompra => multiplicadorPrecioCompra;
    public float MultiplicadorPrecioVenta => multiplicadorPrecioVenta;
    public float TiempoAparicion => tiempoAparicion;
    public float TiempoDesaparicion => tiempoDesaparicion;
    
    /// <summary>
    /// Obtiene una frase aleatoria del vendedor
    /// </summary>
    public string ObtenerFraseAleatoria()
    {
        if (frasesAleatorias.Count == 0)
            return $"¡Bienvenido a mi puesto!";
        return frasesAleatorias[Random.Range(0, frasesAleatorias.Count)];
    }
    
    /// <summary>
    /// Verifica si el vendedor tiene una oferta específica
    /// </summary>
    public bool TieneOferta(ItemBase itemBuscado)
    {
        foreach (var oferta in ofertas)
        {
            if (oferta.itemOfrecido == itemBuscado)
                return true;
        }
        return false;
    }
}

public enum TipoVendedor
{
    Normal,         // Vendedor honesto del bazar
    Especial,       // El Maestro Artesano
    Estafador       // El Estafador Ambulante
}

[System.Serializable]
public class OfertaIntercambio
{
    [Header("Lo que el vendedor ofrece")]
    public ItemBase itemOfrecido;
    public int cantidadOfrecida = 1;
    
    [Header("Lo que el vendedor pide")]
    public ItemBase itemRequerido;
    public int cantidadRequerida = 1;
    
    [Header("Información adicional")]
    [TextArea(1, 2)]
    public string descripcionOferta = "";
    public bool esOfertaEspecial = false;
    
    public OfertaIntercambio(ItemBase ofrecido, int cantOfrec, ItemBase requerido, int cantReq)
    {
        itemOfrecido = ofrecido;
        cantidadOfrecida = cantOfrec;
        itemRequerido = requerido;
        cantidadRequerida = cantReq;
    }
}
