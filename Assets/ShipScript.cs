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

    public Transform shipRelocator;

    public Vector2 shipSpawnPos;

    //Kör igenom koden när den startar
    void Start()
    {
        //Gör så att ship speed är random mellan det minsta och högsta värdet som man skriver in i unity
        shipSpeed = Random.Range(shipSpeedMin, shipSpeedMax);

        //Den randomiserade X koordinaten mellan 2 värden
        finalSpawnX = Random.Range(negativeSpawnX, positiveSpawnX);
        //Den randomiserade Y koordinaten mellan 2 värden
        finalSpawnY = Random.Range(negativeSpawnY, positiveSpawnY);
        //Koordinaten där ship spawnar vilket är X och Y. X och Y är bestämmda i koden ovan
        shipSpawnPos = new Vector2(finalSpawnX, finalSpawnY);
        //Gör så att ship flyttas till där shipSpawnPos har sagt till den att vara
        transform.position = shipSpawnPos;
    }



    //Kör igenom varje frame
    void Update()
    {
        //Gör så att ship åker alltid framåt
        transform.Translate(shipSpeed * Time.deltaTime, 0, 0, Space.Self);

        //Kollar om man använder "A" tangenten
        if (Input.GetKey(KeyCode.A))
        {
            //Roterar ship
            transform.Rotate(0f, 0f, shipRotateSpeedLeft * Time.deltaTime);
            //Säger till den att ändra shipFront
            rend1.color = shipColorFront;
            //Säger till den vilken färg
            rend1.color = new Color(0f, 0f, 1f);
        }
        //Kollar om man använder "S" tangenten
        if (Input.GetKey(KeyCode.S))
        {
            //Gör så att ship blir hälften så snabbt
            transform.Translate(-shipSpeed / 2 * Time.deltaTime, 0, 0, Space.Self);
        }
        //Kollar om man använder "D" tangenten
        if (Input.GetKey(KeyCode.D))
        {
            //Roterar ship åt höger
            transform.Rotate(0f, 0f, -shipRotateSpeedRight * Time.deltaTime);
            //Säger till den att ändra shipFront
            rend1.color = shipColorFront;
            //Säger till den vilken färg
            rend1.color = new Color(0f, 1f, 0f);
        }

        //Kollar om man trycker ner "Space" tangenten
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Väljer hur stark R, G, och B värderna är.
            shipColorRandom1 = Random.Range(0.1f, 1f); //R
            shipColorRandom2 = Random.Range(0.1f, 1f); //G
            shipColorRandom3 = Random.Range(0.1f, 1f); //B

            //Kombinerar färgerna från kodan ovan och ställer upp det så att den förstår att det är färg värden
            shipColorBase = new Color(shipColorRandom1, shipColorRandom2, shipColorRandom3);
            //Säger till den att ändra färgerna
            rend2.color = shipColorBase;
        }

        //Timer som adderar 1 varje sekund
        timer += 1 * Time.deltaTime;
        //Om timer är mer än timerCount så...
        if (timer > timerCount)
        {
            //"Konverterar" den så att det bara står sekunder utan decimaler
            timerCount += 1;
            //Printar ut värdet
            print(string.Format("Timer: {0}", timerCount));
        }

        Vector3 newPosition = transform.position;
        if (newPosition.x > 8 || newPosition.x < -8)
        {
            newPosition.x = -newPosition.x;
        }
        if (newPosition.y > 5 || newPosition.y < -5)
        {
            newPosition.y = -newPosition.y;
        }
        transform.position = newPosition;
    }

}
//-8.89, -5
//8.89, 5