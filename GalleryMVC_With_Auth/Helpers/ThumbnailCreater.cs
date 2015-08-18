using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace GalleryMVC_With_Auth.Helpers
{
    public static class ThumbnailCreater
    {
        public static void ToTmb(string path, string tmbpath)
        {
            var image = Image.FromFile(path);
            var thumb = image.GetThumbnailImage(250, 250, () => false, IntPtr.Zero);
            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            var myEncoder =
                Encoder.Quality;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            thumb.Save(tmbpath, jpgEncoder, myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();

            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}