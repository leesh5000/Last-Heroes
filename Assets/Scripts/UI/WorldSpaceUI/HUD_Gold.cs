using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Gold : UI_Base
{
    public TextMeshPro HUDText { get; set; }

    public float FloatingSpeed { get; set; } = 1.0f;
    public float AlphaSpeed { get; set; } = 1.0f;

    Color newColor;

    public bool Pooling { get; set; }

    public override void Init()
    {
        HUDText = GetComponent<TextMeshPro>();
        newColor = HUDText.color;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, FloatingSpeed * Time.deltaTime, 0));
        transform.rotation = Camera.main.transform.rotation;

        newColor.a = Mathf.Lerp(newColor.a, 0, Time.deltaTime * AlphaSpeed); // 텍스트 알파값
        HUDText.color = newColor;

        if (HUDText.color.a <= 0.1f)
        {
            newColor.a = 1.0f;
            HUDText.color = newColor;

            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            Managers.Resource.Destroy(gameObject);
        }
    }
}
