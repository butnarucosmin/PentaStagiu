using System;
using System.Media;
using System.Threading;

namespace Guess_The_Number
{
    public class Exercises_PentaStagiu
    {
        public void Exercise_Guess_The_Number()
        {
            Console.WriteLine("I'm thinking of a number between 1 and 100. \nTry to guess it. \n");
            
            var random = new Random();
            int randomnumber = random.Next(1, 100);
            int i = 1;
            SoundPlayer playertada = new SoundPlayer(@"c:\Windows\Media\tada.wav");
            SoundPlayer playererror = new SoundPlayer(@"c:\Windows\Media\Windows Error.wav");

            while (true)
            {
                Console.WriteLine("Please enter your number");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int yournumber))
                {
                    if (yournumber < randomnumber)
                    {
                        playererror.Play();
                        Console.WriteLine("My number is higher than {0} ", yournumber);
                        i++;
                        continue;
                    }
                    else if (yournumber > randomnumber)
                    {
                        playererror.Play();
                        Console.WriteLine("My number is lower than {0} ", yournumber);
                        i++;
                        continue;
                    }
                    else if(i > 1)
                    {
                        Console.WriteLine("Congrats!!! \nIt only took you {0} tries to guess the number: {1}", i, randomnumber);
                        playertada.Play();
                        Thread.Sleep(5000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Well guessed! The number was {0}", randomnumber);
                        playertada.Play();
                        Thread.Sleep(5000);
                        break;
                    }

                }
                else
                {
                    playererror.Play();
                    Console.WriteLine("Your input was not a number. Try again.");
                    continue;
                }
            }

            Console.WriteLine();
        }
    }
}
