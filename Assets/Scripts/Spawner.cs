using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    float delayTime = 0;
    int waveCount = 1;
    public List<GameObject> mons = new List<GameObject>();

    public GameObject Boss;

    void Update()
    {
        if (Time.time >= delayTime && waveCount < 3)
        {
            for (int i = 0; i < waveCount; i++)
                Spawn();
            delayTime = Time.time + 8f;
            waveCount++;
        }
        else if (waveCount == 3)
        {
            SpawnBoss();
            waveCount++;
        }
    }


    void SpawnBoss()
    {
        Boss.SetActive(true);
        StartCoroutine(BossMove());
    }

    void Spawn()
    {
        for (int i = 0; i < mons.Count; i++)
        {
            GameObject G = Instantiate(mons[i], new Vector2(Random.Range(9, 12), Random.Range(-2.5f, 2.5f)), Quaternion.identity);
            G.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90, 90));
        }
    }

    IEnumerator BossMove()
    {
        while (Boss.transform.position.x >= 6)
        {
            Boss.transform.Translate(-0.03f, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
