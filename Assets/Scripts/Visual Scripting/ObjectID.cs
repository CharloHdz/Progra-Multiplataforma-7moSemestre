using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectID : MonoBehaviour
{
    public ObjectID Instance;
    public int ID;
    public GameObject Player;
    public Variable variable;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 100);
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Movimiento del bloque

    Vector2 difference = Vector2.zero;

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;

        // Si el objeto tiene un padre, convertimos la posición del mouse al espacio local del padre
        if (transform.parent != null)
        {
            // Convertimos la posición mundial a la posición local del padre
            transform.localPosition = transform.parent.InverseTransformPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));
        }
        else
        {
            // Si no tiene padre, simplemente actualizamos la posición en el espacio mundial
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    public void Instruction(){
        Player.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }
}

public enum Variable{
    Avanzar,
    Saltar,
    Disparar,
    Agacharse
}
