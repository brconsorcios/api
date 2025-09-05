using System.Drawing;
using System.Drawing.Drawing2D;

namespace exp.web.Code
{
    public static class EditarImagem
    {
        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                var originalWidth = image.Width;
                var originalHeight = image.Height;
                var percentWidth = size.Width / (float)originalWidth;
                var percentHeight = size.Height / (float)originalHeight;
                var percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }

            Image newImage = new Bitmap(newWidth, newHeight);
            using (var graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }


        //http://www.dotnetcurry.com/ShowArticle.aspx?ID=214

        //// Add Watermark Text to Image
        //protected Bitmap AddTextToImage(Bitmap bImg, string msg)
        //{
        //    // To void the error due to Indexed Pixel Format
        //    Image img = new Bitmap(bImg, new Size(bImg.Width, bImg.Height));
        //    Bitmap tmp = new Bitmap(img);
        //    Graphics graphic = Graphics.FromImage(tmp);
        //    // Watermark effect
        //    SolidBrush brush = new SolidBrush(Color.FromArgb(120, 255, 255, 255));
        //    // Draw the text string to the Graphics object at a given position.
        //    graphic.DrawString(msg, new Font("Times New Roman", 14, FontStyle.Italic),
        //         brush, new PointF(10, 30));
        //    graphic.Dispose();
        //    return tmp;
        //}
        //// Convert byte array to Bitmap (byte[] to Bitmap)
        //protected Bitmap ConvertToBitmap(byte[] bmp)
        //{
        //    if (bmp != null)
        //    {
        //        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
        //        Bitmap b = (Bitmap)tc.ConvertFrom(bmp);
        //        return b;
        //    }

        //}

        //public void ProcessRequest(HttpContext context)
        //{
        //    Int32 empno;

        //    if (context.Request.QueryString["id"] != null)
        //        empno = Convert.ToInt32(context.Request.QueryString["id"]);
        //    else
        //        throw new ArgumentException("No parameter specified");

        //    // Convert Byte[] to Bitmap
        //    Bitmap newBmp = ConvertToBitmap(ShowEmpImage(empno));
        //    // Watermark Text to be added to image
        //    string text = "Code from dotnetcurry";
        //    if (newBmp != null)
        //    {
        //        Bitmap convBmp = AddTextToImage(newBmp, text);
        //        convBmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        //        convBmp.Dispose();
        //    }
        //    newBmp.Dispose();

        //}
    }
}