#### 1.c#和VisionPro联合编程时，使用ICogFrameGrabber连接相机，初始化相机提示找不到相机。

​		属性中目标平台取消首选32位的勾选。

#### 2.连接相机是设置端口不能正常拍照。

​		摄像头的端口为0时，表示使用默认端口。默认端口是每个摄像头独有的，通常为0。因此，在这种情况下，可以正常加载相机并拍照。

​		当摄像头的端口为8080时，表示使用非默认端口。非默认端口可能被其他摄像头或其他设备占用。因此，在这种情况下，如果其他摄像头或设备正在使用端口8080，则会导致无法加载相机或拍照。

可以通过以下方法解决此问题：

- 检查是否有其他摄像头或设备正在使用端口8080。如果有，则可以将相机的端口改为其他可用端口。
- 使用摄像头的 IP 地址和端口来连接相机。例如，如果摄像头的 IP 地址为 192.168.1.10，端口为 8080，则可以使用以下代码来连接相机：

```C# 
        // 创建CogFrameGrabbers对象，获取所有的硬件 用于存放所有的硬件相机对象
        CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();

        // 根据CogFrameGrabbers元素个数 判断是否存在相机对象
        if (frameGrabbers.Count < 1) {
           MessageBox.Show("没有找到相机！");
           return;
        }

        // 遍历集合
        foreach (ICogFrameGrabber item in frameGrabbers) {
           frameGrabber = item;

           // 设置相机IP地址
           frameGrabber.IPAddress = "192.168.1.10";

           // 设置相机端口
           frameGrabber.Port = 8080;

           // 创建采集接口对象
           acqFifo = frameGrabber.CreateAcqFifo("Generic GigEVision (Mono)",CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
        }
```

