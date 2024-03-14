using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Made using Semag Games' Dialogue tutorial: https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    public bool isOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueAsset dialogueAsset)
    {
        Debug.Log("Show Dialogue");
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueAsset));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueAsset dialogueAsset)
    {
        Debug.Log("Step Through Dialogue");
        for (int i = 0; i < dialogueAsset.Dialogue.Length; i++)
        {
            string dialogue = dialogueAsset.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueAsset.Dialogue.Length - 1 && dialogueAsset.HasResponses) break;
            {

            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueAsset.HasResponses)
        {
            responseHandler.ShowResponses(dialogueAsset.Responses);
        }
        else
        {
            CloseDialogueBox();
        }

        
    }

    public void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
