using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    //Object[] characters;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;

        ////Vector3 knightPos = new Vector3(-71.0f, 0.0f, -13.0f);
        //Vector3 knightPos = new Vector3(-61.0f, 0.0f, -13.0f);
        //GameObject knight = Managers.Resource.Instantiate("Prefabs/Character/Knight", knightPos);
        //knight.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);

        Transform camera = GameObject.Find("Main Camera").transform;
        StartCoroutine("RotateCamera", camera);
        StartCoroutine("MoveCamera", camera);

        //characters = Resources.LoadAll("Prefabs/Character");
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
