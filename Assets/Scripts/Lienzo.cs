using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lienzo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //UI Stuff
    [SerializeField] Animator anim;
    public bool OnHover;

    // funcionalidad
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetTrigger("Open");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetTrigger("Close");
    }
}
