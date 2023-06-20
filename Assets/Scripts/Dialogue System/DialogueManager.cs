using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Queue<string> setences;
    [SerializeField] public float writeSpeed;
    [SerializeField] TextMeshProUGUI dialogueName;
    [SerializeField] TextMeshProUGUI dialogueText;

    [SerializeField] Animator anima;

    void Start()
    {
        setences = new Queue<string>();
    }

    public void StartDialogue(Dialogue _dialogue)
    {
        anima.SetBool("animate", true);
        dialogueName.text = _dialogue.name;

        setences.Clear();

        foreach(string sentence in _dialogue.sentences)
        {
            setences.Enqueue(sentence);
        }

        DiaplayNextSentence();
    }

    public void DiaplayNextSentence()
    {
        if(setences.Count == 0)
        {
            anima.SetBool("animate", false);
            return;
        }

        string sentence = setences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string _sentence)
    {
        dialogueText.text = "";
        foreach(char letter in _sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(writeSpeed);
        }
    }
}
