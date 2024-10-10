# Práctica 3 - Experimentando con la física desde el editor.
## Aday Cuesta Correa
- Así se ve la escena inicial:

![escena_inicial](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Situaciones/Imagenes/escena_inicial-1.png)

### Situación 1
En esta situación se nos pedía lo siguiente:

**El plano no es un objeto físico. El cubo es un objeto físico y la esfera no. En este caso, el plano y la esfera sólo tendrán collider, mientras que el cubo debe tener Rigidbody.**

Así pues, el plano y la esfera poseen el componente collider por defecto, en el caso del cubo si hemos tenido que añadir el Rigidboyd

![cubo_rigidbody](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Situaciones/Imagenes/cubo_rigidbody-2.png)

Aquí vemos como el cubo cae mientras que la esfera, por ejemplo, no.

![cubo_cayendo](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Situaciones/Imagenes/cubo_cayendo-3.gif)

### Situación 2
En esta otra situación se nos pedía lo siguiente:
**El plano no es un objeto físico. El cubo es un objeto físico y la esfera también. En este caso, el plano sólo tendrán collider, mientras que el cubo y la esfera deben tener Rigidbody.**

Tras añadir el rigidbody a la esfera, esta interactua así:

![esfera_rigidbody](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Situaciones/Imagenes/esfera_cayendo-4.gif)

### Situación 3
En esta se nos pedía lo siguiente:
**El plano no es un objeto físico. El cubo es un objeto físico y la esfera es cinemática. En este caso, el plano sólo tendrán collider, mientras que el cubo y la esfera deben tener Rigidbody esta última cinemático.**

Activamos la cinemática en la esfera tal que así:
![kinematic](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Situaciones/Imagenes/kinematic-5.png)

En este caso la esfera está quieta tal y como ocurre en la primera situación (similar al collider).

### Situación 4
Aquí se nos pedía:
**El plano es un objeto físico. El cubo es un objeto físico y la esfera es física. En este caso, todos los objetos deben tener Rigidbody**

Ahora todos los objetos se caen:

![se_cae_todo](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Situaciones/Imagenes/se_cae-6.gif)
