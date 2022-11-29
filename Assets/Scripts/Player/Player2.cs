using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] public float _speed = 5f;
    Vector3 _moveDir;
    public AudioSource _as;
    public AudioClip[] audioClipArray;

    void Awake()
    {
        _as = GetComponent<AudioSource>();
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
            GameHandler.gameHandler.SetPlayer2Health();
            GameHandler.gameHandler.P2Health -= 1;
            if (GameHandler.gameHandler.P2Health == 0)
            {
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
        clampPos.x = 5;
        clampPos.z = Mathf.Clamp(clampPos.z, -3.5f, 3.5f);
        clampPos.y = 0;
        transform.position = clampPos;
    }
}
