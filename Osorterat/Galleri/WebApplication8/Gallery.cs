using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication8
{
    public class Gallery
    {
        private static Regex ApprovedExtensions;
        private static string PhysicalUploadedImagesPath;
        private static Regex SantizePath;

        static Gallery()
        {
            ApprovedExtensions = new Regex(@"^.*\.(gif|jpg|png)$");
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content");
            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
            //SantizePath.Replace();
        }

        public IEnumerable<string> GetImageNames()
        {
            List<string> imageList = new List<string>(100);
            DirectoryInfo di = new DirectoryInfo(PhysicalUploadedImagesPath);
            
                foreach (var fi in di.GetFiles())
                {
                    if (ApprovedExtensions.IsMatch(fi.ToString()))
                    {
                        imageList.Add(fi.ToString());
                    }
                }
            
            imageList.Sort();
            return imageList;
        }

        public static bool ImageExists(string name)
        {
            return File.Exists(Path.Combine(PhysicalUploadedImagesPath, name));            
        }

        private bool IsValidImage(Image image)
        {
            if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
            {
                return true;
            }

            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
            {
                return true;
            }

            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
            {
                return true;
            }

            return false;
        }

        public string SaveImage(Stream stream, string FileName)
        {
            var image = Image.FromStream(stream);

            if (!IsValidImage(image))
            {
                throw new ArgumentException();
            }

            if (ImageExists(FileName))
            {
                string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileName);
                string Extension = Path.GetExtension(FileName);
                FileName = String.Format("{0}" + "(2)" + "{2}", FileNameWithoutExtension, Extension);
            }

            image.Save(Path.Combine(PhysicalUploadedImagesPath, FileName));

            var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);
            thumbnail.Save(Path.Combine(PhysicalUploadedImagesPath, "Thumbnail", FileName));

            return FileName;
            
        }

    }
}