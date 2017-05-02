using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public List<GameObject>[] dots;
    public GameObject dot;
    public static Board board;
    public int xalign;
    public int yalign;
    public int xgap;
    public int ygap;
    public int xmax;
    public int ymax;
    private Nim game;

    // Use this for initialization
    void Start()
    {
        game = gameObject.GetComponent<Nim>();
        Initialize(new int[3] { 3, 4, 5 });
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            game.UpdateBoardState(Passback());
            game.CpuTurn();
            Passhere(game.getboardState());
        }
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

        this.dots = new List<GameObject>[init.Length];
        this.ymax = init.Length;

        for (int i = 0; i < init.Length; i++)
        {
            List<GameObject> temp = new List<GameObject>();
            for (int j = 0; j < init[i]; j++)
            {
                Vector3 dotPos = new Vector3(xalign + j * xgap, yalign - i * ygap, 0);
                temp.Add(GameObject.Instantiate(dot, dotPos, Quaternion.identity));
            }
            dots[i] = temp;
        }
    }

    public int[] Passback()
    {
        UpdateBoard();
        int[] pass = new int[ymax];
        for (int i = 0; i < ymax; i++)
        {
            pass[i] = dots[i].Count;
        }
        return pass;
    }

    public void Passhere(int[] done)
    {
        for (int i = 0; i < done.Length;i++)
        {
            int a = dots[i].Count;
            if (a > done[i])
            {
                for (int j = done[i]; j < dots[i].Count;)
                {
                    dots[i][j].GetComponent<Spacebar>().Delete();
                    this.dots[i].RemoveAt(j);
                }
                UpdateBoard();
            }
        }
    }

    public void UpdateBoard()
    {
        for (int i=0; i<ymax; i++)
        {
            for (int j=0; j<dots[i].Count;)
            {
                if(dots[i][j]==null)
                {
                    this.dots[i].RemoveAt(j);
                }
                else
                {
                    j++;
                }
            }
            
        }
    }
}
