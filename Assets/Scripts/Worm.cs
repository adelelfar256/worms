using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    static bool forceCheck = false;
    static bool jumpCheck = false;
    static float force = 0;
    static float jump = 0;
    static float cool = 3;
    Vector2 jumpHeight;

    static float t = 30;
    public int id = 1;
    public static int turn = 1;
    public Rigidbody2D bulletPrefab;
    public Transform Gun;
    SpriteRenderer ren;
    public float BulletForce = 5;
    public float wormSpeed = 1;

    void Start()
    {
        Gun.GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();
        jumpHeight.x = 0;
        jumpHeight.y = 7.0f;
    }

    void Update()
    {
        if (forceCheck)
            force += Time.deltaTime;

        t -= Time.deltaTime;
        cool -= Time.deltaTime;
        if (t <= 0)
        {

            if (turn == 1)
                turn = 2;
            else
                turn = 1;
            t = 30;
        }


        if (turn == id && cool <= 0)
        {

            RotateGun();

            var hor = Input.GetAxis("Horizontal");
            if (hor == 0)
            {
                Gun.gameObject.SetActive(true);

                ren.flipX = Gun.eulerAngles.z < 180;

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if(Terrain.nxtTurn)
                    forceCheck = true;

                }

                if (Input.GetKeyUp(KeyCode.Q))
                {
                    if(Terrain.nxtTurn)
                    {
                    var p = Instantiate(bulletPrefab, Gun.position - Gun.right, Gun.rotation);
                    force *= 2;
                    p.AddForce(-Gun.right * force * BulletForce, ForceMode2D.Impulse);
                    t = 1;
                    cool = 3;
                    Debug.Log(force);
                    forceCheck = false;
                    force = 0;
                    Terrain.nxtTurn=false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Space))  //makes player jump
                {
                    if (jumpCheck)
                        GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
                    jumpCheck = false;

                }

                if (Input.GetKeyUp(KeyCode.Space))  //makes player jump
                {
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
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "SpongeBob SquarePants Jelly Fields 2")
        {
            jumpCheck = true;
        }
    }
    void RotateGun()
    {
        if(Terrain.nxtTurn)
        {
        var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Gun.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);
        }
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