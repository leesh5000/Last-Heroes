using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    string _itemName;
    ItemStat _itemStat;

    public ItemStat ItemStat { get { return _itemStat; } }

    // Start is called before the first frame update
    void Start()
    {
        _itemStat = Util.GetOrAddComponent<ItemStat>(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
