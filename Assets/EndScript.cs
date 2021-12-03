using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public Sprite end1;
    public Sprite end2;
    public Sprite end3;

    private SpriteRenderer pumpkinRend;
    private SpriteRenderer endRend;
    private Text pumpkinText;
    private Text endText;
    void Start()
    {
        pumpkinRend = transform.GetChild(2).GetChild(0).GetComponent<SpriteRenderer>();
        endRend = transform.GetChild(2).GetChild(1).GetComponent<SpriteRenderer>();

        pumpkinText = transform.GetChild(2).GetChild(2).GetComponent<Text>();
        endText = transform.GetChild(2).GetChild(3).GetComponent<Text>();

        pumpkinRend.flipY = !GlobalScript.pumpkinOwned;
        pumpkinText.text = GlobalScript.pumpkinOwned ? "Tu as trouvé la citrouille maléfique !" : "Tu n'as pas trouvé la citrouille maléfique.";
        switch (GlobalScript.choice)
        {
            case 1:
                endText.text = "Tu as puni Vario";
                endRend.sprite = end1;
                break;
            case 2:
                endText.text = "Tu as pronké les fungis !";
                endRend.sprite = end2;
                break;
            case 3:
                endText.text = "Vous vous êtes fait gronder par maman !";
                endRend.sprite = end3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
