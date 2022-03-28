using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField] Cell enemyCell;
    [SerializeField] Cell healCell;
    public int Score { get; private set; }
    private float maxChanceToEnemyInPercent = 50;
    private float maxChanceToEnemyInFloat;
    private int difficultyDivisor = 10;
    private float enemySpawnChanceDivisor = 0.1f;
    public int difficultyLevel { get; private set; }
    void Awake()
    {
        DontDestroyOnLoad(this);
        Score = 0;
        difficultyLevel = 1;
        if (enemySpawnChanceDivisor == 0) enemySpawnChanceDivisor = 1;
        if (difficultyDivisor == 0) difficultyDivisor = 1;
        if (maxChanceToEnemyInPercent > 100) maxChanceToEnemyInPercent = 100;
        maxChanceToEnemyInFloat = maxChanceToEnemyInPercent / 100;
    }
    public int GetStep()
    {
        return Score;
    }
    public void NewStep()
    {
        Score++;
        difficultyLevel = (Score / difficultyDivisor) + 1;
    }
    public Cell CheckWhichCellToCreate()
    {
        float chance = difficultyLevel * enemySpawnChanceDivisor > maxChanceToEnemyInFloat ? maxChanceToEnemyInFloat : difficultyLevel * enemySpawnChanceDivisor;
        float rnd = Random.Range(0, 1f);
        if (chance > rnd) return enemyCell;
        else return healCell;
    }
    public int CellValue()
    {
        var rnd = Random.Range(0, difficultyLevel + 1) + 1;
        return rnd;
    }
}
