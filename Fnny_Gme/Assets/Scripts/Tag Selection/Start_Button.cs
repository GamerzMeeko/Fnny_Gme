using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Button : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Player;
    public float BossATK;
    public float BossDEF;
    public float BossMaxHP;
    public float PlayerMaxHP;
    public float PlayerATK;
    public float PlayerDEF;
    public void Start()
    {
        BossStats bossstats = Boss.GetComponent<BossStats>();
        bossstats.CurrentATK = BossATK;
        bossstats.CurrentDEF = BossDEF;
        bossstats.CurrentMaxHP = BossMaxHP;

        PlayerHP playerHP = Player.GetComponent<PlayerHP>();
        playerHP.MaxHP = PlayerMaxHP;
        playerHP.DEF = PlayerDEF;
        playerHP.ATK = PlayerATK;
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
