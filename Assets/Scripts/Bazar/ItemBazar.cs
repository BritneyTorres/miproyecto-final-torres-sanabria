using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject para ítems del Bazar de Nix
/// Extiende ItemBase con propiedades de comercio
/// </summary>
[CreateAssetMenu(menuName = "Bazar/Crear Item de Comercio")]
public class ItemBazar : ItemBase
{
    [Header("Propiedades de Comercio")]
    [SerializeField] private int valorBase = 1;
    [SerializeField] private TipoItem tipoItem = TipoItem.Recurso;
    [SerializeField] private RarezaItem rareza = RarezaItem.Comun;
    [SerializeField] private bool esIntercambiable = true;
    [SerializeField] private bool esMaterialMision = false;
    
    [Header("Información de Origen")]
    [SerializeField] private string vendedorOrigen = "";
    [SerializeField] private string descripcionExtendida = "";
    
    public int ValorBase => valorBase;
    public TipoItem Tipo => tipoItem;
    public RarezaItem Rareza => rareza;
    public bool EsIntercambiable => esIntercambiable;
    public bool EsMaterialMision => esMaterialMision;
    public string VendedorOrigen => vendedorOrigen;
    public string DescripcionExtendida => descripcionExtendida;
    
    /// <summary>
    /// Calcula el precio de venta según el vendedor
    /// </summary>
    public int CalcularPrecioVenta(bool esEstafador = false)
    {
        if (esEstafador)
        {
            // El estafador paga muy poco
            return Mathf.Max(1, valorBase / 5);
        }
        return valorBase;
    }
    
    /// <summary>
    /// Calcula el precio de compra según el vendedor
    /// </summary>
    public int CalcularPrecioCompra(bool esEstafador = false)
    {
        if (esEstafador)
        {
            // El estafador cobra mucho más
            return valorBase * 5;
        }
        return Mathf.RoundToInt(valorBase * 1.2f);
    }
}

public enum TipoItem
{
    Recurso,        // Materiales básicos
    Especia,        // Azafrán, canela, pimienta
    Tela,           // Telas de diferentes calidades
    Herramienta,    // Herramientas del herrero
    Alimento,       // Comida
    Artesania,      // Productos artesanales
    Especial,       // Ítems únicos de misión
    Moneda          // Monedas de oro
}

public enum RarezaItem
{
    Comun,          // Fácil de conseguir
    PocoComun,      // Requiere algo de esfuerzo
    Raro,           // Difícil de obtener
    MuyRaro,        // Solo de vendedores específicos
    Legendario      // El Amuleto
}
