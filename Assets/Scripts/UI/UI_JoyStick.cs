using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
// using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Joystick  :MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler 
{
    [SerializeField]
    private RectTransform handler;
    [SerializeField]
    private RectTransform joystickBG;
    private Vector2 moveDir;
    private Vector2 point;
    private float ratio;

    //private Vector2 _joystickTouchPos;
    private Vector2 joystickOriginalPos;

    private float joystickRadius;
    [SerializeField]
    private UI_Arrow arrow;

    private bool pressing;
    private Transform fishTransform;
    private Vector3[] fishPoint;
    public void Init(Transform _fishTransform, Vector3[] _fishPoint)
    {
        fishTransform = _fishTransform;
        fishPoint = _fishPoint;
        UI_Arrow temp =_fishTransform.GetComponentInChildren<UI_Arrow>();
        ratio = 0;
         arrow = temp ?? Instantiate(arrow, _fishTransform);
         change = 1;
        point = Vector2.zero;
    }

    public void Start()
    {
        joystickOriginalPos = RectTransformUtility.WorldToScreenPoint(Camera.main, joystickBG.position) ;
        joystickRadius = joystickBG.sizeDelta.y / 4f;
       
        
    }
    private void Update()
    {
        if(!pressing)
        {
            if(ratio > 0.1f)
                ratio -= Time.deltaTime;
            point -= point * Time.deltaTime;
        }
            
        SetPoint();
        
    }

    void SetPoint()
    {
        if(point.magnitude>  2)//
            point = point.normalized*2;
        else
            point += moveDir * ratio * Time.deltaTime * 3;
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        arrow.SetArrow(angle, ratio);
        fishPoint[0] = point;
    }


    float change;

    void OnPress(Vector2 pressPoint)
    {
        pressing = true;
        float dist = Vector2.Distance(joystickOriginalPos, pressPoint);
        if(dist > joystickRadius)
            dist = joystickRadius;
        ratio = dist / joystickRadius;

        moveDir = (pressPoint - joystickOriginalPos).normalized;
        handler.localPosition = moveDir* dist*2;//+_joystickTouchPos 

        arrow.transform.localScale = Vector3.one* 1/transform.localScale.x;

        if (moveDir.x < 0 != change < 0)
        {
            fishTransform.eulerAngles += Vector3.up * 180;
        }
        change = moveDir.x;

    }
    public void OnPointerDown(PointerEventData eventData) { OnPress(eventData.position); }
    public void OnDrag(PointerEventData eventData) { OnPress(eventData.position); }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
        handler.localPosition = Vector2.zero;
    }


}
