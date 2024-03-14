using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerItems playerItems; 
    [SerializeField] private TextMeshProUGUI coinText; 

    private void Update()
    {
        coinText.text = playerItems.coins.ToString() + " / 5"; 
    }
}
