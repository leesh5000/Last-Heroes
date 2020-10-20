using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Building
{
    List<Collider> colliders = new List<Collider>();

    public override void Init()
    {
        if (Managers.Game.Shop == null)
            Managers.Game.Shop = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        colliders.Add(other);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player") && !Util.IsValid(Managers.UI.UI_ShopDialog))
            {
                if (Util.IsValid(Managers.UI.UI_Worldmap))
                {
                    Managers.UI.UI_Worldmap.GetComponent<UI_Worldmap>().ClosePopupUI();
                }

                Managers.UI.UI_ShopDialog = Managers.UI.OpenPopupUI<UI_ShopDialog>().gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                colliders.Clear(); 
                break;
            }
        }

        if (Util.IsValid(Managers.UI.UI_ShopDialog))
            Managers.UI.CloseAllPopupUI();
    }
}
