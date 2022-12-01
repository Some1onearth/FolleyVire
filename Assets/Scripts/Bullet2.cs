using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //destroy themselves eventually
        if (transform.position.x > 7 || transform.position.x < -7)
        {
            Destroy(gameObject);
            //decrease bullet limit
            GameHandler.gameHandler.MinusBulletLimit2();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //are we touching a bullet?
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bullet2")
        {
            //destroy bullet THEN destroy self
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameHandler.gameHandler.MinusBulletLimit2();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            GameHandler.gameHandler.MinusBulletLimit2();
        }
        if (collision.gameObject.tag == "Mirror")
        {
            gameObject.transform.Rotate(0, 180, 0);
            speed = 10f;
        }
        Debug.Log(collision.gameObject.name);
    }
}
