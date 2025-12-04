// ============================================
// ESTAFADOR AMBULANTE - DIÁLOGOS
// Enemigo no combativo que afecta la economía
// Ofrece malos tratos y puede comprar recursos
// críticos si no se vigila
// ============================================

VAR estafaContador = 0
VAR recursoPerdido = 0
VAR advertido = 0

-> encuentro_estafador

=== encuentro_estafador ===
¡Psst! ¡Oye, tú! Sí, tú, el del puesto ambulante. Tengo ofertas que no podrás rechazar... #speaker:Estafador Ambulante #portrait:estafador
* [¿Quién eres?]
    Me llaman... el Negociante Errante. Pero mis amigos me dicen "El que siempre gana". ¿Quieres saber por qué? #speaker:Estafador Ambulante #portrait:estafador
    -> presentacion_estafador
* [No me interesa]
    ¡Espera, espera! Al menos escucha mis ofertas. Son... únicas. #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador
* [Me han advertido sobre ti]
    ~ advertido = 1
    ¿Advertido? ¡Ja! La gente habla sin saber. Yo solo ofrezco... oportunidades especiales. #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador

=== presentacion_estafador ===
Verás, tengo un talento especial para encontrar... "oportunidades". Y tú pareces alguien que necesita una buena oportunidad, ¿no es así? #speaker:Estafador Ambulante #portrait:estafador
* [¿Qué tipo de oportunidades?]
    -> ofertas_estafador
* [No confío en ti]
    ¡Qué desconfianza! Pero bueno, el tiempo te hará cambiar de opinión... #speaker:Estafador Ambulante #portrait:estafador
    -> despedida_temporal

=== ofertas_estafador ===
Tengo varias ofertas especiales solo para ti: #speaker:Estafador Ambulante #portrait:estafador
* [Escuchar oferta de especias]
    -> oferta_especias_estafa
* [Escuchar oferta de telas]
    -> oferta_telas_estafa
* [Escuchar oferta de herramientas]
    -> oferta_herramientas_estafa
* [Vender mis recursos]
    -> compra_estafador
* [No, gracias. Me voy]
    -> despedida_temporal

=== oferta_especias_estafa ===
¡Azafrán de primera calidad! Bueno... de segunda... pero casi de primera. ¡Solo 10 monedas de oro por una pizca! #speaker:Estafador Ambulante #portrait:estafador
(Nota: El precio real en el mercado es 2 monedas) #speaker:Narrador #portrait:narrator
* [¡Eso es un robo! - Rechazar]
    ¡Robo! ¿Robo? Es una inversión en tu futuro, amigo mío. #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador
* [Comprar de todos modos]
    ~ estafaContador = estafaContador + 1
    ¡Excelente decisión! Aquí tienes tu... "azafrán premium". No lo examines muy de cerca, ¿eh? #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador
* [Volver]
    -> ofertas_estafador

=== oferta_telas_estafa ===
Tela del Alba... o algo parecido. ¡Prácticamente idéntica! 15 monedas de oro. ¡Es una ganga! #speaker:Estafador Ambulante #portrait:estafador
(Nota: La Tela del Alba auténtica solo se consigue con Don Miguel) #speaker:Narrador #portrait:narrator
* [Esto es una falsificación - Rechazar]
    ¡Falsificación es una palabra muy fuerte! Yo diría... "interpretación artística". #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador
* [Comprar de todos modos]
    ~ estafaContador = estafaContador + 1
    ¡Sabía que eras inteligente! Esta tela es... única. Muy única. #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador
* [Volver]
    -> ofertas_estafador

=== oferta_herramientas_estafa ===
¡El Martillo Ancestral! Bueno, no el VERDADERO, pero uno muy parecido. Encontrado en un callejón... quiero decir, en unas ruinas antiguas. 20 monedas. #speaker:Estafador Ambulante #portrait:estafador
(Nota: El Martillo Ancestral real está con Tomás el Herrero) #speaker:Narrador #portrait:narrator
* [Esto es claramente falso - Rechazar]
    ¿Falso? ¡La herrumbre le da autenticidad! #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador
* [Comprar de todos modos]
    ~ estafaContador = estafaContador + 1
    ¡Un conocedor! Este martillo ha... visto cosas. Muchas cosas. #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador
* [Volver]
    -> ofertas_estafador

=== compra_estafador ===
¡Ah, quieres vender! Me encantan los vendedores desesperados... digo, emprendedores. #speaker:Estafador Ambulante #portrait:estafador
* [Vender especias (Precio bajo)]
    Te doy 1 moneda por todas tus especias. Es más de lo que valen, créeme. #speaker:Estafador Ambulante #portrait:estafador
    -> confirmar_venta_especias
* [Vender telas (Precio bajo)]
    Estas telas... están algo usadas. Te doy 2 monedas por el lote completo. #speaker:Estafador Ambulante #portrait:estafador
    -> confirmar_venta_telas
* [Vender herramientas (Precio bajo)]
    Herramientas oxidadas, ¿eh? Te hago un favor: 3 monedas por todo. #speaker:Estafador Ambulante #portrait:estafador
    -> confirmar_venta_herramientas
* [Mejor no vendo nada]
    Tu pérdida, amigo. Tu pérdida. #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador

=== confirmar_venta_especias ===
{advertido == 1:
    (Recuerda: te advirtieron sobre este tipo. Los precios reales son mucho mejores.) #speaker:Narrador #portrait:narrator
}
* [Aceptar venta]
    ~ recursoPerdido = recursoPerdido + 1
    ¡Placer hacer negocios! Ahora estas especias son MÍA. #speaker:Estafador Ambulante #portrait:estafador
    -> despedida_temporal
* [Rechazar]
    Sabía decisión... o quizás no. ¡Nunca se sabe! #speaker:Estafador Ambulante #portrait:estafador
    -> ofertas_estafador

=== confirmar_venta_telas ===
{advertido == 1:
    (Recuerda: te advirtieron sobre este tipo. Los precios reales son mucho mejores.) #speaker:Narrador #portrait:narrator
}
* [Aceptar venta]
    ~ recursoPerdido = recursoPerdido + 1
    ¡Excelente! Estas telas me servirán para... mis propósitos. #speaker:Estafador Ambulante #portrait:estafador
    -> despedida_temporal
* [Rechazar]
    -> ofertas_estafador

=== confirmar_venta_herramientas ===
{advertido == 1:
    (Recuerda: te advirtieron sobre este tipo. Los precios reales son mucho mejores.) #speaker:Narrador #portrait:narrator
}
* [Aceptar venta]
    ~ recursoPerdido = recursoPerdido + 1
    ¡Trato hecho! Herramientas para mí, miseria para ti. Es decir... ¡dinero para ti! #speaker:Estafador Ambulante #portrait:estafador
    -> despedida_temporal
* [Rechazar]
    -> ofertas_estafador

=== despedida_temporal ===
Nos veremos de nuevo, comerciante. El bazar es pequeño y yo estoy en todas partes... #speaker:Estafador Ambulante #portrait:estafador
(El Estafador Ambulante desaparece entre la multitud) #speaker:Narrador #portrait:narrator
-> END

=== advertencia_estafador ===
¡ATENCIÓN! El Estafador Ambulante está intentando acaparar recursos del bazar. Si no vigilas tus pertenencias, podría comprarte materiales críticos a precios ridículos. #speaker:Sistema #portrait:system
* [Entendido]
    -> END
