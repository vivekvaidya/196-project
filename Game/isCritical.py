def isCritical(arr):
    arr.sort()
    count=0
    for elem in arr:
        if elem !=0 and elem != 1 :
            count +=1
        if count >1 :
            return False
    if count == 1:
        return True
    else:
        return False
print (isCritical([1, 1, 7, 1, 1]))
