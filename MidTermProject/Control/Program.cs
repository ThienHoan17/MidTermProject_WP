﻿using Lab08;
using MidTermProject.View.Courses_management;
using MidTermProject.View.Result;
using System;
using System.Windows.Forms;

namespace MidTermProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
