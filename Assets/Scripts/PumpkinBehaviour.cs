using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinBehaviour : MonoBehaviour
{
    private SpriteRenderer sprend;
    private IEnumerator corUp;
    private IEnumerator corDown;

    // Start is called before the first frame update
    void Start()
    {
        sprend = this.transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (corDown != null)
            {
                StopCoroutine(corDown);
            }
            corUp = Fade(false);
            StartCoroutine(corUp);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (corUp != null)
            {
                StopCoroutine(corUp);
            }
            corDown = Fade(true);
            StartCoroutine(corDown);
        }
    }

    IEnumerator Fade(bool exit)
    {
        if (exit)
        {
            Vector4 col;
            while (sprend.color.a > 0.01f)
            {
                col = sprend.color;
                sprend.color = new Vector4(col.x, col.y, col.z, col.w - 0.2f);
                yield return new WaitForSeconds(0.01f);
            }
            col = sprend.color;
            sprend.color = new Vector4(col.x, col.y, col.z, 0);
        } else
        {
            Vector4 col;
            while (sprend.color.a < 0.99f)
            {
                col = sprend.color;
                sprend.color = new Vector4(col.x, col.y, col.z, col.w + 0.2f);
                yield return new WaitForSeconds(0.01f);
            }
            col = sprend.color;
            sprend.color = new Vector4(col.x, col.y, col.z, 1);
        }
    }
}
