using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nim : MonoBehaviour
{
	private bool lastLoses = true;
	private bool critical;
	private int[] boardState;
	private int largestUnbalanced;
	private int operatingRow;
    public void Start () {
    }

    public bool getlastLoses() {
		return this.lastLoses;
	}
	public bool getcritical() {
		return this.critical;
	}
	public int getlargestUnbalanced() {
		return this.largestUnbalanced;
	}
	public int getoperatingRow() {
		return this.operatingRow;
	}
	public int[] getboardState(){
		return this.boardState;
	}

	public void LargestUnbalanced() { //updates 'largestUnbalanced'(ie 4 means 2^4=16's bit is unbalanced)
		int big = 0;
		for (int i=0; i<this.boardState.Length; i++) {
			if (this.boardState[i]>big) {
				big = this.boardState[i];
			}
		} // Gets the largest number in the array
        this.largestUnbalanced = -1;
        int exp = 0;
		while (System.Math.Pow(2, exp) <= big) {
			int sum = 0;
			for (int i=0; i<this.boardState.Length; i++) {
                if (((int)System.Math.Pow(2, exp) & this.boardState[i]) != 0)
                    sum++;
			} //iterates through array and totals up the 1 bits for a given power of 2
            if (sum % 2 == 1)
            {
				this.largestUnbalanced = exp; //if its odd, the array is unbalanced
			}
            exp++;
		}
	}

	public void IsCritical() { //upates 'critical' to whether or not the board state is critical
        this.critical = true;
        bool primed = false;
        for (int i = 0; i<this.boardState.Length; i++)
        {
            if(boardState[i] > 1)
            {
                if (primed)
                {
                    this.critical = false;
                    return;
                }
                else
                    primed = true;
            }
        }
        if (!primed)
            this.critical = false;
	}

	public void RemoveBits() { //helper function for balance board. Deletes bits to the right of largestUnbalanced
		for(int i = 0; i < this.largestUnbalanced; i++) {
			if (((int) this.boardState[this.operatingRow] & (int) System.Math.Pow (2, i)) != 0) {
				this.boardState[this.operatingRow] -= (int)(System.Math.Pow (2, i));
			}
		} 
		this.boardState[this.operatingRow]-=1; //does the subtration for balancing largest unbalanced and making all subsequent columns 1
	}

	public void RowToChange() { //param: x is the largest order unbalanced bit
		for (int i = 0; i < this.boardState.Length; i++) {
			if ((this.boardState[i] & (int) (System.Math.Pow(2,this.largestUnbalanced))) != 0) {
				this.operatingRow = i;
                return;
			}
		}
		this.operatingRow = -1;
	}

	public void BalanceBoard() {
		this.RemoveBits();
        this.LargestUnbalanced();
        if (largestUnbalanced > -1) {
			this.BalanceBoard ();
		}
	}

	public void Random() { //random turn
		List<int> nonZero = new List<int> ();
		for (int i = 0; i < this.boardState.Length; i++) {
			if (this.boardState [i] > 0) {
				nonZero.Add(i);
			}
		}
		System.Random seed = new System.Random();
		int index = nonZero[seed.Next(nonZero.Count)];
        int max = boardState[index] - 1;
        if (max == 0)
        {
            this.boardState[index] = 0;
            return;
        }
		this.boardState[index] = seed.Next(boardState[index] - 1);
	}

	public void CriticalTurn() {
		for (int i = 0; i<this.boardState.Length; i++) {
			if (this.boardState[i]>1) {
				this.boardState[i] = 1;
				this.operatingRow = i;               
				break;
			}
		}
		this.LargestUnbalanced();
		if (this.largestUnbalanced==-1) {
			this.boardState[this.operatingRow]=0;
		}
	}

    public void UpdateBoardState(int[] board) {
        this.boardState = board;
    }

	public int[] CpuTurn() {
        this.LargestUnbalanced();
 		this.IsCritical();
		if (this.largestUnbalanced == -1) {
			this.Random();
		} else if (this.lastLoses && this.critical) {
			this.CriticalTurn();
		} else {
            this.RowToChange();
			this.BalanceBoard();
		}
        return this.boardState;
	}

}

// Use this for initialization
// Update is called once per frame