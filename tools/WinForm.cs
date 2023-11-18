public class WinForm {
    //设置窗口位置居中屏幕
    private void CenterFormOnScreen() {
        // 获取主屏幕的大小
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        // 计算窗口的位置
        int formWidth = this.Width;
        int formHeight = this.Height;

        int x = (screenWidth - formWidth) / 2;
        int y = (screenHeight - formHeight) / 2;

        // 设置窗口位置
        this.Location = new Point(x, y);
    }
}