using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : MonoBehaviour
{
    #region Public Members

    public Image[] m_indicators;
    public Transform m_transform;

    #endregion

    #region Public void

    #endregion

    #region System

    private void Awake()
    {
        m_transform = GetComponent<Transform>();

        GetIndicators();

        foreach(Image indicator in m_indicators)
        {
            indicator.fillAmount = 0;
        }
    }

    private void Update ()
    {
        	
    }

    #endregion

    #region Tools Debug and Utility

    private void GetIndicators()
    {
        m_indicators = Enumerable.Range(0, m_transform.childCount).Select(
            (n) => m_transform.GetChild(n).Find("Foreground").GetComponent<Image>()
       ).ToArray();

        // // Must use a List
        // m_children = new List<Transform>();
        //
        // foreach(Transform child in m_transform)
        //      m_children.Add(child);
    }

    #endregion

    #region Private and Protected Members

    #endregion
}
