using UnityEngine;

/// <summary>
/// Sistema de localización en español para el Bazar de Nix
/// Contiene todos los textos de interfaz del juego
/// </summary>
public static class LocalizacionEspanol
{
    // ==========================================
    // TEXTOS DE INTERFAZ GENERAL
    // ==========================================
    
    // Menú Principal
    public const string MENU_JUGAR = "Jugar";
    public const string MENU_CONTINUAR = "Continuar";
    public const string MENU_OPCIONES = "Opciones";
    public const string MENU_SALIR = "Salir";
    public const string MENU_CREDITOS = "Créditos";
    
    // Pantalla de Carga
    public const string CARGANDO = "Cargando...";
    public const string CARGANDO_BAZAR = "Preparando el bazar...";
    
    // ==========================================
    // TEXTOS DE INVENTARIO
    // ==========================================
    
    public const string INVENTARIO_TITULO = "Inventario";
    public const string INVENTARIO_ESPACIOS = "Espacios: {0}/8";
    public const string INVENTARIO_VACIO = "Inventario vacío";
    public const string INVENTARIO_LLENO = "¡Inventario lleno!";
    public const string INVENTARIO_OBJETO_AGREGADO = "Objeto agregado: {0}";
    public const string INVENTARIO_OBJETO_REMOVIDO = "Objeto removido: {0}";
    
    // ==========================================
    // TEXTOS DEL SISTEMA DE COMERCIO (TRADE UI)
    // ==========================================
    
    public const string COMERCIO_TITULO = "Intercambio";
    public const string COMERCIO_TU_OFERTA = "Tu oferta";
    public const string COMERCIO_SU_OFERTA = "Su oferta";
    public const string COMERCIO_ACEPTAR = "Aceptar intercambio";
    public const string COMERCIO_RECHAZAR = "Rechazar";
    public const string COMERCIO_CANCELAR = "Cancelar";
    public const string COMERCIO_EXITO = "¡Intercambio exitoso!";
    public const string COMERCIO_FALLIDO = "Intercambio cancelado";
    public const string COMERCIO_SIN_RECURSOS = "No tienes suficientes recursos";
    public const string COMERCIO_TRATO_MALO = "¡Cuidado! Este trato no parece justo";
    
    // ==========================================
    // TEXTOS DE MISIONES (QUESTS)
    // ==========================================
    
    public const string MISION_NUEVA = "¡Nueva misión!";
    public const string MISION_COMPLETADA = "¡Misión completada!";
    public const string MISION_EN_PROGRESO = "Misión en progreso";
    public const string MISION_OBJETIVO = "Objetivo: {0}";
    public const string MISION_RECOMPENSA = "Recompensa: {0}";
    
    // Misión principal del Amuleto
    public const string MISION_AMULETO_NOMBRE = "El Amuleto del Comerciante Legendario";
    public const string MISION_AMULETO_DESC = "Reúne los materiales especiales para el Maestro Artesano";
    public const string MISION_AMULETO_OBJ1 = "Obtener Azafrán Dorado";
    public const string MISION_AMULETO_OBJ2 = "Obtener Tela del Alba";
    public const string MISION_AMULETO_OBJ3 = "Obtener Martillo Ancestral";
    public const string MISION_AMULETO_OBJ4 = "Entregar materiales al Maestro Artesano";
    
    // ==========================================
    // NOMBRES DE PERSONAJES
    // ==========================================
    
    public const string PERSONAJE_NIX = "Nix";
    public const string PERSONAJE_NIX_DESC = "Comerciante ambulante";
    
    public const string PERSONAJE_CARMEN = "Doña Carmen";
    public const string PERSONAJE_CARMEN_DESC = "Vendedora de especias";
    
    public const string PERSONAJE_MIGUEL = "Don Miguel";
    public const string PERSONAJE_MIGUEL_DESC = "Vendedor de telas";
    
    public const string PERSONAJE_TOMAS = "Tomás";
    public const string PERSONAJE_TOMAS_DESC = "El herrero";
    
    public const string PERSONAJE_LUCIA = "Lucía";
    public const string PERSONAJE_LUCIA_DESC = "Vendedora de alimentos";
    
    public const string PERSONAJE_ROSA = "Rosa";
    public const string PERSONAJE_ROSA_DESC = "Artesana";
    
    public const string PERSONAJE_MAESTRO = "Maestro Artesano";
    public const string PERSONAJE_MAESTRO_DESC = "Creador de maravillas";
    
    public const string PERSONAJE_ESTAFADOR = "Estafador Ambulante";
    public const string PERSONAJE_ESTAFADOR_DESC = "Comerciante deshonesto";
    
    // ==========================================
    // NOMBRES DE OBJETOS/ITEMS
    // ==========================================
    
    // Especias
    public const string ITEM_AZAFRAN = "Azafrán";
    public const string ITEM_AZAFRAN_DORADO = "Azafrán Dorado";
    public const string ITEM_CANELA = "Canela";
    public const string ITEM_PIMIENTA = "Pimienta";
    
    // Telas
    public const string ITEM_TELA_NORMAL = "Tela";
    public const string ITEM_TELA_FINA = "Tela Fina";
    public const string ITEM_TELA_ALBA = "Tela del Alba";
    
    // Herramientas
    public const string ITEM_HERRAMIENTA_BASICA = "Herramienta básica";
    public const string ITEM_HERRAMIENTA_REFINADA = "Herramienta refinada";
    public const string ITEM_MARTILLO_ANCESTRAL = "Martillo Ancestral";
    
    // Alimentos
    public const string ITEM_ALIMENTO_FRESCO = "Alimento fresco";
    public const string ITEM_ALIMENTO_PREPARADO = "Alimento preparado";
    
