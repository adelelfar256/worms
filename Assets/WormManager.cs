using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    public GameObject c;
    int num = 2;
    Vector3 v1,v2;
    public GameObject go;
    GameObject go1, go2;
          float t=10;
    Worm p1, p2;
    // Use this for initialization
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void StartGame()
    {
        c.SetActive(false);
        v1.x=-14.0f;
        v2.x=14.0f;
        v1.y=1;
        v2.y=1;
        v1.z=1;
        v2.z=1;
        go1 = (GameObject)Instantiate(go,v1, Quaternion.identity);
        go2 = (GameObject)Instantiate(go,v2, Quaternion.identity);

        go1.GetComponent<Worm>().id = 1;
        go2.GetComponent<Worm>().id = 2;
    }
}
