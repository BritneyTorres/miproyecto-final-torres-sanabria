// ============================================
// BAZAR DE NIX - DIÁLOGO PRINCIPAL
// Historia: El comerciante Nix llega a una isla
// y debe negociar con vendedores para obtener
// un objeto raro.
// ============================================

VAR initialize = 0
VAR misionCompletada = 0
VAR objetoRaroObtenido = 0
VAR confianzaVendedor = 0

-> inicio

=== inicio ===
¡Bienvenido al Bazar de la Isla del Sol! El bullicio de los comerciantes llena el aire con ofertas y negociaciones. #speaker:Narrador #portrait:narrator
* [Explorar la plaza]
~ initialize = initialize + 1
    -> plaza_principal
* [Revisar mi inventario primero]
~ initialize = initialize + 1
    -> revisar_inventario

=== plaza_principal ===
La plaza principal del bazar está repleta de actividad. Seis puestos coloridos rodean la fuente central. Puedes ver comerciantes ofreciendo sus mercancías. #speaker:Narrador #portrait:narrator
* [Ir al puesto de especias]
    -> puesto_especias
* [Ir al puesto de telas exóticas]
    -> puesto_telas
* [Ir al puesto de herramientas]
    -> puesto_herramientas
* [Ir al puesto de alimentos]
    -> puesto_alimentos
* [Ir al puesto de artesanías]
    -> puesto_artesanias
* [Ir al puesto del misterioso vendedor]
    -> puesto_misterioso

=== revisar_inventario ===
Tu bolsa contiene los recursos de tu puesto ambulante. Recuerda: necesitas negociar sabiamente para conseguir el objeto raro. #speaker:Narrador #portrait:narrator
* [Volver a la plaza]
    -> plaza_principal

=== puesto_especias ===
¡Hola, comerciante! Soy Doña Carmen, la reina de las especias. ¿Qué buscas hoy? Tengo canela de las montañas, pimienta del este y azafrán dorado. #speaker:Doña Carmen #portrait:carmen
* [¿Qué necesitas para un buen intercambio?]
    Necesito tres unidades de tela fina. A cambio, te daré el mejor azafrán que hayas visto. Es esencial para la receta del Maestro Artesano. #speaker:Doña Carmen #portrait:carmen
    -> oferta_especias
* [Solo estoy mirando, gracias]
    ¡Vuelve cuando quieras negociar! #speaker:Doña Carmen #portrait:carmen
    -> plaza_principal

=== oferta_especias ===
* [Aceptar intercambio - 3 Telas por Azafrán]
    ¡Excelente negocio! Aquí tienes el azafrán. El Maestro Artesano estará encantado. #speaker:Doña Carmen #portrait:carmen
    ~ confianzaVendedor = confianzaVendedor + 1
    -> plaza_principal
* [Rechazar por ahora]
    Entiendo, los negocios requieren tiempo. #speaker:Doña Carmen #portrait:carmen
    -> plaza_principal

=== puesto_telas ===
¡Saludos, viajero! Soy Don Miguel, tejedor de sueños. Mis telas vienen de las tierras más lejanas. #speaker:Don Miguel #portrait:miguel
* [¿Qué intercambios ofreces?]
    Busco herramientas de calidad. Por cada dos herramientas, te daré cinco unidades de mi mejor tela. #speaker:Don Miguel #portrait:miguel
    -> oferta_telas
* [Cuéntame sobre el objeto raro del bazar]
    Ah, hablas del Amuleto del Comerciante Legendario. Solo el Maestro Artesano puede crearlo, pero necesita ingredientes específicos de todos los vendedores. #speaker:Don Miguel #portrait:miguel
    -> plaza_principal
* [Volver a la plaza]
    -> plaza_principal

=== oferta_telas ===
* [Aceptar intercambio - 2 Herramientas por 5 Telas]
    ¡Un placer hacer negocios contigo! #speaker:Don Miguel #portrait:miguel
    ~ confianzaVendedor = confianzaVendedor + 1
    -> plaza_principal
* [Rechazar]
    -> plaza_principal

=== puesto_herramientas ===
¡Buen día! Soy Tomás el Herrero. Mis herramientas son las mejores de todas las islas. #speaker:Tomás #portrait:tomas
* [¿Qué necesitas?]
    Busco alimentos frescos para mi familia. Por cada tres unidades de comida, te daré dos herramientas de primera calidad. #speaker:Tomás #portrait:tomas
    -> oferta_herramientas
* [¿Has visto al Estafador Ambulante?]
    ¡Cuidado con ese tipo! Ofrece tratos que parecen buenos pero siempre sales perdiendo. Vigila tus recursos. #speaker:Tomás #portrait:tomas
    -> plaza_principal
* [Volver]
    -> plaza_principal

=== oferta_herramientas ===
* [Aceptar intercambio - 3 Alimentos por 2 Herramientas]
    ¡Hecho! Estas herramientas te servirán bien. #speaker:Tomás #portrait:tomas
    ~ confianzaVendedor = confianzaVendedor + 1
    -> plaza_principal
