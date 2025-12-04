using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject para misiones del Bazar de Nix
/// Sistema de quests con trueque
/// </summary>
[CreateAssetMenu(menuName = "Bazar/Crear Mision de Trueque")]
public class MisionBazar : ScriptableObject
{
    [Header("Información Básica")]
    [SerializeField] private string nombreMision = "";
    [SerializeField] [TextArea(3, 5)] private string descripcion = "";
    [SerializeField] private Sprite iconoMision;
    
    [Header("Diálogos")]
    [SerializeField] private TextAsset dialogoInicio;
    [SerializeField] private TextAsset dialogoEnProgreso;
    [SerializeField] private TextAsset dialogoCompletado;
    
    [Header("Requisitos")]
    [SerializeField] private List<RequisitoItem> itemsRequeridos = new List<RequisitoItem>();
    [SerializeField] private int monedasRequeridas = 0;
    
    [Header("Recompensas")]
    [SerializeField] private List<RecompensaItem> itemsRecompensa = new List<RecompensaItem>();
    [SerializeField] private int monedasRecompensa = 0;
    [SerializeField] private bool desbloqueaItemRaro = false;
    
    [Header("NPCs Involucrados")]
    [SerializeField] private string npcOrigen = "";
    [SerializeField] private string npcDestino = "";
    
    [Header("Textos de UI")]
    [SerializeField] private string textoGuia = "";
    [SerializeField] private string textoObjetivo = "";
    
    // Propiedades públicas
    public string NombreMision => nombreMision;
    public string Descripcion => descripcion;
    public Sprite IconoMision => iconoMision;
    public TextAsset DialogoInicio => dialogoInicio;
    public TextAsset DialogoEnProgreso => dialogoEnProgreso;
    public TextAsset DialogoCompletado => dialogoCompletado;
    public List<RequisitoItem> ItemsRequeridos => itemsRequeridos;
    public int MonedasRequeridas => monedasRequeridas;
    public List<RecompensaItem> ItemsRecompensa => itemsRecompensa;
    public int MonedasRecompensa => monedasRecompensa;
    public bool DesbloqueaItemRaro => desbloqueaItemRaro;
    public string NPCOrigen => npcOrigen;
    public string NPCDestino => npcDestino;
    public string TextoGuia => textoGuia;
    public string TextoObjetivo => textoObjetivo;
}

[System.Serializable]
public class RequisitoItem
{
    public ItemBase item;
    public int cantidad = 1;
    
    public RequisitoItem(ItemBase item, int cantidad)
    {
        this.item = item;
        this.cantidad = cantidad;
    }
}

[System.Serializable]
public class RecompensaItem
{
    public ItemBase item;
    public int cantidad = 1;
    
    public RecompensaItem(ItemBase item, int cantidad)
    {
        this.item = item;
        this.cantidad = cantidad;
    }
}
