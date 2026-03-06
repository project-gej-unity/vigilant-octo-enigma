using UnityEngine;
using UnityEngine.UIElements;


public class MoveBackAndForth : MonoBehaviour
{
    public float speed = 2.0f; // Szybkość ruchu
    public float distance = 2.0f; // Jak daleko ma ruszać się od pozycji startowej
    private Vector3 startPosition;

    void Start()
    {
        // Zapisujemy pozycję startową obiektu
        startPosition = transform.position;
    }

    void Update()
    {
        // Używamy Mathf.PingPong do obliczenia ruchu przód-tył w czasie
        float movement = Mathf.PingPong(Time.time * speed, distance);

        // Ruch w osi Z (przód/tył). Zmień na transform.right dla boki lub transform.up dla góra/dół
        transform.position = startPosition + transform.forward * movement;
    }
}
