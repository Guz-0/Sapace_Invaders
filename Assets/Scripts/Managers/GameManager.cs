using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public int highScore;
    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            this.highScore = value;
        }
    }

    [HideInInspector] public float numberOfRounds;
    public float NumberOfRounds
    {
        get
        {
            return numberOfRounds;
        }
        set
        {
            this.numberOfRounds = value;
        }
    }

    public float maxMoveTimeFirst;
    public float MaxMoveTimeFirst
    {
        get
        {
            return maxMoveTimeFirst;
        }
        set
        {
            this.maxMoveTimeFirst = value;
        }
    }
    [HideInInspector] public float maxMoveTime;
    public float MaxMoveTime
    {
        get
        {
            return maxMoveTime;
        }
        set
        {
            this.maxMoveTime = value;
        }
    }
    public float maxDivisor;
    public float MaxDivisor
    {
        get
        {
            return maxDivisor;
        }
        set
        {
            this.maxDivisor = value;
        }
    }

    [HideInInspector] public int ammoNumberGlobal;
    public int AmmoNumberGlobal
    {
        get
        {
            return ammoNumberGlobal;
        }
        set
        {
            this.ammoNumberGlobal = value;
        }
    }

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

        this.HighScore = 0;
        MaxMoveTime = MaxMoveTimeFirst;
    }

    public void sumHighScoreByValue(int value)
    {
        this.HighScore += value;
    }

    public int getScore()
    {
        return this.HighScore;
    }

    public void addNumberOfRounds()
    {
        NumberOfRounds += 1f;
        if(MaxMoveTime >= 0.3f)
        {
            MaxMoveTime = MaxMoveTime - MaxDivisor;
        }

    }

    public float getMaxMoveTime()
    {
        return MaxMoveTime ;
    }
}
