using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 1f;

   public void GameOver()
    {
        if (gameEnded == false)
        {

            gameEnded = true;
            Debug.Log("game over");
            Invoke("restart", restartDelay);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
