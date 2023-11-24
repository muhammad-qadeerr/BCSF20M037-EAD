using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern
{
    // Subsystem: Projector
    public class Projector
    {
        public void TurnOn()
        {
            Console.WriteLine("Projector turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Projector turned off");
        }
    }

    // Subsystem: Amplifier
    public class Amplifier
    {
        public void TurnOn()
        {
            Console.WriteLine("Amplifier turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Amplifier turned off");
        }
    }

    // Subsystem: Speakers
    public class Speakers
    {
        public void TurnOn()
        {
            Console.WriteLine("Speakers turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Speakers turned off");
        }
    }

    // Subsystem: DVD Player
    public class DVDPlayer
    {
        public void TurnOn()
        {
            Console.WriteLine("DVD Player turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("DVD Player turned off");
        }

        public void PlayMovie(string movie)
        {
            Console.WriteLine($"Playing movie: {movie}");
        }
    }

    // Facade: Home Theater Facade
    public class HomeTheaterFacade
    {
        private readonly Projector projector;
        private readonly Amplifier amplifier;
        private readonly Speakers speakers;
        private readonly DVDPlayer dvdPlayer;

        public HomeTheaterFacade(Projector projector, Amplifier amplifier, Speakers speakers, DVDPlayer dvdPlayer)
        {
            this.projector = projector;
            this.amplifier = amplifier;
            this.speakers = speakers;
            this.dvdPlayer = dvdPlayer;
        }

        // Simplified methods for the client
        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            projector.TurnOn();
            amplifier.TurnOn();
            speakers.TurnOn();
            dvdPlayer.TurnOn();
            dvdPlayer.PlayMovie(movie);
        }

        public void EndMovieNight()
        {
            Console.WriteLine("Ending movie night...");
            projector.TurnOff();
            amplifier.TurnOff();
            speakers.TurnOff();
            dvdPlayer.TurnOff();
        }
    }

    // Client code
    class Program
    {
        static void Main()
        {
            // Create subsystem components
            Projector projector = new Projector();
            Amplifier amplifier = new Amplifier();
            Speakers speakers = new Speakers();
            DVDPlayer dvdPlayer = new DVDPlayer();

            // Create the Home Theater Facade
            HomeTheaterFacade homeTheater = new HomeTheaterFacade(projector, amplifier, speakers, dvdPlayer);

            // Client uses the simplified interface provided by the facade
            homeTheater.WatchMovie("Inception");
            Console.WriteLine("Enjoying the movie...");

            // Client ends the movie night using the facade
            homeTheater.EndMovieNight();

            Console.ReadLine();
        }
    }

}
