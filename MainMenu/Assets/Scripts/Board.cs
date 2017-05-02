using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public GameObject[,] dots;
    public GameObject dot;
    public static Board board;
    public int xalign;
    public int yalign;
    public int xgap;
    public int ygap;
    public int xmax;
    public int ymax;

    // Use this for initialization
    void Start()
    {
        Initialize(new int[5] { 5, 5, 5, 5, 5 });
        Passhere(new int[5] { 3, 5, 5, 5, 5 }); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Initialize(int[] init)
    {
        int max = 0;
        for (int i = 0; i < init.Length; i++)
        {
            if (init[i] > max) {
                max = init[i];
            }
        }
        this.xmax=max;
        bool xodd = (max % 2 == 1 ? true : false);
        bool yodd = (init.Length % 2 == 1 ? true : false);
        Initialize(init, xodd, yodd, max);
    }

    public void Initialize(int[] init, bool xodd, bool yodd, int xmax)
    {
        if (xodd)
            this.xalign = -(xmax / 2) * xgap;
        else
            this.xalign = -(xmax / 2) * xgap + 1;

        if (yodd)
            this.yalign = (init.Length / 2) * ygap;
        else
            this.yalign = (init.Length / 2) * ygap - 1;

        this.dots = new GameObject[xmax, init.Length];
        this.ymax = init.Length;

        for (int i = 0; i < init.Length; i++)
        {
            for (int j = 0; j < init[i]; j++)
            {
                Vector3 dotPos = new Vector3(xalign + j * xgap, yalign - i * ygap, 0);
                dots[i,j] = GameObject.Instantiate(dot, dotPos, Quaternion.identity);
            }
        }
    }

    public int getLength(int a)
    {
        int count = 0;
        for (int i = 0; i<this.xmax; i++) {
            if (dots[i,a] != null) {
                count+=1;
            }
        } return count;
    }

    public int[] Passback()
    {
        int[] pass = new int[ymax];
        for (int i = 0; i < ymax; i++)
        {
            pass[i] = this.getLength(i);
        }
        return pass;
    }

    public void Passhere(int[] done)
    {
        for (int i = 0; i < done.Length;i++)
        {
            int a = this.getLength(i);
            if (a > done[i])
            {
                for (int j = done[i]; j<a; j++)
                {
                    dots[i,j].GetComponent<Spacebar>().Delete();
                }
            }
        }
    }
}
