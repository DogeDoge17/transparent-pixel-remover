using System.Collections;
using System.Drawing;

namespace TransparentPixelRemover
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.png");

            if(files.Length == 0)
            {
                Console.WriteLine("No files found. Exiting");
                Console.Read();
                return;
            }            

            foreach(string file in files)
            {
                try
                {
                    Bitmap bitmap = (Bitmap)Image.FromFile(file);


                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            Color newColour = bitmap.GetPixel(x, y);
                            //if(newColour.R != 0 && newColour.G != 0 && newColour.B != 0 && newColour.A != 0)
                            //    newColour = Color.FromArgb(255, newColour.R, newColour.G, newColour.B);
                            if (newColour.A != 255)
                                newColour = Color.FromArgb(0, 0, 0, 0);
                            bitmap.SetPixel(x, y, newColour);
                        }
                    }
                    bitmap.Save(Path.GetFileNameWithoutExtension(file) + "_mod.png");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to preform on \"{file}\"\n{ex.Message}");
                }
            }

        }
    }
}
