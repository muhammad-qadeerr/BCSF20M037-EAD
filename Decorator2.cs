using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public interface IText
    {
        string GetText();
    }
    public class SimpleText : IText
    {
        private string text;

        public SimpleText(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return text;
        }
    }
    public abstract class TextDecorator : IText
    {
        protected IText decoratedText;

        public TextDecorator(IText text)
        {
            this.decoratedText = text;
        }

        public virtual string GetText()
        {
            return decoratedText.GetText();
        }
    }

    public class BoldTextDecorator : TextDecorator
    {
        public BoldTextDecorator(IText text) : base(text)
        {
        }

        public override string GetText()
        {
            return $"<b>{base.GetText()}</b>";
        }
    }

    public class ItalicTextDecorator : TextDecorator
    {
        public ItalicTextDecorator(IText text) : base(text)
        {
        }

        public override string GetText()
        {
            return $"<i>{base.GetText()}</i>";
        }
    }
    class Program
    {
        static void Main()
        {
          
            IText simpleText = new SimpleText("Hello, world!");

     
            IText textWithBold = new BoldTextDecorator(simpleText);
            Console.WriteLine($"Formatted Text: {textWithBold.GetText()}");

            IText textWithBoldAndItalic = new ItalicTextDecorator(textWithBold);
            Console.WriteLine($"Formatted Text: {textWithBoldAndItalic.GetText()}");

            Console.ReadLine();
        }
    }

}
