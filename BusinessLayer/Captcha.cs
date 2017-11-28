using System;
using System.Drawing;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Captcha
    {
        int numeroAutogenerado = 0;
        //Jorge Luis|06/11/2017|RW-19
        /*Método para generar un número aleatorio y lo escribe como imagen, el cual se emplea como captcha*/
        public int CargarCaptcha(PictureBox pictureBox) {
            /*Generación de números random en el rango de 100000, 999999 */
            Random random = new Random();
            numeroAutogenerado = random.Next(100000, 999999);
            var image = new Bitmap(pictureBox.Width, pictureBox.Height);
            var font = new Font("Arial", 24, FontStyle.Bold, GraphicsUnit.Pixel);
            var grafico = Graphics.FromImage(image);
            grafico.DrawString(numeroAutogenerado.ToString(), font, Brushes.DeepSkyBlue, new Point(0, 0));
            pictureBox.Image = image;
            return numeroAutogenerado;
        }
    }
}
