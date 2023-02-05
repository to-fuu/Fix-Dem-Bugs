using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using DG.Tweening;

public class Terminal : MonoBehaviour
{

    //HIGH QUALITY CODE UP AHEAD
    public static Terminal instance;

    public static bool started, paused;

    public TextMeshProUGUI terminal;
    string terminalCode;

    //public GameObject playerSpawnEffect;
    public GameObject player;
    public Image avatar;

    public Sprite normal, anxious, angry;

    public GameObject three, two, one;
    public AudioSource gooooo;

    public CanvasGroup HP;

    public CanvasGroup topLeft;
    public TextMeshProUGUI top;
    public TextMeshProUGUI topRight;

    public GameObject pauseScreen;

    private void Awake()
    {
        instance = this;
        started = false;
        paused = false;
    }

    void OnEnable()
    {
        StartCoroutine(RunTerminal());
        started = true;
    }

    public IEnumerator WaveCleared()
    {
        print("Next wave");
        CPU.instance.waveStarted = false;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            terminalCode = "Threat eliminated!! Proceeding with tests";
            terminal.text = terminalCode;
            yield return new WaitForSeconds(1);
            terminalCode += "\n<color=green>test successful</color>";
            terminal.text = terminalCode;
            yield return new WaitForSeconds(0.5f);
            terminalCode += "\n<color=green>test successful</color>";
            terminal.text = terminalCode;
            yield return new WaitForSeconds(0.5f);
            terminalCode += "\n<color=green>test successful</color>";
            terminal.text = terminalCode;
            yield return new WaitForSeconds(2.5f);
            terminalCode += "\n<color=yellow>Warning! New threat detected</color>";
            terminal.text = terminalCode;
            break;
        }
        WavesSpawner.instance.SpawnWave();
        CPU.instance.waveStarted = true;
    }

    IEnumerator RunTerminal()
    {
        while (true)
        {
            terminalCode = "Launching unit tests......";

            terminal.text = terminalCode;

            yield return new WaitForSeconds(1);
            terminalCode += "\n<color=green>test successful</color>";
            terminal.text = terminalCode;


            yield return new WaitForSeconds(0.5f);
            terminalCode += "\n<color=green>test successful</color>";
            terminal.text = terminalCode;
            yield return new WaitForSeconds(0.5f);
            terminalCode += "\n<color=green>test successful</color>";
            terminal.text = terminalCode;

            yield return new WaitForSeconds(1.5f);
            terminalCode += "\n<color=yellow>Warning! Enganging battle mode</color>";
            terminal.text = terminalCode;
            yield return new WaitForSeconds(0.5f);

            three.SetActive(true);
            gooooo.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            two.SetActive(true);
            yield return new WaitForSeconds(1f);
            one.SetActive(true);
            yield return new WaitForSeconds(1f);


            var p = Instantiate(player);
            p.transform.position = new Vector3(-8.94999981f, 0.400000006f, -2.5999999f);
            p.transform.rotation = Quaternion.Euler(0, 40, 0);
            CPU.instance.waveStarted = true;
            WavesSpawner.instance.SpawnWave();
            CPU.instance.startTIme = Time.time;

            topLeft.transform.DOScale(1, 1);
            topLeft.DOFade(1, 1);
            top.DOFade(1, 1);


            DOTween.To(() => HP.alpha, x => HP.alpha = x, 1, 0.75f);
            HP.GetComponent<RectTransform>().DOScale(1, 0.75f);
            HP.GetComponent<RectTransform>().DOAnchorPosY(87, 0.75f);


            break;
        }
    }
    private void Update()
    {
        if (Spaceship.lives <= 0 && CPU.health <= 0)
        {
            terminalCode = "<color=red>System compromised!! App failed</color>";
            terminal.text = terminalCode;

        }

        if (Input.GetKeyDown(KeyCode.Escape) && started && !CPU.gameended)
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
            else
            {
                paused = true;
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
        }


    }

}
