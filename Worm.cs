using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour {

    public Rigidbody2D bulletPrefab;
    public Transform Gun;
    SpriteRenderer ren;
    public float BulletForce = 5;
    public float wormSpeed = 1;

    void Start () {
        Gun.GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();        
    }

    void Update()
    {
        RotateGun();

        var hor = Input.GetAxis("Horizontal");
        if (hor == 0)
        {
            Gun.gameObject.SetActive(true);

            ren.flipX = Gun.eulerAngles.z < 180;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                var p = Instantiate(bulletPrefab,
                                    Gun.position - Gun.right,
                                    Gun.rotation);

                p.AddForce(-Gun.right * BulletForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            Gun.gameObject.SetActive(false);
            transform.position += Vector3.right *
                                hor *
                                Time.deltaTime *
                                wormSpeed;
            ren.flipX = Input.GetAxis("Horizontal") > 0;
        }
    }

    void RotateGun()
    {
        var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Gun.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);
    }
    
    //void RotateGun()
    //{
    //    Vector3 MousePosition = Input.mousePosition;
    //    MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

    //    Vector2 Direction = new Vector2(MousePosition.x - Grenade.transform.parent.position.x,
    //                                    MousePosition.y - Grenade.transform.parent.position.y);

    //    Grenade.transform.parent.up = Direction;
    //}

    //void ThrowGrenade()
    //{
    //    Vector3 m_pos = Input.mousePosition;
    //    Vector3 g_pos = Camera.main.WorldToScreenPoint(Grenade.transform.position);
    //    m_pos.x = m_pos.x - g_pos.x;
    //    m_pos.y = m_pos.y - g_pos.y;
    //    aimAngle = (Mathf.Atan2(m_pos.y, m_pos.x) * Mathf.Rad2Deg);
    //}
}