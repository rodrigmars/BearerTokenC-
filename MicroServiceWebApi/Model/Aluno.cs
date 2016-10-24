using System;

namespace MicroServiceWebApi.Model
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
