using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectSceneUI : MonoBehaviour
{
    public Button selectButton;
    public Button rightButton;
    public Button leftButton;
    public TMP_Text characterName;
    public Transform charactersTransform;

    private int characterCount;
    private int characterIndex = 0;
    
    void Start()
    {
        characterCount = charactersTransform.childCount;
        DeactivateCharacters();
        GameObject currentCharacter = charactersTransform.GetChild(characterIndex).gameObject;
        currentCharacter.SetActive(true);
        characterName.text = currentCharacter.name;

        rightButton.onClick.AddListener(OnClickRightButton);
        leftButton.onClick.AddListener(OnClickLeftButton);
        selectButton.onClick.AddListener(SelectButton);
    }

    private void DeactivateCharacters()
    {
        for (int i = 0; i < charactersTransform.childCount; i++)
        {
            charactersTransform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnClickRightButton()
    {
        charactersTransform.GetChild(characterIndex).gameObject.SetActive(false);

        if (characterIndex >= characterCount-1)
        {
            characterIndex = 0;
        }
        else
        {
            characterIndex++;
        }
        GameObject currentCharacter = charactersTransform.GetChild(characterIndex).gameObject;
        currentCharacter.SetActive(true);
        characterName.text = currentCharacter.name;
    }

    private void OnClickLeftButton()
    {
        charactersTransform.GetChild(characterIndex).gameObject.SetActive(false);

        if (characterIndex <= 0)
        {
            characterIndex = characterCount-1;
        }
        else
        {
            characterIndex--;
        }
        GameObject currentCharacter = charactersTransform.GetChild(characterIndex).gameObject;
        currentCharacter.SetActive(true);
        characterName.text = currentCharacter.name;
    }

    private void SelectButton()
    {
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
        SceneManager.LoadScene("GameScene");
    }
}
