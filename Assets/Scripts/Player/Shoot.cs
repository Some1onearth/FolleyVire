using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static Shoot shoot;
    public uint guns;
    public float spread;
    public float coneSize;
    public GameObject bullet;
    public float fireRate = 3;

    private float timeToFire;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("P1 R1") && Time.time >= timeToFire && guns > 0)
        {
            timeToFire = Time.time + 1 / fireRate;
            if (guns == 1)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                return;
            }
        }
        //    float position = -spread / 2f;//spreads out the range where bullets come from
        //    float space = spread / (guns - 1); //keeps the space between each bullet
        //    Quaternion rotation = Quaternion.Euler(Vector3.up * -coneSize / 2);
        //    float turnAmount = coneSize / (guns - 1);
        //    for (int i = 0; i < guns; i++)
        //    {
        //        Instantiate(bullet, transform.position + Vector3.right * position, rotation);
        //        rotation *= Quaternion.Euler(Vector3.up * turnAmount);//rotates the spread shot direction.
        //        position += space;
        //    }
        //}
        //if (GameHandler.gameHandler.player1Score < 30)
        //{
        //    guns = 1;
        //}
        //if (GameHandler.gameHandler.player1Score > 30 && GameHandler.gameHandler.player1Score < 90)
        //{
        //    guns = 3;
        //}
        //if (GameHandler.gameHandler.player1Score > 90 && GameHandler.gameHandler.player1Score < 150)
        //{
        //    guns = 5;
        //}
        //if (GameHandler.gameHandler.player1Score > 150)
        //{
        //    guns = 7;
        //}
    }
}
