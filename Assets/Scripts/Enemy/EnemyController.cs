using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private AudioClip hitClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PROJECTILE"))
        {
            try
            {
                GameManager.Instance.sumHighScoreByValue(10);
                //Debug.Log(GameManager.Instance.getScore());
            }
            catch (Exception)
            {
                Debug.Log("[" + gameObject.name + "] GAME MANAGER NOT FOUND");
            }
           
            Destroy(collision.gameObject);
            Destroy(gameObject);
            try{
                SoundManager.Instance.PlaySound(hitClip);
            }
            catch (Exception)
            {
                Debug.Log("[" + gameObject.name + "] EFFECT SOURCE NOT FOUND");
            }
            
        }
    }
}
