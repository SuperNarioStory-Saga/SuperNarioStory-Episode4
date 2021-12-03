using System.Collections;
using UnityEngine;

public class PumpkinStartBehaviour : MonoBehaviour
{
    public Sprite pumpkin0;
    public Sprite pumpkin1;
    public Sprite pumpkin2;

    private SpriteRenderer sprend;

    // Start is called before the first frame update
    void Start()
    {
        sprend = transform.GetComponent<SpriteRenderer>();
        StartCoroutine(Flash());    
        StartCoroutine(Boing());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Flash()
    {
        while (true)
        {
            int randTime;
            randTime = Random.Range(3, 10);
            yield return new WaitForSeconds(randTime);
            Sprite sprite = Random.Range(0, 2) == 0 ? pumpkin1 : pumpkin2;
            sprend.sprite = sprite;
            yield return new WaitForSeconds(1);
            sprend.sprite = pumpkin0;
        }
    }

    IEnumerator Boing()
    {
        float i = 0;
        while (true)
        {
            if (this.transform.position.x > 11)
            {
                i = 0;
                this.transform.position = new Vector3(-11.5f, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x + 0.06f, Mathf.Abs(Mathf.Sin(i * 0.85f) * 1.3f) - 3f, this.transform.position.z);
                i += 0.06f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
