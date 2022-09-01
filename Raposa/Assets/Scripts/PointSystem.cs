using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public int Points {get;private set;} = 0;
    public Text TextPoints;
    private void Start()
    {
        Points = 0;
        if(TextPoints == null) TextPoints = GameObject.FindWithTag("PointTextLocation").GetComponent<Text>();
        UpdateText();
    }
    public void AddPoints(int amount)
    {
        Points += amount;
        UpdateText();
    }
    public void RemovePoints(int amount)
    {
        Points -= amount;
        UpdateText();
    }
    private void UpdateText()
    {
        TextPoints.text = "Points: " + Points.ToString();
    }
}
