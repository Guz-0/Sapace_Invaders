using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsController : MonoBehaviour
{
    [SerializeField] private GameObject x2Ammo;
    [SerializeField] private GameObject x3Ammo;

    [SerializeField] private int minSec;
    [SerializeField] private int maxSec;
    private float waitTime = 0;

    [SerializeField] private int round2Ammo;
    [SerializeField] private int round3Ammo;

    [SerializeField] private GameObject asteroidObj;
    [SerializeField] private float specialSpeedAsteroid;
    [SerializeField] private float minSecAsteroid;
    [SerializeField] private float maxSexAsteroid;

    [SerializeField] private float specialSpeedAmmo = 1f;
    private float resultSec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnRandom();
    }

    void spawnRandom()
    {
        if(waitTime == 0)
        {
            resultSec = UnityEngine.Random.Range(minSec, maxSec);
        }
        
        waitTime += Time.deltaTime;
        if(waitTime >= resultSec)
        {
            if(GameManager.Instance.numberOfRounds >= round2Ammo)
            {
                
                if(GameManager.Instance.numberOfRounds < round3Ammo)
                {
                    whichAmmo(x2Ammo);
                }
                else if(GameManager.Instance.numberOfRounds >= round3Ammo)
                {
                    if (UnityEngine.Random.Range(0, 2) == 1)
                    {
                        whichAmmo(x2Ammo);
                    }
                    else
                    {
                        whichAmmo(x3Ammo);
                    }
                }
            }
            

        }
    }

    void whichAmmo(GameObject ammo)
    {
        float randX = UnityEngine.Random.Range(-8.5f, 8.5f);
        var special = Instantiate(ammo, new Vector2(randX, transform.position.y), transform.rotation);
        special.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, specialSpeedAmmo * -1);

        waitTime = 0;
        Debug.Log("SPAWNED SPECIAL");
    }

    void spawnAsteroid(GameObject asteroid)
    {
        /*
        float waitTimeAst =;
        waitTimeAst += Time.deltaTime;
        */}
}
