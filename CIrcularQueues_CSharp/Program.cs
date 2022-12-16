using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIrcularQueues_CSharp
{
    class Queues
    {
        int FRONT, REAR, max = 5;
        int[] queue_array = new int[5];
        public Queues()
        {
            /*Innitialing the values of the variables REAR and FRONT to -1
             to indicate that the queue is initially empty. */
            FRONT = -1;
            REAR = -1;
        }
        public void insert(int element)
        {
            /*This statement checks for the overflow condition. */
            if ((FRONT == 0 && REAR == max - 1) || (FRONT == REAR + 1))
            {
                Console.WriteLine("\nQueue overflow\n");
                return;
            }
            /*The following statement checks whether the queue is empty. If the queue is empty,
             then the value of the REAR and FRONT variables is set to 0.*/
            if (FRONT == -1)
            {
                FRONT = 0;
                REAR = 0;
            }
            else
            {
                /*If REAR is at the last position of the array, then the value of REAR is set to 0
                 that corresponds to the first position of the array.*/
                if (REAR == max - 1)
                    REAR = 0;
                else
                    /*If REAR is not at the last position, then its value is incremented by one.*/
                    REAR = REAR + 1;
            }
            /*Once the position of the REAR is dtermined, the element is added at its proper place.*/
            queue_array[REAR] = element;
        }
        public void remove()
        {
            /*Checks whether the queue is empty. */
            if (FRONT == -1)
            {
                Console.WriteLine("Queue underflow\n");
                return;
            }
            Console.WriteLine("\nThe element deleted from the queue is: " + queue_array[FRONT] + "\n");
            /*Checks if the queue has one element. */
            if (FRONT == REAR)
            {
                FRONT = -1;
                REAR = -1;
            }
            else
            {
                /* If the element to be deleted is at the last position of the array, then the value of FRONT
                 set to 0 i.e to the first element of the array.*/
                if (FRONT == max - 1)
                    FRONT = 0;
                else
                    /*FRONT is incremented by one if it is not the first element of array. */
                    FRONT = FRONT + 1;
            }
        }
        public void display()
        {
            int FRONT_position = FRONT;
            int REAR_position = REAR;
            /*Checks if the queue is empty*/
            if (FRONT == -1)
            {
                Console.WriteLine("Queue is empty\n");
                return;
            }
            Console.WriteLine("\nElements in the queue are .........................\n");
            if (FRONT_position <= REAR_position)
            {
                /*Traverse the queue till the last element present in an array.*/
                while (FRONT_position <= REAR_position)
                {
                    Console.Write(queue_array[FRONT_position] + "   ");
                    FRONT_position++;
                }
                Console.WriteLine();
            }
            else
            {
                /*Traverse the queue till the last position of the array*/
                while (FRONT_position <= max - 1)
                {
                    Console.Write(queue_array[FRONT_position] + "   ");
                    FRONT_position++;
                }
                /*Set the FRONT position to the first element of the array.*/
                FRONT_position = 0;
                /*Traverse the array till the last element present in the queue. */
                while (FRONT_position <= REAR_position)
                {
                    Console.Write(queue_array[FRONT_position] + "   ");
                    FRONT_position++;
                }
                Console.WriteLine();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Queues q = new Queues();
            char ch;
            while (true)
            {
                try
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Implement insert operation");
                    Console.WriteLine("2. Implement delete operation");
                    Console.WriteLine("3. Display values");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("\nEnter your choice (1-4): ");
                    ch = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine();
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.Write("Enter a number : ");
                                int num = Convert.ToInt32(System.Console.ReadLine());
                                Console.WriteLine();
                                q.insert(num);
                            }
                            break;
                        case '2':
                            {
                                q.remove();
                            }
                            break;
                        case '3':
                            {
                                q.display();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option!!");
                            }
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the value entered. ");
                }
            }
        }
    }
}