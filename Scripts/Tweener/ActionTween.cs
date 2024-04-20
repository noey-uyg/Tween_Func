using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct TweenData
{
    public Transform target;
    public object from;
    public object to;
    public float duration;
    public EaseType easeType;
    public LoopType loopType;
    public Action OnComplete;

    public float elapsedTime;
    public float delayTimer;
    public bool isCompleted;
}

public class ActionTween : MonoBehaviour
{
    public Transform _target;
    public object _from;
    public object _to;
    public float _duration;
    public EaseType _easeType;
    public LoopType _loopType;
    public Action OnComplete;

    public float elapsedTime;
    public bool isCompleted;
    public float _delayTimer;

    private bool _isRunning;

    public Dictionary<EaseType, Func<float, float>> easeFunc;

    public virtual void SetTweenData(TweenData data)
    {
        _target = data.target;
        _duration = data.duration;
        _from = data.target.transform.position;
        _to = data.to;
        _duration = data.duration;
        _easeType = data.easeType;
        _loopType = data.loopType;
        _delayTimer = data.delayTimer;
        OnComplete = data.OnComplete;

        elapsedTime = 0f;
        isCompleted = false;
    }

    public void RunTween()
    {
        if (isCompleted) return;

        isCompleted = true;
        elapsedTime = 0f;
    }

    private void Awake()
    {
        InitEase();
    }

    protected virtual void Update()
    {
        if (!isCompleted) return;

        if (_delayTimer > 0)
        {
            Debug.Log("딜레이중");
            _delayTimer -= Time.deltaTime;
            return;
        }

        Debug.Log("딜레이 없음");
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / _duration);

        Func<float, float> selectedEaseFunction = easeFunc[_easeType];
        float easeV = selectedEaseFunction(t);

        UpdateTween(easeV);

        if (elapsedTime >= _duration)
        {
            isCompleted = false;
            OnComplete?.Invoke();
        }
    }

    protected virtual void UpdateTween(float easeV)
    {

    }


    #region 이징함수
    //https://easings.net/ko# 이징 함수 치트 시트
    private void InitEase()
    {
        easeFunc = new Dictionary<EaseType, Func<float, float>> {
            {EaseType.Linear, Linear },
            {EaseType.InSine, InSine },
            {EaseType.OutSine, OutSine },
            {EaseType.InOutSine, InOutSine },
            {EaseType.InQuad, InQuad },
            {EaseType.OutQuad, OutQuad },
            {EaseType.InOutQuad, InOutQuad },
            {EaseType.InCubic, InCubic },
            {EaseType.OutCubic, OutCubic },
            {EaseType.InOutCubic, InOutCubic },
            {EaseType.InQuart, InQuart },
            {EaseType.OutQuart, OutQuart },
            {EaseType.InOutQuart, InOutQuart },
            {EaseType.InQuint, InQuint },
            {EaseType.OutQuint, OutQuint },
            {EaseType.InOutQuint, InOutQuint },
            {EaseType.InExpo, InExpo },
            {EaseType.OutExpo, OutExpo },
            {EaseType.InOutExpo, InOutExpo },
            {EaseType.InCirc, InCirc },
            {EaseType.OutCirc, OutCirc },
            {EaseType.InOutCirc, InOutCirc },
            {EaseType.InElastic, InElastic },
            {EaseType.OutElastic, OutElastic },
            {EaseType.InOutElastic, InOutElastic },
            {EaseType.InBack, InBack },
            {EaseType.OutBack, OutBack },
            {EaseType.InOutBack, InOutBack },
            {EaseType.InBounce, InBounce },
            {EaseType.OutBounce, OutBounce },
            {EaseType.InOutBounce, InOutBounce },
        };
    }

    private float Linear(float t){
        return t;
    }

    private float InSine(float t){
        return 1f - Mathf.Cos((t * Mathf.PI) / 2);
    }

    private float OutSine(float t) {
        return Mathf.Sin((t * Mathf.PI) / 2);
    }

    private float InOutSine(float t) {
        return -(float)(Mathf.Cos(Mathf.PI * t) - 1 / 2);
    }

    private float InQuad(float t) {
        return t * t;
    }

    private float OutQuad(float t) {
        return 1 - (1 - t) * (1 - t);
    }

    private float InOutQuad(float t) {
        return t < 0.5 ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2;
    }

    private float InCubic(float t) {
        return t * t * t;
    }

    private float OutCubic(float t) {
        return 1 - Mathf.Pow(1 - t, 3);
    }

    private float InOutCubic(float t) {
        return t < 0.5 ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
    }

    private float InQuart(float t) {
        return t * t * t * t;
    }

    private float OutQuart(float t) {
        return 1 - Mathf.Pow(1 - t, 4);
    }

    private float InOutQuart(float t) {
        return t < 0.5 ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
    }

    private float InQuint(float t) {
        return t * t * t * t * t;
    }

    private float OutQuint(float t) {
        return 1 - Mathf.Pow(1 - t, 5);
    }

    private float InOutQuint(float t) {
        return t < 0.5 ? 16 * t * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
    }

    private float InExpo(float t) {
        return t == 0 ? 0 : Mathf.Pow(2, 10 * t - 10);
    }

    private float OutExpo(float t) {
        return t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
    }

    private float InOutExpo(float t) {
        return t == 0 ? 0 : t == 1 ? 1 : t < 0.5 ? Mathf.Pow(2, 20 * t - 10) / 2 : (2 - Mathf.Pow(2, -20 * t + 10)) / 2;
    }

    private float InCirc(float t) {
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));
    }

    private float OutCirc(float t) {
        return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
    }

    private float InOutCirc(float t) {
        return t < 0.5 ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;
    }

    private float InElastic(float t) {
        float c4 = (2 * Mathf.PI) / 3;

        return t == 0 ? 0 : t == 1 ? 1 : -(float)(Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4));
    }
    private float OutElastic(float t) {
        float c4 = (2 * Mathf.PI) / 3;

        return t == 0 ? 0 : t == 1 ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4 + 1);
    }

    private float InOutElastic(float t) {
        float c5 = (2 * Mathf.PI) / 4.5f;

        return t ==0?0:t==1?1:t<0.5
            ? -(float)(Mathf.Pow(2,20*t-10)*Mathf.Sin((20*t-11.125f)*c5))/2
            : (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2 + 1;
    }

    private float InBack(float t) {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return c3 * t * t * t - c1 * t * t;
    }

    private float OutBack(float t) {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
    }

    private float InOutBack(float t) {
        float c1 = 1.70158f;
        float c2 = c1 * 1.525f;

        return t < 0.5
            ? (Mathf.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2
            : (Mathf.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;

    }

    private float InBounce(float t) {
        return 1 - OutBounce(1 - t);
    }

    private float OutBounce(float t) {
        float n1 = 7.5625f;
        float d1 = 2.75f;

        if (t < 1 / d1)
        {
            return n1 * t * t;
        }
        else if (t < 2 / d1)
        {
            return n1 * (t -= 1.5f / d1) * t + 0.75f;
        }
        else if (t < 2.5 / d1)
        {
            return n1 * (t -= 2.25f / d1) * t + 0.9375f;
        }
        else
        {
            return n1 * (t -= 2.625f / d1) * t + 0.984375f;
        }
    }

    private float InOutBounce(float t) {
        return t < 0.5
            ? (1 - OutBounce(1 - 2 * t)) / 2
            : (1 + OutBounce(2 * t - 1)) / 2;
    }
    #endregion
}
