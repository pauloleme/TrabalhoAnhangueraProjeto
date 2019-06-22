
using System;
using System.Collections;

namespace Competicao_lol
{
    public class Time
    {
        public string nome { get; set; }
        public ArrayList jogadores { get; set; }

        public Time()
        {
            jogadores = new ArrayList();
        }
    }
}