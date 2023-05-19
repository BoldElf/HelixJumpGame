using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScores : BallEvents
{
    [SerializeField] private ScoresCollector scoresCollector;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text recordScore;

    private int value;

    private void Start()
    {
        Load();
    }
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if(type != SegmentType.Trap)
        {
            scoreText.text = scoresCollector.Scores.ToString();

           
        }

        if(type == SegmentType.Finish)
        {
            if(scoresCollector.Scores > value)
            {
                value = scoresCollector.Scores;
                recordScore.text = ("Рекорд: " + scoresCollector.Scores.ToString());
                Save();
            }
        }
    }

    private void Save()
    {
        PlayerPrefs.SetString("Record", recordScore.text);
        PlayerPrefs.SetInt("Cnt", value);
    }

    private void Load()
    {
        recordScore.text = PlayerPrefs.GetString("Record","Рекорд: 0");
        value = PlayerPrefs.GetInt("Cnt", 0);
    }

}
