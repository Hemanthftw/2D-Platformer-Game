using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button ButtonRestart;

    private void Awake()
    {
        //ButtonRestart.onClick.AddListener(ReloadLevel);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        Debug.Log("Reloading Scene.....");
        // SceneManager.LoadScene(1);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
