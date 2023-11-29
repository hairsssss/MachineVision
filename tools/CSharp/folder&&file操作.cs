public class FileHelper {
    // ʹ�� Directory ��� GetCurrentDirectory ������ȡ��ǰ����Ŀ¼
    string currentPath = Directory.GetCurrentDirectory();
    // ʹ�� Directory ��� GetParent ������ȡ��ǰ����Ŀ¼�ĸ�Ŀ¼
    DirectoryInfo parentPath = Directory.GetParent(currentPath);
    // ʹ�� Directory ��� GetParent ������ȡ��Ŀ¼�ĸ�Ŀ¼�����������·��
    DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName)



    //�����ļ���
    public static void CreateDirectory(string folderPath) {
        if (!Directory.Exists(folderPath)) {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"�ļ��� {folderPath} �����ɹ�");
        } else {
            Console.WriteLine($"�ļ��� {folderPath} �Ѵ���");
        }
    }

    //ɾ���ļ���
    public static void DeleteDirectory(string folderPath) {
        if (Directory.Exists(folderPath)) {
            Directory.Delete(folderPath, true); // �ڶ���������ʾ�ݹ�ɾ�����ļ��к��ļ�
            Console.WriteLine($"�ļ��� {folderPath} ɾ���ɹ�");
        } else {
            Console.WriteLine($"�ļ��� {folderPath} �����ڣ��޷�ɾ��");
        }
    }

    //ɾ���ļ����������ļ�
    public static void DeleteAllFilesInDirectory(string folderPath) {
        if (Directory.Exists(folderPath)) {
            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files) {
                File.Delete(file);
                Console.WriteLine($"�ļ� {file} ɾ���ɹ�");
            }

            Console.WriteLine($"�ļ��� {folderPath} �µ������ļ�ɾ���ɹ�");
        } else {
            Console.WriteLine($"�ļ��� {folderPath} �����ڣ��޷�ɾ���ļ�");
        }
    }

    //�����ļ�
    public static void CreateFile(string filePath) {
        if (!File.Exists(filePath)) {
            File.Create(filePath).Close();
            Console.WriteLine($"�ļ� {filePath} �����ɹ�");
        } else {
            Console.WriteLine($"�ļ� {filePath} �Ѵ���");
        }
    }

    //ɾ���ļ�
    public static void DeleteFile(string filePath) {
        if (File.Exists(filePath)) {
            File.Delete(filePath);
            Console.WriteLine($"�ļ� {filePath} ɾ���ɹ�");
        } else {
            Console.WriteLine($"�ļ� {filePath} �����ڣ��޷�ɾ��");
        }
    }

    //д������
    public static void WriteToFile(string filePath, string content) {
        try {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"����д���ļ� {filePath} �ɹ�");
        } catch (Exception ex) {
            Console.WriteLine($"д���ļ� {filePath} ʱ�����쳣: {ex.Message}");
        }
    }

    //��ȡ�ļ�����
    public static string ReadFromFile(string filePath) {
        try {
            string content = File.ReadAllText(filePath);
            Console.WriteLine($"���ļ� {filePath} ��ȡ���ݳɹ�");
            return content;
        } catch (Exception ex) {
            Console.WriteLine($"��ȡ�ļ� {filePath} ʱ�����쳣: {ex.Message}");
            return null;
        }
    }
}