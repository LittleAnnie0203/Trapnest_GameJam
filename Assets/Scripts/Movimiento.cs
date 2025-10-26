using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{

    //ANA DANIELA CHURATA SILVESTRE

   
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float lookSensitivity = 2f;
    [SerializeField] Transform cameraTransform;

    Rigidbody rigi;
    Vector2 moveInput;
    Vector2 lookInput;
    float verticalLookRotation;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();

        
        if (cameraTransform == null)
        {
            Camera cam = GetComponentInChildren<Camera>();
            if (cam != null)
                cameraTransform = cam.transform;
            else
                Debug.LogError("No se encontró ninguna cámara para cameraTransform");
        }
    }

    void Update()
    {
       
        if (cameraTransform != null)
        {
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            forward.y = 0f; 
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            Vector3 movimiento = forward * moveInput.y + right * moveInput.x;
            rigi.MovePosition(rigi.position + movimiento * moveSpeed * Time.deltaTime);
        }

   
        transform.Rotate(Vector3.up * lookInput.x * lookSensitivity);

        if (cameraTransform != null)
        {
            verticalLookRotation -= lookInput.y * lookSensitivity;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -80f, 80f);
            cameraTransform.localRotation = Quaternion.Euler(verticalLookRotation, 0, 0);
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rigi.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
