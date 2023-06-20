using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] DialogueManager dm;

    public void TriggerDialogue()
    {
        dm.StartDialogue(dialogue);
    }
}
