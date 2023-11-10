using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections;
namespace ProyectoTemperatura
{
    public partial class Form1 : Form

    {
        System.IO.Ports.SerialPort Port;
        bool IsClosed = false;
        float valorRangoSUP = 0;
        string valorIngresadoSUP;

        float valorRangoINF = 0;
        string valorIngresadoINF;



        Graphics papel;
        Font fuente = new Font("Arial", 8);
        SolidBrush pincel = new SolidBrush(Color.White);
        SolidBrush pincelHORAS = new SolidBrush(Color.Black);
        Pen pincelmorado = new Pen(Color.Purple);


        Queue<string> horaQ = new Queue<string>();
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        string[] horaA;

        Queue<string> temperaturaQ = new Queue<string>();
        string[] temperaturaA;


        string temperatura;

        private List<PointF> lineasDibujadas = new List<PointF>(); // Lista para almacenar las líneas dibujadas

        public Form1()
        {
            InitializeComponent();
            Port = new System.IO.Ports.SerialPort();
            Port.PortName = "COM4";
            Port.BaudRate = 9600;
            Port.ReadTimeout = 1000;

            try
            {
                Port.Open();
            }
            catch
            {


            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen lapizamarillo = new Pen(Color.Yellow);


            Thread Hilo = new Thread(EscucharSerial);
            Hilo.Start();


        }


        public void EscucharSerial()
        {
            while (!IsClosed)
            {
                try
                {
                    temperatura = Port.ReadLine();
                    txtAlgo.Invoke(new MethodInvoker(
                        delegate
                        {


                            string message = temperatura + "°C      HORA " + currentTime;
                            txtAlgo.Text = message;



                        }));

                }
                catch
                {


                }
            }

        }

        public void DibujarGrafica()
        {


            papel = pictureBox1.CreateGraphics();
            Pen lapizverde = new Pen(Color.Green);
            Pen lapizrojo = new Pen(Color.Red);
            Pen lapizamarillo = new Pen(Color.Yellow);
            Pen lapizgris = new Pen(Color.DimGray);



            //Dibujos del eje de las gráficas
            papel.DrawLine(lapizamarillo, (pictureBox1.Width / 2) - 300, 0, (pictureBox1.Width / 2) - 300, pictureBox1.Height); //Eje vertical ("y")
            papel.DrawLine(lapizamarillo, 0, (pictureBox1.Height / 2) + 150, pictureBox1.Width, (pictureBox1.Height / 2) + 150); //Eje horizontal ("x")

            //Dibujo de las líneas de Escalado TEMPERATURA de las graficas

            int espacioEntreLineas = 5;
            int numLineas = pictureBox1.Height / espacioEntreLineas;
            //MessageBox.Show("Número de líneas: " + numLineas);


            for (int i = numLineas; i >= 0; i--)
            {


                int y = (i * espacioEntreLineas);
                papel.DrawLine(lapizgris, 45, y - 35, pictureBox1.Width, y - 35); // Dibuja una línea horizontal

                int numeroLinea = (numLineas + 1 - i);


                if (i % 5 == 0)
                {
                    string textoNumero = numeroLinea.ToString();

                    papel.DrawString(textoNumero, fuente, pincel, 10, y - 35);
                }



            }


            int espacioEntreLineasHORA = (pictureBox1.Width) / 5;
            int numLineasHORA = pictureBox1.Width / espacioEntreLineasHORA;
            //MessageBox.Show("Número de líneas: " + numLineas);


            for (int i = numLineasHORA; i >= 0; i--)
            {

                if (i > 0)
                {
                    int x = (i * espacioEntreLineasHORA);
                    papel.DrawLine(lapizgris, x + 40, pictureBox1.Height - 32, x + 40, 5); // Dibuja una línea horizontal



                }

            }


        }



        private void button1_Click(object sender, EventArgs e)
        {

            //encender flama

            fuego.Visible = true;
            alerta.Visible = true;


            #region Dibujo de la gráfica en el PictureBox


            papel = pictureBox1.CreateGraphics();
            Pen lapizverde = new Pen(Color.Green);
            Pen lapizrojo = new Pen(Color.Red);
            Pen lapizamarillo = new Pen(Color.Yellow);
            Pen lapizgris = new Pen(Color.DimGray);



            //Dibujos del eje de las gráficas
            papel.DrawLine(lapizamarillo, (pictureBox1.Width / 2) - 300, 0, (pictureBox1.Width / 2) - 300, pictureBox1.Height); //Eje vertical ("y")
            papel.DrawLine(lapizamarillo, 0, (pictureBox1.Height / 2) + 150, pictureBox1.Width, (pictureBox1.Height / 2) + 150); //Eje horizontal ("x")

            //Dibujo de las líneas de Escalado TEMPERATURA de las graficas

            int espacioEntreLineas = 5;
            int numLineas = pictureBox1.Height / espacioEntreLineas;
            //MessageBox.Show("Número de líneas: " + numLineas);


            for (int i = numLineas; i >= 0; i--)
            {


                int y = (i * espacioEntreLineas);
                papel.DrawLine(lapizgris, 45, y - 35, pictureBox1.Width, y - 35); // Dibuja una línea horizontal

                int numeroLinea = (numLineas + 1 - i);


                if (i % 5 == 0)
                {
                    string textoNumero = numeroLinea.ToString();

                    papel.DrawString(textoNumero, fuente, pincel, 10, y - 35);
                }



            }


            int espacioEntreLineasHORA = (pictureBox1.Width) / 5;
            int numLineasHORA = pictureBox1.Width / espacioEntreLineasHORA;
            //MessageBox.Show("Número de líneas: " + numLineas);


            for (int i = numLineasHORA; i >= 0; i--)
            {

                if (i > 0)
                {
                    int x = (i * espacioEntreLineasHORA);
                    papel.DrawLine(lapizgris, x + 40, pictureBox1.Height - 32, x + 40, 5); // Dibuja una línea horizontal



                }

            }


            #endregion

            #region Cola  Horas y Temperaturas

            horaQ.Enqueue(currentTime);
            while (horaQ.Count < 4)
            {
                horaQ.Enqueue(currentTime);
            }


            if (horaQ.Count > 4)
            {
                horaQ.Dequeue();
            }


            horaA = horaQ.ToArray();





            temperaturaQ.Enqueue(temperatura);
            while (temperaturaQ.Count < 4)
            {
                temperaturaQ.Enqueue(temperatura);
            }


            if (temperaturaQ.Count > 4)
            {
                temperaturaQ.Dequeue();
            }


            temperaturaA = temperaturaQ.ToArray();

            #region Conversion de temperatura string a double



            #endregion


            #endregion

            timer1.Start();


        }


        #region Leer y graficar entrada de los rangos


        private void txtbRangoSup_TextChanged(object sender, EventArgs e)
        {
            // Dibujar la línea horizontal del rango superior

            if (!string.IsNullOrEmpty(txtbRangoSup.Text))
            {
                try
                {
                    valorIngresadoSUP = txtbRangoSup.Text;
                    valorRangoSUP = float.Parse(valorIngresadoSUP);
                }
                catch (FormatException)
                {
                    // Manejar la excepción si el valor no es un número flotante válido
                    // Por ejemplo, mostrar un mensaje de error al usuario o realizar alguna acción específica.
                    MessageBox.Show("El valor ingresado no es válido. Ingrese un número flotante válido.");
                    // También puedes establecer un valor predeterminado para valorRangoSUP si es necesario.
                }
            }
            else
            {
                valorRangoSUP = -700;// Aquí puedes manejar el caso en el que la TextBox está vacía.
                // Puedes asignar un valor predeterminado o tomar alguna otra acción según tus necesidades.
            }

        }




        private void txtbRangoInf_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbRangoSup.Text))
            {
                try
                {
                    valorIngresadoINF = txtbRangoInf.Text;
                    valorRangoINF = float.Parse(valorIngresadoINF);
                }
                catch (FormatException)
                {
                    // Manejar la excepción si el valor no es un número flotante válido
                    // Por ejemplo, mostrar un mensaje de error al usuario o realizar alguna acción específica.
                    MessageBox.Show("El valor ingresado no es válido. Ingrese un número flotante válido.");
                    // También puedes establecer un valor predeterminado para valorRangoSUP si es necesario.
                }
            }
            else
            {
                valorRangoINF = -700;// Aquí puedes manejar el caso en el que la TextBox está vacía.
                // Puedes asignar un valor predeterminado o tomar alguna otra acción según tus necesidades.
            }
        }
        #endregion





        #region Limitar a solo números los Rangos sup e inf
        private void txtbRangoSup_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite recibir solo Números

            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingresa sólo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;

            }
        }
        private void txtbRangoInf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite recibir solo Números

            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingresa sólo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;

            }

        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {




            papel.FillRectangle(new SolidBrush(Color.Black), 0, 0, 700, 700);
            DibujarGrafica();


            Pen lapizrojo = new Pen(Color.Red);
            Pen lapizazul = new Pen(Color.Blue);

            //INSERTAR LINEAS DE RANGO 



            papel.DrawLine(lapizrojo, 0, ((70 - valorRangoSUP * ((pictureBox1.Height / 2) + 150) / 70)) + 268, pictureBox1.Width, ((70 - valorRangoSUP * ((pictureBox1.Height / 2) + 150) / 70)) + 268); //Eje horizontal ("x")


            papel.DrawLine(lapizazul, 0, ((70 - valorRangoINF * ((pictureBox1.Height / 2) + 150) / 70)) + 268, pictureBox1.Width, ((70 - valorRangoINF * ((pictureBox1.Height / 2) + 150) / 70)) + 268); //Eje horizontal ("x")



            //RECORRER LAS HORAS MIENTRAS VAN LLEGANDO  
            currentTime = DateTime.Now.ToString("HH:mm:ss");
            horaQ.Enqueue(currentTime);

            horaQ.Dequeue();
            horaA = horaQ.ToArray();


            int xRectangulo = pictureBox1.Width - 530; // Posición X para centrar el rectángulo
            int yRectangulo = pictureBox1.Height - 28; // Posición Y para centrar el rectángulo
            papel.FillRectangle(new SolidBrush(Color.Black), xRectangulo, yRectangulo, 500, 60);

            int posicionHora0 = pictureBox1.Width - 512;
            int posicionHora1 = pictureBox1.Width - 375;
            int posicionHora2 = pictureBox1.Width - 240;
            int posicionHora3 = pictureBox1.Width - 104;

            papel.DrawString(horaA[3], fuente, pincel, posicionHora3, pictureBox1.Height - 28);
            papel.DrawString(horaA[2], fuente, pincel, posicionHora2, pictureBox1.Height - 28);
            papel.DrawString(horaA[1], fuente, pincel, posicionHora1, pictureBox1.Height - 28);
            papel.DrawString(horaA[0], fuente, pincel, posicionHora0, pictureBox1.Height - 28);

            //RECORRER LAS TEMPERATURAS MIENTRAS VAN LLEGANDO


            string newTemperature = null;
            try
            {
                newTemperature = temperatura;
            }
            catch (TimeoutException)
            {
                // Maneja la excepción de tiempo de espera
                // Puedes mostrar un mensaje o realizar otra acción adecuada
                newTemperature = "Sin datos"; // Puedes establecer un valor predeterminado
            }

            // Recorrer las temperaturas mientras van llegando







            temperaturaQ.Enqueue(newTemperature);
            temperaturaQ.Dequeue();
            temperaturaA = temperaturaQ.ToArray();



            papel.FillRectangle(new SolidBrush(Color.Purple), posicionHora3, ((70 - float.Parse(temperaturaA[0])) * (((pictureBox1.Height / 2f) + 150) / 70)), 10, 10);
            papel.DrawString(temperaturaA[0], fuente, pincel, posicionHora3, ((70 - float.Parse(temperaturaA[0])) * (((pictureBox1.Height / 2f) + 150) / 70)));

            papel.FillRectangle(new SolidBrush(Color.Purple), posicionHora2, ((70 - float.Parse(temperaturaA[0])) * (((pictureBox1.Height / 2f) + 150) / 70)), 10, 10);
            papel.DrawString(temperaturaA[1], fuente, pincel, posicionHora2, ((70 - float.Parse(temperaturaA[0])) * (((pictureBox1.Height / 2f) + 150) / 70)));

            papel.FillRectangle(new SolidBrush(Color.Purple), posicionHora1, ((70 - float.Parse(temperaturaA[0])) * (((pictureBox1.Height / 2f) + 150) / 70)), 10, 10);
            papel.DrawString(temperaturaA[2], fuente, pincel, posicionHora1, ((70 - float.Parse(temperaturaA[0])) * (((pictureBox1.Height / 2f) + 150) / 70)));

            papel.FillRectangle(new SolidBrush(Color.Purple), posicionHora0, ((70 - float.Parse(temperaturaA[0])) * (((pictureBox1.Height / 2f) + 150) / 70)), 10, 10);
            papel.DrawString(temperaturaA[3], fuente, pincel, posicionHora0, ((70 - float.Parse(temperaturaA[0])) * (((pictureBox1.Height / 2f) + 150) / 70)));




            float temperaturaActual = float.Parse(temperaturaA[0]);

            if (temperaturaActual > valorRangoSUP)
            {
                alerta.BackColor = Color.Red;
                alerta.Text = "ALERTA: Temperatura actual: " + temperaturaActual.ToString() + " °C por arriba del rango máximo " + valorRangoSUP.ToString() + " °C .Apague el mechero.";
            }
            else if (temperaturaActual < valorRangoINF)
            {
                alerta.BackColor = Color.Blue;
                alerta.Text = "ALERTA: Temperatura actual: " + temperaturaActual.ToString() + " °C por debajo del rango mínimo " + valorRangoSUP.ToString() + " °C Encienda el mechero.";
            }
            else
            {
                alerta.BackColor = Color.Green;
                alerta.Text = "ALERTA: Temperatura: " + temperaturaActual.ToString() + " °C en rango.";
            }









        }






        #region BOTÓN APAGAR
        private void btnStop_Click(object sender, EventArgs e)
        {
            fuego.Visible = false;
            alerta.Visible = false;

            Graphics borrarpapel;

            borrarpapel = pictureBox1.CreateGraphics();
            borrarpapel.Clear(Color.Black);
            timer1.Stop();

        }
        #endregion


        #region Cerrar puerto serie
        //para que no se quede esperando valores el puerto serie y evitar errores

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsClosed = true;
            if (Port.IsOpen)
            {
                Port.Close();
            }
        }
        #endregion












    }



}