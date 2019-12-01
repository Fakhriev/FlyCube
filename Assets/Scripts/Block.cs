using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ColorManager colorManager;

    [SerializeField] private Transform player;

    [SerializeField] private float delta;

    private void Start()
    {
        //StartCoroutine(GetTheColor());
        meshRenderer.material = colorManager.GetTheColor(2);
        BlockStart();
    }

    private void Update()
    {
        if (player.transform.position.z > transform.position.z + 5)
            BlockStart();
    }

    private void BlockStart()
    {
        transform.position = new Vector3(Random.Range(player.position.x - delta, player.position.x + delta), Random.Range(player.position.y - delta, player.position.y + delta), player.position.z + Random.Range(10, 25));
        transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
    }

    IEnumerator GetTheColor()
    {
        yield return new WaitForEndOfFrame();
        meshRenderer.material = colorManager.GetTheColor(2);
    }

}
