using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private SceneLoadMaster slm;
    private float pause = 2.5f;
    [SerializeField] private GameObject LosePanel;

    public void Lose()
    {
        StartCoroutine(GameLoseCoroutine());
    }
    private IEnumerator GameLoseCoroutine()
    {
        slm = FindObjectOfType<SceneLoadMaster>();
        LosePanel.SetActive(true);
        yield return new WaitForSeconds(pause);
        slm.ToResult();
    }
}
