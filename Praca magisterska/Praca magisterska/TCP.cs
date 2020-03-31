using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Praca_magisterska
{
    class TCP
    {

        //Deklaracje zmiennych prywatnych
        private CountTimer timer130; //timer pomiaru czasu oczekiwania na odpowiedź z FIS
        private TcpClient client; //soket komunikacji TCPIP
        private NetworkStream stream; //strumień komunikacji TCPIP

        //Deklaracja zmiennych publicznych
        public string textToSlave; //tekst do wysłąnia do FIS
        public string textFromSlave; //tekst do odebrania od FIS



        private int _krok; //krok cyklu komunikacji z FIS
        public int Krok
        {
            get
            {
                return _krok;
            }
        }

        private bool _start; //sygnał startu komunikacji z FIS
        public bool Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        private string _addressIp; //adres IP FIS
        public string AddresIp
        {
            get
            {
                return _addressIp;
            }
            set
            {
                _addressIp = value;
            }
        }

        private int _port; //numer portu FIS
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        private bool _connected; //stan połączenia z FIS
        public bool Connected
        {
            get
            {
                return _connected;
            }
        }

        public bool IsMessage //Sprawdzenie, czy przyszła odpowiedź z FIS
        {
            get
            {
                bool wynik = false;

                if (_connected)
                {
                    if (client.Available > 0)
                    {
                        wynik = true;
                    }
                }

                return wynik;
            }
        }



        public TCP(string ip = "", int port = 0) //Konstruktor klasy
        {
            //inicjalizacja zmiennych
            _krok = 0;
            timer130 = new CountTimer();
            timer130.Time = 2000;
            client = null;
            stream = null;
            textToSlave = "";
            textFromSlave = "";

            _start = false;
            _addressIp = ip;
            _port = port;
            _connected = false;
        }



        public bool Connect() //Otwarcie połączenia z FIS
        {
            if (!_connected)
            {
                try
                {
                    client = new TcpClient(_addressIp, _port);
                }
                catch
                {
                    client = null;
                    _connected = false;
                    return false;
                }

                try
                {
                    stream = client.GetStream();
                }
                catch
                {
                    stream = null;
                    _connected = false;
                    return false;
                }

                _connected = true;
            }

            return true;
        }

        public bool Connect(string ip, int port) //Otwarcie połączenia z FIS
        {
            _addressIp = ip;
            _port = port;

            return Connect();
        }

        public bool Disconnect() //Zamknięcie połączenia z FIS
        {
            stream.Close();
            client.Close();

            stream = null;
            client = null;

            _connected = false;

            return true;
        }

        public bool SendMessage(string message) //Wysłanie wiadomości do FIS
        {
            if (_connected)
            {
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Send the message to the connected TcpServer.
                try
                {
                    stream.Write(data, 0, data.Length);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string ReceiveMessage() //Odebranie wiadomści z FIS
        {
            string result;

            if ((_connected) & (IsMessage))
            {
                int bytesReady, bytesIs;

                // Buffer to store the response bytes.
                Byte[] data = new Byte[256];

                // Read the first batch of the TcpServer response bytes.
                //bytes = stream.Read(data, 0, data.Length);
                bytesReady = client.Available;
                try
                {
                    bytesIs = stream.Read(data, 0, client.Available);
                }
                catch
                {
                    return "";
                }

                if (bytesReady == bytesIs)
                {
                    result = System.Text.Encoding.ASCII.GetString(data, 0, bytesIs);

                    //result = System.Text.Encoding.Unicode.GetString(data, 0, bytesIs);
                }
                else
                {
                    result = "";
                }
            }
            else
            {
                result = "";
            }

            return result;
        }

        public int Run() //Pełna komunikacja z FIS za pomocą właściwości
        {
            if (!_start)
            {
                if (_krok > 100) _krok = 0;
            }

            timer130.Check();

            switch (_krok)
            {
                case 0:
                    {
                        if (_connected) _krok = 10;
                        else _krok = 100;
                    }
                    break;
                case 10:
                    {
                        Disconnect();
                        _krok = 100;
                    }
                    break;
                case 100: //Oczekiwanie na uruchomienie komunikacji z TCP
                    {
                        if (_start)
                        {
                            _krok = 110;
                        }
                        else
                        {
                        }
                    }
                    break;
                case 110: //Otwarcie połączenia z TCP
                    {
                        if (Connect(_addressIp, _port))
                        {
                            _krok = 120;
                        }
                        else
                        {
                            _krok = 10000;
                        }
                    }
                    break;
                case 120: //Wysłanie wiadomości do TCP
                    {
                        if (SendMessage(textToSlave))
                        {
                            _krok = 130;
                        }
                        else
                        {
                            _krok = 10000;
                        }
                    }
                    break;
                case 130: //Oczekiwanie na odpowiedź
                    {
                        timer130.Enable = true;

                        if (IsMessage)
                        {
                            _krok = 140;
                        }
                        else if (timer130.Q)
                        {
                            _krok = 10000;
                        }
                    }
                    break;
                case 140: //Odbieranie wiadomości
                    {
                        textFromSlave = ReceiveMessage();

                        if (textFromSlave != "")
                        {
                            _krok = 150;
                        }
                        else
                        {
                            _krok = 10000;
                        }
                    }
                    break;
                case 150: //Zamknięcie połączenia
                    {
                        Disconnect();
                        _start = false;
                        _krok = 200;
                    }
                    break;
                case 10000: //sygnalizacja błędu komunikacji
                    {
                        textFromSlave = "";
                        _start = false;
                    }
                    break;
                default:
                    {
                        timer130.Enable = false;
                    }
                    break;
            }

            return _krok;
        }

    }
}
