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

### Situación 5
En esta situación se nos pedía lo siguiente:

**El plano es un objeto físico. El cubo es un objeto físico y la esfera es física con 10 veces más masa que el cubo. En este caso, todos los objetos deben tener Rigidbody.**

Añadimos 10 veces la masa del cubo a la esfera, pero estos caen a la misma velocidad debido a la nula resistencia del aire, así que el resultado es igual que en la situación anterior.

### Situación 6
En esta otra situación se nos pedía lo siguiente:

**El plano es un objeto físico. El cubo es un objeto físico y la esfera es física con 100 veces más masa que el cubo. En este caso, todos los objetos deben tener Rigidbody.**

Ocurre exactamente lo mismo que en la situación anterior.

### Situación 7
En este caso se nos pide hacer lo siguiente:

**El plano es un objeto físico. El cubo es un objeto físico y la esfera es física con fricción. En este caso, todos los objetos deben tener Rigidbody.**

He añadido 1 de drag a la esfera (he devuelto el estado de la masa al original, que era 1), ahora esta cae más lenta que los demás objetos.

![drag](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Situaciones/Imagenes/drag-7.gif)

### Situación 8
Se nos pide:

**El plano es un objeto físico. El cubo es un objeto físico y la esfera no es física y es Trigger. En este caso, todos los objetos deben tener Rigidbody.**

Cuando eliminamos el rigidbody de la esfera y en el collider activamos trigger, la esfera se mantiene en el aire mientras que el plano y el cubo caen.

### Situación 9
Por último se nos pide:

**El plano es un objeto físico. El cubo es un objeto físico y la esfera es física y es Trigger. En este caso, todos los objetos deben tener Rigidbody.**

En este caso los 3 objetos caen. Debido a como se nos pidió las escena inicial no vemos mucho cambio al añadir el trigger, pero la gracia está en que cuando un objeto atraviesa a otro que posea el trigger, se pueden "disparar" acciones para que ocurran cosas en nuestra escena.
