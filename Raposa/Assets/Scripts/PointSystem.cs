using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public int Points {get;private set;} = 0;
    public Text TextPoints;
    public Text TextAdd;
    private float counttime = 3f;

    private void Start()
    {
        Points = 0;
        if(TextPoints == null) {
            TextPoints = GameObject.FindWithTag("PointTextLocation").GetComponent<Text>();
            TextAdd = GameObject.FindWithTag("PointAddLocation").GetComponent<Text>();
        }
        
        UpdateText();
    }
    public void AddPoints(int amount)
    {
        Points += amount;
        TextAdd.text = amount>=0 ? "+" + amount.ToString() : amount.ToString();
        UpdateText();
    
    }
    public void RemovePoints(int amount)
    {
        Points -= amount;
        TextAdd.text = "-" + amount.ToString();
        UpdateText();
    }
    private void UpdateText()
    {
        if(TextPoints != null) TextPoints.text = "Points: " + Points.ToString();
       
    }

    void Update(){
        counttime-=Time.deltaTime;
        TextAdd.color=new Color (1,1,1,counttime);
        if(counttime<=0){
            TextAdd.text = "";
            counttime=3f;
        }
    }
}
