using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{ 
    public bool inAir;
    // Use this for initialization
    void Start()
    {
        inAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && inAir == false)
            {
                inAir = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 10.0f);
            }
        }
    }
}
