using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormManager : MonoBehaviour
{


    int num = 2;
    public GameObject go;
    GameObject go1, go2;
          float t=10;
    Worm p1, p2;
    // Use this for initialization
    void Start()
    {
        go1 = (GameObject)Instantiate(go, Vector3.zero, Quaternion.identity);
        go2 = (GameObject)Instantiate(go, Vector3.zero, Quaternion.identity);

        go1.GetComponent<Worm>().id = 1;
        go2.GetComponent<Worm>().id = 2;

    }

    // Update is called once per frame
    void Update()
    {
      t-=Time.deltaTime;
      if(t<=0)
      {
        t=5;
        
      }

    }
}
