using UnityEngine;
using UnityEngine.UI;
 

public class HP : MonoBehaviour
{
    public KnifePickup Knife;

    public Slider hpSlider; 
    public int maxHp = 3;
    public int currentHp;

    public Canvas gameOver;
    public Vector3 spawnPoint;
    
    void Start()
    {
        currentHp = maxHp;
        spawnPoint = gameObject.transform.position;
        gameOver.enabled = false;
    }
    void Update()
    { 
        if(hpSlider.value != currentHp)
        { hpSlider.value = currentHp; }
    }

    public void Damage(int damageAmount)
    {
        currentHp -= damageAmount;

        if (currentHp <= 0)
        {
                Knife.hasKnife = false;              
                gameOver.enabled = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
        }
    }

    public void Heal(int healAmount)
    {
        if (healAmount < 0)
            Debug.LogError("Heal amount should be positive");

        if (currentHp + healAmount > maxHp)
        {
            currentHp = maxHp;
        }
        else 
        { 
            currentHp += healAmount; 
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DHazard"))
        {
            Damage(currentHp);
        }

    }

    public void SetSpawnPoint(Vector3 newposition)
    {
        spawnPoint = newposition; 
    }

    public void Reset()
    {
        Knife = FindObjectOfType<KnifePickup>();
    }
}

