using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyDEFDOWN20 : MonoBehaviour
{
    public Color WantedColor;
    public Color BaseColor;
    public Color HighLightColor;
    public Button button;
    public GameObject Player;
    public bool FDD_Tag;
    public GameObject display;
    public GameObject image;
    public void Start()
    {

    }
    public void FRDEFDWN20()
    {
        PlayerHP playerHP = Player.GetComponent<PlayerHP>();
        if (FDD_Tag == false)
        {
            FDD_Tag = true;
            playerHP.DEF = playerHP.DEF * 0.8f;



            ColorBlock cb = button.colors;
            cb.normalColor = WantedColor;
            cb.selectedColor = WantedColor;
            cb.highlightedColor = WantedColor;
            button.colors = cb;
            display.gameObject.SetActive(true);
            image.gameObject.SetActive(true);
        }
        else if (FDD_Tag == true)
        {
            FDD_Tag = false;
            playerHP.DEF = Mathf.Round(playerHP.DEF / 0.8f);



            ColorBlock cb = button.colors;
            cb.normalColor = BaseColor;
            cb.selectedColor = BaseColor;
            cb.highlightedColor = HighLightColor;
            button.colors = cb;
            display.gameObject.SetActive(false);
            image.gameObject.SetActive(false);
        }
    }
}
