using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform cube;
    [SerializeField] private float rotationSpeed;

    private float rotationParametr;
    private float maxRotationSpeed;
    private int health = 3;

    private void Start()
    {
        maxRotationSpeed = rotationSpeed;
    }

    private void Update()
    {
        rotationParametr += rotationSpeed * Time.deltaTime;
        cube.rotation = Quaternion.Euler(rotationParametr * 2, rotationParametr * 3, rotationParametr);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
            OnBlockHit();
    }

    private void OnBlockHit()
    {
        StartCoroutine(RotationSlowDown());
    }

    IEnumerator RotationSlowDown()
    {
        health--;

        if (health > 0)
        {
            rotationSpeed = maxRotationSpeed * 20;
            while (rotationSpeed > maxRotationSpeed)
            {
                yield return new WaitForSeconds(0.1f);
                rotationSpeed -= maxRotationSpeed * 2;
            }
            rotationSpeed = maxRotationSpeed;
        }
        else
            rotationSpeed = maxRotationSpeed * 0.5f;
        
    }
}
