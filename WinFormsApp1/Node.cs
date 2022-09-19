using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class Nodo
    {
        private int x;
        private int y;
        private string letter;
        public Nodo(int x, int y, string letter)
        {
            this.x = x;
            this.y = y;
            this.letter = letter;
        }
        public string getletter()
        {
            return this.letter;
        }
        public int gety() { return y; }
        public int getx() { return x; }
    }
    
}
