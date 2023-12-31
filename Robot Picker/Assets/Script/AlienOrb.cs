using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienOrb : MonoBehaviour
{
    public static float bottomY = -20f;

    public AudioSource audioSource;
    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Invoke("DisableSound", 3f);
    }
    private void DisableSound()
    {
        // ��������� ����� ����� ��������� �������
        audioSource.Stop();
    }

    void Update()
    {
       if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.AlienOrbDestroyed();
        }
    }
}
