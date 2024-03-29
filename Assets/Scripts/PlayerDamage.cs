﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private PlayerMobileControll playerMovement;
    [SerializeField] private PlayerCamera playerCamera;

    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private ColorManager colorManager;
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private Button replayButton;
    [SerializeField] private Button nextLvlButton;

    private int health = 3;

    private void Start()
    {
        meshRenderer.material = colorManager.GetTheColor(1);
        replayButton.onClick.AddListener(Replay);
        nextLvlButton.onClick.AddListener(Replay);
    }

    private void OnBlockHit()
    {
        health--;
        if (health == 0)
        {
            PlayerLoose();
        }
    }

    private void PlayerLoose()
    {
        meshRenderer.material = colorManager.GetTheColor(2);
        playerMovement.PlayerLoose();
        playerCamera.PlayerLoose();
        playerScore.PlayerLoose();
        replayButton.gameObject.SetActive(true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
            OnBlockHit();
    }

    private void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerWin()
    {
        playerMovement.PlayerLoose();
        playerCamera.PlayerLoose();
        playerScore.PlayerLoose();
        nextLvlButton.gameObject.SetActive(true);
    }
}
