using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is a long string containing many words. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur cursus, nunc at tempus laoreet, justo sapien imperdiet quam, quis pulvinar mauris mi ac ipsum. Aenean lacinia justo enim, vel tempor urna malesuada a. Nulla faucibus tincidunt dictum. Nulla facilisi. Proin eget posuere risus, nec dictum arcu. Vivamus interdum elementum dignissim. Donec tincidunt, nunc nec euismod iaculis, dui lorem feugiat tortor, sit amet ultricies augue magna id diam. Curabitur aliquet, libero vehicula eleifend blandit, eros velit dictum justo, nec auctor diam mauris sed urna. Etiam eu mi sapien. Praesent vitae nulla fringilla, porttitor turpis eget, sagittis justo.";
                        
            Console.WriteLine(text.Shorten(6));

        }

    }
}
