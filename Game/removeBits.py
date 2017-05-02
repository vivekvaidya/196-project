import math
def removeBits(arr, x):
    for i in range (0,x):
        if (int) (arr[y] & (int) (math.pow(2,i))) !=0:
            arr[y]-= (int) (math.pow(2,i))
            return arr[y]
