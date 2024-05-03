using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform arrow;
    public void SetArrow(float rotate, float ratio)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotate);
        arrow.localPosition = Vector3.right*90 * ratio;
    }

}
