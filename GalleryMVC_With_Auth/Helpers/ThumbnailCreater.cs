using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace GalleryMVC_With_Auth.Helpers
{
    public static class ThumbnailCreater
    {
        public static void ToTmb(string path, string tmbpath)
        {
            var thumb = Image.FromFile(path).GetThumbnailImage(250, 250, () => false, IntPtr.Zero);
            var myEncoderParameters = new EncoderParameters(1){Param = {[0] = new EncoderParameter(Encoder.Quality, 50L)}};
            thumb.Save(tmbpath, GetEncoder(ImageFormat.Jpeg), myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().FirstOrDefault(codec => codec.FormatID == format.Guid);
        }
    }
}