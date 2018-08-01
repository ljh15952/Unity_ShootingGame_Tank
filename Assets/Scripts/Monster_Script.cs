using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Script : MonoBehaviour
{


    public int Hp;
    float Next_Shot_Time;
    public GameObject Bullet;
    public List<GameObject> items = new List<GameObject>();
    public GameObject R;
    // Use this for initialization
    void Start()
    {
        Next_Shot_Time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name != "Boss")
        transform.Translate(-0.05f, 0, 0);

        if (Time.time >= Next_Shot_Time && gameObject.name == "Monster_Shot(Clone)")
        {
            ShotBullet();
            Next_Shot_Time = Time.time + 2f;
        }
        if (Time.time >= Next_Shot_Time && (gameObject.name == "Monster_YouDo(Clone)"||gameObject.name=="Boss"))
        {
            ShotYoudoBullet();
            Next_Shot_Time = Time.time + 2.5f;
        }

    }

    void ShotYoudoBullet()
    {
        GameObject B = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
        B.SetActive(true);
    }

    void ShotBullet()
    {
        GameObject B = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
        B.SetActive(true);
    }


    public UIMANAGER UI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Hp--;
            if (Hp == 0)
            {
                UI.AddScore();
                gameObject.SetActive(false);
                if (gameObject.name == "Monster_YouDo(Clone)")
                {
                    Instantiate(items[Random.Range(0, 3)], transform.position, Quaternion.identity);
                }
                if (gameObject.name == "Boss")
                {
                    UI.ShowResult();
                    R.SetActive(true);
                }
            }
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Wall")&&gameObject.name !="Boss")
        {
            if (transform.rotation.z > 0)
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90, 0));
            else
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 90));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            //gameObject.SetActive(false);
        }
    }
}
