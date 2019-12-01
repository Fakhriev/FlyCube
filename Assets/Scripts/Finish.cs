using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private ColorManager colorManager;

    private void Start()
    {
        sprite.color =  colorManager.GetTheColor(4).color;
    }
}
