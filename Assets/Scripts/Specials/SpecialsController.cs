using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsController : MonoBehaviour
{
    [SerializeField] private GameObject x2Ammo;
    [SerializeField] private GameObject x3Ammo;

    [SerializeField] private int minSecAmmo;
    [SerializeField] private int maxSecAmmo;
    [SerializeField] private float specialSpeedAmmo = 1f;
    private float waitTimeAmmo = 0f;
    private float actualWaitTimeAmmo;

    [SerializeField] private int round2Ammo;
    [SerializeField] private int round3Ammo;

    [SerializeField] private GameObject asteroidObj;
    [SerializeField] private float minSecAsteroid;
    [SerializeField] private float maxSecAsteroid;
    [SerializeField] private float specialSpeedAsteroid;
    private float waitTimeAsteroid = 0f;
    private float actualWaitTimeAsteroid;

   
    void Update()
    {
        spawnRandom();
    }

    void spawnRandom()
    {
        if(waitTimeAmmo == 0)
        {
            actualWaitTimeAmmo = UnityEngine.Random.Range(minSecAmmo, maxSecAmmo);
        }
        if(waitTimeAsteroid == 0)
        {
            actualWaitTimeAsteroid = UnityEngine.Random.Range(minSecAsteroid, maxSecAsteroid);
        }
        
        waitTimeAmmo += Time.deltaTime;
        waitTimeAsteroid += Time.deltaTime;

        if(waitTimeAmmo >= actualWaitTimeAmmo)
        {
            if(GameManager.Instance.NumberOfRounds >= round2Ammo)
            {
                
                if(GameManager.Instance.NumberOfRounds < round3Ammo)
                {
                    WhichObjectToSpawn(x2Ammo, specialSpeedAmmo);
                }
                else if(GameManager.Instance.NumberOfRounds >= round3Ammo)
                {
                    if (UnityEngine.Random.Range(0, 2) == 1)
                    {
                        WhichObjectToSpawn(x2Ammo, specialSpeedAmmo);
                    }
                    else
                    {
                        WhichObjectToSpawn(x3Ammo, specialSpeedAmmo);
                    }
                }
            }
            

        }

        if(waitTimeAsteroid >= actualWaitTimeAsteroid)
        {
            WhichObjectToSpawn(asteroidObj, specialSpeedAsteroid);
            
        }
    }

    void WhichObjectToSpawn(GameObject obj, float specialSpeed)
    {
        float randX = UnityEngine.Random.Range(-8.5f, 8.5f);
        var special = Instantiate(obj, new Vector2(randX, transform.position.y), transform.rotation);
        special.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, specialSpeed * -1);

        if (special.CompareTag("ASTEROID"))
        {
            this.waitTimeAsteroid = 0f;
            //this.minSecAsteroid -= 1f;
            //this.maxSecAsteroid -= 1f;
        }
        else
        {
            this.waitTimeAmmo = 0f;
        }
        Debug.Log("SPAWNED SPECIAL: " + special.name);
    }
}
