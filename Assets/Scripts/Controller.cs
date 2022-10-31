using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private ArcadeInput aci = new ArcadeInput();
    // Start is called before the first frame update
    void Start()
    {
        aci.PlayerNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(aci.hori))
        {
            //do thing: move horizontal
        }
    }
}
