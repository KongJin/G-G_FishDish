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

    private bool pressing;

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
        if(!pressing&&ratio > 0.2f)
        {
            ratio -= Time.deltaTime;
            point -= point * Time.deltaTime;
        }
            
        SetPoint();
        fish.Move(point);
    }

    void SetPoint()
    {
        
        if(point.sqrMagnitude>  ratio*2)
        {
            point = moveDir * ratio*2;
        }
        else
        {
            point += moveDir * ratio * Time.deltaTime * 10;
        }
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        arrow.SetArrow(angle, ratio);
    }
    void OnPress(Vector2 pressPoint)
    {
        pressing = true;
        float dist = Vector2.Distance(joystickOriginalPos, pressPoint);
        if(dist > joystickRadius)
            dist = joystickRadius;
        ratio = dist / joystickRadius;

        moveDir = (pressPoint - joystickOriginalPos).normalized;
        handler.localPosition = moveDir* dist*2;//+_joystickTouchPos 
    }
    public void OnPointerDown(PointerEventData eventData) { OnPress(eventData.position); }
    public void OnDrag(PointerEventData eventData) { OnPress(eventData.position); }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
        handler.localPosition = Vector2.zero;
    }


}