    // Artesanías
    public const string ITEM_ARTESANIA_DECORATIVA = "Artesanía decorativa";
    public const string ITEM_ARTESANIA_ESPECIAL = "Artesanía especial";
    
    // Objeto raro
    public const string ITEM_AMULETO = "Amuleto del Comerciante Legendario";
    public const string ITEM_AMULETO_DESC = "Un amuleto místico que garantiza los mejores tratos";
    
    // Monedas
    public const string ITEM_MONEDAS = "Monedas de oro";
    
    // ==========================================
    // TEXTOS DEL ESTAFADOR
    // ==========================================
    
    public const string ESTAFADOR_APARECE = "¡Cuidado! El Estafador Ambulante está cerca...";
    public const string ESTAFADOR_OFERTA = "El Estafador te ofrece un trato";
    public const string ESTAFADOR_ADVERTENCIA = "¡Este trato parece muy malo!";
    public const string ESTAFADOR_COMPRO = "El Estafador compró tu {0} por un precio muy bajo";
    
    // ==========================================
    // TEXTOS DE DIÁLOGO
    // ==========================================
    
    public const string DIALOGO_CONTINUAR = "Presiona para continuar";
    public const string DIALOGO_OPCION = "Elige una opción";
    public const string DIALOGO_SALTAR = "Saltar";
    
    // ==========================================
    // TEXTOS DE NOTIFICACIONES
    // ==========================================
    
    public const string NOTIF_GUARDADO = "Partida guardada";
    public const string NOTIF_CARGADO = "Partida cargada";
    public const string NOTIF_ERROR_GUARDAR = "Error al guardar";
    public const string NOTIF_NUEVO_OBJETO = "¡Nuevo objeto obtenido!";
    public const string NOTIF_MISION_ACTUALIZADA = "Misión actualizada";
    
    // ==========================================
    // TEXTOS DE TUTORIAL
    // ==========================================
    
    public const string TUTORIAL_BIENVENIDA = "¡Bienvenido al Bazar de la Isla del Sol!";
    public const string TUTORIAL_MOVIMIENTO = "Usa el joystick para moverte";
    public const string TUTORIAL_INTERACCION = "Toca a los vendedores para hablar";
    public const string TUTORIAL_INVENTARIO = "Abre tu inventario con el botón";
    public const string TUTORIAL_COMERCIO = "Selecciona objetos para intercambiar";
    
    // ==========================================
    // TEXTOS DE UBICACIONES
    // ==========================================
    
    public const string UBICACION_BAZAR = "Plaza del Bazar";
    public const string UBICACION_ESPECIAS = "Puesto de Especias";
    public const string UBICACION_TELAS = "Puesto de Telas";
    public const string UBICACION_HERRAMIENTAS = "Herrería";
    public const string UBICACION_ALIMENTOS = "Puesto de Alimentos";
    public const string UBICACION_ARTESANIAS = "Taller de Artesanías";
    public const string UBICACION_MISTERIOSO = "Puesto Misterioso";
    
    // ==========================================
    // TEXTOS DE ECONOMÍA
    // ==========================================
    
    public const string ECONOMIA_PRECIO = "Precio: {0} monedas";
    public const string ECONOMIA_VALOR = "Valor: {0} monedas";
    public const string ECONOMIA_DESCUENTO = "¡{0}% de descuento!";
    public const string ECONOMIA_SIN_DINERO = "No tienes suficiente dinero";
    
    // ==========================================
    // MÉTODOS AUXILIARES
    // ==========================================
    
    /// <summary>
    /// Formatea un texto con parámetros
    /// </summary>
    public static string Formatear(string texto, params object[] args)
    {
        return string.Format(texto, args);
    }
    
    /// <summary>
    /// Obtiene el nombre localizado de un personaje
    /// </summary>
    public static string ObtenerNombrePersonaje(string id)
    {
        switch (id.ToLower())
        {
            case "nix": return PERSONAJE_NIX;
            case "carmen": return PERSONAJE_CARMEN;
            case "miguel": return PERSONAJE_MIGUEL;
            case "tomas": return PERSONAJE_TOMAS;
            case "lucia": return PERSONAJE_LUCIA;
            case "rosa": return PERSONAJE_ROSA;
            case "maestro": return PERSONAJE_MAESTRO;
            case "estafador": return PERSONAJE_ESTAFADOR;
            default: return id;
        }
    }
    
    /// <summary>
    /// Obtiene el nombre localizado de un objeto
    /// </summary>
    public static string ObtenerNombreObjeto(string id)
    {
        switch (id.ToLower())
        {
            case "azafran": return ITEM_AZAFRAN;
            case "azafran_dorado": return ITEM_AZAFRAN_DORADO;
            case "canela": return ITEM_CANELA;
            case "pimienta": return ITEM_PIMIENTA;
            case "tela": return ITEM_TELA_NORMAL;
            case "tela_fina": return ITEM_TELA_FINA;
            case "tela_alba": return ITEM_TELA_ALBA;
            case "herramienta": return ITEM_HERRAMIENTA_BASICA;
            case "herramienta_refinada": return ITEM_HERRAMIENTA_REFINADA;
            case "martillo_ancestral": return ITEM_MARTILLO_ANCESTRAL;
            case "alimento": return ITEM_ALIMENTO_FRESCO;
            case "alimento_preparado": return ITEM_ALIMENTO_PREPARADO;
            case "artesania": return ITEM_ARTESANIA_DECORATIVA;
            case "artesania_especial": return ITEM_ARTESANIA_ESPECIAL;
            case "amuleto": return ITEM_AMULETO;
            case "monedas": return ITEM_MONEDAS;
            default: return id;
        }
    }
}
