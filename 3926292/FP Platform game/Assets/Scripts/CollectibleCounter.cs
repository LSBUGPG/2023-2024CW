using UnityEngine;
using TMPro;

public class CollectibleCounter : MonoBehaviour
{
    public static CollectibleCounter instance;

    public TMP_Text coinText;
    public TMP_Text flowerText;

    public int currentCoins = 0;
    public int currentFlowers = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coinText.text = "Coins: " + currentCoins.ToString();
        flowerText.text = "Flowers: " + currentFlowers.ToString();
    }

    void Update()
    {
        
    } 

    public void IncreaseFlowers(int v)
    { 
        currentFlowers += v;
        flowerText.text = "Flowers: " + currentFlowers.ToString();
    } 
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "Coins: " + currentCoins.ToString();
    }
}
