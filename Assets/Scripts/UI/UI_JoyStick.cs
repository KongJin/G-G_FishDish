using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Joystick  :MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler 
{
    [SerializeField]
    private RectTransform _handler;
    [SerializeField]
    private RectTransform _joystickBG;
    private Vector2 _moveDir;

    //private Vector2 _joystickTouchPos;
    private Vector2 _joystickOriginalPos;

    private float _joystickRadius;
    IMoveAble fish;


    public void Init(IMoveAble _fish)
    {
        fish = _fish;
    }

    public void Start()
    {
        _joystickOriginalPos = RectTransformUtility.WorldToScreenPoint(Camera.main, _joystickBG.position) ;
        _joystickRadius = _joystickBG.sizeDelta.y / 4f;
        
        
    }
    private void Update()
    {
        fish.Move(_moveDir);
    }
    void OnPress(Vector2 pressPoint)
    {
        float dist = Vector2.Distance(_joystickOriginalPos, pressPoint);
        if(dist > _joystickRadius)
            dist = _joystickRadius;

        Vector2 point = pressPoint - _joystickOriginalPos;
        _moveDir = point.normalized;

        _handler.localPosition = _moveDir* dist*2;//+_joystickTouchPos 
    }
    public void OnPointerDown(PointerEventData eventData) { OnPress(eventData.position); }
    public void OnDrag(PointerEventData eventData) { OnPress(eventData.position); }

    public void OnPointerUp(PointerEventData eventData)
    {
        _moveDir = Vector2.zero;
        _handler.localPosition = Vector2.zero;
    }

}
