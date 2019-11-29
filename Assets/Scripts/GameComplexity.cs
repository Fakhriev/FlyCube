using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameComplexity : MonoBehaviour
{
    [SerializeField] private GameObject[] blocksPack = new GameObject[0];
    [SerializeField] private TextMeshProUGUI scoreTMP;

    private int complexityLevel = 1;
    private float playerScore;

    private void Update()
    {
        if (complexityLevel == 4)
            return;

        playerScore = System.Convert.ToInt32(scoreTMP.text);
        if (playerScore < 2500 * complexityLevel)
            return;
        
        ComplexityLevelIncrease();
    }

    private void ComplexityLevelIncrease()
    {
        blocksPack[complexityLevel - 1].SetActive(true);
        complexityLevel++;
    }
}
