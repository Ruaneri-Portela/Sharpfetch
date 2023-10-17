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
            string e = "\u001b";
            int t = 0;
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
        }
    }
}