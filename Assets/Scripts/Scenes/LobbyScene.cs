using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    GameObject[] characterOrigin;
    public GameObject[] characters { get; set; }
    Vector3 characterSpawnPos = new Vector3(-61.0f, 0.0f, -13.0f);

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Lobby;

        { // 캐릭터 데이터 불러오기 & 생성하기
            characterOrigin = Resources.LoadAll<GameObject>("Prefabs/Character");
            characters = new GameObject[characterOrigin.Length];

            // 생성한 캐릭터 "실체"를 리스트에 넣어주기
            for (int i=0; i<characterOrigin.Length; i++)
            {
                GameObject origin = characterOrigin[i];
                characters[i] = Instantiate(origin, characterSpawnPos, Quaternion.Euler(0.0f, -90.0f, 0.0f));
                characters[i].name = origin.name;
                characters[i].SetActive(false);
            }
        }

        Transform camera = GameObject.Find("Main Camera").transform;
        StartCoroutine("RotateCamera", camera);
        StartCoroutine("MoveCamera", camera);
    }

    void Update()
    {

    }

    public override void Clear()
    {
        
    }

    IEnumerator MoveCamera(Transform camera)
    {
        //Vector3 targetPos = new Vector3(-75.0f, 1.5f, -15.0f);
        Vector3 targetPos = new Vector3(-65.0f, 1.5f, -15.0f);

        //while (Vector3.Distance(camera.position, targetPos) > 0.25f)
        while (camera.position != targetPos)
        {
            camera.position = Vector3.Lerp(camera.position, targetPos, 0.04f);

            yield return new WaitForSeconds(0.01f);

            if (Vector3.Distance(camera.position, targetPos) < 2.0f && Managers.UI.UI_LobbyScene == null)
                Managers.UI.UI_LobbyScene = Managers.UI.OpenSceneUI<UI_LobbyScene>().gameObject;
        }
    }

    IEnumerator RotateCamera(Transform camera)
    {
        Quaternion targetRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

        while (camera.rotation != targetRotation)
        {
            camera.rotation = Quaternion.Slerp(camera.rotation, targetRotation, 0.04f);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
