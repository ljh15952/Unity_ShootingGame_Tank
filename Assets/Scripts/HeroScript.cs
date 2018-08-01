using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeroScript : MonoBehaviour
{

    public GameObject Bullet;

    public List<GameObject> Bullet_List = new List<GameObject>();

    int BulletCount;

    public Image Hp_bar;

    public GameObject result;

    public UIMANAGER UM;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, GetAngle() + 90);
        BulletCount = 0;
        Singleton.GetInstance.Hero_Move_Speed = 0.055f;

        for (int i = 0; i < Bullet_List.Count; i++)
        {
            Bullet_List[i] = Instantiate(Bullet);
        }

    }


    IEnumerator BB()
    {
        int count = 0;
        int B = 0;
        while (count < 3)
        {
            if (B >= 100)
                B = 0;
            for (int i = 0; i < 36; i++)
            {
                ShotBullet(Singleton.GetInstance.ShotBulletAngle * i);
                if (i >= 2)
                {
                    if (i % 2 == 0)
                    {
                        Bullet_List[B].transform.position = transform.position;
                        Bullet_List[B].transform.rotation = Quaternion.Euler(0, 0, GetAngle() - 90 + -10 * i);
                        Bullet_List[B].gameObject.SetActive(true);
                    }
                    else
                    {
                        Bullet_List[B].transform.position = transform.position;
                        Bullet_List[B].transform.rotation = Quaternion.Euler(0, 0, GetAngle() - 90 + 10 * i);
                        Bullet_List[B].gameObject.SetActive(true);
                    }
                }
                B++;
            }
            count++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, Singleton.GetInstance.Hero_Move_Speed, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -Singleton.GetInstance.Hero_Move_Speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraShake.shake = 0.5f;
            StartCoroutine(BB());
        }



        if (Input.GetMouseButton(0))
        {
            if (Time.time >= Singleton.GetInstance.Next_Shot_Time)
            {
                for (int i = 0; i < Singleton.GetInstance.ShotBulletCount; i++)
                {
                    //if (i == 2)
                    //    ShotBullet(-(Singleton.GetInstance.ShotBulletAngle * (i - 1)));
                    //else
                    //    ShotBullet(Singleton.GetInstance.ShotBulletAngle * i);

                    if (i >= 2)
                    {
                        if (i % 2 == 0)
                            ShotBullet(-(Singleton.GetInstance.ShotBulletAngle * (i - 1)));
                        else
                            ShotBullet(Singleton.GetInstance.ShotBulletAngle * i);
                    }
                    else
                        ShotBullet(Singleton.GetInstance.ShotBulletAngle * i);


                }

                Singleton.GetInstance.Next_Shot_Time = Time.time + Singleton.GetInstance.Next_Shot_Delay;
            }

        }

        transform.rotation = Quaternion.Euler(0, 0, GetAngle() + 90);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp_Item"))
        {
            if (Singleton.GetInstance.ShotBulletCount < 6)
                Singleton.GetInstance.ShotBulletCount++;
            Singleton.GetInstance.ShotBulletAngle += 5;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("SpeedUp_Item"))
        {
            if (Singleton.GetInstance.Hero_Move_Speed < 0.6f)
                Singleton.GetInstance.Hero_Move_Speed += 0.05f;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("ShotSpeedUp_Item"))
        {
            Singleton.GetInstance.Next_Shot_Delay -= 0.05f;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Hp_bar.fillAmount -= 0.2f;
            if(Hp_bar.fillAmount<=0.1f)
            {
                UM.ShowResult();
                result.SetActive(true);
            }
            collision.gameObject.SetActive(false);
        }


    }

    float GetAngle()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle;

        float xPos = transform.position.x - MousePos.x;
        float yPos = transform.position.y - MousePos.y;

        angle = Mathf.Atan2(yPos, xPos) * Mathf.Rad2Deg;


        return angle;
    }

    void ShotBullet(float addAngle)
    {
        if (BulletCount >= 100)
            BulletCount = 0;
        Bullet_List[BulletCount].transform.position = transform.position;
        Bullet_List[BulletCount].transform.rotation = Quaternion.Euler(0, 0, GetAngle() - 90 + addAngle);
        Bullet_List[BulletCount].gameObject.SetActive(true);
        BulletCount++;
    }

}
