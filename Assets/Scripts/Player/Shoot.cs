using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public int maxBulletCount = 2;

    public AudioSource _as;
    public AudioClip[] audioClipArray;

    void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        ShootBullet();
    }
    public void ShootBullet()
    {
        if (Input.GetButtonDown("P1 R1") && GameHandler.gameHandler.bulletLimit1 < maxBulletCount)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            GameHandler.gameHandler.AddBulletLimit1();
            _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            _as.PlayOneShot(_as.clip);
            return;
        }
    }
}
