using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Sequence sequaence;
    public float moveTime = 0.5f;
    public IEnumerator MoveAnnimated(Cell eatenCell)
    {
        sequaence = DOTween.Sequence();
        yield return sequaence.Append(transform.DOMove(eatenCell.transform.position, moveTime)).WaitForCompletion();
        GetComponent<Player>().EatCell(eatenCell);
    }
}
