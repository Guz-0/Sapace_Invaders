using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]private float projSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 target;

    private GameObject muzzle;
    private bool directionSet = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        muzzle = GameObject.Find("Muzzle");
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        Elimination();
    }

    void Movement()
    {
        if (!directionSet)
        {
            if (rb.position.y == muzzle.transform.position.y)
            {
                target = new Vector2(0, 1 * projSpeed);
            }
            else
            {
                target = new Vector2(0, -1 * projSpeed);
            }
            directionSet = true;
        }

        rb.velocity = target;
    }

    void Elimination()
    {
        if(rb.position.y >= 5.5f)
        {
            Destroy(gameObject);
        }
    }
}
