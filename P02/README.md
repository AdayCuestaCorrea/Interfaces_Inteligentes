# Práctica 2 - Introducción a C\#: Scripts
## Aday Cuesta Correa
Para la realización de esta práctica se nos pidió completar 8 ejercicios diferentes.

**1. Crea un script asociado a un objeto en la escena que inicialice un vector de 3 posiciones con valores entre 0.0 y 1.0, para tomarlo como un vector de color (Color). Cada 120 frames se debe cambiar el valor de una posición aleatoria y asignar el nuevo color al objeto. Parametrizar la cantidad de frames de espera para poderlo cambiar desde el inspector.**

He creado el siguiente script para llevar a cabo esta tarea:
```C#
public class ColorAndPosRandom : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    color = new Color(Random.value, Random.value, Random.value);
    GetComponent<Renderer>().material.color = color;
  }
  // Update is called once per frame
  void Update() {
    frameCounter++;
    if (frameCounter >= framesToWait) {
      // Resetear el contador de frames
      frameCounter = 0;
      // Cambiar el valor de una posición aleatoria
      int randomIndex = Random.Range(0, 3);
      switch (randomIndex) {
        case 0:
          color.r = Random.value;
          break;
        case 1:
          color.g = Random.value;
          break;
        case 2:
          color.b = Random.value;
          break;
      }
      // Asignar el nuevo color
      GetComponent<Renderer>().material.color = color;
    }
  }
  public int framesToWait = 120;
  private int frameCounter = 0;
  private Color color;
}
```

Gracias al switch cambiamos una de las 3 posiciones del vector de colores a un número aleatorio, además como la variable ***framesToWait*** es publica esta puede modificarse desde el inspector. El resultado obtenido es el siguiente:

![coloresFrame](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/QuadModoFeria-Ej_1.gif)

**2. Crea una escena simple en la que ubiques un plano y sobre él un cubo, una esfera y un cilindro. Cada uno de los objetos debe estar en un color diferente. En la consola cada objeto debe mostrar su nombre**

La escena ha quedado tal que así despues de añadir los objetos pedidos:

![escena_ej2](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/Escena-Ej_2.png)

He creado el siguiente script para mostrar por consola el nombre de los objetos:

```C#
public class PrintName : MonoBehaviour
{
  // Start is called before the first frame update
  void Start() {
    Debug.Log("My name is: " + gameObject.name);
  }
  // Update is called once per frame
  void Update() {
      
  }
}
```

Y esto es lo que aparece por consola:

![consola_ej2](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/Consola-Ej_2.png)

**3. Crea un script asociado a la esfera con dos variables Vector3 públicas. Dale valor a cada componente de los vectores desde el inspector. Muestra en la consola:
a. La magnitud de cada uno de ellos. 
b. El ángulo que forman
c. La distancia entre ambos.
d. Un mensaje indicando qué vector está a una altura mayor.
Muestra en el inspector cada uno de esos valores.**

El script que logra esto es el siguiente:

```C#
public class Vector3Stats : MonoBehaviour {
  public Vector3 firstVector = new Vector3(1, 2, 3);
  public Vector3 secondVector = new Vector3(4, 5, 6);
  [SerializeField] private int firstVectorMagnitude;
  [SerializeField] private int secondVectorMagnitude;
  [SerializeField] private int angleBetweenVectors;
  [SerializeField] private int distanceBetweenVectors;
  [SerializeField] private string higherVector;
  void Start() {
    
  }
  // Update is called once per frame
  void Update() {
    firstVectorMagnitude = (int)firstVector.magnitude;
    secondVectorMagnitude = (int)secondVector.magnitude;
    angleBetweenVectors = (int)Vector3.Angle(firstVector, secondVector);
    distanceBetweenVectors = (int)Vector3.Distance(firstVector, secondVector);
    higherVector = firstVector[2] > secondVector[2] ? "First Vector is higher" : "Second Vector is higher";
  }
}
```

