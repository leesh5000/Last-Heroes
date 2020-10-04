using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Building
{
    public override void Init()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Managers.UI.OpenPopupUI<UI_Dialog>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Managers.UI.ClosePopupUI();
        }
    }
}
