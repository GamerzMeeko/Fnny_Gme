using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class TagsScripts : MonoBehaviour
{
    public Color WantedColor = new Color(0.6627451f,0.1098039f,0.1098039f,1f);
    public Color BaseColor;
    public Color HighLightColor;
    public Button button;
    public GameObject Boss;
    public bool EAU_Tag;
    public GameObject display;
    public GameObject image;
    public void Start()
    {

    }
    public void EneATKUP20()
    {
        BossStats bossstats = Boss.GetComponent<BossStats>();
        if (EAU_Tag == false)
        {
            EAU_Tag = true;
            bossstats.CurrentATK = bossstats.CurrentATK * 1.2f;
            ColorBlock cb = button.colors;
            cb.normalColor = WantedColor;
            cb.selectedColor = WantedColor;
            cb.highlightedColor = WantedColor;
            button.colors = cb;
            display.gameObject.SetActive(true);
            image.gameObject.SetActive(true);
        }
        else if (EAU_Tag == true)
        {
            EAU_Tag = false;
            bossstats.CurrentATK = Mathf.Round(bossstats.CurrentATK / 1.2f);
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
