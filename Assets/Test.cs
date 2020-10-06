using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    TextAsset textAsset;

    void Start()
    {
        textAsset = Managers.Resource.Load<TextAsset>("Data/ChracterStatData");

        print(textAsset.text);
    }
}
