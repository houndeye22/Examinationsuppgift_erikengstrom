using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ShipScript : MonoBehaviour
{
    //Functions och variabler
    public SpriteRenderer rend1;
    public SpriteRenderer rend2;
    public Color shipColorFront;
    public Color shipColorBase;
    public Transform shipLocation;

    [Range(-500, 500)]
    public int shipSpeed;

    public int shipSpeedMin;
    public int shipSpeedMax;

    [Range(-720, 720)]
    public float shipRotateSpeedLeft;

    [Range(-720, 720)]
    public float shipRotateSpeedRight;

    public float timer;
    public int timerCount;

    public float shipColorRandom1;
    public float shipColorRandom2;
    public float shipColorRandom3;


    public int negativeSpawnX;
    public int negativeSpawnY;
    public int positiveSpawnX;
    public int positiveSpawnY;
    public int finalSpawnX;
    public int finalSpawnY;
    public Vector2 shipSpawnPos;


    void Start()
    {
        shipSpeed = Random.Range(shipSpeedMin, shipSpeedMax);

        finalSpawnX = Random.Range(negativeSpawnX, positiveSpawnX);
        finalSpawnY = Random.Range(negativeSpawnY, positiveSpawnY);
        shipSpawnPos = new Vector2(finalSpawnX, finalSpawnY);
        transform.position = shipSpawnPos;
    }




    void Update()
    {
        transform.Translate(shipSpeed * Time.deltaTime, 0, 0, Space.Self);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, shipRotateSpeedLeft * Time.deltaTime);
            rend1.color = shipColorFront;
            rend1.color = new Color(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-shipSpeed / 2 * Time.deltaTime, 0, 0, Space.Self);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -shipRotateSpeedRight * Time.deltaTime);
            rend1.color = shipColorFront;
            rend1.color = new Color(0f, 1f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipColorRandom1 = Random.Range(0.1f, 1f);
            shipColorRandom2 = Random.Range(0.1f, 1f);
            shipColorRandom3 = Random.Range(0.1f, 1f);

            shipColorBase = new Color(shipColorRandom1, shipColorRandom2, shipColorRandom3);
            rend2.color = shipColorBase;
        }

        timer += 1 * Time.deltaTime;
        if (timer > timerCount)
        {
            timerCount += 1;
            print(string.Format("Timer: {0}", timerCount));
        }
        
    }
}
