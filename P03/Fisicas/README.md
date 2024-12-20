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

### Ejercicio 4

- Mueve el cubo con las teclas de flecha arriba-abajo, izquierda-derecha a la velocidad speed. Cada uno de estos ejes implican desplazamientos en el eje vertical y horizontal respectivamente. Mueve la esfera con las teclas w-s (movimiento vertical) a-d (movimiento horizontal).

He creado el siguiente script:

```Cs
public class MoveObject : MonoBehaviour {
  public KeyCode upKey = KeyCode.UpArrow;
  public KeyCode downKey = KeyCode.DownArrow;
  public KeyCode leftKey = KeyCode.LeftArrow;
  public KeyCode rightKey = KeyCode.RightArrow;
  public float speed = 1.0f;
  void Update() {
    if (Input.GetKey(upKey)) {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    } else if (Input.GetKey(downKey)) {
      transform.Translate(Vector3.back * speed * Time.deltaTime);
    } else if (Input.GetKey(leftKey)) {
      transform.Translate(Vector3.left * speed * Time.deltaTime);
    } else if (Input.GetKey(rightKey)) {
      transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
  }
}
```

Como las teclas de movimiento son publicas, en la esfera simplemente cambie las flechas por wasd.

![teclas_esfera](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/esfera_Ej-4.png)

El resultado de la ejecución del script es el siguiente:

![moviendo_objetos](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/Objetos-Moviendose_Ej-4.gif)

### Ejercicio 5

- Adapta el movimiento en el ejercicio 4 para que sea proporcional al tiempo transcurrido durante la generación del frame.

Esto ya está hecho en el ejercicio anterior.

### Ejercicio 6

- Adapta el movimiento en el ejercicio 5 para que el cubo se mueva hacia la posición de la esfera. Debes considerar, que el avance no debe estar influenciado por cuánto de lejos o cerca estén los dos objetos.

Hemos creado el siguiente script para obtener el resultado esperado:

```Cs
public class MoveObjectToSphere : MonoBehaviour {
  private GameObject sphere;
  private Vector3 spherePosition;
  public float speed = 1.0f;
  void Start() { // Cambiado a 'Start' con mayúscula
    sphere = GameObject.Find("Sphere");
  }
  void Update() {
    spherePosition = sphere.transform.position;
    Vector3 direction = (spherePosition - transform.position).normalized;
    direction.y = 0; // Mantener la componente Y en cero
    transform.Translate(direction * speed * Time.deltaTime);
  }
}
```

El resultado obtenido es el siguiente:

![cubo_a_esfera](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/Moviendose-a-la-esfera_Ej-6.gif)

### Ejercicio 7

- Adapta el movimiento en el ejercicio 6 de forma que el cubo gire hacia la esfera. Realiza pruebas cambiando la posición de la esfera mediante las teclas awsd

He creado un nuevo script a partir del anterior tal que así:

```Cs
public class LookWhileMoving : MonoBehaviour {
  private GameObject sphere;
  private Vector3 spherePosition;
  public float speed = 1.0f;
  void Start() { // Cambiado a 'Start' con mayúscula
    sphere = GameObject.Find("Sphere");
  }
  void Update() {
    spherePosition = sphere.transform.position;
    Vector3 direction = (spherePosition - transform.position).normalized;
    direction.y = 0; // Mantener la componente Y en cero para el movimiento
    transform.Translate(direction * speed * Time.deltaTime, Space.World);
    transform.LookAt(spherePosition);
  }
}
```

He tenido que especificar que el movimiento sea relativo al espacio del mundo. El resultado es el siguiente:

![mirando_esfera](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/mirando-cubo_Ej-7.gif)

### Ejercicio 8

- Utilizar el eje “Horizontal” para girar el objetivo y que avance siempre en la dirección hacia adelante.

Para realizar esto hemos girado el cubo y creado el siguiente script:

```Cs
public class MoveForward : MonoBehaviour {
  public float speed = 5.0f;
  public float rotationSpeed = 100.0f;

  void Update() {
    float horizontalInput = Input.GetAxis("Horizontal");
    transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
  }
}
```

El resultado obtenido es el siguiente:

![cubo_girado](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/cubo-girado_Ej-8.gif)

### Ejercicio 9

- Configura el cilindro como un objeto físico, cuando el cubo o la esfera colisionen con él se debe mostrar un mensaje en consola con la etiqueta del objeto que haya colisionado.

Para realizar esto, le añadí el componente rigidbody a todos los objetos de la escena y les quité la gravedad para que no se cayeran.

El Script que creé es el siguiente:

```Cs
public class Collision : MonoBehaviour {
  void OnCollisionEnter(UnityEngine.Collision collision) {
    Debug.Log("El " + gameObject.name + " colisionó con: " + collision.gameObject.name);
  }
}
```

