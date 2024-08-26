using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playermagiccirclefp = GameObject.FindWithTag("MagicCircleFp");
        this.transform.position = playermagiccirclefp.transform.position;
    }
}
