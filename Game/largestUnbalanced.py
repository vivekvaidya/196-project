import math
def largesUnbalanced(arr):
    arr.sort()
    n = int (math.log2(arr[-1]))
    while n>0:
        sum=0
        for elem in arr:
            sum += int ((int (math.pow(2,i)) & elem) // (math.pow(2,i)))
        if sum%2 == 1:
            return n
        else:
            n-=1
    return -1
print (isBalanced([1,1,1,1]))
