using System;
using System.Runtime.InteropServices;

namespace Animals
{
    class Program
    {
        static void Main()
        {
            var dog = new Dog(10, 45);
            var cat = new Cat(5);
            var whale = new Whale(38);

            var random = new Random();
            var randomDistance = random.Next(1, 100);
            DoSomeStuff(dog, randomDistance);
            DoSomeStuff(cat, randomDistance);
            DoSomeStuff(whale, randomDistance);
        }

        private static void DoSomeStuff(IAnimal animal, int distance)
        {
            Console.WriteLine($"I am a {animal.Type}");

            Console.WriteLine($"I take {animal.TimeToTravel(distance)} minutes to go {distance} miles.");


        }
    }

    public interface IAnimal
    {
        Animal Type { get; }
        decimal TimeToTravel(int miles);
    }

    public class Dog : IAnimal
    {
        public Dog(int walkingFps, int runningFps)
        {
            WalkingFps = walkingFps;
            RunningFps = runningFps;
        }

        public Animal Type => Animal.Dog;

        private int WalkingFps { get; }
        private int RunningFps { get; }

        public decimal TimeToTravel(int miles)
        {
            var random = new Random();

            var feet = miles * 5280;
            var feetTraveled = 0;
            var time = 0;

            while (feetTraveled < feet)
            {
                var typeOfTravel = random.Next(2);
                if (typeOfTravel == 1)
                {
                    feetTraveled += WalkingFps;
                }
                else
                {
                    feetTraveled += RunningFps;
                }

                time++;
            }

            return Math.Round(time / 60m, 2);
        }
    }

    public class Cat : IAnimal
    {
        public Cat(int walkingFps)
        {
            WalkingFps = walkingFps;
        }

        public Animal Type => Animal.Cat;

        private int WalkingFps { get; set; }

        public decimal TimeToTravel(int miles)
        {
            var random = new Random();

            var feet = miles * 5280;
            var feetTraveled = 0;
            var time = 0;

            while (feetTraveled < feet)
            {
                var decision = random.Next(3);
                switch (decision)
                {
                    case 0:
                        feetTraveled += WalkingFps;
                        time++;
                        break;
                    case 1:
                        feetTraveled += play(random);
                        time += sleep(random);
                        break;
                    default:
                        time += sleep(random);
                        break;

                }
            }

            return Math.Round(time / 60m, 2);
        }

        private int play(Random random)
        {
            var distancePlayed = random.Next(0, 45);

            if (random.Next(1) == 0)
            {
                return distancePlayed;
            }
            else
            {
                return -distancePlayed;
            }
        }

        private int sleep(Random random)
        {
            return random.Next(3, 500);
        }
    }

    public class Whale : IAnimal
    {
        public Whale(int swimmingFps)
        {
            SwimmingFps = swimmingFps;
        }

        public Animal Type => Animal.Whale;

        private int SwimmingFps { get; }

        public decimal TimeToTravel(int miles)
        {
            var feet = miles * 5280;
            
            return Math.Round((decimal)feet / SwimmingFps / 60, 2);
        }
    }

    public enum Animal
    {
        Dog,
        Cat,
        Whale
    }

}
