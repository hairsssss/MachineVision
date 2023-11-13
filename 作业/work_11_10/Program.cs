using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace work_11_10 {
    internal class Program {
        static void Main(string[] args) {
            #region 1.收集常见异常处理问题
            // System.IO.IOException：处理 I/ O 错误，比如文件不存在或无法访问。
            // System.IndexOutOfRangeException：处理当方法指向超出范围的数组索引时生成的错误。
            // System.NullReferenceException：处理当依从一个空对象时生成的错误。
            // System.DivideByZeroException：处理当除以零时生成的错误。
            // System.InvalidCastException：处理在类型转换期间生成的错误。
            // System.OutOfMemoryException：处理空闲内存不足生成的错误。
            // System.StackOverflowException：处理栈溢出生成的错误。

            /*    try {
                    // 尝试除以零
                    int a = 10;
                    int b = 0;
                    int c = a / b;
                    Console.WriteLine("The result is {0}", c);
                } catch (DivideByZeroException ex) {
                    // 捕获除以零的异常
                    Console.WriteLine("An exception occurred: {0}------", ex.Message);
                    Console.WriteLine(ex.ToString() + "-----");
                    // 抛出异常
                    throw;
                } finally {
                    // 无论是否发生异常都要执行的代码
                    Console.WriteLine("The program ends.");
                }*/
            #endregion


            #region 2.在指定位置创建文件夹 然后创建10个文件    然后再把10个文件删除  （提示 Directory）
            // 使用 Directory 类的 GetCurrentDirectory 方法获取当前工作目录
            string currentPath = Directory.GetCurrentDirectory();
            // 使用 Directory 类的 GetParent 方法获取当前工作目录的父目录
            DirectoryInfo parentPath = Directory.GetParent(currentPath);
            // 使用 Directory 类的 GetParent 方法获取父目录的父目录，即解决方案路径
            DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName);

            //string folderPath = "D:\\A_material\\MachineVision\\作业\\work_11_10\\";
            string folderPath = solutionPath.ToString() + "\\testFolder";
            DirectoryAndFileHelper.CreatDirectory(folderPath.ToString());

            DirectoryAndFileHelper.CreateFiles("testFile", 10);
            Console.Write("是否删除刚创建的文件（Y/N）：");
            string input = Console.ReadLine().ToUpper();
            if (input == "Y") {
                DirectoryAndFileHelper.DeleteFiles();
            }

            #endregion


            #region 3.数据持久化版 登录注册    要求  账号和密码能存入 本地文件    再下次程序启动后 读取本地文件 继续使用注册过的账号
            AuthenticationManager.CreatFile();
            while (true) {
                Console.Write("1. 注册  ");
                Console.Write("2. 登录  ");
                Console.Write("3. 退出  ");
                Console.Write("请选择一个选项：");
                int op = int.Parse(Console.ReadLine());
                if (op == 1) {
                    AuthenticationManager.Register();
                } else if (op == 2) {
                    AuthenticationManager.Login();
                } else if (op == 3) {
                    Console.WriteLine("退出程序！");
                    break;
                } else {
                    Console.WriteLine("无效的选择");
                }
            }

            #endregion

            Console.ReadKey();
        }

        #region 2.在指定位置创建文件夹 然后创建10个文件    然后再把10个文件删除  （提示 Directory）
        public class DirectoryAndFileHelper {
            public static string FolderPath { get; set; }
            public static string FilePath { get; set; }
            public static int FileCount { get; set; }
            public static void CreatDirectory(string folderPath) {
                FolderPath = folderPath;
                //判断是否有该文件夹
                if (!Directory.Exists(folderPath)) {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine("文件夹创建成功");
                }

            }
            public static void CreateFiles(string fp, int fileCount) {
                FilePath = fp;
                FileCount = fileCount;
                for (int i = 0; i < fileCount; i++) {
                    string filePath = FolderPath + "\\" + fp + (i + 1) + ".txt";
                    if (!File.Exists(filePath)) {

                        using (FileStream file = File.Create(filePath)) {
                            Console.WriteLine($"{filePath} 文件创建成功");
                            Console.WriteLine("File {0} created with size {1}", file.Name, file.Length);
                            file.Close();
                            // 将文件路径拆分为目录和文件名
                            string directory = Path.GetDirectoryName(filePath);
                            string fileName = Path.GetFileName(filePath);
                            // 创建包含目录和文件名的字符串数组
                            string[] resultArray = { directory, fileName };
                            File.WriteAllLines(filePath, resultArray);
                        }
                    }

                }
            }

            public static void DeleteFiles() {
                // 输出文件是否存在的结果
                for (var i = 0; i < FileCount; i++) {
                    string filePath = FolderPath + "\\" + FilePath + i + 1 + ".txt";
                    Console.WriteLine(filePath + "---++++++----");
                    File.Delete(filePath);
                    // 输出文件是否存在的结果
                    if (!File.Exists(filePath)) {
                        Console.WriteLine("删除成功！");
                    }
                }
            }
        }
        #endregion


        #region 3.数据持久化版 登录注册  要求  账号和密码能存入 本地文件  再下次程序启动后 读取本地文件 继续使用注册过的账号
        public class UserInfo {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        public class AuthenticationManager {
            // 使用 Directory 类的 GetCurrentDirectory 方法获取当前工作目录
            public static string currentPath = Directory.GetCurrentDirectory();
            // 使用 Directory 类的 GetParent 方法获取当前工作目录的父目录
            public static DirectoryInfo parentPath = Directory.GetParent(currentPath);
            // 使用 Directory 类的 GetParent 方法获取父目录的父目录，即解决方案路径
            public static DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName);

            //文本存放地址
            public static string _filePath = solutionPath.ToString() + "\\userInfo.txt";
            public static List<UserInfo> UserList = new List<UserInfo> { };

            //创建存储用户名密码的txt文档
            public static void CreatFile() {
                if (!File.Exists(_filePath)) {
                    File.Create(_filePath).Close();
                } else {
                    string[] lines = File.ReadAllLines(_filePath);
                    foreach (string line in lines) {
                        string[] parts = line.Split(',');
                        UserList.Add(new UserInfo { UserName = parts[0], Password = parts[1] });
                    }
                }
            }

            // 登录
            public static void Login() {
                Console.Write("请输入账号：");
                string username = Console.ReadLine();
                Console.Write("请输入密码：");
                string password = Console.ReadLine();

                while (true) {
                    UserInfo user = UserList.Find(item => item.UserName == username);
                    if (user != null) {
                        while (true) {
                            Console.Write("请输入密码：");
                            string inputPassword = Console.ReadLine();
                            user = UserList.Find(item => item.UserName == username && item.Password == inputPassword);

                            if (user != null) {
                                Console.WriteLine($"用户 {username} 登录成功。");
                                break; // 登录成功，退出内部循环
                            } else {
                                Console.Write("密码错误，请重新输入密码：");
                            }
                        }
                        break; // 登录成功，退出外部循环
                    } else {
                        Console.Write("用户名不存在，请重新输入账号：");
                        username = Console.ReadLine();
                    }
                }

            }

            //注册
            public static void Register() {
                Console.Write("请输入账号：");
                string username = Console.ReadLine();

                while (true) {
                    if (!UserExists(username)) {
                        Console.Write("请输入密码：");
                        string password = Console.ReadLine();
                        while (true) {
                            if (password.Length < 6 || password.Length > 18) {
                                Console.Write("密码长度过长或过短，请重新输入：");
                                password = Console.ReadLine();
                            } else {
                                UserList.Add(new UserInfo { UserName = username, Password = password });
                                Console.WriteLine($"User {username}  注册成功");
                                using (StreamWriter writer = new StreamWriter(_filePath, true)) {
                                    writer.WriteLine($"{username},{password}");
                                    Console.WriteLine($"用户名密码已写入{_filePath}中");
                                }
                                break;
                            }
                        }
                        break;
                    } else {
                        Console.Write($"用户名 {username} 已被注册,请重新输入用户名：");
                        username = Console.ReadLine();
                    }
                }
            }

            //判断用户名是否重复
            private static bool UserExists(string username) {
                return UserList.Exists(item => item.UserName == username);
            }
        }
        #endregion


        #region 4.自己封装文件相关操作功能类
        public class FileHelper {
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

        #endregion
    }
}
