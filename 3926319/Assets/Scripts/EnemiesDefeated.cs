using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemiesDefeated : MonoBehaviour
{
    public TextMeshProUGUI enemiesDefeatedTxt;
    public GameObject[] enemies;
    public float enemyNum;
    public string finalLevel;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesDefeated enemiesDefeated = FindFirstObjectByType<EnemiesDefeated>();
        if (enemiesDefeated != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        EnemiesDefeatedFunc();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (enemyNum == 0 && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(finalLevel) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Game Over") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("You Win") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Main Menu"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        enemiesDefeatedTxt.text = enemyNum.ToString();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(finalLevel) && enemyNum == 0)
        {
            SceneManager.LoadScene("You Win");
        }
    }
    void EnemiesDefeatedFunc()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Game Over") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("You Win") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Main Menu"))
        {
            enemiesDefeatedTxt = FindAnyObjectByType<TextMeshProUGUI>();
        }

        foreach (var obj in enemies)
        {
            if (obj.tag == "Enemy")
            {
                enemyNum = enemies.Length;
                Debug.Log(enemyNum);
            }
        }
    }

    private void OnLevelWasLoaded()
    {
        EnemiesDefeatedFunc();
    }
}
