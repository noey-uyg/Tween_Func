using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public GameObject Go1;
    public GameObject Go2;

    public void OnGo1()
    {
        Tweener.MoveToTarget(Go1.transform, Go2.transform.position, 2f, EaseType.Linear, LoopType.None);
        //Go1.SetActive(!Go1.activeSelf);
    }

    public void OnGo2()
    {
        Tweener.MoveToTarget(Go2.transform, Go1.transform.position, 2f, EaseType.InSine, LoopType.None);
        //Go2.SetActive(!Go2.activeSelf);
    }
}
