using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollider : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collect"))
        {
            gm.ScoreUp();
            ParticleSystem current =  Instantiate(gm.starsParticle,other.transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(current.gameObject, 2);
        }
        if(other.CompareTag("Enemy"))
        {
            gm.ScoreDown();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            gm.StopGame();
        }
    }
}
