using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Color color;
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;
    public bool isFromHallucination = false;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        color = this.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update () {
        if (isFromHallucination) {
            fadeIn();
        }
    }


    void fadeIn() {
        float t = (Time.time - startTime) / duration;
        this.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, Mathf.SmoothStep(minimum, maximum, t));
    }
}
