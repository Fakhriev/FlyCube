using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private Material[] materialPack = new Material[0];
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject cube;

    [SerializeField] private float delta;
    
    private void Start()
    {
        BlockStart();
    }

    private void Update()
    {
        if (player.transform.position.z > transform.position.z + 5)
            BlockStart();
    }

    private void BlockStart()
    {
        cube.SetActive(false);
        transform.position = new Vector3(Random.Range(player.position.x - delta, player.position.x + delta), Random.Range(player.position.y - delta, player.position.y + delta), player.position.z + Random.Range(10, 25));
        meshRenderer.material = materialPack[Random.Range(0, 3)];
        cube.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            BlockStart();
    }

}
