using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] public float _speed = 5f;
    Vector3 _moveDir;

    void Update()
    {
        PlayerMovement();
        StayOnScreen();
    }

    public void PlayerMovement()
    {
        float translation = Input.GetAxisRaw("P1 Verti") * _speed;
        translation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet2")
        {
            GameHandler.gameHandler.MinusBulletLimit2();
            GameHandler.gameHandler.SetPlayer1Health();
            GameHandler.gameHandler.P1Health -= 1;
            if (GameHandler.gameHandler.P1Health == 0)
            {
                Destroy(gameObject);
                GameHandler.gameHandler.Buttons();
                GameHandler.gameHandler.P1Wins.SetActive(true);
            }
            Destroy(collision.gameObject);
        }        
        if (collision.gameObject.tag == "Bullet")
        {
            GameHandler.gameHandler.MinusBulletLimit1();
            GameHandler.gameHandler.SetPlayer1Health();
            GameHandler.gameHandler.P1Health -= 1;
            if (GameHandler.gameHandler.P1Health == 0)
            {
                Destroy(gameObject);
                GameHandler.gameHandler.Buttons();
                GameHandler.gameHandler.P2Wins.SetActive(true);
            }
            Destroy(collision.gameObject);
        }
    }

    public void StayOnScreen()
    {
        Vector3 clampPos = transform.position;
        clampPos.x = -5;
        clampPos.z = Mathf.Clamp(clampPos.z, -3.5f, 3.5f);
        clampPos.y = 0;
        transform.position = clampPos;
    }
}
