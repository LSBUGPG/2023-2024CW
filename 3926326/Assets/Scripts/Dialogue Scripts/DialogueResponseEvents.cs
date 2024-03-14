
using UnityEngine;
using System;

//Made using Semag Games' Dialogue tutorial: https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA

public class DialogueResponseEvents : MonoBehaviour
{
    [SerializeField] private DialogueAsset dialogueAsset;
    [SerializeField] private ResponseEvent[] events;

    public DialogueAsset DialogueAsset => dialogueAsset;
    public ResponseEvent[] Events => events;

    public void OnValidate()
    {
        if (dialogueAsset == null) return;
        if (dialogueAsset.Responses == null) return;
        if (events != null && events.Length == dialogueAsset.Responses.Length) return;

        if (events == null)
        {
            events = new ResponseEvent[dialogueAsset.Responses.Length];
        }
        else
        {
            Array.Resize(ref events, dialogueAsset.Responses.Length);
        }

        for (int i = 0; i < dialogueAsset.Responses.Length; i++)
        {
            Response response = dialogueAsset.Responses[i];

            if (events[i] != null)
            {
                events[i].name = response.ResponseText;
                continue;
            }

            events[i] = new ResponseEvent() { name= response.ResponseText };
        }
    }
}
