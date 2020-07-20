using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CreatorCrads _Ccards;
     private int id;
    [SerializeField] private SpriteRenderer secondRender;

    void Start()
    {
        _Ccards = CreatorCrads.instance;
    }

    private void OnMouseDown()
    {
        if (secondRender.enabled == false && _Ccards.youcanreveal)
        {
            print(id+"id");
           
            secondRender.enabled = true;
            _Ccards.fillup(this);
        }
    }
    public void setid(int _id) {
        id = _id;
    }
    public void setface(Sprite two)
    {
        secondRender.sprite = two;
        secondRender.enabled = false;

    }
    public int getid() {
        return id;
    }
    // Update is called once per frame
    public void unreveld(){
        secondRender.enabled = false;
    }

}
