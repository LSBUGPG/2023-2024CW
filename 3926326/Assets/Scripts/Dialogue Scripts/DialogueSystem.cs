using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Made using Semag Games' Dialogue tutorial: https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject dialogueBox;

    public void ShowDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
        dialogueBox.SetActive(true);
    }

    public void EndDialogue()
    {
        dialogueText.text = null;
        dialogueBox.SetActive(false);
    }
}
