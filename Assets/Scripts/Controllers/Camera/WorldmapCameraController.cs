using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapCameraController : MonoBehaviour
{
    [SerializeField]
    LayerMask _cullingMask = ~(1 << (int)Define.Layer.Monster | 1 << (int)Define.Layer.WaveMonster | 1 << (int)Define.Layer.Player | 1 << (int)Define.Layer.Building);

    void Start()
    {
        gameObject.GetComponent<Camera>().cullingMask = _cullingMask;
        gameObject.SetActive(false);
    }
}