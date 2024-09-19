using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectID : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Este script funcionará como un bloque de código
    public int id;
    public bool isMoveable;
    void Instruction()
    {
        //Ejemplo: Avanzar 1 casilla
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isMoveable)
        {
            //on click follow mouse
            transform.position = Input.mousePosition;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Mouse enter");
        isMoveable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Mouse exit");
        isMoveable = false;
    }

}