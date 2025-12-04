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
¿Por qué Ibarra necesitaba una explicación sobre su padre?
* [Porque quería ayudar a su padre.]
~ score = score + 0
    -> question2
* [Para tener claridad y comprensión sobre el pasado de su familia.]
~ score = score + 1
    -> question2
* [Solo le pareció interesante.]
~ score = score + 0
    Eso no es lo que había escuchado.
    -> question2


=== question2 ===
¿Cuál es la implicación de la historia del teniente sobre el artillero en la historia de Ibarra?
* [Proporciona una descripción detallada del comportamiento del artillero.]
~ score = score + 0
    ¿No era Crisóstomo el hombre que vino de Europa?
    -> question3
* [Se convierte en un ejemplo del cambio de su padre.]
~ score = score + 1
    -> question3
* [La historia no tiene conexión con la historia de Ibarra.]
~ score = score + 0
    -> question3

=== question3 ===
¿Cómo se relacionó la música del violín en la escena de la Fonda de Lala con los sentimientos de Ibarra? 
* [Aclaró la escena pero no tuvo efecto en Ibarra.]
~ score = score + 0
    -> question4
* [Causó emociones profundas y dio paso a la introspección de Ibarra.]
~ score = score + 1
    -> question4
* [No ayudó a la escena y causó somnolencia.]
~ score = score + 0
    -> question4
    
-> question4
=== question4 ===
¿Cuál podría ser el efecto del color del rostro del Capitán Tiago en su personaje?
* [Muestra su salud.]
~ score = score + 0
    -> question5
* [Proporciona información sobre su personalidad.]
~ score = score + 1
    -> question5
* [No tiene importancia en la historia.]
~ score = score + 0
    -> question5

=== question5 ===
¿Por qué es importante para Ibarra saber qué le pasó a su padre?
* [Da paso al desarrollo de la historia.]
~ score = score + 1
    -> question6
* [Da la oportunidad de expresar la ira hacia el Padre Dámaso.]
~ score = score + 0
    -> question6
* [Para castigar a los culpables de lo que le pasó a su padre.]
~ score = score + 0
    -> question6
    
-> question6
=== question6 ===
¿Cuál fue la reacción de Ibarra ante los eventos en la Fonda de Lala?
* [No sintió ninguna emoción.]
~ score = score + 0
    -> question7
* [Estaba feliz y contento con la escena.]
~ score = score + 0
    -> question7
* [Mostró que estaba muy afectado y hizo muchas preguntas.]
~ score = score + 1
    -> question7
    
-> question7
=== question7 ===
¿Cómo difiere la reacción de Ibarra a la historia del teniente de lo que muchos esperaban?
* [No reaccionó porque no le importaba la historia del teniente.]
~ score = score + 0
    -> question8
* [Ibarra parecía feliz con la declaración del teniente.]
~ score = score + 1
    -> question8
* [Mostró que estaba muy afectado y hizo muchas preguntas.]
~ score = score + 0
    -> question8
    
-> question8
=== question8 ===
¿Por qué es importante la música en la escena de la Fonda de Lala en toda la historia?
* [Proporciona color y emoción a la escena.]
~ score = score + 1
    -> question9
* [Solo proporciona entretenimiento a los personajes.]
~ score = score + 0
    -> question9
* [La música no tiene relación con la historia.]
~ score = score + 0
    -> question9
    
-> question9
=== question9 ===
¿Cuál fue el efecto de la historia del teniente en la visión de Ibarra sobre la religión?
* [Su opinión sobre la iglesia aumentó.]
~ score = score + 0
    -> question10
* [Tuvo miedo y dudas sobre la religión.]
~ score = score + 1
    -> question10
* [No tiene importancia en la historia.]
~ score = score + 0
    -> question10
    

=== question10 ===
¿Cómo se vio afectada la perspectiva de Ibarra sobre su padre después de la historia del teniente?
* [Su ira hacia su padre se intensificó.]
~ score = score + 0
    -> correction
* [Tuvo una comprensión profunda y compasión por su padre.]
~ score = score + 1
    -> correction
* [No tuvo efecto en él.]
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
