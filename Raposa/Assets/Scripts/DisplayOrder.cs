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
    public float AlfaTransitionSpeed = 1f;
    public bool Machine = false;

    private float timerDisplay = 0f;
    private GameObject player;
    private GameObject father;

    private GameObject display;
    private SpriteRenderer displayRenderer;
    private GameObject displayBackground;
    private SpriteRenderer displayBackgroundRenderer;

    private Color alfaTransitionColor;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        father = Instantiate(Resources.Load<GameObject>("Cafeteria/EmptyPrefab"), transform);
        display = Instantiate(Resources.Load<GameObject>("Cafeteria/EmptyPrefab"), father.transform);
        displayBackground = Machine ? Instantiate(Resources.Load<GameObject>("Cafeteria/MachineBackground"), father.transform) : Instantiate(Resources.Load<GameObject>("Cafeteria/Background"), father.transform);

        displayRenderer = display.AddComponent<SpriteRenderer>();
        displayRenderer.sprite = Machine ? GetComponent<PickUpable>().Output : GetComponent<PickUpable>().Needed;
        displayRenderer.sortingOrder = OrderInLayer;

        displayBackgroundRenderer = displayBackground.GetComponent<SpriteRenderer>();

        displayRenderer.color = new Color(1f, 1f, 1f, 0f);
        displayBackgroundRenderer.color = new Color(1f, 1f, 1f, 0f);

        alfaTransitionColor = new Color(0f, 0f, 0f, AlfaTransitionSpeed / 1000);

        father.transform.localPosition = positionOrder;
    }

    void Update()
    {
        timerDisplay += Time.deltaTime * VelocityShake;
        father.transform.localPosition = new Vector3(positionOrder.x, positionOrder.y + Mathf.Sin(timerDisplay) / InverseAmplitudeShake, positionOrder.z);

        if (CheckIfInRange())
        {
            if (displayRenderer.color.a < 1f)
            {
                displayRenderer.color += alfaTransitionColor;
                displayBackgroundRenderer.color += alfaTransitionColor;
            }
        }
        else
        {
            if (displayRenderer.color.a > 0f)
            {
                displayRenderer.color -= alfaTransitionColor;
                displayBackgroundRenderer.color -= alfaTransitionColor;
            }
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