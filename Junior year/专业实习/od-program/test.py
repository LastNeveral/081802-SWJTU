import pandas as pd

data1 = pd.read_excel('ans.xlsx',sheet_name=0)
data2 = pd.read_excel('ans.xlsx',sheet_name=1)

possion=data2.iloc[1,:]
data1.index = data1['OD']

maxN = 18 #站台数

ans = data1.iloc[:,1:maxN+1]
ans.loc[1:maxN-1,2:maxN]=0
Y = ans['上车人数'].copy()

for j in range(2,maxN):
    list1 = [Y[k]*possion[j-k] for k in range(1,j)]
    syp = sum(list1)
    if ans.loc['下车人数',j]==1:
        nn = list1.index(max(list1))+1
        i = nn
        ans.loc[i, j] = 1
        Y[i] = Y[i] - 1
    else:
        for i in range(1,j):
            ff = round((ans.loc['下车人数',j]*Y[i]*possion[j-i])/syp)
            ans.loc[i, j]=ff
            Y[i] = Y[i]-ff

ans.loc[1:maxN-1,maxN] = Y

print(ans)










