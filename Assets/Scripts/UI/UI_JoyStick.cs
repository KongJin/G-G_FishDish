using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
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
    PlayableFish fish;
    [SerializeField]
    private UI_Arrow arrow;

    public void Init(PlayableFish _fish)
    {
        fish = _fish;
        arrow = Instantiate(arrow, fish.transform);
        
    }

    public void Start()
    {
        joystickOriginalPos = RectTransformUtility.WorldToScreenPoint(Camera.main, joystickBG.position) ;
        joystickRadius = joystickBG.sizeDelta.y / 4f;
        
        
    }
    private void Update()
    {
        fish.Move(point);


    }

    void SetPoint()
    {
        point = moveDir * ratio;

        float angle = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;
        arrow.SetArrow(angle, ratio);
    }
    void OnPress(Vector2 pressPoint)
    {
        float dist = Vector2.Distance(joystickOriginalPos, pressPoint);
        if(dist > joystickRadius)
            dist = joystickRadius;
        ratio = dist / joystickRadius;

        moveDir = (pressPoint - joystickOriginalPos).normalized;
        SetPoint();

        handler.localPosition = moveDir* dist*2;//+_joystickTouchPos 

    }
    public void OnPointerDown(PointerEventData eventData) { OnPress(eventData.position); }
    public void OnDrag(PointerEventData eventData) { OnPress(eventData.position); }

    public void OnPointerUp(PointerEventData eventData)
    {
        ratio *=  0.7f;
        SetPoint();

        moveDir = Vector2.zero;
        handler.localPosition = Vector2.zero;
    }


}
