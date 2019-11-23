using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayerDamage playerDamage;

    [SerializeField] private TextMeshProUGUI currentLevelNum;
    [SerializeField] private TextMeshProUGUI nextLevelNum;
    [SerializeField] private RectTransform bar;
    
    [SerializeField] private GameObject[] newBlocks = new GameObject[0];
    [SerializeField] private GameObject finishObject;

    [SerializeField] private float minimalDistance;
    [SerializeField] private float multiplyDistance;

    private float currentLevel;

    private float finishDistance;
    private float leftDistance;
    private float xScale;

    private bool gameEnd;

    private void Start()
    {
        InitLevel();
    }

    private void Update()
    {
        if (gameEnd)
            return;

        leftDistance = finishDistance - player.transform.position.z;
        xScale = 1 - leftDistance / finishDistance;

        if(leftDistance <= 20 && !finishObject.activeInHierarchy)
        {
            SetTheFinish();
        }

        if (xScale >= 1)
        {
            xScale = 1;
            gameEnd = true;
            LevelComplete();
        }

        bar.localScale = new Vector3(xScale, 1, 1);
    }

    private void InitLevel()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
            PlayerPrefs.SetFloat("CurrentLevel", 1);

        currentLevel = PlayerPrefs.GetFloat("CurrentLevel");

        currentLevelNum.text = currentLevel.ToString();
        nextLevelNum.text = (currentLevel + 1).ToString();
        finishDistance = GetDistance();
    }
    
    private void SetTheFinish()
    {
        finishObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + leftDistance);
        finishObject.SetActive(true);
    }

    private float GetDistance()
    {
        return minimalDistance + multiplyDistance * currentLevel;
    }

    private void LevelComplete()
    {
        PlayerPrefs.SetFloat("CurrentLevel", currentLevel + 1);
        gameEnd = true;
        playerDamage.PlayerWin();
    }

    private void BlocksActive()
    {
        
        /*
        private int newBlocksLevel = 1;

        if (newBlocksLevel != 2 && score > 1000 * newBlocksLevel)
        BlocksActive();

        if (newBlocks[newBlocksLevel - 1] != null)
            newBlocks[newBlocksLevel - 1].SetActive(true);

        newBlocksLevel++; 
        */
    }
}
