using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
[SerializeField] private Rigidbody2D currentBallRigidbody;// 1. Campo Para Identificar Cuerpo Rigido Ball.

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Touchscreen.current.primaryTouch.press.isPressed)
        {
            currentBallRigidbody.isKinematic = false; // 3. Desactivar la propiedad "Kinematic" con el Input/ Toque.
            return;
        }

        currentBallRigidbody.isKinematic = true; //4. Propiedad "Kinematic" por defecto.

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        currentBallRigidbody.position = worldPosition; //2. Determinar Posicion Objeto a Posicion del Mundo.
    }
}
