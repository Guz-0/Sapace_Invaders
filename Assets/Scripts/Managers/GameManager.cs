using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]public int highScore;
    [HideInInspector]public float numberOfRounds;
    public float maxMoveTimeFirst;
    [HideInInspector] public float maxMoveTime;
    public float maxDivisor;

    [HideInInspector] public int ammoNumberGlobal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        this.highScore = 0;
        maxMoveTime = maxMoveTimeFirst;
    }

    public void sumHighScoreByValue(int value)
    {
        this.highScore += value;
    }

    public int getScore()
    {
        return this.highScore;
    }

    public void addNumberOfRounds()
    {
        numberOfRounds += 1f;
        if(maxMoveTime >= 0.3f)
        {
            maxMoveTime = maxMoveTime - maxDivisor;
        }

    }

    public float getMaxMoveTime()
    {
        return maxMoveTime ;
    }
}
