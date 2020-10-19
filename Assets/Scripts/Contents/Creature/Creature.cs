using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour
{
    public CreatureStat Stat { get; set; }
    
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void Init();

}
