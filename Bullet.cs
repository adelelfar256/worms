using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    bool IsPicked;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            IsPicked = false;
        }

        if (IsPicked == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = mousePos;
        }
    }

    void OnMouseDown()
    {
        IsPicked = true;
    }
}
