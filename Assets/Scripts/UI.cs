using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    GameObject recordSlot;
    GameObject scoreSlot;
    GameObject difficultyLevelSlot;
    Difficulty difficulty;
    SaveLoad saveLoad;

    private void Start()
    {
        difficulty = FindObjectOfType<Difficulty>();
        saveLoad = FindObjectOfType<SaveLoad>();
        recordSlot = GameObject.Find("RecordSlot");
        difficultyLevelSlot = GameObject.Find("DifficultyLevelSlot");
        scoreSlot = GameObject.Find("ScoreSlot");
        UpdateUI();
    }
    public void UpdateUI()
    {
        if (recordSlot != null)
        {
            TextMeshProUGUI recordSlotTemp = recordSlot.GetComponent<TextMeshProUGUI>();
            recordSlotTemp.text = saveLoad.scoreSaveData.ToString();
        }
        if(scoreSlot != null)
        {
            TextMeshProUGUI scoreSlotTemp = scoreSlot.GetComponent<TextMeshProUGUI>();
            scoreSlotTemp.text = difficulty.Score.ToString();

        }
        if(difficultyLevelSlot != null)
        {
            TextMeshProUGUI difficultyLevelSlotTemp = difficultyLevelSlot.GetComponent<TextMeshProUGUI>();
            difficultyLevelSlotTemp.text = difficulty.difficultyLevel.ToString();
        }
    }
}
