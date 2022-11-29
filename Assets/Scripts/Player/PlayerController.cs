using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
        //movement forwards backwards left and right
        //temporary storage to calculate movement vector
        Vector3 movement;
        //assigns the x axis of the movement vector to match the players' hoizontal input
        movement.x = 0;
        //leave y axis alone as we don't want to be move up and down
        movement.y = 0;
        //assigns the z axis of the movement vector to match the player's vertical input
        movement.z = Input.GetAxisRaw("P1 Verti");
        //make vector framemate independant
        movement *= Time.deltaTime;
        //apply speed multiplayer
        movement *= _speed;

        transform.Translate(movement);
        StayOnScreen();
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
