using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectID : MonoBehaviour
{
    //Este script funcionará como un bloque de código
    public int id;
    public bool isDragging;

    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Verifica si el mouse está sobre el objeto
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
            }
        }

        // Si suelta el botón izquierdo del mouse, deja de arrastrar
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Si está arrastrando, mueve el objeto a la posición del mouse
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Hola MOndongo");
        if(other.gameObject.CompareTag("Lienzo")){
            transform.SetParent(other.transform);
        }
    }
}