Gracias al uso de SerializeField esas variables pueden verse en el inspector pero no se pueden modificar los valores de, por ejemplo, la magnitud. Por otro lado los unicos que si se pueden modificar en el inspector son los valores de los vectores.

![statsVector](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/inspector-Ej_3.png)

**4. Muestra en pantalla el vector con la posición de la esfera.**

Para lograr esto primero cree un objeto de texto hijo de la esfera y mediante un script consigo que escriba el nombre de su padre y su vector de coordenadas:

```C#
public class ShowPosition : MonoBehaviour {
  // Reference to the TextMeshProUGUI component
  [SerializeField] private TMP_Text positionText;

  // Start is called before the first frame update
  void Start() {
    if (positionText == null) {
      Debug.LogError("Position Text is not assigned.");
    }
  }

  // Update is called once per frame
  void Update() {
    if (positionText != null) {
      Vector3 parentPosition = transform.parent.position;
      positionText.text = transform.parent.name + " Position: " + parentPosition.ToString();
    }
  }
}
```

![coordenadas](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/Mostrar_Posicion-Ej_4.png)

**5. Crea un script para la esfera que muestre en consola la distancia a la que están el cubo y el cilindro.**

Para lograr esto creé un script que se asigna al objeto que desees y mediante unas variables publicas, se puede modificar a que objetos quieres hacer el calculo de la distancia:

```C#
public class DistanceToObject : MonoBehaviour
{
    // Start is called before the first frame update
    public string firstObjectName = "Red_Cube";
    public string secondObjectName = "Green_Cylinder";
    private GameObject firstObject;
    private GameObject secondObject;
    void Start() {
      firstObject = GameObject.Find(firstObjectName);
      secondObject = GameObject.Find(secondObjectName);
      Debug.Log("Distance between " + gameObject.name + " and " + firstObjectName + ": " + Vector3.Distance(transform.position, firstObject.transform.position));
      Debug.Log("Distance between " + gameObject.name + " and " + secondObjectName + ": " + Vector3.Distance(transform.position, secondObject.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```

![distancias](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/Distance_Between-Ej_5.png)

**6. Selecciona tres posiciones en tu escena a través de un objeto invisible (marcador) que incluya 3 vectores numéricos para configurar posiciones en las que quieres ubicar los objetos en respuesta a pulsar la barra espaciadora. Estos vectores representan un desplazamiento respecto a la posición original del objeto. Crea un script que ubique en las posiciones configuradas cuando el usuario pulse la barra espaciadora.**

Para hacer el marcador creé un objeto invisible y otros 3 objetos invisibles hijos de este tal que así:

![marcador](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/marker_Ej-6.png)

Lo que hago en el script es obtener la posición de esos 3 marcadores y cada vez que el usuario le da al espacio muevo el objeto cuyo script está asociado a una de esas 3 posiciones:

```C#
public class MoveObjectToMarker : MonoBehaviour {
  public GameObject marker;
  private Vector3[] markerPositions;
  private int indexPosition = 0;

    // Start is called before the first frame update
  void Start() {
    // Get the number of child objects
    int childCount = marker.transform.childCount;
    // Initialize the markerPositions array
    markerPositions = new Vector3[childCount];
    // Store the positions of the child objects
    for (int i = 0; i < childCount; i++) {
      markerPositions[i] = marker.transform.GetChild(i).position;
    }
  }

    // Update is called once per frame
  void Update() {
    // Check if the space key is pressed
    if (Input.GetKeyDown(KeyCode.Space)) {
      // Move the object to the current marker position
      transform.position = markerPositions[indexPosition];
      // Update the index to the next position
      indexPosition = (indexPosition + 1) % markerPositions.Length;
    }
  }
}
```

El resultado es el siguiente:

![changingPos](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/changing_pos-Ej_6.gif)

