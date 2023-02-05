using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using static Cinemachine.DocumentationSortingAttribute;

public class CPU : MonoBehaviour
{

    //HIGH QUALITY CODE UP AHEAD

    public static bool gameended;
    public static CPU instance;

    public static float health = 500;
    public bool infected;

    public float depletionRate = 10;

    public Image gaugeFill;
    public static int score;

    public TextMeshProUGUI scoreText;

    public bool waveCompleted;
    public bool waveStarted;

    public float startTIme;

    MeshRenderer mesh => GetComponent<MeshRenderer>();

    public GameObject gameoverScreen;


    public TextMeshProUGUI clearText;

    public GameObject life1, life2, life3;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = 500;
        score = 0;
        gameended = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Spaceship.lives == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (Spaceship.lives == 2)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(false);
        }
        else if (Spaceship.lives == 1)
        {
            life1.SetActive(true);
            life2.SetActive(false);
            life3.SetActive(false);
        }
        else if (Spaceship.lives == 0)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }


        scoreText.text = string.Format("{0:00000000}", score);

        var enemies = GameObject.FindGameObjectsWithTag("enemy");

        if (enemies.Length == 0 && !waveCompleted && waveStarted)
        {
            clearText.gameObject.SetActive(true);
            clearText.DOFade(1, 0);
            clearText.DOFade(1, 0).SetDelay(1.5f).OnComplete(() =>
            {
                clearText.text = "Next Wave";
            });


            clearText.DOFade(0, 1).SetDelay(2.0f).OnComplete(() =>
            {
                clearText.gameObject.SetActive(false);
            });


            waveCompleted = false;
            waveStarted = false;
            Terminal.instance.avatar.sprite = Terminal.instance.normal;
            Terminal.instance.StartCoroutine(Terminal.instance.WaveCleared());

        }
        else if (enemies.Length > 0)
        {
            if (health < 500)
            {
                Terminal.instance.avatar.sprite = Terminal.instance.angry;
            }
            else
            {
                Terminal.instance.avatar.sprite = Terminal.instance.anxious;
            }
        }

        infected = enemies.Length > 0;

        if (waveStarted)
        {
            if (infected)
            {
                health -= Time.deltaTime * depletionRate;
            }
            else
            {
                health += Time.deltaTime * depletionRate * 0.75f;
            }
        }


        mesh.materials[0].SetColor("_BaseColor", Color.Lerp(Color.red, new Color(0.78f, 0.5f, 0.2f), Mathf.Clamp01(health / 500)));

        health = Mathf.Clamp(health, 0, 1000);
        gaugeFill.fillAmount = health / 1000;
    }
}
