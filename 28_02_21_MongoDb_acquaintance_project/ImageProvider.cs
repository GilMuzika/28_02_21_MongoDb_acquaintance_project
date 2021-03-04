using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project
{
    public static class ImageProvider
    {
        private static Random _rnd = new Random();

        static Stream _imageString;

        public static byte[] GetPersonImageAsByteArray()
        {
            return ReadToEnd(_imageString);
        }



        public static string GetPersonImageAs64BaseString()
        {
            _imageString = Statics.GetStreamFromUrl("https://thispersondoesnotexist.com/image");

            return Convert.ToBase64String(ReadToEnd(_imageString));
        }

        public static Bitmap GetResizedPersonImageAsBitmap(int resizeFactor)
        {
            _imageString = Statics.GetStreamFromUrl("https://thispersondoesnotexist.com/image");

            byte[] byteBuffer = ReadToEnd(_imageString);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            Bitmap bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            Bitmap resizedImg = bmpReturn.ResizeImage(bmpReturn.Width / resizeFactor, bmpReturn.Height / resizeFactor);

            return resizedImg;
        }

        /// <summary>
        /// Convert Stream with image information to actual image(Bitmap), resize it by the resizing factor(int) return it as Base64String.
        /// </summary>
        /// <param name="resizeFactor"></param>
        /// <returns></returns>
        public static string GetResizedPersonImageAs64BaseString(int resizeFactor)
        {


            Bitmap resizedImg = GetResizedPersonImageAsBitmap(resizeFactor);

            MemoryStream memoryStream = new MemoryStream();
            resizedImg.Save(memoryStream, ImageFormat.Jpeg);
            byte[] byteImage = memoryStream.ToArray();

            //this code is only to check converting an image to Base64String and back to Bitmap, and then saving to the disk
            /*
            byteBuffer = Convert.FromBase64String(Convert.ToBase64String(byteImage));
            memoryStream = new MemoryStream(byteBuffer);
            resizedImg.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);
            bmpReturn.Save("sampleImage.jpg", ImageFormat.Jpeg);*/
            //End: this code is only to check converting an image to Base64String and back to Bitmap, and then saving to the disk

            memoryStream.Close();
            return Convert.ToBase64String(byteImage);
        }

        private static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }


        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(this Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        public static System.Drawing.Imaging.ImageFormat GetImageFormat(this System.Drawing.Image img, out string extension)
        {
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                extension = "jpg";
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            }
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
            {
                extension = "bmp";
                return System.Drawing.Imaging.ImageFormat.Bmp;
            }
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
            {
                extension = "png";
                return System.Drawing.Imaging.ImageFormat.Png;
            }
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
            {
                extension = "emf";
                return System.Drawing.Imaging.ImageFormat.Emf;
            }
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif))
            {
                extension = "exif";
                return System.Drawing.Imaging.ImageFormat.Exif;
            }
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
            {
                extension = "gif";
                return System.Drawing.Imaging.ImageFormat.Gif;
            }
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
            {
                extension = "ico";
                return System.Drawing.Imaging.ImageFormat.Icon;
            }
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
            {
                extension = "memoryBmp";
                return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            }
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
            {
                extension = "tif";
                return System.Drawing.Imaging.ImageFormat.Tiff;
            }
            else
            {
                extension = "wmf";
                return System.Drawing.Imaging.ImageFormat.Wmf;
            }

        }


        public static Bitmap ByteArrayToBitmap(byte[] bytearray)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(bytearray))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }
    }
}
