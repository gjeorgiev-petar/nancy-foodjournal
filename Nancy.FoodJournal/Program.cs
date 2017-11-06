﻿using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace Nancy.FoodJournal
{
    class Program
    {
        private static readonly ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var port = 8080;
            if(args.Length > 0)
            {
                int.TryParse(args[0], out port);
            }

            Console.CancelKeyPress += (sender, eArgs) =>
            {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            using (WebApp.Start<Startup>(string.Format("http://*:{0}", port)))
            {
                Console.WriteLine("Started");
                _quitEvent.WaitOne();
            }
        }
    }
}
