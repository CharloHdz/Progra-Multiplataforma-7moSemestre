using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // Necesario para usar LINQ

public class Lienzo : MonoBehaviour
{
    public List<GameObject> ObjectID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Sort();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayGame();
        }
    }

    public void Sort()
    {
        // Ordenar los objetos por su posición en el eje Y de mayor a menor (del objeto más alto al más bajo)
        ObjectID = ObjectID.OrderByDescending(obj => obj.transform.position.y).ToList();
    }

    public void PlayGame()
    {
        for (int i = 0; i < ObjectID.Count; i++)
        {
            ObjectID[i].GetComponent<ObjectID>().Instruction();
            WaitForSeconds wait = new WaitForSeconds(1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObjectID")
        {
            ObjectID.Add(other.gameObject);
            for (int i = 0; i < ObjectID.Count; i++)
            {
                print(ObjectID[i].GetComponent<ObjectID>().ID);
                WaitForSeconds wait = new WaitForSeconds(1);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObjectID")
        {
            ObjectID.Remove(other.gameObject);
        }
    }
}

