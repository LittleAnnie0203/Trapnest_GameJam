using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class GamepadManager : MonoBehaviour

    // ANA DANIELA CHURATA SILVESTRE
{
    public TextMeshProUGUI messageText; 

    void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        
        if (device is Gamepad)
        {
            if (change == InputDeviceChange.Added)
                StartCoroutine(ShowMessage("Gamepad conectado"));
            else if (change == InputDeviceChange.Removed)
                StartCoroutine(ShowMessage("Gamepad desconectado"));
        }
    }

    IEnumerator ShowMessage(string msg)
    {
        messageText.text = msg;
        messageText.gameObject.SetActive(true); 
        yield return new WaitForSeconds(3f);   
        messageText.gameObject.SetActive(false); 
    }
}