El resultado fue este:

![colisiones](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/colisiones_Ej-9.gif)

![consola_ej9](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/consola_Ej-9.png)

### Ejercicio 10

- Configura el cubo como un objeto cinemático y la esfera como un objeto físico. Adapta los scripts del ejercicio 9 para obtener el mismo comportamiento.

Tal y como está hecho el script no es necesario modificar nada pues se sigue mostrando por consola la colisión.

### Ejercicio 11

- Configura el cilindro como un objeto de tipo Trigger. Adapta los scripts de los ejercicios anteriores para obtener el mismo comportamiento.

Después de activar is Trigger en el Capsule Collider del cilindro creé otro script nuevo para este ejercicio:

```Cs
public class TriggerCollision : MonoBehaviour {
  void OnTriggerEnter(UnityEngine.Collider other) {
    Debug.Log("El " + gameObject.name + " tuvo una Trigger collision con: " + other.gameObject.name);
  }
}
```

El resultado fue el siguiente:

![colision_trigger](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/colisiones_Ej-11.gif)
![consola_ej11](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/consola_Ej-11.png)

### Ejercicio 12

- Agrega un cilindro de un color diferente al que ya hay en la escena y configúralo como un objeto físico. Selecciona un conjunto de teclas que te permitan controlar su movimiento por la escena y prográmale un movimiento que permita dirigirlo hacia la esfera. Prueba diferentes configuraciones de la esfera física con masa 10 veces mayor que el cilindro, física con masa 10 veces menor que el cilindro, cinemática y trigger. También prueba la configuración del cilindro de forma que su fricción se duplique o no.

Después de crear el cilindro, le asigné el script de movimiento que hicimos en el ejercicio 4 aunque tuve que modificarlo un poco porque ahora estamos trabajando con rigidbodies:
```Cs
public class MoveRigidBody : MonoBehaviour {
  public KeyCode upKey = KeyCode.W;
  public KeyCode downKey = KeyCode.S;
  public KeyCode leftKey = KeyCode.A;
  public KeyCode rightKey = KeyCode.D;
  public float speed = 1.0f;
  private Rigidbody rb;
  void Start() {
    rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
  }
  void FixedUpdate() {
    Vector3 movement = Vector3.zero;
    if (Input.GetKey(upKey)) {
      movement += Vector3.forward;
    } 
    if (Input.GetKey(downKey)) {
      movement += Vector3.back;
    } 
    if (Input.GetKey(leftKey)) {
      movement += Vector3.left;
    } 
    if (Input.GetKey(rightKey)) {
      movement += Vector3.right;
    }
    rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
  }
}
```
y modifiqué el del ejercicio 7 para que se mueva de manera automática hacia la esfera si pulsas la tecla *h*:
```Cs
public class ActiveAutomaticMovement : MonoBehaviour {
  private GameObject sphere;
  private Vector3 spherePosition;
  public float speed = 1.0f;
  public KeyCode toggleKey = KeyCode.H;
  private bool isMoving = false;
  private Rigidbody rb;
  void Start() {
    sphere = GameObject.Find("Sphere");
    rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
  }
  void Update() {
    // Verificar si se presiona la tecla 'H'
    if (Input.GetKeyDown(toggleKey)) {
      isMoving = !isMoving; // Alternar el estado de movimiento
    }
  }
  void FixedUpdate() {
    // Ejecutar el movimiento solo si isMoving es verdadero
    if (isMoving) {
      spherePosition = sphere.transform.position;
      Vector3 direction = (spherePosition - transform.position).normalized;
      rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
      Vector3 lookAtPosition = new Vector3(spherePosition.x, transform.position.y, spherePosition.z);
      transform.LookAt(lookAtPosition);
    }
  }
}
```

Nótese que he utilizao MovePosition para mover el objeto rígido. El resultado de las diferentes ejecuciones fueron los siguientes:
1. Esfera física con masa 10 veces mayor que el cilindro (100 de masa):

![esfera_mas_masa](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/esfera-masa_Ej-12.gif)

El cilindro apenas puede mover a la esfera.

2. Esfera con masa 10 veces menor que el cilindro (1 de masa):

![esfera_menos_masa](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/esfera-poca-masa_Ej-12.gif)

No le supone problema alguno mover a la esfera.

3. Esfera cinemática:

![esfera_cinemática](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/esfera-cinematica_Ej-12.gif)

El cilindro es incapaz de mover la esfera.

4. Esfera Trigger:

![esfera_trigger](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P03/Fisicas/Imagenes/esfera-trigger_Ej-12.gif)

El cilindro traspasa la esfera, aunque tenga el modo cinemático activado.

5. Cilindro con fricción duplicada:

En este caso no noté ninguna diferencia por mucho que aumentara la fricción del cilindro.
