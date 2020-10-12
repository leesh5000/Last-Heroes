using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    string _itemName;
    ItemStat _itemStat;
    Text _itemText;

    public ItemStat ItemStat { get { return _itemStat; } }

    // Start is called before the first frame update
    void Start()
    {
        _itemStat = Util.GetOrAddComponent<ItemStat>(gameObject);
        _itemText = gameObject.transform.Find("Text").GetComponent<Text>();
        _itemText.text = "Lv " + _itemStat.Level.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
