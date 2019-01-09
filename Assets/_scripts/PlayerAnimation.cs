using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    public Sprite[] standing, walking, jumping, dying; //1 standing, 8 walking, 5 jumping, 10 dying
    public SpriteRenderer rend;
    public float intervalTime = 30f, targetTime;

	public void Standing()
    {
        rend.sprite = standing[0];
    }

    public void Walking()
    {
        rend.sprite = walking[0];
    }

    public void Jumping()
    {
        rend.sprite = jumping[0];
    }

    public void Dying()
    {
        rend.sprite = dying[0];
        getTime();
        while(targetTime > Time.time)
        {

        }
    }

    private float getTime()
    {
        targetTime = Time.time + intervalTime;
        return targetTime;
    }
}
