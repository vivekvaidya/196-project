x=rowToChange(arr)
y=largestUnbalanced(arr)
def balanceBoard(arr):
    changes=[]
    changes=arr
    changes[y]=removebits(changes[y],x)
    changes[y]-=1
    n=largestUnbalanced(changes)
    if n==-1:
        return changes
    else:
        return balanceBoard(changes, n, y)