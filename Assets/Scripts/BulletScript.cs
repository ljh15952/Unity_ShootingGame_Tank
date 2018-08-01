﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    

    // Use this for initialization
    void Start()
    {
        //gameObject.SetActive(false);	
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.5f, 0);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
