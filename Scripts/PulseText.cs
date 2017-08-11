using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PulseText : MonoBehaviour
{

    public bool useUnscaledTime;
    public float period;
    private float timer;

    private Text text;
    private Color startColor;
    private Vector2 startScale;

    // Use this for initialization
    void Start()
    {

        text = GetComponent<Text>();
        startColor = text.color;
        startScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

        timer -= useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;

        if (timer < 0) { timer = period; }

        float percentage = period == 0 ? 0 : timer / period;
        float pulse = (0.5f + 0.5f * Mathf.Sin(percentage * Mathf.PI * 2)) * 0.5f + 0.5f;

        text.color = startColor * new Color(1, 1, 1, pulse);
        transform.localScale = startScale * (pulse * 0.5f + 0.5f);

    }
}