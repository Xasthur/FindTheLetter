using System;
using TMPro;
using UnityEngine;

public class scoreDisplay : MonoBehaviour
{
    public void updateScore(int score)
    {
        GetComponent<TMP_Text>().text = "x" + score;
    }
}
