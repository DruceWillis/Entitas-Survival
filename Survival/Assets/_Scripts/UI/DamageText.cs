using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public TMP_Text _text;

    public void Initialize(int damage)
    {
        _text.text = damage.ToString();
        _text.enabled = true;

        float moveByX = Random.Range(-.2f, .2f);
        Vector3 newPos = transform.position + new Vector3(moveByX, 0.5f, 0);
        transform.DOMove(newPos, 0.35f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
