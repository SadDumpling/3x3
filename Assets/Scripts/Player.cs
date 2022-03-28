using UnityEngine;

public class Player : Cell
{
    private GameOver gameOver;
    private UI ui;
    private Difficulty difficulty;
    private PlayerAnimation playerAnnimation;
    public int Health { get; private set; }
    private RectTransform rt;
    private void Start()
    {
        playerAnnimation = GetComponent<PlayerAnimation>();
        difficulty = FindObjectOfType<Difficulty>();
        gameOver = FindObjectOfType<GameOver>();
        Health = Value;
        ui = FindObjectOfType<UI>();
    }
    public void TryMove(Cell cell)
    {
        if(this.X + 1 == cell.X || this.X - 1 == cell.X || this.Y + 1 == cell.Y || this.Y -1 == cell.Y)
        {
            if (this.X != cell.X && this.Y != cell.Y) return;
            else
            {
                StartCoroutine(playerAnnimation.MoveAnnimated(cell));
                StartCoroutine(cell.GetComponent<CellAnimation>().CellDestroyAnimation());
                StartCoroutine(FindObjectOfType<Field>().CreateNewCellAfterMove(GetComponent<Player>(), cell));
            }
        }
    }
    public void EatCell(Cell eatenCell)
    {
        if(eatenCell is Heal) Health += eatenCell.Value;
        else if (eatenCell is Enemy) Health -= eatenCell.Value;
        if (Health <= 0) gameOver.Lose();
        difficulty.NewStep();
        points.text = Health.ToString();
        ui.UpdateUI();        
    }
}
