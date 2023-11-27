import cv2 as cv

def image_blur(image_path: str):
    """
    图像卷积操作：设置卷积核大小，步距
    :param image_path:
    :return:
    """
    img = cv.imread(image_path, cv.IMREAD_COLOR)
    cv.imshow('input', img)
    # 模糊操作（类似卷积），第二个参数ksize是设置模糊内核大小
    result = cv.blur(img, (7, 7))
    cv.imshow('result', result)
    cv.imwrite('bb.bmp', result)

    cv.waitKey(0)
    cv.destroyAllWindows()


if __name__ == '__main__':
    path = 's3.bmp'
    image_blur(path)
