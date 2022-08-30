using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public static int Points {get;private set;} = 0;
    private static Text textPoints;
    private void Start()
    {
        Points = 0;
        textPoints = GameObject.FindWithTag("PointTextLocation").GetComponent<Text>();
        UpdateText();
    }
    public static void AddPoints(int amount)
    {
        Points += amount;
        UpdateText();
    }
    public static void RemovePoints(int amount)
    {
        Points -= amount;
        UpdateText();
    }
    private static void UpdateText()
    {
        textPoints.text = "Points: " + Points.ToString();
    }
}
