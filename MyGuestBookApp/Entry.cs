using System;

namespace MyGuestBookApp
{

    public class Entry(string owner, string content)
    {
        public string Owner { get; set; } = owner;
        public string Content { get; set; } = content;

        public override string ToString()
        {
            return $"{Owner}: {Content}";
        }
    }
}