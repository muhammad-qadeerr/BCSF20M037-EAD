using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight_Pattern
{
    public interface ICharacter
    {
        void Display(int position);
    }


    public class Character : ICharacter
    {
        private readonly char symbol;

        public Character(char symbol)
        {
            this.symbol = symbol;
        }

        public void Display(int position)
        {
            Console.WriteLine($"Character '{symbol}' at position {position}");
        }
    }

  
    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> characters = new Dictionary<char, ICharacter>();

        public ICharacter GetCharacter(char symbol)
        {
            if (!characters.TryGetValue(symbol, out ICharacter character))
            {
                character = new Character(symbol);
                characters[symbol] = character;
            }

            return character;
        }
    }

    class Program
    {
        static void Main()
        {
            CharacterFactory characterFactory = new CharacterFactory();

            ICharacter charA = characterFactory.GetCharacter('A');
            charA.Display(1);

            ICharacter charB = characterFactory.GetCharacter('B');
            charB.Display(2);

            ICharacter charA2 = characterFactory.GetCharacter('A');  // Reuses existing flyweight
            charA2.Display(3);

            Console.ReadLine();
        }
    }

}
