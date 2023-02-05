using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Bullet : MonoBehaviour
{

    //HIGH QUALITY CODE UP AHEAD

    CinemachineImpulseSource impulse;
    public float speed = 30;
    public GameObject destroyEffect;

    AudioSource src => GetComponent<AudioSource>();
    public AudioClip impact, explosion;

    void SpawnDestroyEffect()
    {
        if (destroyEffect)
            Instantiate(destroyEffect, transform.position, Quaternion.Euler(90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 4);
    }

    private void Start()
    {
        impulse = FindObjectOfType<CinemachineImpulseSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("wall"))
        {
            InvokeRepeating("SpawnDestroyEffect", 0, 0.1f);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(impact,Camera.main.transform.position,1);
            if (other.CompareTag("enemy"))
            {
                AudioSource.PlayClipAtPoint(explosion, Camera.main.transform.position, 1);
                CPU.score += 1000;
                impulse.GenerateImpulse(0.05f);
                Destroy(other.gameObject);
            }
         
        }
    }


}
