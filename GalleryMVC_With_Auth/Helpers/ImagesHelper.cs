using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using GalleryMVC_With_Auth.Domain.Entities;
using GalleryMVC_With_Auth.Models;

namespace GalleryMVC_With_Auth.Helpers
{
    public class ImagesHelper
    {
        public static void ToTmb(string path, string tmbpath)
        {
            var thumb = Image.FromFile(path).GetThumbnailImage(250, 250, () => false, IntPtr.Zero);
            var myEncoderParameters = new EncoderParameters(3)
            {
                Param =
                {
                    [0] = new EncoderParameter(Encoder.Quality, 100L),
                    [1] = new EncoderParameter(Encoder.ScanMethod, (int) EncoderValue.ScanMethodInterlaced),
                    [2] = new EncoderParameter(Encoder.RenderMethod, (int) EncoderValue.RenderProgressive)
                }
            };
            thumb.Save(tmbpath, GetEncoder(ImageFormat.Jpeg), myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().FirstOrDefault(codec => codec.FormatID == format.Guid);
        }

        public static List<Picture> GetListOfPictures(PictureModel model)
        {
            var pList = new List<Picture>();
            foreach (var file in model.Files)
            {
                var pic = Path.GetFileName($"{(file.FileName + DateTime.Now.Ticks).GetHashCode()}.jpg");
                var pth = $"/Content/images/{pic}";
                var path = HttpContext.Current.Server.MapPath($"{pth.Insert(0, "~")}");

                var tmbpath =
                    HttpContext.Current.Server.MapPath($"{pth.Insert(pth.Length - pic.Length, "tmb/").Insert(0, "~")}");
                // file is uploaded
                file.SaveAs(path);

                ToTmb(path, tmbpath);

                //Upload info to DB
                pList.Add(new Picture
                {
                    Path = pth,
                    TmbPath = pth.Insert(pth.Length - pic.Length, "tmb/"),
                    Name = model.Name,
                    Description = model.Description,
                    Tag = model.Tag,
                    Price = model.Price,
                    AlbumId = model.AlbumId
                });
            }
            return pList;
        }
    }
}