**7. Cambia el color del cilindro cuando el usuario pulse la tecla C, cambia el color del cubo cuando el usuario pulse la flecha arriba.**

Para realizar este script decidí que se pueda cambiar la tecla con la que cambias el color del objeto asociado al script desde el inspector:

```C#
public class PressToChangeColor : MonoBehaviour {
    // Key to press to change color
    public KeyCode key = KeyCode.C;

    // Update is called once per frame
    void Update() {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(key)) {
            // Change the color of the object to a random color
            ChangeColor();
        }
    }

    // Method to change the color of the object to a random color
    void ChangeColor() {
        // Generate a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Apply the random color to the object's material
        GetComponent<Renderer>().material.color = randomColor;
    }
}
```

El resultado es el siguiente:

![changeColor](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/key_color-Ej_7.gif)

**8. Agrega 5 esferas más en la escena. Crea un grupo de 2 , asígnales la misma etiqueta para indicar esferas de tipo 1 y a las restantes otra etiqueta diferente a ésta para indicar esferas de grupo 2. En la escena también habrá un cubo. Implementa un script que aumente la altura de la esfera de tipo 2 más cercana al cubo. Cambia el color de la más lejana cuando el jugador pulsa la tecla espacio.**

Tras añadir las esferas a la escena esta quedó tal que así (en los laterales tenemos las de tipo 1 y entre estas están las de tipo 2):

![escena_ej-8](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/Escena_Ej-8.png)

Así pues también creé las etiquetas SphereGroup1 y SphereGroup2, utilizadas en el script para obtener la esfera necesaria de cada grupo para la tarea. Para el primer grupo hice el script que cambia el color de la esfera:

```C#
public class ChangeColorOfFurthestObject : MonoBehaviour {
  public KeyCode key = KeyCode.Space;
  public string objectTag = "SphereGroup1";
  private GameObject referenceObject;
  private GameObject furthestObject;
  void Start() {
    referenceObject = gameObject;
    furthestObject = GameObject.FindGameObjectsWithTag(objectTag)[0];
    foreach (GameObject obj in GameObject.FindGameObjectsWithTag(objectTag)) {
      if (Vector3.Distance(referenceObject.transform.position, obj.transform.position) > Vector3.Distance(referenceObject.transform.position, furthestObject.transform.position)) {
        furthestObject = obj;
      }
    }
  }

  void Update() {
    // Check if the specified key is pressed
    if (Input.GetKeyDown(key)) {
      // Change the color of the object to a random color
      ChangeColor();
    }
  }

  // Method to change the color of the object to a random color
  void ChangeColor() {
    // Generate a random color
    Color randomColor = new Color(Random.value, Random.value, Random.value);
    // Apply the random color to the object's material
    furthestObject.GetComponent<Renderer>().material.color = randomColor;
  }
}
```

Para el segundo grupo hice el otro script que aumenta la altura de la esfera más lejana:

```C#
public class IncreaseHeightOfFurthestObject : MonoBehaviour {
  public string objectTag = "SphereGroup2";
  public float increase = 0.1f;
  private GameObject referenceObject;
  private GameObject furthestObject;
  void Start() {
    referenceObject = gameObject;
    furthestObject = GameObject.FindGameObjectsWithTag(objectTag)[0];
    foreach (GameObject obj in GameObject.FindGameObjectsWithTag(objectTag)) {
      if (Vector3.Distance(referenceObject.transform.position, obj.transform.position) > Vector3.Distance(referenceObject.transform.position, furthestObject.transform.position)) {
        furthestObject = obj;
      }
    }
  }

    // Update is called once per frame
  void Update() {
    furthestObject.transform.position = new Vector3(furthestObject.transform.position.x, furthestObject.transform.position.y + increase * Time.deltaTime, furthestObject.transform.position.z);
  }
}
```

El resultado final de la ejecución de dichos scripts es el siguiente:

![ej-8](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P02/Im%C3%A1genes/objeto_lejano_Ej-8.gif)
