from  PIL import  Image
import  os
import  random
file=os.listdir(r'C:/Users/lilywang/Desktop/xx1') #目录
c=1
for  f  in file:
    print(f)
    im1 = Image.open(r'C:/Users/lilywang/Desktop/xx1/'+f)
    x=random.randint(0,10)
    im2 = im1.rotate(x)
    # im2.show()
    im2.save(r'C:/Users/lilywang/Desktop/xx2/y'+str(c)+".bmp")
    c=c+1