using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    private static int points = 0;
    private static Text textPoints;
    private void Start()
    {
        points = 0;
        textPoints = GameObject.FindWithTag("PointTextLocation").GetComponent<Text>();
        UpdateText();
    }
    public static void AddPoints(int amount)
    {
        points += amount;
        UpdateText();
    }
    public static void RemovePoints(int amount)
    {
        points -= amount;
        UpdateText();
    }
    public static int GetPoints()
    {
        return points;
    }
    private static void UpdateText()
    {
        textPoints.text = "Points: " + points.ToString();
    }
}
