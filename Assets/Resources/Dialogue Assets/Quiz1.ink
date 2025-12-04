VAR initialize = 0
VAR score = 0

->start
=== start ===
¡Hola! He sentido tu presencia en este lugar. Han ocurrido cosas aquí de las que he oído hablar. ¿Podrías contarme de nuevo los sucesos? #speaker:Guardián #portrait:tagapag_bantay
* [Sí]
~ initialize = initialize + 2
    -> question1
* [Quizás después, primero voy a explorar.]
~ initialize = initialize + 1
    -> END

=== question1 ===
Había mucho alboroto afuera hace un rato y mucha gente estaba afuera. ¿A dónde crees que iban? 
* [Porque el Capitán Tiago es conocido y repartiría tinola caliente para todos.]
~ score = score + 1
    ¡Ahh! Sí, eso es lo que había escuchado. 
    -> question2
* [Tal vez la casa del Capitán Tiago se estaba incendiando, por eso había tanta gente afuera.]
~ score = score + 0
    Eso no es lo que había escuchado.
    -> question2
* [Porque el Capitán Tiago es conocido y repartiría tinola caliente para todos.]
~ score = score + 0
    Eso no es lo que había escuchado.
    -> question2


=== question2 ===
Cuando ya estaban adentro, ¿quiénes eran las personas allí? Y también dicen que llegó alguien de Europa, ¿quién era? 
* [Eran Juan y Pedro, y el de Europa era el Teniente.]
~ score = score + 0
    ¿No era Crisóstomo el hombre que vino de Europa?
    -> question3
* [Hubo una pelea afuera y las mujeres resultaron afectadas.]
~ score = score + 0
    ¿No era Crisóstomo el hombre que vino de Europa?
    -> question3
* [Los que fueron eran el Padre Dámaso, el Padre Sibyla, el Guardia y el Teniente. Y el que llegó de Europa fue Crisóstomo Ibarra.]
    Ahh, Crisóstomo era el hombre que vino de Europa… 
~ score = score + 1
    -> question3

=== question3 ===
También escuché que el Padre Dámaso estaba muy enojado. ¿Qué estaba insinuando? 
* [El Padre Dámaso estaba molesto con los invitados favoritos del Capitán Tiago, especialmente Crisóstomo Ibarra.]
~ score = score + 0
    -> question4
* [El Padre Dámaso estaba enojado porque Crisóstomo Ibarra favorecía más a España que a su propio país.]
~ score = score + 1
    -> question4
* [El Padre Dámaso estaba molesto porque quería sinigang con mucha carne.]
~ score = score + 0
    -> question4
    
-> question4
=== question4 ===
¿Qué le gustó a Ibarra cuando estuvo en Europa?
* [Ibarra dijo que era hermoso allí porque había muchas mujeres.]
~ score = score + 0
    -> question5
* [Ibarra dijo que el triunfo de las necesidades del pueblo en Europa era igual a su libertad.]
    Es cierto... Lo que posee un país se ve en la libertad del país. Sabes mucho, hijo. 
~ score = score + 1
    -> question5
* [Ibarra dijo que había muchos lugares para visitar.]
~ score = score + 0
    -> question5

-> question5
=== question5 ===
¿Puedes contarme lo que sigue?
* [¡Por supuesto!]
~ score = score + 1
    -> question6
* [Ya no quiero, no recuerdo los sucesos.]
~ score = score + 0
    -> question6

-> question6
=== question6 ===
¿Sabes qué? Tengo hambre. ¡Ay! ¿Cuando cenaron? ¡Se veía deliciosa la comida! ¿Qué era?
* [¡Tinola! Pero el Padre Dámaso recibió las peores piezas de carne, por eso también se enojó.]
~ score = score + 1
    -> question7
* [¡Sinigang! Pero no era muy ácido, por eso el Padre Dámaso se enojó.]
~ score = score + 0
    -> question7
* [¡Adobo! Pero estaba demasiado salado, por eso el Padre Dámaso se enojó.]
~ score = score + 0
    -> question7
    
-> question7
=== question7 ===
Dicen que Ibarra se fue rápidamente. ¿A dónde iba?
* [Al bosque]
~ score = score + 0
    -> question8
* [A Binondo]
~ score = score + 0
    -> question8
* [A San Diego]
~ score = score + 1
    -> question8
    
-> question8
=== question8 ===
Parece que aprendiste mucho de estos capítulos. ¿Cómo qué?
* [Lo que aprendí es que esto abrió el tema de la educación y mostró su sueño de un sistema educativo más justo y significativo.]
~ score = score + 0
    -> question9
* [Lo que aprendí es que es mejor estudiar en otros países para aprender más.]
~ score = score + 1
    -> question9
* [Estudiar no es importante porque podemos aprender de nuestro entorno.]
~ score = score + 0
    -> question9
    
-> question9
=== question9 ===
Sí, es correcto, la educación es la mejor arma en la vida diaria. ¿Qué más?
* [La presentación de Crisóstomo Ibarra trajo malas noticias de Europa.]
~ score = score + 0
    -> question10
* [La mesa tuvo una alegre celebración y felicidad durante todo el capítulo.]
~ score = score + 0
    -> question10
* [La presentación de Crisóstomo Ibarra enfatiza su fama y el reconocimiento de su padre.]
~ score = score + 1
    -> question10
    

=== question10 ===
Una más... para demostrar que aprendiste algo de este capítulo.
* [Aprender de su propia práctica de tradición y cultura de Europa y valorar la bondad natural de nuestro país.]
~ score = score + 1
    -> correction
* [El objetivo principal de Crisóstomo Ibarra en este capítulo es insultar y herir los sentimientos de otros personajes.]
~ score = score + 0
    -> correction
* [El recuerdo de Ibarra sobre su padre causa su deseo de hacer crecer y desarrollar el pueblo para mejorar la condición de la gente.]
~ score = score + 0
    -> correction

    
=== correction ===
{score == 10:
    Lo lograste perfectamente y por eso, puedes continuar.
    -> end
    - else:
    No lo lograste perfectamente y por eso, tendrás que repetir.
    -> end
}

=== end ===
Obtuviste {score} puntos de 10 preguntas.
-> END
