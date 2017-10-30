susing System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class point_indicator : MonoBehaviour {

    [SerializeField]
    private Text pointText_P1;

    [SerializeField]
    private Text pointText_P2;

    [SerializeField]
    private Text lifeText;

    [SerializeField]
    private Text roundPoint;

    void Awake()
    {
        if (pointText_P1 == null && pointText_P2 == null && lifeText == null && roundPoint == null)
        {
            Debug.LogError("no text object");
        }
    }

    public void setPoint_P1(int _cur)
    {
        pointText_P1.text = _cur.ToString();
    }

    public void setPoint(int _cur,string _s)
    {
        if(_s == "P1")
        {
            pointText_P1.text = _cur.ToString();
        }
        if(_s == "P2")
        {
            pointText_P2.text = _cur.ToString();
        }
        
    }

    public void setPoint_P2(int _cur)
    {
        pointText_P2.text = _cur.ToString();
    }

    public void setLife(int _cur)
    {
        lifeText.text = _cur.ToString();
    }

    public void setRound(int _cur)
    {
        roundPoint.text = _cur.ToString();
    }
}
