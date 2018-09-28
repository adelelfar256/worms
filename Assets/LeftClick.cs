using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeftClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject go;
    // Use this for initialization
    bool pressed = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed == true)
        {
            if (go.transform.position.x > -2.35f)
                go.transform.Translate(-0.01f, 0.0f, 0.0f);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        pressed = false;
    }
}
