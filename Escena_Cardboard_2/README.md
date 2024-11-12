# Escenas Cardboard 2
## Aday Cuesta Correa

### Ejercicio

- Con la escena del ejercicio 8 de la práctica anterior crea un proyecto de CardBoard, en el que implementes la mecánica de recolección de algún objeto. La interacción para la recolección se lleva a cabo con la mirada del jugador. Además cuando se llega a una determinada puntuación un tipo de objetos debe dirigirse hacia un punto preestablecido.

Para esta práctica he creado un script para poder abrir puertas al acercame a ellas y mirarlas (no es muy útil actualmente porque en el teléfono no puedo moverme)

```cs
public class InteractWithDoor : MonoBehaviour {
  private GameObject door;
  public float openAngle = 90f;
  public float openSpeed = 2f;
  private bool isOpen = false; 
  private bool isPlayerNearby = false;
  private bool lookingAtDoor = false;
  private bool isAnimating = false;
  private Quaternion closedRotation; 
  private Quaternion openRotation;

  void Start() {
    door = this.gameObject;
    closedRotation = door.transform.rotation;
    openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
  }

  void Update() {
    if (isPlayerNearby && lookingAtDoor && !isAnimating) {
      isOpen = !isOpen;
      isAnimating = true;
    }

    if (isOpen) {
      door.transform.rotation = Quaternion.Slerp(door.transform.rotation, openRotation, Time.deltaTime * openSpeed);
      if (Quaternion.Angle(door.transform.rotation, openRotation) < 0.1f) {
        door.transform.rotation = openRotation;
        isAnimating = false;
      }
    } else {
      door.transform.rotation = Quaternion.Slerp(door.transform.rotation, closedRotation, Time.deltaTime * openSpeed);
      if (Quaternion.Angle(door.transform.rotation, closedRotation) < 0.1f) {
        door.transform.rotation = closedRotation;
        isAnimating = false;
      }
    }
  }

  public void OnPointerEnter() {
    lookingAtDoor = true;
  }

  public void OnPointerExit() {
    lookingAtDoor = false;
  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      isPlayerNearby = true;
    }
  }

  void OnTriggerExit(Collider other) {
    if (other.CompareTag("Player")) {
      isPlayerNearby = false;
    }
  }
}
```

También he creado un script para saber cuando estoy mirando hacia un huevo de araña:

```cs
public class PointingEgg : MonoBehaviour
{
    public delegate void pointingAtEgg(GameObject egg);
    public static event pointingAtEgg onPointingEgg;

    public float activationDistance = 1.5f; // Set the distance within which the event can be triggered
    private GameObject player;
    private bool isPointing = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= activationDistance && isPointing) {
            isPointing = true;
            onPointingEgg?.Invoke(this.gameObject);
        }
    }

    public void OnPointerEnter() {
      isPointing = true;
    }

    public void OnPointerExit() {
      isPointing = false;
    }
}
```

Por otro lado he creado el script que va aumentando el marcador de puntos cada vez que cogemos un huevo:

```cs
public class PlayerScore : MonoBehaviour
{
    [SerializeField] public static int playerScore = 0;
    public int addScore = 25;
    public delegate void ScoreChanged(int newScore);
    public static event ScoreChanged onScoreChanged;

    void OnEnable() {
        PointingEgg.onPointingEgg += AddScoreAndDestroy;
    }

    void OnDisable() {
        PointingEgg.onPointingEgg -= AddScoreAndDestroy;
    }

    void AddScoreAndDestroy(GameObject egg) {
        playerScore += addScore;
        Debug.Log("Player Score = " + playerScore);
        egg.layer = 0; // Set the layer to default (0)
        egg.SetActive(false); // Set the egg to inactive
        onScoreChanged?.Invoke(playerScore); // Notify score change
    }
}
```

Por último creé un script para que al coger todos los huevos (es decir, llegar a una puntuación de 100), la araña vaya a por ti:

```cs
public class SpiderToSomething : MonoBehaviour
{
  public Transform moveToObject; // Reference to the object we have to move to
    public float speed = 4f; // Speed of the spider
    private Rigidbody rb;
    private Animator animator;
    private bool shouldMove = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void OnEnable() {
        PlayerScore.onScoreChanged += CheckScore;
    }

    void OnDisable() {
        PlayerScore.onScoreChanged -= CheckScore;
    }

    void CheckScore(int score) {
        if (score >= 100) {
            shouldMove = true;
        }
    }

    void FixedUpdate() {
        if (shouldMove && moveToObject != null) {
            Vector3 moveToObjectPosition = moveToObject.position;
            Vector3 direction = (moveToObjectPosition - transform.position).normalized;
            direction.y = 0;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            animator.SetBool("IsRunning", true);
        } else {
            rb.velocity = Vector3.zero;
            animator.SetBool("IsRunning", false);
        }
    }
}
```

Como no puedes moverte de momento pues no puedes huir de ella.

Este es un ejemplo de la ejecución desde el teléfono:

![vr_movil](https://github.com/AdayCuestaCorrea/Interfaces_Inteligentes/blob/main/Escena_Cardboard_2/Im%C3%A1genes/Ara%C3%B1a_ataca.gif)
