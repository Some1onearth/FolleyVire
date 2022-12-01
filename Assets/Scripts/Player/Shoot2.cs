using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour
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
        if (Input.GetButtonDown("P2 R1") && GameHandler.gameHandler.bulletLimit2 < maxBulletCount)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            GameHandler.gameHandler.AddBulletLimit2();
            //play shooting clip at random between full amount of sfx
            _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            _as.PlayOneShot(_as.clip);
            return;
        }
    }
}
