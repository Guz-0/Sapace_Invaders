using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    private const string score = "SCORE: ";

    [SerializeField] private TMP_Text ammoText;
    private const string ammo = "AMMO: x";

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        updateTexts();
        
    }

    void updateTexts()
    {
        try
        {
            scoreText.SetText(score + GameManager.Instance.getScore());
            ammoText.SetText(ammo + GameManager.Instance.ammoNumberGlobal);
        }
        catch (Exception)
        {
            Debug.Log("[" + gameObject.name + "] GAME MANAGER NOT FOUND");
        }
    }
}
