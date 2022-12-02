using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp
{
    public class EC2 : IAWSServer
    {
        class Server
        {
            public int weight { get; set; }
            public int index { get; set; }

            public Server(int weight, int index)
            {
                this.weight = weight;
                this.index = index;
            }

        }

        class AssignedServer
        {
            public int freeTime { get; set; }
            public Server server { get; set; }

            public AssignedServer(int freeTime, Server server)
            {
                this.freeTime = freeTime;
                this.server = server;
            }
        }

        class ServerComparer : IComparer<Server>
        {
            public int Compare(Server x, Server y)
            {
                if(x.weight - y.weight == 0)
                {
                    return x.index - y.index;
                }
                else
                {
                    return x.weight - y.weight;
                }
            }
        }

        class AssignedServerComparer : IComparer<AssignedServer>
        {
            public int Compare(AssignedServer x, AssignedServer y)
            {
                return x.freeTime - y.freeTime;
            }
        }

        void IAWSServer.Analytics()
        {
            Console.WriteLine("CPU Usage: X, Memory Usage: Y, Storage Usage: Z");
        }

        void IAWSServer.Compute()
        {
            Console.WriteLine("N instances for computing available.");
        }

        void IAWSServer.Storage()
        {
            Console.WriteLine("M instances for storage available.");
        }

        public int[] ProcessTasks(int[] servers, int[] tasks)
        {
            //Initialize two priority queues for servers and assigned servers
            var serverQueue = new PriorityQueue<Server, Server>(new ServerComparer());
            var assignedServerQueue = new PriorityQueue<AssignedServer, AssignedServer>(new AssignedServerComparer());

            //Store servers into priority queue for servers
            for(int i = 0; i < servers.Length; i++)
            {
                Server server = new Server(servers[i], i);
                serverQueue.Enqueue(server, server);
            }

            //Start assigning and processing tasks
            int[] returnArray = new int[tasks.Length];
            int j = 0;
            int time = 0;

            while(j < tasks.Length)
            {
                //Check what servers have become free
                while(assignedServerQueue.Count > 0 && assignedServerQueue.Peek().freeTime <= time)
                {
                    Server server = assignedServerQueue.Dequeue().server;
                    serverQueue.Enqueue(server, server);
                }

                //Assign tasks to available servers
                while(serverQueue.Count != 0 && j <= time && j < tasks.Length)
                {
                    int task = tasks[j];
                    Server server = serverQueue.Dequeue();
                    AssignedServer assignedServer = new AssignedServer(time + task, server);
                    assignedServerQueue.Enqueue(assignedServer, assignedServer);
                    returnArray[j] = server.index;
                    j++;
                }

                //Increase time to process the next task
                if (serverQueue.Count > 0)
                    time++;
                else
                    time = assignedServerQueue.Peek().freeTime;
            }
            return returnArray;
        }
    }
}
