using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawner : MonoBehaviour
{
    public GameObject boulderPrefab;
    public float spawnTime = 0.2f;
    public int[,] taken = new int[200,2];
    int indexT = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(boulderRain());
    }

    private /*IEnumerator*/ void spawnBoulder()
    {
        GameObject b = Instantiate(boulderPrefab) as GameObject;
        int randx = Random.Range(-8, 17);
        int randy = Random.Range(-14, 11);
        for(int i = 0; i < 200; i++)
        {
            if (taken[i, 0] == randx && taken[i,1] == randy)
            {
                return;
            }
        }
        taken[indexT, 0] = randx;
        taken[indexT, 1] = randy;
        b.transform.position = new Vector2(randx, randy);
        indexT++;
    }

    // Update is called once per frame
    IEnumerator boulderRain()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnBoulder();
        }
    }
}
