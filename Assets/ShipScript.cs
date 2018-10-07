﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ShipScript : MonoBehaviour
{
    //Functions och variabler
    public SpriteRenderer rend;
    public Color shipColor;
    public Transform shipLocation;

    [Range(-500, 500)]
    public int shipSpeed;

    [Range(-720, 720)]
    public float shipRotateSpeed;

    public float timer;


    void Start()
    {

    }




    void Update()
    {
        transform.Translate(shipSpeed * Time.deltaTime, 0, 0, Space.Self);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, shipRotateSpeed * Time.deltaTime);
            rend.color = shipColor;
            rend.color = new Color(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-shipSpeed / 2 * Time.deltaTime, 0, 0, Space.Self);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -shipRotateSpeed * Time.deltaTime);
            rend.color = shipColor;
            rend.color = new Color(0f, 1f, 0f);
        }

        timer += 1 * Time.deltaTime;
        print(string.Format("Timer: {0}", timer));
    }
}
