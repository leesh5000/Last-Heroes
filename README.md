### Game Client Programming

> [영상 링크](https://www.youtube.com/watch?v=8ug1vFNf_KM)

<br>
>  플레이어를 가리는 물체가 있을 때, 그 물체를 흐려지게 만들기
<br>

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Version 1
public class MainCameraController : MonoBehaviour
{
    // 카메라 위치의 offset
    [SerializeField]
    Vector3 _offset = new Vector3(-9.0f, 9.0f, -9.0f);

    LayerMask _cameraMask = (1 << (int)Define.Layer.Monster | 1 << (int)Define.Layer.Building | 1<<(int)Define.Layer.Wall);

    List<MeshRenderer> fadeInList = new List<MeshRenderer>();

    void Start()
    {

    }

    void Update()
    {
        if (Managers.Game.Player != null)
            transform.position = Managers.Game.Player.transform.position + _offset;

        // 플레이어가 벽에 가려졌을때 처리
        if (Managers.Game.Player.IsValid() == false)
        {
            return;
        }

        // 플레이어 -> 카메라 위치로 레이캐스팅해서 플레이어를 가리는 물체가 있는지 확인
        RaycastHit[] hits;
        hits = Physics.RaycastAll(Managers.Game.Player.transform.position + Vector3.up * 0.75f, _offset.normalized, _offset.magnitude, _cameraMask);

        if (hits.Length != 0)
        {
            Transform parent = hits[0].collider.gameObject.transform.parent;

            // TODO : 이 코드는 위험할 수도 있으니 나중에 수정할 것
            for (int i = 0; i < fadeInList.Count; i++)
            {
                MeshRenderer fadeInRenderer = fadeInList[i];
                if (fadeInRenderer.transform.parent.name != parent.name)
                {
                    StartCoroutine("FadeIn", fadeInRenderer);
                    fadeInList.Remove(fadeInRenderer);
                }
            }

            foreach (Transform child in parent)
            {
                MeshRenderer renderer = child.GetComponent<MeshRenderer>();

                if (renderer != null)
                {
                    if (renderer.material.color.a == 1)
                    {
                        fadeInList.Add(renderer);
                        StartCoroutine("FadeOut", renderer);
                    }
                }
            }
        }

        else
        {
            foreach (Renderer renderer in fadeInList)
            {
                if (renderer != null)
                {
                    StartCoroutine("FadeIn", renderer);
                }
            }

            fadeInList.Clear();
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
```

