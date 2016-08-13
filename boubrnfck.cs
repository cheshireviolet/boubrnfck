using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boubrnfck
{
    class boubrnfck
    {
        //This is probably not optimized sorry about the mess 
        class Func
        {
            public int start, end;
            public Func(int a, int b)
            {
                start = a;
                end = b;
            }

        }


        int[] _mem = new int[30000], _lInit = new int[14999];//Tape and an array that'll store '[' positions
        int _p = 0, _l = 0, _f = 0, _c = 0; //tape, loop, function and input pointers.
        string _i; // input
        Func[] _fun = new Func[14000];

        public boubrnfck(string a)
        {
            _i = a;
            Exec();
        }

        private void Exec(int start = 0, int end = 0)
        {

            end = (end == 0) ? _i.Length : end;
            for(int a = start; a < end;a++)
            {
                _c = a;
                Action(_i[a]);
                a = _c;
            }
        }

        private void Action(char a)
        {
            switch (a)
            {
                case '+': _mem[_p] += (_mem[_p] == 255) ? -255 : 1; break;
                case '-': _mem[_p] += (_mem[_p] == 0) ? 255 : -1; break;
                case '.': Console.Write((char)_mem[_p]); break;
                case ',': _mem[_p] = Console.ReadKey().KeyChar; break;
                case '>': _p++; break;
                case '<': _p--; break;
                case '[':
                    _lInit[_l] = (_mem[_p] > 0) ? _c : 0; _l++;
                    if (_mem[_p] == 0)
                    {
                        int _k = 1;
                        while (_k != 0)
                        {
                            _c++;
                            switch (_i[_c]) { case '[': ++_k; break; case ']': --_k; break; }
                        }
                    }
                    break;
                case ']': --_l; if (_lInit[_l] != 0 && _mem[_p] > 0) _c = _lInit[_l] - 1; break;
                case 'v': ++_f; break;
                case '^': --_f; break;
                case '{': SaveFunction(); break;
                case '@': int _t = _c; Exec(_fun[_f].start, _fun[_f].end); _c = _t;  break;
            }
        }

        private void SaveFunction()
        {
            int _k = 0;
            int _a = _c;
            int _fStart = _a+1;
            do
            {
                switch (_i[_a])
                {
                    case '{': ++_k; break;
                    case '}': --_k; break;
                    default: break;
                }
                _a++;
            } while (_k > 0);
            _fun[_f] = new Func(_fStart, _a-1);
            _c = _a-1;
        }
    }
}
