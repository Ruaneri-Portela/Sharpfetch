using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
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
        static string barSpace = "   ";
        static void Main(string[] args)
        {
            int argc = args.Count();
            string execTerm = "";
            string outMsg = "";
            if (argc > 0)
            {
                for (int i = 0; i < argc; i++)
                {
                    switch (args[i])
                    {
                        case "-h":
                        case "--help":
                            Console.WriteLine("Sharpfetch help\n\n" +
                                "  -h, --help\t\t\tShow this help message\n" +
                                "  -v, --version\t\t\tShow version\n" +
                                "  -s, --setcolor <color>\t\tSet color\n" +
                                "  -n, --nocolor\t\t\tDisable color\n" +
                                "  -l, --language <language>\t\tSet language\n" +
                                "  -e, --exec <program>\t\tExec program on end show Sharpfetch\n"+
                                "  -b, --beep \t\tbeeep sound" +
                                "  -m, --mensagem <text>\t\tWrite custrom mensagem on exit\n");
                            return;
                        case "-v":
                        case "--version":
                            Console.WriteLine("Sharpfetch version 0.0.1");
                            return;
                        case "-s":
                        case "--setcolor":
                            if (i + 1 < argc)
                            {
                                data = new TextData(data.lang, args[i + 1]);
                            }
                            else
                            {
                                Console.WriteLine("Error: Missing argument for option: " + args[i]);
                                return;
                            }
                            break;
                        case "-n":
                        case "--nocolor":
                            data = new TextData(data.lang, data.unsetcolor);
                            break;
                        case "-l":
                        case "--language":
                            if (i + 1 < argc)
                            {
                                data = new TextData(args[i + 1], data.color);
                            }
                            else
                            {
                                Console.WriteLine("Error: Missing argument for option: " + args[i]);
                                return;
                            }
                            break;
                        case "-b":
                        case "--beep":
                            Console.Beep();
                            break;
                        case "-e":
                        case "--exec":
                            if (i + 1 < argc)
                            {
                                execTerm = args[i + 1];
                            }
                            else
                            {
                                Console.WriteLine("Error: Missing argument for option: " + args[i]);
                                return;
                            }
                            break;
                        case "-m":
                        case "--mensagem":
                            if (i + 1 < argc)
                            {
                                outMsg = args[i + 1];
                            }
                            else
                            {
                                Console.WriteLine("Error: Missing argument for option: " + args[i]);
                                return;
                            }
                            break;
                    }
                }
            }
            //Format uptime
            string formatCharset = @"d\ \.hh\ \:mm\ \:ss";
            string formatedTime = uptime.ToString(formatCharset);
            List<string> localList = new List<string>();
            //Create common headers
            localList.Add(data.color + userName + data.unsetcolor + "@" + data.color + hostName + data.unsetcolor);
            localList.Add(data.color + "------------------------");
            localList.Add(data.texts[0] + osPlatform);
            localList.Add(data.texts[1] + systemArch);
            localList.Add(data.texts[2] + formatedTime);
            // Choice by os
            if (osPlatform.Contains("Windows"))
            {
                // Get version and check if windows 11
                string space = "";
                int splashSet;
                int ver = int.Parse(QueryReg("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentBuild"));
                if (ver > 19045)
                {
                    localList[2] = data.texts[0] + "Windows 11";
                    space = "   ";
                    splashSet = 0;
                }
                else
                {
                    localList[2] = data.texts[0] + "Windows 10";
                    space = "";
                    splashSet = 2;
                }
                // Check variant
                string variant = QueryReg("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "EditionID");
                localList[2] += " " + variant;
                localList[3] += " NT " + ver;
                // Append Windows Comuns data
                List<string> mergeList = localList.Concat(FetchWindows()).ToList();
                int index = 0;
                int size = mergeList.Count - 1;
                // Import splash
                SplashData splash = new SplashData(splashSet);
                foreach (string line in splash.asciiArt)
                {
                    Console.Write(line + space);
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
            else if (osPlatform.Contains("Debian"))
            {
                // Get version
                string[] version = GenericQuery("lsb_release", "-d").Split("\n");
                int debianIndex = version[0].IndexOf("Debian");
                localList[2] = data.texts[0] + version[0].Substring(debianIndex).Trim();
                // Get Packges
                string[] parts = GenericQuery("dpkg", "--get-selections").Split("\n");
                localList.Add(data.texts[5] + (parts.Length - 1));
                // Merge with linux communs data
                List<string> mergeList = localList.Concat(FetchLinux()).ToList();
                int index = 0;
                int size = mergeList.Count - 1;
                // Import splash
                SplashData splash = new SplashData(1);
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
            Console.ForegroundColor = ConsoleColor.Gray;
            if (execTerm.Length > 0)
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = execTerm,
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    CreateNoWindow = true
                };
                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    process.WaitForExit();
                };
            }
            Console.WriteLine(outMsg);
        }
        static List<string> FetchLinux()
        {
            List<string> localList = new List<string>();
            return localList;
        }
        static List<string> FetchWindows()
        {
            List<string> localList = new List<string>();
            // Get Packges
            string[] parts = GenericQuery("reg", "query HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\").Split("\n");
            localList.Add(data.texts[5] + (parts.Length - 1));
            // Get CPU and SysName
            localList.Add(data.texts[4] + QueryReg("HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\BIOS", "SystemFamily"));
            localList.Add(data.texts[3] + QueryReg("HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0", "ProcessorNameString"));
            // Get GPU
            string[] parts3 = GenericQuery("wmic", "path win32_videocontroller get caption").Split("\n");
            parts3[1].Replace("\r\r", "");
            localList.Add(data.texts[9] + parts3[1]);
            // Get memory
            string[] parts2 = GenericQuery("wmic", "OS get FreePhysicalMemory, TotalVisibleMemorySize").Split("\n");
            string pattern = @"\d+";
            MatchCollection matches = Regex.Matches(parts2[1], pattern);
            List<string> memory = new List<string>();
            foreach (Match match in matches)
            {
                double value = double.Parse(match.Value) / 1028;
                memory.Add(value.ToString("F2"));
            }
            localList.Add(data.texts[6] + data.texts[7] + memory[0] + " MB / " + data.texts[8] + memory[1] + " MB");
            // Get disk space
            string rootDriveLetter = QueryReg("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "PathName");
            DriveInfo drive = new DriveInfo(rootDriveLetter.Substring(0));
            long free = drive.AvailableFreeSpace;
            long space = drive.TotalSize;
            string freeSpaceInGB = (free / (1024 * 1024 * 1024.0)).ToString("F2");
            string spaceInGB = (space / (1024 * 1024 * 1024.0)).ToString("F2");
            localList.Add(data.texts[10] + data.texts[12] + freeSpaceInGB + " GB / " + data.texts[11] + spaceInGB + " GB");
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
        static string GenericQuery(string exec, string args)
        {
            string queryReturn = "";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = exec,
                Arguments = args,
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
            Console.Write(barSpace);
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
            Console.Write(barSpace);
            Console.ResetColor();
        }
    }
};