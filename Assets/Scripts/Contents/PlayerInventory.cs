using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Item[] PlayerItems { get; set; } = new Item[6];

    // TODO
    // 인벤토리에 Add, Remove 함수 만들고, Knight 스크립트에서 이벤트로 연동할 것
    // 이벤트 함수는 ADD, Remove 된 아이템 정보를 스텟에 반영하는 함수

    void Start()
    {
        Init();        
    }

    void Update()
    {
           
    }

    public void Init()
    {

    }

}
