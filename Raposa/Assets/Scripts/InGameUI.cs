using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public int NumDiamonds = 0;
    public Text textDiamonds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadDiamondsText()
    {
        NumDiamonds++;
        textDiamonds.text = NumDiamonds.ToString();
    }
}
