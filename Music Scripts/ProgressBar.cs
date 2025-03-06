using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // public float FillSpeed = 0.5f;
    public static ProgressBar instance;
    
    private Slider slider;
    //private float targetProgress = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncrementProgress(float newProgress)
    {
        slider.value = newProgress;
    }
}
