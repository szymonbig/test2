using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_magisterska
{
    class CountTimer
    {

        private int poczatekTimera; //czas od startu timera
        private int pamiecTimera; //zliczony czas w timerze z pamięcią
        private bool kontrolatTmera; //znacznik kontroli timera



        private bool _enable; //stan uruchomienia timera
        public bool Enable //Właściwość stanu uruchomienia timera
        {
            get
            {
                return _enable;
            }
            set
            {
                if (_type == "TON")
                {
                    if ((!_enable) & (value)) //zbocze narastające sygnału Enable
                    {
                        poczatekTimera = Environment.TickCount;
                    }
                }
                else if (_type == "TOFF")
                {
                    if ((_enable) & (!value)) //zbocze opadające sygnału Enable
                    {
                        poczatekTimera = Environment.TickCount;
                    }
                }
                else if (_type == "TMON")
                {
                    if ((!_enable) & (value)) //zbocze narastające sygnału Enable
                    {
                        poczatekTimera = Environment.TickCount;
                    }
                    else if ((_enable) & (!value)) //zbocze opadające sygnału Enable
                    {
                        pamiecTimera += Environment.TickCount - poczatekTimera;
                    }
                }

                kontrolatTmera = false;
                _enable = value;
            }
        }

        private bool _q; //stan wyjścia timera
        public bool Q //Właściwość stanu wyjścia timera
        {
            get
            {
                if (_type == "TON")
                {
                    if (_enable)
                    {
                        if (ActualTime >= _time) _q = true;
                        else _q = false;
                    }
                    else
                    {
                        _q = false;
                    }
                }
                else if (_type == "TOFF")
                {
                    if (_enable)
                    {
                        _q = true;
                    }
                    else
                    {
                        if (_q)
                        {
                            if (ActualTime >= _time) _q = false;
                            else _q = true;
                        }
                        else
                        {
                            _q = false;
                        }
                    }
                }
                if (_type == "TMON")
                {
                    if (ActualTime >= _time) _q = true;
                    else _q = false;
                }

                return _q;
            }
        }

        private int _time; //wartość czasu timera
        public int Time //Właściwość wartości czasu timera
        {
            get
            {
                return _time;
            }
            set
            {
                if (value > 0) _time = value;
                else _time = 0;
            }
        }

        private int _actualTime; //wartość aktualnie zliczonego czasu
        public int ActualTime //Właściwość wartości aktualnie zliczonego czasu
        {
            get
            {
                if ((_type == "TON") & (_enable)) _actualTime = Environment.TickCount - poczatekTimera;
                else if ((_type == "TOFF") & (!_enable) & (_q)) _actualTime = Environment.TickCount - poczatekTimera;
                else if (_type == "TMON") _actualTime = pamiecTimera + (Environment.TickCount - poczatekTimera);
                else _actualTime = 0;

                return _actualTime;
            }
        }

        private string _type; //typ timera
        public string Type //Właściwość typu timera
        {
            get
            {
                return _type;
            }
            set
            {
                switch (value)
                {
                    case "TON":
                    case "TOFF":
                    case "TMON":
                        _type = value;
                        break;
                    default:
                        _type = "TON";
                        break;
                }
            }
        }

        private bool _reset; //zmienna resetowania timera
        public bool Reset //Właściwość zmiennej resetowania timera
        {
            get
            {
                return _reset;
            }
            set
            {
                poczatekTimera = Environment.TickCount;
                pamiecTimera = 0;
                _reset = value;
            }
        }



        public CountTimer(string type = "TON", int time = 0) //Konstruktor klasy
        {
            _enable = false;
            _q = false;
            _time = time;
            _actualTime = 0;
            _type = type;
            _reset = false;
            pamiecTimera = 0;
        }

        public void Check()
        {
            if (_enable)
            {
                if (kontrolatTmera)
                {
                    Enable = false;
                }

                kontrolatTmera = true;
            }
        }

    }
}
