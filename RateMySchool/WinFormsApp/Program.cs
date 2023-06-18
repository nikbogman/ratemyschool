using Core.Entities.SchoolEntities;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.RepositoryInterfaces;
using DAL.Repositories;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms.Design;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}