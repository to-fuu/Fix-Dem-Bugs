using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class TextExplode : MonoBehaviour
{


    TextMeshProUGUI tm => GetComponent<TextMeshProUGUI>();
    // Start is called before the first frame update
    void Start()
    {
        tm.DOFade(0, 0.25f).SetDelay(0.75f);
        tm.transform.DOScale(10, 0.25f).SetDelay(0.75f);
        Destroy(gameObject, 1);
    }
}
