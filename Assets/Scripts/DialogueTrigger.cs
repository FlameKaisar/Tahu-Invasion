using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool isTrigger = false;
    public float timer;
    public Dialogue dialogue;


    private void Update()
    {
        if (timer  > 0)
        {
            timer -= Time.deltaTime;
            
        }
        else
        {
            if (isTrigger == true)
            {
                TriggerDialogue();
                isTrigger = false;
            }
        }
    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
