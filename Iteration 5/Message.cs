using System;
namespace Swin_Adventure
{
    public class Message
    {
        private string _text;
        public Message(string text)
        {
            _text = text;
        }

        public void Print()
        {
            Console.WriteLine(_text);
        }
    }
}

