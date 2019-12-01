using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Material[] playerMat = new Material[0];
    [SerializeField] private Material[] torusMat = new Material[0]; //Текущий индекс умноженный на три, плюс либо ноль, либо один, либо два.

    [SerializeField] private Material[] blockMat = new Material[0];

    [SerializeField] private Material other;
    [SerializeField] private bool needToReset;

    private int index;

    private void Awake()
    {
        if (needToReset)
            ResetAll();

        if (!PlayerPrefs.HasKey("index"))
            PlayerPrefs.SetInt("index", 0);

        index = PlayerPrefs.GetInt("index");
    }

    public Material GetTheColor(int objectType)
    {
        if (objectType == 1)
            return playerMat[index];
        
        if (objectType == 2)
            return blockMat[index * 3 + Random.Range(0, 3)];
        

        if (objectType == 3)
            return torusMat[index];

        if (objectType == 4)
        {
            if (index == 4)
                return playerMat[0];

            return playerMat[index + 1];
        }

        return other;
    }

    private void ResetAll()
    {
        PlayerPrefs.SetFloat("CurrentLevel", 1);
        PlayerPrefs.SetFloat("Complexity", 1);
        PlayerPrefs.SetFloat("highscore", 0);
        PlayerPrefs.SetInt("index", 0);
    }
}
