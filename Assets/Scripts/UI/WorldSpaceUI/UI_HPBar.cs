﻿using System.Collections;
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

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        //_stat = transform.parent.GetComponent<Stat>();
    }

    private void Update()
    {
        Transform parent = transform.parent;

        transform.position = parent.position + Vector3.up * (parent.gameObject.GetComponentInChildren<Collider>().bounds.size.y);
        transform.rotation = Camera.main.transform.rotation;

        _stat = transform.parent.GetComponent<CreatureStat>();
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
