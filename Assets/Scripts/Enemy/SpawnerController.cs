using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField] private GameObject enemyGroup;
    private bool done = false;
    private bool startedCourotine = false;

    [SerializeField] private TMP_Text timerText;
    private int timer = 1;

    private void Awake()
    {
        timerText.enabled = false;
    }
    void Start()
    {

    }


    void Update()
    {
        checkRound();
    }

    void checkRound()
    {
        if(this.transform.childCount == 0)
        {
            if (!startedCourotine)
            {
                StartCoroutine(startRound());
                startedCourotine = true;
            }

            if (done)
            {
                var enemy = Instantiate(enemyGroup, new Vector2(1f, 1f), transform.rotation);
                enemy.transform.parent = this.transform;
                done = false;
                startedCourotine = false;
            }
        }
    }

    IEnumerator startRound()
    {
        timerText.enabled = true;
        timer = 1;
        timerText.SetText(timer.ToString());
        yield return new WaitForSeconds(1f);

        timer += 1;
        timerText.SetText(timer.ToString());
        done = true;
        yield return new WaitForSeconds(1f);

        timer += 1;
        timerText.SetText(timer.ToString());
        yield return new WaitForSeconds(1f);

        timerText.SetText("GO!");
        yield return new WaitForSeconds(1f);

        timerText.enabled = false;

        yield return null;
    }
}
