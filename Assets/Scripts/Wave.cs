using System.Collections;
using System.Collections.Generic;
using ND_VariaBULLET;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private Timer disableTime;
    public int autoDisable;
    public GameObject wave;

    // Start is called before the first frame update
    void Start()
    {
        autoDisable = Mathf.Abs(autoDisable);
        disableTime = new Timer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (wave.activeSelf == false)
        {
            this.transform.gameObject.SetActive(true);
        }

        if (DisableCheck())
        {
            this.transform.gameObject.SetActive(false);
        }
    }

    private bool DisableCheck()
    {
        if (autoDisable <= 0)
        {
            return false;
        }

        disableTime.RunOnce(autoDisable);
        return disableTime.Flag;
    }
}
