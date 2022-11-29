using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        }
        Debug.Log(collision.gameObject.name);
    }
}
