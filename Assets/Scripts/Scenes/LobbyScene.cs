using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;


        Vector3 knightPos = new Vector3(-25, 0, -15);
        GameObject knight = Managers.Resource.Instantiate("Prefabs/Character/Knight", knightPos);
        knight.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

        Transform camera = GameObject.Find("Main Camera").transform;
        StartCoroutine("MoveCamera", camera);
        StartCoroutine("RotateCamera", camera);

        //GetComponent<Camera>().transform.position = Vector3.Lerp(transform.position, _cameraMoveVelocity, 5.0f);
        //_camera.transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0, 90, 0), 5.0f);
    }

    void Update()
    {

    }

    public override void Clear()
    {
        
    }

    IEnumerator MoveCamera(Transform camera)
    {
        Vector3 targetPos = new Vector3(-35, 3, -15);

        while (camera.position != targetPos)
        {
            camera.position = Vector3.Slerp(camera.position, targetPos, 0.1f);

            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator RotateCamera(Transform camera)
    {
        Quaternion targetRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

        while (camera.rotation != targetRotation)
        {
            camera.rotation = Quaternion.Slerp(camera.rotation, targetRotation, 0.1f);

            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator FadeOut(MeshRenderer renderer)
    {
        Object material = Resources.Load("Arts/Environments/Materials/PolyKnights_Mat_01_Fade");
        renderer.material = material as Material;

        int i = 10;
        while (i > 1)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator FadeIn(MeshRenderer renderer)
    {
        int i = 1;
        while (i < 10)
        {
            i += 1;
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }

        Object material = Resources.Load("Arts/Environments/Materials/PolyKnights_Mat_01");
        renderer.material = material as Material;
    }
}
