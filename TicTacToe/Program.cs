using System;

namespace TicTacToe
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            App a = new App();
            a.Run();
        }
    }
}
