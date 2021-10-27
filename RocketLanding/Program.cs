using RocketLanding.Service;
using System;

namespace RocketLanding
{
    internal class Program
    {
        private readonly IRocketLandingService _rocketLandingService;

        public Program(IRocketLandingService rocketLandingService)
        {
            _rocketLandingService = rocketLandingService;
        }

        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("----------------------Create Platform----------------------");
                Console.WriteLine("Enter Platform Horizantal Length");
                var xLength = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Platform Vertical Length");
                var yLength = Convert.ToInt32(Console.ReadLine());

                IRocketLandingService rocketLandingService = new RocketLandingService(xLength, yLength);
                var program = new Program(rocketLandingService);

                program.Invoke();
            }
            catch (FormatException)
            {
                Console.WriteLine("Digits please.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Lets take it slow, shall we?");
            }
            catch (Exception ex)
            {
                //ooopsies
            }
        }

        public void Invoke()
        {
            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine("----------------------Target Query----------------------");
                Console.WriteLine("Enter Target x");
                var targetx = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Target y");
                var targety = Convert.ToInt32(Console.ReadLine());
                var response = _rocketLandingService.GetResponse(targetx, targety);
                Console.WriteLine(response);

                Console.Write("Continue? N for exit ");
                string go = Console.ReadLine();
                if (go.ToUpper() == "N")
                {
                    repeat = false;
                }
            }
        }
    }
}