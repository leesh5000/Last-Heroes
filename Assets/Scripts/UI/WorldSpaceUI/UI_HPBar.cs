using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : UI_Base
{
    enum GameObjects
    {
        HPBar,
    }

    CreatureStat _stat;
    float _targetHeight;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        _stat = transform.parent.GetComponent<CreatureStat>();
        _targetHeight = (transform.parent.gameObject.GetComponentInChildren<Collider>().bounds.size.y);
    }

    private void Update()
    {
        Transform parent = transform.parent;

        transform.position = parent.position + Vector3.up * _targetHeight;
        transform.rotation = Camera.main.transform.rotation;

        if (_stat != null)
        {
            float ratio = _stat.Hp / (float)_stat.MaxHp;
            SetHpRatio(ratio);
        }
    }

    public void SetHpRatio(float ratio)
    {
        Get<GameObject>((int)GameObjects.HPBar).GetComponent<Slider>().value = ratio;
    }


}
