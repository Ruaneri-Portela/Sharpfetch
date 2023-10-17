namespace SharpFetch
{
    public struct TextData
    {
        public List<string> texts;
        public string color = "\u001b[31m";
        public string unsetcolor = "\u001b[0m";
        public TextData(string lang)
        {
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
                        "Total: ",
                        "Disponivel:",
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