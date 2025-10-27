using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private Rigidbody rb;

    void Start()
    {
        // Obtenemos el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Si no tiene Rigidbody, se puede agregar desde el Inspector o cambiar el código a transform.Translate
        if (rb == null)
            Debug.LogWarning("No hay Rigidbody en el objeto. Agrégalo o cambia a movimiento con transform.Translate.");
    }

    void FixedUpdate()
    {
        // Leer entrada del teclado (WASD o flechas)
        float moveX = Input.GetAxis("Horizontal"); // A/D o Flechas izquierda/derecha
        float moveZ = Input.GetAxis("Vertical");   // W/S o Flechas arriba/abajo

        // Crear vector de movimiento
        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed;

        // Mover el personaje usando física
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
