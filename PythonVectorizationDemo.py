
# coding: utf-8

# In[52]:

import numpy as np
import time


# In[53]:

arrA = np.random.rand(1, 1000000)


# In[54]:

print(arrA[0])


# In[55]:

arrB = np.random.rand(1000000,1)


# In[56]:

print(arrB[2])


# In[57]:

tic = time.time()
c = np.dot(arrA, arrB)
print(c[0])
toc = time.time()
diff = 1000*(toc - tic)
print(diff, " secs")


# In[58]:

t1 = time.time()
n = 0
for i in range(1,1000000):
    n += arrA[0][i]*arrB[i]
print(n)
t2 = time.time()
diff1 = 1000*(t2 - t1)
print(diff1, " secs")


# In[ ]:



