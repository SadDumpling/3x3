using TMPro;
using UnityEngine;

public abstract class Cell : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Value { get; private set; }
    [SerializeField] protected TextMeshProUGUI points;
     
    public void CreateCellValue(int x, int y, int value)
    {
        X = x;
        Y = y;
        Value = value;
        points.text = value.ToString();
    }
}
