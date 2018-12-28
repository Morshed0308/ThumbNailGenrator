using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.NET;
using GhostscriptSharp;


namespace imgthumb
{
    class Program
    {
        static void Main(string[] args)
        {
            ThumbNailAsync();
            VideoThumbNail();
            imagethumbNail();
            
        }

        public static async void ThumbNailAsync()
        {

            var inputFile = new MediaFile(@"D:\one.mp4");
            var outputFile = new MediaFile(@"D:\oneee.jpg");
            var ffmpeg = new Engine("D:\\MediaToolkit\\ffmpeg.exe");


            // Saves the frame located on the 15th second of the video.
            var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(3) };
            await ffmpeg.GetThumbnailAsync(inputFile, outputFile, options);

        }
        public static  void VideoThumbNail()
        {
            string inpath = "D:\\";
            string inext = ".pdf";
            var inp = inpath + "one" + inext;
            var outp = "D:\\three.jpg";

            GhostscriptWrapper.GeneratePageThumb(inp, outp, 6, 110, 90);
        }

        public static void imagethumbNail()
        {
            var path = "D:\\oneee.jpg";
            int thumbWidthInPix = 200;
            int thumbHeightInPix = 200;
            Image image = Image.FromFile(path);
            Image thumb = image.GetThumbnailImage(thumbWidthInPix,thumbHeightInPix, () => false, IntPtr.Zero);
            thumb.Save(Path.ChangeExtension(path, "thumb"));
        }

    }
}
