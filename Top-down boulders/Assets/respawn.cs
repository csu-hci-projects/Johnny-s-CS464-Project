using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    public int Respawn;
    private BoxCollider2D col;
    public bool killZone = false;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    public void EnableKillZone()
    {
        killZone = true;
    }
    public void DisableKillZone()
    {
        killZone = false;
    }

    IEnumerator OnTriggerEnter2D(Collider2D thing)
    {
        if (killZone && thing.CompareTag("Player"))
        {
            Timer.instance.EndTimer();
            playerMovement2D.instance.killPlayer();
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(Respawn);
        }
    }
    IEnumerator OnTriggerStay2D(Collider2D thing)
    {
        if (killZone && thing.CompareTag("Player"))
        {
            Timer.instance.EndTimer();
            playerMovement2D.instance.killPlayer();
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(Respawn);
        }
    }

}
