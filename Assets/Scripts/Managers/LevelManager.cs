using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform apple;
    public Transform exit;
    public void RestartLevelManager()
    {
        apple.gameObject.SetActive(true);

        apple.DOKill();
        apple.position = new Vector3(apple.position.x, .5f, apple.position.z);
        apple.DOMoveY(1f, 1f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);

        apple.rotation = Quaternion.identity;
        apple.DORotate(Vector3.up * 90, 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);

        exit.gameObject.SetActive(false);

        exit.position = new Vector3(-5.7f, .4f, UnityEngine.Random.Range(-2.8f,2.8f));
    }
}
