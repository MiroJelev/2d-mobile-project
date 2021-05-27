
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay;

    public GameObject completeLevelUI;
    public GameObject endLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Invoke("Restart", restartDelay);
    }


    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            endLevelUI.SetActive(true);
            //Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
       
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
