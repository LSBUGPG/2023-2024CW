using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made using Semag Games' Dialogue tutorial: https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA

[CreateAssetMenu]

public class DialogueAsset : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;

    public string[] Dialogue => dialogue;

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
}
