using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadMaster : MonoBehaviour
{
    private SaveLoad saveLoad;

    private void Start()
    {
        saveLoad = FindObjectOfType<SaveLoad>();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void ToGame()
    {
        var transit = FindObjectOfType<Difficulty>();
        if(transit != null) Destroy(transit);
        SceneManager.LoadScene("Game");
    }
    public void ToMainMenu()
    {
        var transit = FindObjectOfType<Difficulty>();
        if (transit != null) Destroy(transit);
        SceneManager.LoadScene("Menu");
    }
    public void ToResult()
    {
        saveLoad.SaveGameResults();
        SceneManager.LoadScene("GameOver");
    }
}
