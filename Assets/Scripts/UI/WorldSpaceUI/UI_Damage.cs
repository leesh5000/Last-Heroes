using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Damage : UI_Base
{
    Text damageText;

    float textSpeed = 2.0f;
    float alphaSpeed = 2.0f;

    Color newColor;

    public bool Pooling { get; set; }

    public override void Init()
    {
        damageText = GetComponent<Text>();

        newColor = damageText.color;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, textSpeed * Time.deltaTime, 0));
        transform.rotation = Camera.main.transform.rotation;

        newColor.a = Mathf.Lerp(newColor.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
        damageText.color = newColor;

        if (damageText.color.a <= 0.1f)
        {
            newColor.a = 1.0f;
            damageText.color = newColor;

            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            Managers.Resource.Destroy(gameObject);
        }
    }
}
