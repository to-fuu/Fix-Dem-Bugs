using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DefinitelyAGameoverScreen : MonoBehaviour
{

    //HIGH QUALITY CODE UP AHEAD
    public TextMeshProUGUI tm;

    private void OnEnable()
    {
        tm.text = tm.text.Replace("XXXXX", Object.FindObjectOfType<Timer>().GetComponent<TextMeshProUGUI>().text);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
