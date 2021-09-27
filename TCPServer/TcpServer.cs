using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ModelLib;


namespace TCPServer
{
    class TcpServer
    {
        private List<FootballPlayer> playerlist = new List<FootballPlayer>()
        {
            new FootballPlayer("Matthew nice", 25000, 10, 1),
            new FootballPlayer("Patrick awesome", 10000, 9, 2),
            new FootballPlayer("Anton Blommesen", 15000, 8, 3)
        };

        public void start()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 2121);
            tcpListener.Start();

            TcpClient socket = tcpListener.AcceptTcpClient();
            DoClient(socket);

        }

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                string line = sr.ReadLine().ToLower();
                if (line == null)
                {
                    sw.WriteLine("input field = null");

                    return;
                }

                string line2 = sr.ReadLine();
                if (line != "hentalle" && line2 == null)
                {
                    sw.WriteLine("Ingen input");
                    return;
                }

                if (line == "hentalle")
                {
                    foreach (FootballPlayer player in playerlist)
                    {
                        string jsonCV = JsonSerializer.Serialize(player);
                        sw.WriteLine(jsonCV);
                    }

                    return;
                }
                else if (line == "hent")
                {
                    int id = Convert.ToInt32(line2);
                    foreach (FootballPlayer player in playerlist)
                        if (player.Id == id)
                        {
                            string JsonCV = JsonSerializer.Serialize(player);
                            sw.WriteLine(JsonCV);
                            return;
                        }

                    return;
                }

                else if (line == "gem")
                {
                    FootballPlayer newplayer = JsonSerializer.Deserialize<FootballPlayer>(line2);
                    if(newplayer != null) playerlist.Add(newplayer);
                }
            }
            
             
        }
    }
}
