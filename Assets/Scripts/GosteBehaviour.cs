using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosteBehaviour : MonoBehaviour
{
    public Sprite calmGoste;
    public Sprite angryGoste;
    public float wanderingRadius = 1;

    private Vector3 initialPos;
    private bool attackPlayer;
    private bool wanderingPointReached;
    private Vector3 wanderingPoint;
    private Vector3 playerPoint;
    private SpriteRenderer sprend;
    // Start is called before the first frame update
    void Start()
    {
        sprend = transform.GetComponent<SpriteRenderer>();
        initialPos = transform.position;
        wanderingPointReached = true;
        attackPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackPlayer) // Player in range
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, playerPoint, Time.deltaTime * 2f);
            sprend.flipX = newPos.x < transform.position.x;
            transform.position = newPos;
        } else
        {
            if (wanderingPointReached)
            {
                float r = Random.value * wanderingRadius;
                float t = Random.value * 2 * Mathf.PI;
                float x = r * Mathf.Cos(t);
                float y = r * Mathf.Sin(t);
                wanderingPoint = new Vector3(initialPos.x + x, initialPos.y + y, initialPos.z);
                wanderingPointReached = false;
            }
            
            Vector3 newPos = Vector3.MoveTowards(transform.position, wanderingPoint, Time.deltaTime * 1.6f);
            sprend.flipX = newPos.x < transform.position.x;
            transform.position = newPos;
            
            wanderingPointReached = Vector3.Distance(wanderingPoint, transform.position) < 0.5f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attackPlayer = true;
            playerPoint = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attackPlayer = false;
        }
    }
}
