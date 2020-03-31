using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_magisterska
{
    
    public partial class Form1 : Form
    {
        private TCP tcp;                    //inicjalizacja klasy

        public Form1()
        {
            InitializeComponent();

            tcp = new TCP("192.168.1.120", 502);                //konstruktor klasy TCP - adres IP karty sieciowej Arduino

        }



        private void timer_Tick(object sender, EventArgs e)
        {
            tcp.Run();
            if (tcp.Connected)
            {
                panel_KontrolkaPolaczenieTCP.BackColor = Color.Lime;
            }
            else
            {
                panel_KontrolkaPolaczenieTCP.BackColor = Color.DarkGray;
            }

            if(tcp.textFromSlave != "")
            {
                textBox_WiadomoscOdSlave.Text = tcp.textFromSlave;
            }

        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            if(textBox_WiadomoscDoSlave.Text != "")
            {
                tcp.textToSlave = textBox_WiadomoscDoSlave.Text;
                textBox_WiadomoscDoSlave.Clear();
                textBox_WiadomoscOdSlave.Clear();
                tcp.Start = true;
            }
            
        }
    }
}
