using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {
public GameObject MyInventory;
    public Button inv;

	// Use this for initialization
	void Start () {
	Button btn1 = inv.GetComponent<Button>();
    btn1.onClick.AddListener(TaskOnClick);

	}
	 void TaskOnClick()
    {
		MyInventory.SetActive(true);
		Debug.Log("hey");
    }
	
	// Update is called once per frame
	void Update () {
	  
if(Input.GetKeyDown(KeyCode.Escape))
{
	MyInventory.SetActive(false);

}
	}
	public void ShowInv()
	{
		
	}
	}
