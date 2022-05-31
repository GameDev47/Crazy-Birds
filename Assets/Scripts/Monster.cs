using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if (bird != false)

            Die();

    }

    private void Die()
    {
        StartCoroutine(DieAfterDelay());
    }

    private IEnumerator DieAfterDelay()
    {
        particleSystem.Play();
        yield return new WaitForSeconds(0.2f);
        
        gameObject.SetActive(false);

    }
}