* [Rechazar]
    -> plaza_principal

=== puesto_alimentos ===
¡Hola, hola! Soy Lucía, la mejor cocinera del bazar. ¿Tienes hambre o quieres comerciar? #speaker:Lucía #portrait:lucia
* [Quiero comerciar]
    Perfecto. Necesito artesanías decorativas para mi puesto. Por cada artesanía, te daré cuatro unidades de comida fresca. #speaker:Lucía #portrait:lucia
    -> oferta_alimentos
* [¿Conoces al Maestro Artesano?]
    ¡Por supuesto! Es el único que puede crear el Amuleto del Comerciante Legendario. Pero necesita ayuda reuniendo los materiales. Si le ayudas, te recompensará generosamente. #speaker:Lucía #portrait:lucia
    -> plaza_principal
* [Volver]
    -> plaza_principal

=== oferta_alimentos ===
* [Aceptar intercambio - 1 Artesanía por 4 Alimentos]
    ¡Delicioso trato! #speaker:Lucía #portrait:lucia
    ~ confianzaVendedor = confianzaVendedor + 1
    -> plaza_principal
* [Rechazar]
    -> plaza_principal

=== puesto_artesanias ===
Bienvenido a mi humilde taller. Soy Rosa, artesana de corazón. Creo belleza con mis manos. #speaker:Rosa #portrait:rosa
* [¿Qué buscas para intercambiar?]
    Necesito especias raras para teñir mis creaciones. Por cada unidad de especias, te daré dos hermosas artesanías. #speaker:Rosa #portrait:rosa
    -> oferta_artesanias
* [¿Puedes ayudarme con el Maestro Artesano?]
    El Maestro necesita: azafrán de Doña Carmen, tela especial de Don Miguel, y una herramienta única de Tomás. Reúne todo eso y él creará el Amuleto para ti. #speaker:Rosa #portrait:rosa
    -> plaza_principal
* [Volver]
    -> plaza_principal

=== oferta_artesanias ===
* [Aceptar intercambio - 1 Especia por 2 Artesanías]
    ¡Gracias! Estas artesanías están hechas con amor. #speaker:Rosa #portrait:rosa
    ~ confianzaVendedor = confianzaVendedor + 1
    -> plaza_principal
* [Rechazar]
    -> plaza_principal

=== puesto_misterioso ===
Ah, Nix, el comerciante ambulante... Te estaba esperando. Soy el Maestro Artesano. He oído que buscas algo especial. #speaker:Maestro Artesano #portrait:maestro
* [Busco el Amuleto del Comerciante Legendario]
    Para crearlo, necesito tres cosas: Azafrán Dorado de Doña Carmen, Tela del Alba de Don Miguel, y el Martillo Ancestral de Tomás. #speaker:Maestro Artesano #portrait:maestro
    -> mision_amuleto
* [¿Quién eres?]
    Soy quien crea maravillas a partir de lo ordinario. He vivido en este bazar toda mi vida, observando a comerciantes ir y venir. Tú eres diferente, lo puedo sentir. #speaker:Maestro Artesano #portrait:maestro
    -> plaza_principal
* [Volver]
    -> plaza_principal

=== mision_amuleto ===
¿Aceptas la misión de reunir los materiales para el Amuleto del Comerciante Legendario? #speaker:Maestro Artesano #portrait:maestro
* [¡Acepto la misión!]
    Excelente. Ten cuidado con el Estafador Ambulante. Intentará comprarte los materiales a precios ridículos o venderte falsificaciones. ¡No confíes en él! #speaker:Maestro Artesano #portrait:maestro
    ~ misionCompletada = 1
    -> plaza_principal
* [Necesito prepararme primero]
    Tómate tu tiempo, pero no demasiado. El Estafador también busca estos materiales. #speaker:Maestro Artesano #portrait:maestro
    -> plaza_principal

=== fin_mision ===
{misionCompletada == 1 && confianzaVendedor >= 3:
    -> entregar_materiales
- else:
    -> plaza_principal
}

=== entregar_materiales ===
¡Nix! Has reunido todos los materiales. Eres un verdadero comerciante. #speaker:Maestro Artesano #portrait:maestro
Dame los materiales y crearé el Amuleto del Comerciante Legendario para ti. #speaker:Maestro Artesano #portrait:maestro
* [Entregar los materiales]
    ¡Magnífico! El Amuleto del Comerciante Legendario es tuyo. Con él, siempre encontrarás los mejores tratos y tu reputación crecerá en todos los bazares del mundo. #speaker:Maestro Artesano #portrait:maestro
    ~ objetoRaroObtenido = 1
    -> final
* [Esperar]
    -> plaza_principal

=== final ===
¡Felicidades! Has completado la misión del Bazar de la Isla del Sol. El Amuleto del Comerciante Legendario brilla en tu cuello, símbolo de tu astucia y habilidad negociadora. #speaker:Narrador #portrait:narrator
Tu leyenda como Nix, el comerciante ambulante, apenas comienza... #speaker:Narrador #portrait:narrator
-> END
