public class WinForm {
    //���ô���λ�þ�����Ļ
    private void CenterFormOnScreen() {
        // ��ȡ����Ļ�Ĵ�С
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        // ���㴰�ڵ�λ��
        int formWidth = this.Width;
        int formHeight = this.Height;

        int x = (screenWidth - formWidth) / 2;
        int y = (screenHeight - formHeight) / 2;

        // ���ô���λ��
        this.Location = new Point(x, y);
    }
}