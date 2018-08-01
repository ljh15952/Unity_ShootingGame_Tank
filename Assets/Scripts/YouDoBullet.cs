using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDoBullet : MonoBehaviour {

    public GameObject Hero;


	// Use this for initialization
	void Start () {
		
        transform.rotation = Quaternion.Euler(0, 0, GetAngle() + 90);
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(0, 0.1f, 0);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }


    float GetAngle()
    {
        float angle;

        float xPos = transform.position.x - Hero.transform.position.x;
        float yPos = transform.position.y - Hero.transform.position.y;

        angle = Mathf.Atan2(yPos, xPos) * Mathf.Rad2Deg;


        return angle;
    }
}
