using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public int scoreSaveData;
    public int difficultyLevelSaveData;
    private void Awake()
    {
        LoadGameResults();
    }
    private bool ItIsNewRecord()
    {
        var difficulty = FindObjectOfType<Difficulty>();
        if (difficulty.Score > scoreSaveData)
        {
            scoreSaveData = difficulty.Score;
            return true;
        }
        else return false;
    }
    public void SaveGameResults()
    {
        if (ItIsNewRecord())
        {
            PlayerPrefs.SetInt("Score", scoreSaveData);
        }
    }
    void LoadGameResults()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            scoreSaveData = PlayerPrefs.GetInt("Score");
        }
        else
        {
            scoreSaveData = 0;
        }
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
