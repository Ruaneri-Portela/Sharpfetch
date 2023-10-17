using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Globalization;
using System.Text.RegularExpressions;
namespace SharpFetch
{
    class Program
    {
        static CultureInfo currentCulture = CultureInfo.CurrentCulture;
        static TextData data = new TextData(currentCulture.Name);
        static string osPlatform = RuntimeInformation.OSDescription;
        static string systemArch = RuntimeInformation.OSArchitecture.ToString();
        static string hostName = Dns.GetHostName();
        static string userName = Environment.UserName;
        static TimeSpan uptime = TimeSpan.FromMilliseconds(Environment.TickCount);
        static string barSpace = "    ";
        static void Main(string[] args)
        {
            string formatCharset = @"d\ \.hh\ \:mm\ \:ss";
            string formatedTime = uptime.ToString(formatCharset);
            List<string> localList = new List<string>();
            localList.Add(data.color + userName + data.unsetcolor + "@" + data.color + hostName + data.unsetcolor);
            localList.Add("------------------------");
            localList.Add(data.texts[0] + osPlatform);
            localList.Add(data.texts[1] + systemArch);
            localList.Add(data.texts[2] + formatedTime);
            if (osPlatform.Contains("Windows"))
            {
                List<string> mergeList = localList.Concat(FetchWindows()).ToList();
                int index = 0;
                int size = mergeList.Count - 1;
                SplashData splash = new SplashData(0);
                foreach (string line in splash.asciiArt)
                {
                    Console.Write(line + "    ");
                    if (size >= index)
                    {
                        Console.Write(mergeList[index]);
                    }
                    else if (size + 1 >= index)
                    {
                        Console.Write("");
                    }
                    else if (size + 2 >= index)
                    {
                        DarkBar();
                    }
                    else if (size + 3 >= index)
                    {
                        Bar();
                    };
                    Console.WriteLine();
                    index++;
                }
            }
        }
        static List<string> FetchWindows()
        {
            List<string> localList = new List<string>();
            localList.Add(data.texts[3] + QueryReg("HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0", "ProcessorNameString"));
            localList.Add(data.texts[4] + QueryReg("HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\BIOS", "SystemFamily"));
            string[] parts = ListReg("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\").Split("\n");
            localList.Add(data.texts[5] + (parts.Length - 1));
            string[] parts2 = QueryWmic("OS get FreePhysicalMemory, TotalVisibleMemorySize").Split("\n");
            string[] parts3 = QueryWmic("path win32_videocontroller get caption").Split("\n");
            string pattern = @"\d+";
            MatchCollection matches = Regex.Matches(parts2[1], pattern);
            List<string> memory = new List<string>();
            foreach (Match match in matches)
            {
                memory.Add(match.Value);
            }
            localList.Add(data.texts[6] + data.texts[7] + memory[0] + "KB / " + data.texts[8] + memory[1] + "KB");
            parts3[1].Replace("\r\r", "");
            localList.Add(data.texts[9] + parts3[1]);
            return localList;
        }
        static string QueryReg(string reg, string value)
        {
            string query;
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "reg.exe",
                Arguments = $"query \"{reg}\" /v {value}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                int index = output.IndexOf("REG_SZ");
                query = output.Substring(index + "REG_SZ".Length).Trim();
            };
            return query;
        }
        static string ListReg(string value)
        {
            string searchResult = "";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "reg.exe",
                Arguments = $"query {value}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                searchResult = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            };
            return searchResult;
        }
        static string QueryWmic(string value)
        {
            string queryReturn = "";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "wmic.exe",
                Arguments = $"{value}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                queryReturn = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            };
            return queryReturn;
        }
        static void DarkBar()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ResetColor();
        }
        static void Bar()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write(barSpace);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ResetColor();
        }
    }
};