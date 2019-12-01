using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ColorManager colorManager;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject cube;

    [SerializeField] private float delta;
    [SerializeField] private float spawnRange;

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
        transform.position = new Vector3(Random.Range(player.position.x - delta, player.position.x + delta), Random.Range(player.position.y - delta, player.position.y + delta), player.position.z + spawnRange);

        meshRenderer.material = colorManager.GetTheColor(3);
        cube.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            BlockStart();
    }
}
