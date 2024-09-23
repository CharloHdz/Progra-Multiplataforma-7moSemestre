using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectID_UI : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int ID;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Lienzo_UI lienzoUI;  // Referencia al lienzo para verificar la "entrada" del objeto

    public Variable1 var;
    private Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        lienzoUI = FindObjectOfType<Lienzo_UI>();  // Obtenemos referencia al Lienzo en la escena
        originalPosition = rectTransform.anchoredPosition;  // Guardamos la posición original
    }

    // Evento cuando se empieza a arrastrar el objeto
    public void OnPointerDown(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;  // Guardamos la posición cuando empieza el arrastre
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Comenzó a arrastrar el objeto con ID: " + ID);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Movemos el objeto según la posición del puntero
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out movePos);
        rectTransform.anchoredPosition = movePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Terminó de arrastrar el objeto con ID: " + ID);

        // Verificamos si el objeto está dentro del área del panel (lienzo)
        if (lienzoUI.IsObjectInsidePanel(gameObject))
        {
            Debug.Log("El objeto " + ID + " ha sido soltado dentro del área del lienzo.");
            lienzoUI.ObjectIDList.Add(gameObject);  // Añadir el objeto al Lienzo si está dentro del área
        }
        else
        {
            Debug.Log("El objeto " + ID + " está fuera del área del lienzo.");
        }
    }

    // Método para ejecutar una instrucción
    public void Instruction()
    {
        Debug.Log("Ejecutando instrucción del objeto con ID: " + ID);
        // Aquí puedes implementar las instrucciones específicas para cada objeto

        switch(var){
            case Variable1.Saltar:
                Player.Instance.PlayerRB.AddForce(transform.up * 100);
            break;
            case Variable1.Agacharse:
                print("Agachar");
            break;
            case Variable1.Avanzar:
                Rigidbody2D rb = Player.Instance.PlayerRB;
                if (rb != null)
                {
                    rb.AddForce(Vector2.right * 200);
                    print("Avanzar");
                }
                print("Avanzar");
            break;
            case Variable1.Disparar:
                print("Disparar");
            break;
        }
    }
}

public enum Variable1{
    Avanzar,
    Saltar,
    Disparar,
    Agacharse
}


