using System.Collections;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] Cell playerCell;
    private Difficulty difficulty;
    private RectTransform rectTransform;
    private Cell[,] cells;
    [SerializeField] private int fieldSize;
    private int playerSpawnX;
    private int playerSpawnY;
    private RectTransform panelRectTransform;
    public static bool readyToNextMove = true;
    private void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        difficulty = FindObjectOfType<Difficulty>();
        CreateField();
    }
    private void CreateField()
    {
        playerSpawnX = Random.Range(0, fieldSize);
        playerSpawnY = Random.Range(0, fieldSize);
        cells = new Cell[fieldSize, fieldSize];
        PlayerCellCreate(playerSpawnX, playerSpawnY, 1);
        cells[playerSpawnX, playerSpawnY].gameObject.AddComponent<CellAnimation>();
        for (int x = 0; x < fieldSize; x++)
        {
            for (int y = 0; y < fieldSize; y++)
            {
                if (x == playerSpawnX && y == playerSpawnY) continue;
                else CreateRandomCell(x, y);
            }
        }
    }
    public IEnumerator CreateNewCellAfterMove(Player playerFirstCell, Cell eatCell)
    {
        readyToNextMove = false;
        var playerMoveTime = playerFirstCell.GetComponent<PlayerAnimation>().moveTime;
        var cellEatenTime = eatCell.GetComponent<CellAnimation>().eatTime;
        var tempTime = playerMoveTime > cellEatenTime ? playerMoveTime : cellEatenTime;
        yield return new WaitForSeconds(tempTime);
        var tempPlayerCell = playerFirstCell;
        var tempEatCell = eatCell;
        Destroy(playerFirstCell.gameObject);
        Destroy(eatCell.gameObject);
        PlayerCellCreate(tempEatCell.X, tempEatCell.Y, tempPlayerCell.Health);
        CreateRandomCell(tempPlayerCell.X, tempPlayerCell.Y);
        readyToNextMove = true;
    }
    private Cell NewCell()
    {
        var cell = difficulty.CheckWhichCellToCreate();
        return cell;
    }
    private void PlayerCellCreate(int x, int y, int value)
    {
        CellInstatiate(x, y, playerCell);
        cells[x, y].CreateCellValue(x, y, value);
    }
    private void CreateRandomCell(int x, int y)
    {
        var newCell = NewCell();
        CellInstatiate(x, y, newCell);
    }
    private void CellInstatiate(int x, int y, Cell cell)
    {
        var instCell = Instantiate(cell, transform, false);
        var cellAnchor = instCell.GetComponent<RectTransform>();
        cellAnchor.anchorMin = new Vector2((float)x / (float)fieldSize + 0.09f / fieldSize, (float)y / (float)fieldSize + 0.09f / fieldSize);
        cellAnchor.anchorMax = new Vector2((float)x / (float)fieldSize + 1f / fieldSize, (float)y / (float)fieldSize + 1f / fieldSize);
        instCell.CreateCellValue(x, y, difficulty.CellValue());
        cells[x, y] = instCell;
    }
}
