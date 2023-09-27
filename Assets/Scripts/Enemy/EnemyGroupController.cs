using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupController : MonoBehaviour
{
    private Vector2 currentPosition;
    [SerializeField] private float offset = -0.5f;
    private float maxMoveTime;
    [SerializeField] private float maxDivisor;
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;

    private Animator animator;
    [SerializeField] private float maxTimeAnimation;
    
    private float moveTime = 0f;

    private void Awake()
    {
        GameManager.Instance.addNumberOfRounds();
        currentPosition = transform.position;
        maxMoveTime = GameManager.Instance.getMaxMoveTime();
        Debug.Log(GameManager.Instance.numberOfRounds + " - " + maxMoveTime.ToString());

    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        Debug.Log("disabled ANIMATOR");
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        
        moveTime += Time.deltaTime;
        if(moveTime >= maxMoveTime)
        {
            if (currentPosition.x <= leftBorder || currentPosition.x >= rightBorder)
            {

                transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                offset = offset * -1;

                if (maxMoveTime >= 0.3f)
                {
                    maxMoveTime = maxMoveTime - maxDivisor;
                }

                //Debug.Log("HIT WALL: " + maxMoveTime);
            }

            transform.position = new Vector2(currentPosition.x + offset, transform.position.y);
            currentPosition = transform.position;

            moveTime = 0;
            //Debug.Log("MOVED");
        }

        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }

    }

}
