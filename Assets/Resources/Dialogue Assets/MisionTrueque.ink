// ============================================
// MISIÓN DE TRUEQUE - EL AMULETO LEGENDARIO
// Misión principal que desbloquea el ítem raro
// ============================================

VAR fase_mision = 0
VAR tiene_azafran = 0
VAR tiene_tela = 0
VAR tiene_martillo = 0

-> inicio_mision

=== inicio_mision ===
{fase_mision == 0:
    -> mision_no_aceptada
- else:
    -> progreso_mision
}

=== mision_no_aceptada ===
Aún no has aceptado la misión del Maestro Artesano. Búscalo en su puesto misterioso en la plaza principal. #speaker:Sistema #portrait:system
-> END

=== progreso_mision ===
MISIÓN: El Amuleto del Comerciante Legendario #speaker:Sistema #portrait:system
Reúne los siguientes materiales para el Maestro Artesano: #speaker:Sistema #portrait:system
* [Ver progreso]
    -> ver_progreso
* [Consejos para la misión]
    -> consejos_mision
* [Cerrar]
    -> END

=== ver_progreso ===
Estado de los materiales: #speaker:Sistema #portrait:system
{tiene_azafran == 1:
    ✓ Azafrán Dorado - OBTENIDO
- else:
    ○ Azafrán Dorado - Habla con Doña Carmen (Puesto de Especias)
}
{tiene_tela == 1:
    ✓ Tela del Alba - OBTENIDO
- else:
    ○ Tela del Alba - Habla con Don Miguel (Puesto de Telas)
}
{tiene_martillo == 1:
    ✓ Martillo Ancestral - OBTENIDO
- else:
    ○ Martillo Ancestral - Habla con Tomás (Puesto de Herramientas)
}
* [Volver]
    -> progreso_mision

=== consejos_mision ===
Consejos importantes: #speaker:Sistema #portrait:system
1. Negocia con los vendedores para obtener lo que necesitan. #speaker:Sistema #portrait:system
2. Cada vendedor necesita algo que otro vendedor tiene. #speaker:Sistema #portrait:system
3. ¡CUIDADO con el Estafador Ambulante! Sus productos son falsificaciones. #speaker:Sistema #portrait:system
4. Administra bien tu inventario de 8 espacios. #speaker:Sistema #portrait:system
* [Volver]
    -> progreso_mision

=== obtener_azafran ===
¡Has obtenido el Azafrán Dorado de Doña Carmen! #speaker:Sistema #portrait:system
Este ingrediente mágico es esencial para el Amuleto. #speaker:Sistema #portrait:system
~ tiene_azafran = 1
-> verificar_completado

=== obtener_tela ===
¡Has obtenido la Tela del Alba de Don Miguel! #speaker:Sistema #portrait:system
Esta tela especial brilla con la luz del amanecer. #speaker:Sistema #portrait:system
~ tiene_tela = 1
-> verificar_completado

=== obtener_martillo ===
¡Has obtenido el Martillo Ancestral de Tomás! #speaker:Sistema #portrait:system
Esta herramienta ha forjado leyendas. #speaker:Sistema #portrait:system
~ tiene_martillo = 1
-> verificar_completado

=== verificar_completado ===
{tiene_azafran == 1 && tiene_tela == 1 && tiene_martillo == 1:
    -> mision_completada
- else:
    -> END
}

=== mision_completada ===
¡MISIÓN COMPLETADA! #speaker:Sistema #portrait:system
Has reunido todos los materiales. ¡Ve con el Maestro Artesano para reclamar tu recompensa! #speaker:Sistema #portrait:system
-> END
