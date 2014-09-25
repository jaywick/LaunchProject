using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchProject
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var args = Environment.GetCommandLineArgs().Skip(1).ToList();

            if (!args.Any())
                return;

            var directory = new DirectoryInfo(args[0]);
            var solutions = directory.GetFiles("*.sln", SearchOption.AllDirectories);

            if (solutions.Length > 1)
            {
                MessageBox.Show(solutions.Length + " project files found");
            }
            else if (solutions.Length == 0)
            {
                MessageBox.Show("Zero project files found");
            }
            else
            {
                Process.Start(solutions.Single().FullName);
            }
        }
    }
}
