using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public EaseType easeType;
    public GameObject Go1;
    public GameObject cube;
    public GameObject Go2;

    SequenceTween sequence;
    ParallelTween parallel;

    private void Start()
    {
        sequence = new SequenceTween(() => Debug.Log("Sequence complete"));
        parallel = new ParallelTween(() => Debug.Log("Parallel complte"));
    }
    public void OnGo1()
    {
        Tweener.MoveToTarget(cube.transform, Go2.transform.position, 2f, easeType, LoopType.None);
        Tweener.MoveToTarget(Go1.transform, Go2.transform.position, 2f, easeType, LoopType.None);
    }

    public void OnGo2()
    {
        Tweener.RotateToTarget(cube.transform, new Vector3(360, 360, 0), 2f, easeType, LoopType.None);
        Tweener.RotateToTarget(Go1.transform, new Vector3(360,360,0), 2f, easeType, LoopType.None);
    }

    public void OnGo3()
    {
        Tweener.ScaleToTarget(cube.transform, new Vector3(1.5f, 1.5f, 1.5f), 2f, easeType, LoopType.None);
        Tweener.ScaleToTarget(Go1.transform, new Vector3(1.5f,1.5f,1.5f), 2f, easeType, LoopType.None);
    }

    public void OnGo4()
    {
        Tweener.ColorToTarget(cube.transform, new Color(214, 213, 152), 2f, easeType, LoopType.None);
        Tweener.ColorToTarget(Go1.transform, new Color(214,213,152), 2f, easeType, LoopType.None);
    }

    public void OnGo5()
    {
        Tweener.AlphaToTarget(cube.transform, 0, 2f, easeType, LoopType.None);
        Tweener.AlphaToTarget(Go1.transform, 0, 2f, easeType, LoopType.None);
    }

    public void OnGo6()
    {
        sequence.AddTween(Tweener.MoveToTarget(Go1.transform, Go2.transform.position, 2f, EaseType.OutCirc, LoopType.None,5f));
        sequence.AddTween(Tweener.RotateToTarget(Go1.transform, new Vector3(360, 360, 0), 2f, EaseType.InOutQuad, LoopType.None));
        sequence.Play();

    }

    public void OnGo7()
    {
        parallel.AddTween(Tweener.ScaleToTarget(cube.transform, new Vector3(1.5f, 1.5f, 1.5f), 2f, EaseType.InOutCirc, LoopType.None));
        parallel.AddTween(Tweener.ColorToTarget(cube.transform, new Color(214, 213, 152), 2f, EaseType.InOutQuint, LoopType.None));
        parallel.Play();
    }
}
