using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RightClick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

public GameObject go;
	// Use this for initialization
	 bool pressed = false;
	bool r=false,l=false;
	void Start () {
	}
   
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(r);
if(r==true)
go.transform.Translate(0.01f,0.0f,0.0f);

	}

		 public void OnPointerDown(PointerEventData eventData)
    {
      r=true;
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
		
r=false;
    }
}
