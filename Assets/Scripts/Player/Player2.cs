using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] public float _speed = 5f;
    Vector3 _moveDir;
    public AudioSource auxSauce;
    public AudioClip[] audioClipArray;

    void Awake()
    {
        auxSauce = GetComponent<AudioSource>();
    }
    void Update()
    {
        PlayerMovement();
        StayOnScreen();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameHandler.gameHandler.MinusBulletLimit1();
            GameHandler.gameHandler.SetPlayer2Health();
            GameHandler.gameHandler.P2Health -= 1;
            auxSauce.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            auxSauce.PlayOneShot(auxSauce.clip);
            if (GameHandler.gameHandler.P2Health == 0)
            {
                Destroy(gameObject);
                GameHandler.gameHandler.Buttons();
                GameHandler.gameHandler.P1Wins.SetActive(true);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bullet2")
        {
            GameHandler.gameHandler.MinusBulletLimit2();
            GameHandler.gameHandler.SetPlayer2Health();
            GameHandler.gameHandler.P2Health -= 1;
            auxSauce.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            auxSauce.PlayOneShot(auxSauce.clip);
            if (GameHandler.gameHandler.P2Health == 0)
            {
                Destroy(gameObject);
                GameHandler.gameHandler.Buttons();
                GameHandler.gameHandler.P2Wins.SetActive(true);
            }
            Destroy(collision.gameObject);
        }
    }

    public void PlayerMovement()
    {
        float translation = Input.GetAxisRaw("P2 Verti") * _speed;
        translation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
    }

    public void StayOnScreen()
    {
        Vector3 clampPos = transform.position;
        clampPos.x = 5; //locks movement on this axis on that value
        clampPos.z = Mathf.Clamp(clampPos.z, -3.5f, 3.5f); //clamp's movement between these last two values on
        clampPos.y = 0;
        transform.position = clampPos;
    }
}
