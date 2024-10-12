# Práctica 3 - Movimiento: Físicas
## Aday Cuesta Correa

### Ejercicio 1

- Agrega un campo velocidad a un cubo y asígnale un valor que se pueda cambiar en el inspector de objetos. Muestra la consola el resultado de multiplicar la velocidad por el valor del eje vertical y por el valor del eje horizontal cada vez que se pulsan las teclas flecha arriba-abajo ó flecha izquierda-derecha. El mensaje debe comenzar por el nombre de la flecha pulsada.

Para lograr esto he creado el siguiente script

```Cs
public class Speed : MonoBehaviour {
  public float speed = 5f;
  private float verticalAxis;
  private float horizontalAxis;
  void Update() {
    horizontalAxis = Input.GetAxis("Horizontal");
    verticalAxis = Input.GetAxis("Vertical");
    if (Input.GetKeyDown(KeyCode.UpArrow)) {
      Debug.Log("Up Arrow: " + (speed * horizontalAxis * verticalAxis * Time.deltaTime));
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow)) {
      Debug.Log("Down Arrow: " + (speed * horizontalAxis * verticalAxis * Time.deltaTime));
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
      Debug.Log("Left Arrow: " + (speed * horizontalAxis * verticalAxis * Time.deltaTime));
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow)) {
      Debug.Log("Right Arrow: " + (speed * horizontalAxis * verticalAxis * Time.deltaTime));
    }
  }
}
```

Por consola aparece lo siguiente cuando se presiona una de las teclas descritas en el enunciado:

![ej_1](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/Ej-1.png)

### Ejercicio 2

- Mapea la tecla H a la función disparo.

![ej_2](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/Ej-2.png)

### Ejercicio 3

- Crea un script asociado al cubo que en cada iteración traslade al cubo una cantidad proporcional un vector que indica la dirección del movimiento: moveDirection que debe poder modificarse en el inspector.  La velocidad a la que se produce el movimiento también se especifica en el inspector, con la propiedad speed. Inicialmente la velocidad debe ser mayor que 1 y el cubo estar en una posición y=0.

Para completar esto cree el siguiente script:

```Cs
public class Move : MonoBehaviour {
  public Vector3 moveDirection = new Vector3(0, 0, 1);
  public float moveSpeed = 1.5f;
  void Update() {
    transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
  }
}
```

Así pues el resultado es el siguiente:

![ej_3](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/Inspector_Ej-3.png)
![ej_3.1](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/Cubo-Alejandose_Ej-3.gif)

Ahora procederé a explicar las situaciones que se nos pedía realizar:

- **Duplicar las coordenadas de la dirección del movimiento**: Al duplicar las coordenadas de la dirección del movimiento el cubo se alejaba más rápido de nosotros
- **Duplicar la velocidad manteniendo la dirección del movimiento**: Al poner más velocidad el cubo se aleja más rápido igual que pasó en la situación anterior.
- **Usar una velocidad menor que 1**: El cubo se mueve más lento.
- **La posición del cubo tiene y>0**: No pasa nada, se mueve a la misma velocidad independientemente del valor de la y.
- **Intercambiar el movimiento relativo al sistema de referencia local y el mundial**: Para realizar esto tuve que modificar un poco el script original y añadir Space.World a los parametros del translate, después de eso ejecuté el script y no noté ningún cambio significativo.
