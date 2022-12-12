using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp
{
    // This is an example class for the factory design pattern.
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

        /* 
           You are given two 0-indexed integer arrays servers and tasks of length n and m respectively. servers[i] is the weight of the ith server, and tasks[j] is the time needed to process the jth task in seconds.
           Tasks are assigned to the servers using a task queue. Initially, all servers are free, and the queue is empty.
           At second j, the jth task is inserted into the queue (starting with the 0th task being inserted at second 0). As long as there are free servers and the queue is not empty, the task in the front of the queue will be assigned to a free server with the smallest weight, and in case of a tie, it is assigned to a free server with the smallest index.
           If there are no free servers and the queue is not empty, we wait until a server becomes free and immediately assign the next task. If multiple servers become free at the same time, then multiple tasks from the queue will be assigned in order of insertion following the weight and index priorities above.
           A server that is assigned task j at second t will be free again at second t + tasks[j].
           Build an answer array of length m, where ans[j] is the index of the server the jth task will be assigned to.
           Return the answer array.
        */
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
