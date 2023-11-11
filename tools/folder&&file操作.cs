public class FileHelper {
    // 使用 Directory 类的 GetCurrentDirectory 方法获取当前工作目录
    string currentPath = Directory.GetCurrentDirectory();
    // 使用 Directory 类的 GetParent 方法获取当前工作目录的父目录
    DirectoryInfo parentPath = Directory.GetParent(currentPath);
    // 使用 Directory 类的 GetParent 方法获取父目录的父目录，即解决方案路径
    DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName)



    //创建文件夹
    public static void CreateDirectory(string folderPath) {
        if (!Directory.Exists(folderPath)) {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"文件夹 {folderPath} 创建成功");
        } else {
            Console.WriteLine($"文件夹 {folderPath} 已存在");
        }
    }

    //删除文件夹
    public static void DeleteDirectory(string folderPath) {
        if (Directory.Exists(folderPath)) {
            Directory.Delete(folderPath, true); // 第二个参数表示递归删除子文件夹和文件
            Console.WriteLine($"文件夹 {folderPath} 删除成功");
        } else {
            Console.WriteLine($"文件夹 {folderPath} 不存在，无法删除");
        }
    }

    //删除文件夹下所有文件
    public static void DeleteAllFilesInDirectory(string folderPath) {
        if (Directory.Exists(folderPath)) {
            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files) {
                File.Delete(file);
                Console.WriteLine($"文件 {file} 删除成功");
            }

            Console.WriteLine($"文件夹 {folderPath} 下的所有文件删除成功");
        } else {
            Console.WriteLine($"文件夹 {folderPath} 不存在，无法删除文件");
        }
    }

    //创建文件
    public static void CreateFile(string filePath) {
        if (!File.Exists(filePath)) {
            File.Create(filePath).Close();
            Console.WriteLine($"文件 {filePath} 创建成功");
        } else {
            Console.WriteLine($"文件 {filePath} 已存在");
        }
    }

    //删除文件
    public static void DeleteFile(string filePath) {
        if (File.Exists(filePath)) {
            File.Delete(filePath);
            Console.WriteLine($"文件 {filePath} 删除成功");
        } else {
            Console.WriteLine($"文件 {filePath} 不存在，无法删除");
        }
    }

    //写入内容
    public static void WriteToFile(string filePath, string content) {
        try {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"内容写入文件 {filePath} 成功");
        } catch (Exception ex) {
            Console.WriteLine($"写入文件 {filePath} 时发生异常: {ex.Message}");
        }
    }

    //读取文件内容
    public static string ReadFromFile(string filePath) {
        try {
            string content = File.ReadAllText(filePath);
            Console.WriteLine($"从文件 {filePath} 读取内容成功");
            return content;
        } catch (Exception ex) {
            Console.WriteLine($"读取文件 {filePath} 时发生异常: {ex.Message}");
            return null;
        }
    }
}