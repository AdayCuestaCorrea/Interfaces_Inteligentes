# Práctica 1 - Introducción a Unity
## Aday Cuesta Correa
Para la realización de esta práctica se nos pidió crear una escena 3D en unity, configurada de la siguiente manera:
1. Incluir objetos 3D básicos
2. Incluir  en el proyecto el paquete Starter Assets.
3. Incluir un objeto libre de la Asset Store que no sea de los Starter Assets.
4. Crear un terreno.
5. Cada objeto debe tener una etiqueta que lo identifique.
6. Utilizar prefabs de Starter Asset FPS o Third Person
7. Agregar un script que escriba en la consola la posición de cada objeto que hayas utilizado. 

Como resultado final he creado esta escena:
![Escena](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P01/Im%C3%A1genes/Escena.jpg)

- Aquí podemos observar el uso de los objetos 3D básicos (he utilizado 3 cubos para crear la bandera de España)
- Por otro lado, he includo el paquete Starter Assets al proyecto, así como muchos otros para la creación del terreno (árboles y texturas del suelo) y los lanceros y escuderos.

![Paquetes](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P01/Im%C3%A1genes/Paquetes.png)

- He utilizado el prefab de Starter Asset Third Person como se puede observar en el muñeco que se ve rosa (no se exactamente a que se debe la falta de texturas)
- He creado distintas etiquetas para los nuevos objetos y se las he asignado:

![Tags](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P01/Im%C3%A1genes/Tags.png)

- Por último he creado un script que muestra por consola la posición de los objetos en todo momento:

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintPosition : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    Debug.Log("Object called " + gameObject.name + " Position: " + transform.position);
  }

  // Update is called once per frame
  void Update() {
    Debug.Log("Object called " + gameObject.name + " Position: " + transform.position);
  }
}
```

Aquí tenemos un ejemplo de su ejecución en un gif:

![gif](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P01/Im%C3%A1genes/Demo_P01_II.gif)

Y así es como se ve una captura de la consola (Debido a que quizás en el gif no se ve exactamente que se está imprimiendo):

![Consola](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/P01/Im%C3%A1genes/Resultado_Consola.png)
