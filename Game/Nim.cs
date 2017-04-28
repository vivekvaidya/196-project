using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Nim : MonoBehaviour
{
	private bool lastLoses;
	private bool critical;
	private int[] boardState;
	private int largestUnbalanced;
	private int operatingRow;

	void Start (){
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
	public Nim(int[] boardState, bool lastLoses) {
		this.boardState = boardState;
		this.lastLoses = lastLoses;
	}

	public void LargestUnbalanced() { //updates 'largestUnbalanced'(ie 4 means 2^4=16's bit is unbalanced)
		int big = 0;
		for (int i=0; i<this.boardState.Length; i++) {
			if (this.boardState[i]>big) {
				big = this.boardState[i];
			}
		} // Gets the largest number in the array
		int n = (int) System.Math.Log((double) big, 2.0);
		while (n>0) {
			int sum = 0;
			for (int i=0; i<this.boardState.Length; i++) {
				sum+= (int) (((int) System.Math.Pow(2,n) & this.boardState[i]) / (int) System.Math.Pow(2,n));
			} //iterates through array and totals up the 1 bits for a given power of 2
			if (sum % 2 == 1) {
				this.largestUnbalanced = n; //if its odd, the array is unbalanced
			} else {
				n -= 1; //otherwise check the next largest power of
			}
		}
		this.largestUnbalanced = -1;
	}

	public void IsCritical() { //upates 'critical' to whether or not the board state is critical
		int count = 0;
		for (int i = 0; i<this.boardState.Length; i++) {
			if (this.boardState [i] != 0 && this.boardState [i] != 1) {
				count++;
			} if (count>1) {
				this.critical = false;
			}
		}
		if (count == 1) {
			this.critical = true;
		} else {
			this.critical = false;
		}
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
		int index = seed.Next(nonZero.Count);
		this.boardState[index] = seed.Next(boardState[index] - 1);
	}

	public void CriticalTurn() {
		int i = 0;
		for (i = 0; i<this.boardState.Length; i++) {
			if (this.boardState[i]>1) {
				this.boardState[i] = 1;
				this.operatingRow = i;
				break;
			}
		}
		this.LargestUnbalanced();
		if (this.largestUnbalanced>-1) {
			this.boardState[this.operatingRow]=0;
		}
	}

	public void UpdateBoardState(Board board) {
		int[] tempBoardState = new int[board.length];
		for (int i=0; i<board.length; i++) {
			tempBoardState[i]=board[i].length;
		}
		this.boardState=tempBoardState;
	}
	public void CpuTurn() {
		this.LargestUnbalanced();
		this.IsCritical();
		if (this.largestUnbalanced == -1) {
			this.Random ();
		} else if (this.lastLoses && this.critical) {
			this.CriticalTurn();
		} else {
			this.BalanceBoard();
		}
	}

	public void PrintBoardState() {
		for (int i=0; i<this.boardState.Length; i++) {
			System.Console.Write (this.boardState [i] + ", ");
		}
		System.Console.WriteLine ("");
	}

	public static void Test() {
		int[] test = new int[] { 3, 4, 5 };
		Nim Test = new Nim(test, true);
		Test.PrintBoardState();
		Test.CpuTurn();
		Test.PrintBoardState();
	}
		
	void Update () {

	}
}

// Use this for initialization
// Update is called once per frame