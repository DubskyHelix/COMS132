using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountItHighter : MonoBehaviour
{
    private int _num = 0;

    void Update()
    {
        print(nextNum);
    }

    public int nextNum
    {
        get
        {
            _num++;
            return (_num);
        }
    }

    public int currentNum
    {
        get { return (_num); }
        set { _num = value; }
    }
}
