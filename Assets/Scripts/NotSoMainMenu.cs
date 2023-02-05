using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.Events;

public class NotSoMainMenu : MonoBehaviour
{

    //HIGH QUALITY CODE UP AHEAD
    public Image topRight;
  
    public UnityEvent onStart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
          
            topRight.gameObject.SetActive(true);
            topRight.transform.DOScale(1, 1);
            topRight.DOFade(1, 1);

            onStart.Invoke();
          
            Destroy(gameObject);
        }
    }
}
