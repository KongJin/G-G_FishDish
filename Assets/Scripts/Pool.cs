using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool :MonoBehaviour
{
    Fish _fish;
    Queue<Fish> fishQueue;
    

    public Fish Get()
    {
        if (fishQueue.Peek().gameObject.activeSelf ==false)
            return fishQueue.Dequeue();
        return Instantiate(_fish);
    }


    public void Release(Fish element)
    {
        element.gameObject.SetActive(false);
        fishQueue.Enqueue(element);
    }

}
