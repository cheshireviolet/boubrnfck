using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boubrnfck
{
    class boubrnfck
    {
        int[] _mem;
        string _input, _output = "";
        int _pointer = 0, _loopStart, _loopEnd, _charCounter = 0;
        bool _ignoreLoop = false;

        //boubrnfck stuff
        string[] _func;
        int _fPointer = 0;
        bool _saveFunc = false;
        string _tempfunc = "";

        public boubrnfck(string a)
        {
            _mem = new int[30000];
            _func = new string[15000];
            _input = a;
        }

        void Action(char a)
        {
            switch (a)
            {
                case '+': _mem[_pointer] = (_mem[_pointer] == 255) ? 0 : _mem[_pointer]+ 1; break;
                case '-': _mem[_pointer] = (_mem[_pointer] == 0) ? 255 : _mem[_pointer]- 1; break;
                case '.': _output+= (char)_mem[_pointer]; break;
                case ',': _mem[_pointer] = Console.ReadKey().KeyChar; break;
                case '>': _pointer++; break;
                case '<': _pointer--; break;
                case '[': if (_mem[_pointer] > 0) { _loopStart = _charCounter+1;} else { _ignoreLoop = true; }; break;
                case ']': _loopEnd = _charCounter-1; Loop(); break;
                //boubrnfck stuff
                case '{': _saveFunc = true; break;
                case '^': _fPointer--; break;
                case 'v': _fPointer++; break;
                case '@': ExecFunc(); break;
                default: break;
            }
        }

        public void Exec()
        {
            foreach (char a in _input)
            {
                if (!_ignoreLoop)
                {
                    if (!_saveFunc) Action(a);
                    else if (a == '}') { _saveFunc = false; SaveFunc(); }
                    else _tempfunc += a;
                }
                else if (a == ']') _ignoreLoop = false;
                ++_charCounter;
            }
            Console.WriteLine(_output);
        }

        void Loop()
        {
            bool stay = true;
            int _tempS = _loopStart, _tempE = _loopEnd;
            while (stay)
            {
                for (int a = _tempS; a <= _tempE; a++)
                {
                    Action(_input[a]);
                }
                stay = (_mem[_pointer] > 0) ? true : false;
            }
        }

        void SaveFunc()
        {
            _func[_fPointer] = _tempfunc;
            _tempfunc = "";
        }

        void ExecFunc()
        {
            foreach(char a in _func[_fPointer])
            {
                Action(a);
            }
        }

    }
}
