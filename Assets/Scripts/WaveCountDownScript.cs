using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCountDownScript : MonoBehaviour
{
    [SerializeField] private GameObject victoryscreen;

    public static WaveCountDownScript countdownScript;

    [SerializeField] private Text countTxt;

    private float testCount;

    private void Start()
    {
        countdownScript = this;
    }

    public void CountdownText(float count)
    {
        countTxt.text = count.ToString("F0");
        testCount = count;
    }

    private void Update()
    {
      if(testCount <= 0 )
        {
            countTxt.text = null;
        }
    }

    public void Victory()
    {
        victoryscreen.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
