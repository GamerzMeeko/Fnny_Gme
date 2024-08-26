using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Congratsscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(beat_boss());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator beat_boss()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
