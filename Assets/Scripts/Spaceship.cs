using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]
public class Spaceship : MonoBehaviour
{

    //HIGH QUALITY CODE UP AHEAD

    Rigidbody rb2d => GetComponent<Rigidbody>();
    public SpriteRenderer sprite;

    public float speed = 20;

    public GameObject bullet;

    public Transform pointer;

    AudioSource src => GetComponent<AudioSource>();

    public static int lives = 3;

    Vector3 mouseHit;
    public LayerMask playgroundMask;



    Vector3 InputDir
    {
        get
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }
    }

    float H
    {
        get
        {
            return Input.GetAxis("Horizontal");
        }
    }



    private void Awake()
    {
        lives = 3;
        var vcam = Object.FindObjectOfType<CinemachineVirtualCamera>();
        if (vcam)
        {
            vcam.m_Follow = transform;
            vcam.m_LookAt = transform;
        }


    }

    private void Start()
    {
        StartCoroutine(SpawnBullets());
        mouseHit = transform.position + transform.forward;

    }

    void SpawnBullet()
    {
        if (bullet)
        {
            if (src)
            {
                src.Play();
            }
            var b = Instantiate(bullet);
            b.transform.position = transform.position + (mouseHit - transform.position).normalized;
            b.transform.position = new Vector3(b.transform.position.x, transform.position.y, b.transform.position.z);
            b.transform.forward = Vector3.ProjectOnPlane((mouseHit - transform.position), Vector3.up);

        }
    }


    IEnumerator SpawnBullets()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                SpawnBullet();
            }

            yield return new WaitForSeconds(0.05f);
        }
    }


    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, playgroundMask))
        {
            Transform objectHit = hit.transform;
            mouseHit = hit.point;
            pointer.position = transform.position + (hit.point - transform.position).normalized;
        }
    }

    void Update()
    {
        rb2d.velocity = Vector3.Lerp(rb2d.velocity, InputDir.normalized * speed, Time.deltaTime * 10);


        if (InputDir.magnitude > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rb2d.velocity.normalized, Vector3.up), Time.deltaTime * 30);

        if (CPU.health <= 0)
        {
            Die();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") )
        {
            lives--;


            if (lives >= 0)
            {
                var trail = GetComponent<TrailRenderer>();
                transform.position = new Vector3(-8.94999981f, 0.400000006f, -2.5999999f);
                transform.rotation = Quaternion.Euler(0, 40, 0);
                trail.Clear();
            }
            else
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
        CPU.instance.gameoverScreen.SetActive(true);
        Terminal.instance.topLeft.DOFade(0, 0.5f);
        Terminal.instance.top.DOFade(0, 0.5f);
        Terminal.instance.topRight.DOFade(0, 0.5f);
        CPU.gameended = true;
    }


}
