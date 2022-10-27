using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOrder : MonoBehaviour
{
    public float RangeToAppear = 1f;
    public int OrderInLayer = 4;
    public Vector3 positionOrder;
    public float InverseAmplitudeShake;
    public float VelocityShake;
    private float timerDisplay = 0f;
    private GameObject player;
    private GameObject father;
    private GameObject display;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        father = Instantiate(Resources.Load<GameObject>("Cafeteria/EmptyPrefab"), transform);
        display = Instantiate(Resources.Load<GameObject>("Cafeteria/EmptyPrefab"), father.transform);
        Instantiate(Resources.Load<GameObject>("Cafeteria/Background"), father.transform);

        father.transform.localPosition = positionOrder;

        SpriteRenderer displayRenderer = display.AddComponent<SpriteRenderer>();
        displayRenderer.sprite = GetComponent<PickUpable>().Needed;
        displayRenderer.sortingOrder = OrderInLayer;

    }

    void Update()
    {
        timerDisplay += Time.deltaTime * VelocityShake;
        father.transform.localPosition = new Vector3(positionOrder.x, positionOrder.y + Mathf.Sin(timerDisplay) / InverseAmplitudeShake, positionOrder.z);

        if (CheckIfInRange())
        {
            father.SetActive(true);
        }
        else
        {
            father.SetActive(false);
        }
    }

    private bool CheckIfInRange()
    {
        Vector3 distanceObject = transform.position - player.transform.position;

        if (distanceObject.magnitude > RangeToAppear)
        {
            return false;
        }

        return true;
    }
}