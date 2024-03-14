using UnityEngine;

//Made using Semag Games' Dialogue tutorial: https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA

[System.Serializable]
public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueAsset dialogueAsset;

    public string ResponseText => responseText;

    public DialogueAsset DialogueAsset => dialogueAsset;
}
