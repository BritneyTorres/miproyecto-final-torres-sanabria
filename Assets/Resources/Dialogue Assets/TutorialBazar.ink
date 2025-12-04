// ============================================
// TUTORIAL DEL BAZAR - INTRODUCCIÓN
// Guía para nuevos jugadores en español
// ============================================

VAR tutorialCompletado = 0

-> inicio_tutorial

=== inicio_tutorial ===
¡Bienvenido al mundo de los comerciantes! #speaker:Guía #portrait:guia
Eres Nix, un comerciante ambulante que ha llegado a la legendaria Isla del Sol. #speaker:Guía #portrait:guia
* [Continuar]
    -> explicacion_bazar

=== explicacion_bazar ===
El Bazar de la Isla del Sol es famoso por sus intercambios y tesoros únicos. #speaker:Guía #portrait:guia
Aquí encontrarás 6 puestos con diferentes vendedores, cada uno con mercancías especiales. #speaker:Guía #portrait:guia
* [¿Cómo funciona el comercio?]
    -> tutorial_comercio
* [¿Cuál es mi objetivo?]
    -> tutorial_objetivo

=== tutorial_comercio ===
El comercio en el bazar funciona así: #speaker:Guía #portrait:guia
1. Habla con los vendedores para conocer sus ofertas. #speaker:Guía #portrait:guia
2. Cada vendedor necesita algo específico y ofrece algo a cambio. #speaker:Guía #portrait:guia
3. Usa el sistema de intercambio (Trade UI) para hacer trueques. #speaker:Guía #portrait:guia
4. Administra tu inventario sabiamente - ¡solo tienes 8 espacios! #speaker:Guía #portrait:guia
* [Entendido]
    -> tutorial_inventario
* [¿Y los precios?]
    -> tutorial_precios

=== tutorial_precios ===
Los precios son justos con los vendedores honestos del bazar. #speaker:Guía #portrait:guia
PERO... ten cuidado con el Estafador Ambulante. Él ofrece precios terribles y productos falsos. #speaker:Guía #portrait:guia
Si le vendes tus recursos, perderás mucho valor. #speaker:Guía #portrait:guia
Si le compras, obtendrás falsificaciones que no sirven para la misión. #speaker:Guía #portrait:guia
* [Gracias por la advertencia]
    -> tutorial_inventario

=== tutorial_inventario ===
Tu inventario tiene 8 espacios para almacenar recursos y objetos. #speaker:Guía #portrait:guia
Los recursos que puedes encontrar son: #speaker:Guía #portrait:guia
• Especias (Azafrán, Canela, Pimienta) #speaker:Guía #portrait:guia
• Telas (Normal, Fina, del Alba) #speaker:Guía #portrait:guia
• Herramientas (Básicas, Refinadas, Ancestrales) #speaker:Guía #portrait:guia
• Alimentos (Frescos, Preparados) #speaker:Guía #portrait:guia
• Artesanías (Decorativas, Especiales) #speaker:Guía #portrait:guia
* [¿Cuál es mi objetivo?]
    -> tutorial_objetivo

=== tutorial_objetivo ===
Tu objetivo principal es obtener el Amuleto del Comerciante Legendario. #speaker:Guía #portrait:guia
Para conseguirlo, debes: #speaker:Guía #portrait:guia
1. Encontrar al Maestro Artesano y aceptar su misión. #speaker:Guía #portrait:guia
2. Reunir los 3 materiales especiales de diferentes vendedores. #speaker:Guía #portrait:guia
3. Entregarlos al Maestro Artesano. #speaker:Guía #portrait:guia
4. ¡Evitar las trampas del Estafador Ambulante! #speaker:Guía #portrait:guia
* [¿Cuáles son los materiales?]
    -> tutorial_materiales
* [Estoy listo para comenzar]
    -> fin_tutorial

=== tutorial_materiales ===
Los materiales especiales para el Amuleto son: #speaker:Guía #portrait:guia
1. Azafrán Dorado - Se obtiene de Doña Carmen (Especias) #speaker:Guía #portrait:guia
2. Tela del Alba - Se obtiene de Don Miguel (Telas) #speaker:Guía #portrait:guia
3. Martillo Ancestral - Se obtiene de Tomás (Herramientas) #speaker:Guía #portrait:guia
Pero cada vendedor necesita algo a cambio. Deberás hacer varios intercambios para conseguir lo que necesitan. #speaker:Guía #portrait:guia
* [Entendido, estoy listo]
    -> fin_tutorial

=== fin_tutorial ===
¡Excelente! Ahora conoces lo básico del bazar. #speaker:Guía #portrait:guia
Recuerda: #speaker:Guía #portrait:guia
• Negocia con sabiduría #speaker:Guía #portrait:guia
• Cuida tu inventario #speaker:Guía #portrait:guia
• Evita al Estafador Ambulante #speaker:Guía #portrait:guia
• ¡Disfruta tu aventura comercial! #speaker:Guía #portrait:guia
~ tutorialCompletado = 1
¡Buena suerte, Nix! #speaker:Guía #portrait:guia
-> END
