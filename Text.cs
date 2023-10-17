namespace SharpFetch
{
    public struct TextData
    {
        public List<string> texts;
        public string color;
        public string unsetcolor = "\u001b[0m";

        public string lang;
        public TextData(string langEntry, string colorEntry = "\u001b[31m")
        {
            lang = langEntry;
            color = colorEntry;
            switch (lang)
            {
                case "pt-BR":
                    texts = new List<string>(){
                        color+"Versão do SO: "+unsetcolor,
                        color+"Arquitetura: "+unsetcolor,
                        color+"Tempo Ativo: "+unsetcolor,
                        color+"CPU: "+unsetcolor,
                        color+"Maquina: "+unsetcolor,
                        color+"Pacotes: "+unsetcolor,
                        color+"Memoria: "+unsetcolor,
                        "Usada:",
                        "Disponivel:",
                        color+"GPU: "+unsetcolor,
                        color+"Disco: "+unsetcolor,
                        "Total:",
                        "Disponivel:"
                    };
                    break;
                case "ja-JP":
                    texts = new List<string>()
                    {
                    color + "OS バージョン: " + unsetcolor,
                    color + "アーキテクチャ: " + unsetcolor,
                    color + "アクティブ時間: " + unsetcolor,
                    color + "CPU: " + unsetcolor,
                    color + "マシン: " + unsetcolor,
                    color + "パッケージ: " + unsetcolor,
                    color + "メモリ: " + unsetcolor,
                    "使用中:",
                    "利用可能:",
                    color + "GPU: " + unsetcolor,
                    color + "ディスク: " + unsetcolor,
                    "合計:",
                    "利用可能:"
                    };
                    break;
                case "ru-RU":
                    texts = new List<string>()
                    {
                    color + "Версия ОС: " + unsetcolor,
                    color + "Архитектура: " + unsetcolor,
                    color + "Активное время: " + unsetcolor,
                    color + "ЦП: " + unsetcolor,
                    color + "Машина: " + unsetcolor,
                    color + "Пакеты: " + unsetcolor,
                    color + "Память: " + unsetcolor,
                    "Используется:",
                    "Доступно:",
                    color + "Графический процессор: " + unsetcolor,
                    color + "Диск: " + unsetcolor,
                    "Всего:",
                    "Доступно:"
                    };
                    break;
                case "de-DE":
                    texts = new List<string>()
                    {
                    color + "Betriebssystemversion: " + unsetcolor,
                    color + "Architektur: " + unsetcolor,
                    color + "Aktive Zeit: " + unsetcolor,
                    color + "CPU: " + unsetcolor,
                    color + "Maschine: " + unsetcolor,
                    color + "Pakete: " + unsetcolor,
                    color + "Arbeitsspeicher: " + unsetcolor,
                    "In Verwendung:",
                    "Verfügbar:",
                    color + "GPU: " + unsetcolor,
                    color + "Festplatte: " + unsetcolor,
                    "Gesamt:",
                    "Verfügbar:"
                    };
                    break;
                case "es-ES":
                    texts = new List<string>()
                    {
                    color + "Versión del SO: " + unsetcolor,
                    color + "Arquitectura: " + unsetcolor,
                    color + "Tiempo activo: " + unsetcolor,
                    color + "CPU: " + unsetcolor,
                    color + "Máquina: " + unsetcolor,
                    color + "Paquetes: " + unsetcolor,
                    color + "Memoria: " + unsetcolor,
                    "Usada:",
                    "Disponible:",
                    color + "GPU: " + unsetcolor,
                    color + "Disco: " + unsetcolor,
                    "Total:",
                    "Disponible:"
                    };
                    break;
                case "fr-FR":
                    texts = new List<string>()
                    {
                    color + "Version du système d'exploitation : " + unsetcolor,
                    color + "Architecture : " + unsetcolor,
                    color + "Temps actif : " + unsetcolor,
                    color + "CPU : " + unsetcolor,
                    color + "Machine : " + unsetcolor,
                    color + "Packages : " + unsetcolor,
                    color + "Mémoire : " + unsetcolor,
                    "Utilisée :",
                    "Disponible :",
                    color + "GPU : " + unsetcolor,
                    color + "Disque : " + unsetcolor,
                    "Total :",
                    "Disponible :"
                    };
                    break;
                default:
                    texts = new List<string>(){
                        color+"OS Version: "+unsetcolor,
                        color+"Architecture: "+unsetcolor,
                        color+"Uptime: "+unsetcolor,
                        color+"CPU: "+unsetcolor,
                        color+"Host: "+unsetcolor,
                        color+"Packges: "+unsetcolor,
                        color+"Memory: "+unsetcolor,
                        "Used:",
                        "Avaliable:",
                        color+"GPU: "+unsetcolor,
                        color+"Disco: "+unsetcolor,
                        "Total:",
                        "Available:",
                    };
                    break;
            }
        }
    };
    struct SplashData
    {
        public List<string> asciiArt;
        public SplashData(int i)
        {
            asciiArt = new List<string>();
            string e;
            int t;
            switch (i)
            {
                case 0:
                    e = "\u001b";
                    t = 0;
                    asciiArt = new List<string>()
                    {
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34m                                 ",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll",
                    $"{e}[{t};34mlllllllllllllll   lllllllllllllll"
                    };
                    break;
                case 1:
                    e = "\u001b";
                    t = 0;
                    asciiArt = new List<string>()
                    {
                    $"{e}[{t};31m       _,met$$$$$gg.      ",
                    $"{e}[{t};31m    ,g$$$$$$$$$$$$$$$P.   ",
                    $"{e}[{t};31m  ,g$$P\"     \"\"\"Y$$\".",
                    $"{e}[{t};31m ,$$P'              `$$$. ",
                    $"{e}[{t};31m',$$P       ,ggs.     `$$b",
                    $"{e}[{t};31m`d$$'     ,$P\"   .    $$$",
                    $"{e}[{t};31m $$P      d$'     ,    $$P",
                    $"{e}[{t};31m $$:      $$.   -    ,d$$'",
                    $"{e}[{t};31m $$;      Y$b._   _,d$P'  ",
                    $"{e}[{t};31m Y$$.    `.`\"Y$$$$P\"'   ",
                    $"{e}[{t};31m `$$b      \"-.__         ",
                    $"{e}[{t};31m  `Y$$                    ",
                    $"{e}[{t};31m   `Y$$.                  ",
                    $"{e}[{t};31m     `$$b.                ",
                    $"{e}[{t};31m       `Y$$b.             ",
                    $"{e}[{t};31m          `\"Y$b._        ",
                    $"{e}[{t};31m              `\"\"\"     "
                    };
                    break;
            }

        }
    }
}