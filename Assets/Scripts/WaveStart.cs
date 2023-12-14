using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    public static bool waveStart = false;
    public GameObject nextWave;
    public float timeBeforeNextWave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveStart == true)
        {
            if (timeBeforeNextWave > 0)
            {
                timeBeforeNextWave -= Time.deltaTime;
            }
            else
            {
                nextWave.SetActive(true);
            }
        }
    }
}
