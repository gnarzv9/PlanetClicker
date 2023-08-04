using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    [SerializeField] private TMP_Text time;
    public int OverTime;

    public float TimeLimit
    {
        get { return timeLimit; }
    }

    private float gameStartTime;

    private void Start()
    {
        gameStartTime = Time.time;
    }

    public float GetElapsedTime()
    {
        return Time.time - gameStartTime;
    }

    public void TimeText()
    {
        OverTime = (int)(TimeLimit - GetElapsedTime());
        time.text = OverTime.ToString() + "s";
    }
}
