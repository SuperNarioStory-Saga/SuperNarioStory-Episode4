using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehaviour : MonoBehaviour
{
    public AudioClip thunder;
    private AudioSource audsrc;
    private Light lig;

    // Start is called before the first frame update
    void Start()
    {
        lig = transform.GetComponent<Light>();
        StartCoroutine(Lightning());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Lightning()
    {
        while (true)
        {
            int time = Random.Range(10, 75);
            yield return new WaitForSeconds(time);
            //play thunder noise
            lig.intensity = 0.89f;
            yield return new WaitForSeconds(0.1f);
            lig.intensity = 0.5f;
            yield return new WaitForSeconds(0.2f);
            lig.intensity = 0.89f;
            while (lig.intensity < 0.5f)
            {
                lig.intensity = lig.intensity - 0.02f;
                yield return new WaitForSeconds(0.2f);
            }
            lig.intensity = 0.2f;
        }
    }
}
