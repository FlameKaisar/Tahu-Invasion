using ND_VariaBULLET;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;

public class BossPattern : MonoBehaviour
{
    public GameObject Boss;

    public TMP_Text healthText;

    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;

    Renderer rend;
    Color c;
    [SerializeField] float invul = 1;

    [SerializeField] private float timebeforestart = 2;

    public float HpPhase1 = 25;
    public float HpPhase2 = 10;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        StartCoroutine("bossStart");
    }

    // Update is called once per frame
    void Update()
    {
        //timer();
        HpBoss();
    }

    void HpBoss()
    {
        ShotCollisionDamage boss = Boss.GetComponent<ShotCollisionDamage>();
        float HPBoss = boss.HP;
        if (HPBoss <= HpPhase1 && phase1 == true)
        {
            Debug.Log("Phase 2");
            phase1 = false;
            phase2 = true;
            Phase2();
        }

        if (HPBoss <= HpPhase2 && phase2 == true)
        {
            phase2 = false;
            phase3 = true;
            Phase3();
        }

    }

    void timer()
    {
        if (timebeforestart >= 0)
        {
            timebeforestart -= Time.deltaTime;
        }
        else
        {
            CustomPath path = GetComponent<CustomPath>();
            CustomPath1 path1 = GetComponent<CustomPath1>();
            path.enabled = false;
            path1.enabled = true;
        }
    }

    IEnumerator bossStart()
    {
        yield return new WaitForSeconds(timebeforestart);
        CustomPath path = GetComponent<CustomPath>();
        CustomPath1 path1 = GetComponent<CustomPath1>();
        path.enabled = false;
        path1.enabled = true;
        Debug.Log("Mulai lawan Boss");
    }

    void Phase2()
    {
        CustomPath1 path1 = GetComponent<CustomPath1>();
        CustomPath2 path2 = GetComponent<CustomPath2>();
        path1.enabled = false;
        path2.enabled = true;
        FullPresetSwitcher switcher = GetComponent<FullPresetSwitcher>();
        switcher.triggerSwitch = true;
        StartCoroutine("GetInvulnerable");
    }

    void Phase3()
    {
        CustomPath2 path2 = GetComponent<CustomPath2>();
        CustomPath3 path3 = GetComponent<CustomPath3>();
        path2.enabled = false;
        path3.enabled = true;
        FullPresetSwitcher switcher = GetComponent<FullPresetSwitcher>();
        switcher.triggerSwitch = true;
        StartCoroutine("GetInvulnerable");
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(invul);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        c.a = 1f;
        rend.material.color = c;
    }

}
