using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CellAnimation : MonoBehaviour
{
    private Sequence sequaence;
    public float appearTime = 0.25f;
    public bool readyToDie = false;
    public float eatTime = 0.45f;
    private void Start()
    {
        sequaence = DOTween.Sequence();
        this.transform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(ScaleAppearAnimation());
    }
    private IEnumerator ScaleAppearAnimation()
    {
        sequaence = DOTween.Sequence();
        yield return sequaence.Append(transform.DOScale(1, appearTime)).WaitForCompletion();
        readyToDie = true;
    }
    public IEnumerator CellDestroyAnimation()
    {
        sequaence = DOTween.Sequence();
        yield return sequaence.Append(transform.DOScale(0, eatTime)).WaitForCompletion();
    }
}
