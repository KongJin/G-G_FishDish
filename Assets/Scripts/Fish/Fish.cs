using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Fish : MonoBehaviour  ,IMoveAble
{
    public Spec spec { get; protected set; }
    public Vector3[] direction { get; protected set; }
    
    protected RectTransform rectTransform;
    public IFishPool pool { get; protected set; }

    // Start is called before the first frame update
    public void Init( Vector3 position ,IFishPool _pool, Spec _spec , Sprite sprite )
    {
        pool = _pool;
        direction = new Vector3[] { Vector3.zero };
        UnityEngine.UI.Image img = GetComponent<UnityEngine.UI.Image>();
        img.sprite = sprite;
        img.SetNativeSize();

        spec = _spec;


        eater = EaterMaker.GetEater(this);            
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = position;
        Vector3 AddY = Vector3.up * UnityEngine.Random.Range(-0.22f,0.22f);
        if (position.x >0)
        {
            direction[0] =  Vector3.left+ AddY;
            transform.eulerAngles = new Vector3( 0, 180, 0 );
        }
        else if(position.x <0)
        {
            direction[0] = Vector3.right+ AddY;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        

        mover = new FishMove(rectTransform);
        gameObject.SetActive(true);
    }

    protected virtual void Start()
    {

        gameObject.layer = myLayer = (short)Define.LayerType.Indegenous;
    }

    protected IMoveAble mover;
    void Update()
    {
        Move(direction,spec.speed);
        if(rectTransform.localPosition.x <-Define.screenWide- Define.space || rectTransform.localPosition.x> Define.screenWide+ Define.space)
            pool.Release(this);
        
    }

    protected IEatAble eater;
   
    protected short myLayer;

    public void OnTriggerStay2D(Collider2D other)
    {
        Fish _fish = other.GetComponent<Fish>();
        if ( _fish.gameObject.layer == myLayer)
            return;
        eater.Eat(_fish.spec.size,_fish.eater);
    }

    public void Move(Vector3[] direction, float speed)
    {
        
        mover?.Move(direction,speed );
    }
}
