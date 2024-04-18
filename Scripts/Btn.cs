using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public EaseType easeType;
    public GameObject Go1;
    public GameObject Go2;

    Vector3 originPos;

    private void Start()
    {
        originPos = Go1.transform.position;
    }

    public void OnGo1()
    {

        Tweener.MoveToTarget(Go1.transform, Go2.transform.position, 2f, easeType, LoopType.None);
    }

    public void OnGo2()
    {
        Tweener.RotateToTarget(Go1.transform, new Vector3(360,180,0), 2f, easeType, LoopType.None);
    }

    public void OnGo3()
    {
        Tweener.ScaleToTarget(Go1.transform, new Vector3(1.5f,1.5f,1.5f), 2f, easeType, LoopType.None);
    }

    public void OnGo4()
    {
        Tweener.ColorToTarget(Go1.transform, new Color(214,213,152), 2f, easeType, LoopType.None);
    }
}
