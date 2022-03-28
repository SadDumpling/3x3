
using UnityEngine.UI;

public class ObjectCell : Cell
{
    private CellAnimation cellAnimation;
    void Start()
    {
        cellAnimation = GetComponent<CellAnimation>();
        var tempPos = transform.position;
        tempPos.z = 0;
        transform.position = tempPos;
    }
    public void ClickOnThisCell()
    {
        if(cellAnimation.readyToDie && Field.readyToNextMove)
        {
            var player = FindObjectOfType<Player>();
            player.TryMove(this);
        }
    }
}
