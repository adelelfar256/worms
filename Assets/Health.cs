using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Health : MonoBehaviour
{
    public int health;
	public Slider s;
    // Use this for initialization
    void Start()
    {
        health = 100;
		s=FindObjectOfType<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
		s.value=health;

		if(health>100)
		health=100;
		if(health<=0)
        {
            health=0;
            Destroy(gameObject);
        }
    }
}
