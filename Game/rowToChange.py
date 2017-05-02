def rowToChange (arr,x):
    for i in range (0,len(arr)):
        if (arr[i] & (int) (math.pow(2,x)) !=0):
            return i
