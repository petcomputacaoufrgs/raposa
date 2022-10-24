using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPoints : MonoBehaviour
{
    public float MaxPoints = 300f;
    public float Decay = 20f;
    public float PointsLost = 200f;
    public float ColorChangeSpeed = 1.5f;
    public Vector3 TimerPosition = new Vector3(0f, 0.3f, 0f);
    public Color TimerStartColor = Color.green;
    public Color TimerEndColor = Color.red;
    private float points;
    private PointSystem pointSystem;
    private GameObject displayTimer;
    private SpriteRenderer displayTimerSprite;
    private float originalScale;

    // Start is called before the first frame update
    void Start()
    {
        pointSystem = GameObject.FindWithTag("Player").GetComponent<PointSystem>();
        TimerPosition += transform.position;
        displayTimer = Instantiate(Resources.Load<GameObject>("Circle"), TimerPosition, new Quaternion(0f, 0f, 0f, 0f), transform);
        displayTimerSprite = displayTimer.GetComponent<SpriteRenderer>();
        points = MaxPoints;
        originalScale = displayTimer.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        MaxPoints -= Decay*Time.deltaTime; // Remove points
        float porcentage = MaxPoints/points; // Get the porcentage of points
        displayTimer.transform.localScale = new Vector3(porcentage*originalScale, porcentage*originalScale, 1f); // Scale the timer
        displayTimerSprite.color = Color.Lerp(TimerEndColor, TimerStartColor, Mathf.Pow(porcentage, ColorChangeSpeed)); // Change the color of the timer
        

        if (MaxPoints <= 0)
        {
            MaxPoints = -PointsLost; // Remove points
            Destroy(gameObject); // Destroy the client
            return; // Return to stop the rest of the code from running
        }
    }
    void OnDestroy()
    {
        if (pointSystem != null) 
        {
            pointSystem.AddPoints((int)MaxPoints); // Add points
        }
    }
}