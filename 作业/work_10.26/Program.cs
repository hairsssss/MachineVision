using System;
using System.Collections.Generic;

namespace work_10._26 {
    internal class Program {
        static void Main(string[] args) {
            //1、一维数组  二维数组
            /*int[] intArr1 = { 1, 2, 3 };
            string[] strArr1 = { "张三", "李四", "王五", "赵六" };
            double[] doubleArr1 = { 1.1, 2.2, 3.3, 4, 4 };
            bool[] boolArr1 = { true, false, true };
            float[] floatArr1 = { 9.9f, 8.8f, 7.7f };

            int[,] intArr2 = { { 1, 2 }, { 3, 4 } };
            string[,] strArr2 = { { "赵", "钱" }, { "孙", "李" } };
            double[,] doubleArr2 = { { 1.1, 2.2 }, { 3.3, 4.4 } };
            bool[,] boolArr2 = { { true, false }, { false, false } };
            float[,] floatArr2 = { { 1.23f, 2.232f }, { 3.333f, 4.444f } };
*/
            //2、4 5 6 维数组
            /*string[,,,] stringArr4 = new string[3, 4, 2, 2]
            {
                {
                    {
                        { "富强", "民主" },
                        { "文明", "和谐" }
                    },
                    {
                        { "自由", "平等" },
                        { "公正", "法治" }
                    },
                    {
                        { "爱国", "敬业" },
                        { "诚信", "友善" }
                    },
                    {
                        { "富强", "民主" },
                        { "文明", "和谐" }
                    }
                },
                {
                    {
                        { "自由", "平等" },
                        { "公正", "法治" }
                    },
                    {
                        { "爱国", "敬业" },
                        { "诚信", "友善" }
                    },
                    {
                        { "富强", "民主" },
                        { "文明", "和谐" }
                    },
                    {
                        { "自由", "平等" },
                        { "公正", "法治" }
                    }
                },
                {
                    {
                        { "爱国", "敬业" },
                        { "诚信", "友善" }
                    },
                    {
                        { "富强", "民主" },
                        { "文明", "和谐" }
                    },
                    {
                        { "自由", "平等" },
                        { "公正", "法治" }
                    },
                    {
                        { "爱国", "敬业" },
                        { "诚信", "友善" }
                    }
                }
            };
            for (int i = 0; i < stringArr4.GetLength(0); i++) {
                for (int j = 0; j < stringArr4.GetLength(1); j++) {
                    for (int k = 0; k < stringArr4.GetLength(2); k++) {
                        for (int l = 0; l < stringArr4.GetLength(3); l++) {
                            Console.WriteLine(stringArr4[i, j, k, l]);
                        }
                    }
                }
            }*/
            //5维数组
            /*   double[,,,,] doubleArr5 = new double[2, 3, 4, 5, 6];
               for (int i = 0; i < 2; i++) {
                   for (int j = 0; j < 3; j++) {
                       for (int k = 0; k < 4; k++) {
                           for (int l = 0; l < 5; l++) {
                               for (int m = 0; m < 6; m++) {
                                   doubleArr5[i, j, k, l, m] = 8.8; // 初始化为0.0，您可以根据需要修改初始值
                               }
                           }
                       }
                   }
               }
               for (int i = 0; i < doubleArr5.GetLength(0); i++) {
                   for (int j = 0; j < doubleArr5.GetLength(1); j++) {
                       for (int k = 0; k < doubleArr5.GetLength(2); k++) {
                           for (int l = 0; l < doubleArr5.GetLength(3); l++) {
                               for (int m = 0; m < doubleArr5.GetLength(4); m++) {
                                   Console.WriteLine(doubleArr5[i, j, k, l, m]);
                               }
                           }
                       }
                   }
               }
   */
            //6维数组
            /*   bool[,,,,,] boolArray6 = new bool[2, 3, 4, 5, 6, 7];
               int totalElements = boolArray6.Length;
               int trueCount = totalElements / 2;

               Random random = new Random();

               for (int i = 0; i < 2; i++) {
                   for (int j = 0; j < 3; j++) {
                       for (int k = 0; k < 4; k++) {
                           for (int l = 0; l < 5; l++) {
                               for (int m = 0; m < 6; m++) {
                                   for (int n = 0; n < 7; n++) {
                                       if (trueCount > 0) {
                                           boolArray6[i, j, k, l, m, n] = true;
                                           trueCount--;
                                       } else {
                                           boolArray6[i, j, k, l, m, n] = false;
                                       }
                                   }
                               }
                           }
                       }
                   }
               }

               int[] dimensions = new int[boolArray6.Rank];
               for (int i = 0; i < dimensions.Length; i++) {
                   dimensions[i] = boolArray6.GetLength(i);
               }

               for (int i = 0; i < dimensions[0]; i++) {
                   for (int j = 0; j < dimensions[1]; j++) {
                       for (int k = 0; k < dimensions[2]; k++) {
                           for (int l = 0; l < dimensions[3]; l++) {
                               for (int m = 0; m < dimensions[4]; m++) {
                                   for (int n = 0; n < dimensions[5]; n++) {
                                       Console.WriteLine(boolArray6[i, j, k, l, m, n]);
                                   }
                               }
                           }
                       }
                   }
               }*/

            //3、
            List<string> nameArr = new List<string>();
            List<int> ageArr = new List<int>();
            List<int> genderArr = new List<int>();
            List<double> scoreArr = new List<double>();
            while (true) {
                Console.Write("请输入学生名字：");
                nameArr.Add(Console.ReadLine());

                Console.Write("请输入该学生的成绩：");
                while (true) {
                    if (double.TryParse(Console.ReadLine(), out double score)) {
                        if (score >= 0 && score <= 100) {
                            scoreArr.Add(score);
                            break;
                        } else {
                            Console.Write("格式错误，请重新输入：");
                        }
                    } else {
                        Console.Write("格式错误，请重新输入：");
                    }
                }

                Console.Write("请输入该学生的年龄：");
                while (true) {
                    if (int.TryParse(Console.ReadLine(), out int age)) {
                        if (age >= 18 && age <= 20) {
                            ageArr.Add(age);
                            break;
                        } else {
                            Console.Write("格式错误，请重新输入：");
                        }
                    } else {
                        Console.Write("格式错误，请重新输入：");
                    }
                }

                Console.Write("请输入该学生的性别：");
                while (true) {
                    string genderStr = Console.ReadLine();
                    if (genderStr != "男" && genderStr != "女") {
                        Console.Write("格式错误，请重新输入：");
                    } else {
                        if (genderStr == "男") {
                            genderArr.Add(1);
                            break;
                        } else {
                            genderArr.Add(1);
                            break;
                        }
                    }
                }

                for (int i = 0; i < genderArr.Count; i++) {
                    string gender1 = genderArr[i] == 0 ? "女" : "男";
                    Console.WriteLine($"{i + 1}、{nameArr[i]}性别{gender1}年龄{ageArr[i]}考了{scoreArr[i]}分");
                }

                Console.Write("是否修改学生信息（Y/N）");
                while (true) {
                    string isRevise = Console.ReadLine();
                    if (isRevise.ToUpper() != "Y" && isRevise.ToUpper() != "N") {
                        Console.Write("格式错误，请重新输入：");
                    } else {
                        if (isRevise.ToUpper() == "N") {
                            break;
                        } else {
                            Console.Write("请输入要修改的学生的编号：");
                            while (true) {
                                if (int.TryParse(Console.ReadLine(), out int serialNumber)) {
                                    Console.Write("请输入要修改后的学生成绩：");
                                    while (true) {
                                        if (double.TryParse(Console.ReadLine(), out double score)) {
                                            if (score >= 0 && score <= 100) {
                                                string gender2 = genderArr[serialNumber - 1] == 0 ? "女" : "男";
                                                scoreArr[serialNumber - 1] = score;
                                                Console.WriteLine($"修改成功、{nameArr[serialNumber - 1]}性别{gender2}年龄{ageArr[serialNumber - 1]}考了{scoreArr[serialNumber - 1]}分");
                                                break;
                                            } else {
                                                Console.Write("格式错误，请重新输入：");
                                            }
                                            break;
                                        } else {
                                            Console.Write("格式错误，请重新输入：");
                                        }
                                    }
                                    break;
                                } else {
                                    Console.Write("格式错误，请重新输入：");
                                }
                            }
                            break;
                        }
                    }

                }
                Console.Write("是否继续录入学生信息（Y/N）：");
                bool boolIsEnter = true;
                while (true) {
                    string isEnter = Console.ReadLine();
                    if (isEnter.ToUpper() != "Y" && isEnter.ToUpper() != "N") {
                        Console.Write("格式错误，请重新输入：");
                    } else {
                        if (isEnter.ToUpper() == "N") {
                            boolIsEnter = true;
                            Console.WriteLine(genderArr.Count);
                            for (int i = 0; i < genderArr.Count; i++) {
                                string gender3 = genderArr[i] == 0 ? "女" : "男";
                                Console.WriteLine($"{i + 1}、{nameArr[i]}性别{gender3}年龄{ageArr[i]}考了{scoreArr[i]}分");
                            }
                            break;
                        } else {
                            boolIsEnter = false;
                            break;
                        }
                    }
                }
                if (boolIsEnter) {
                    break;
                }
            }
        }
    }
}
