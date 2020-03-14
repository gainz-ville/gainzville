namespace Gainzville.Desktop
{
    using System;
    using WebWindows;

    class Program
    {
        static void Main(string[] args)
        {
            var window = new WebWindow("Gainzville");
            window.NavigateToLocalFile("wwwroot/index.html");
            window.WaitForExit();
        }
    }
}