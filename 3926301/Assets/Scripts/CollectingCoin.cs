using UnityEngine;
using UnityEngine.UI;

public class CollectingCoin : MonoBehaviour
{
    public int coins = 0;
    public GameObject scoreText;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins = coins + 1;
            scoreText.GetComponent<Text>().text = "Score: " + coins;
            Destroy(other.gameObject);
        }
    }


}
