using System;

namespace APIEmpresaCelulares.Model
{
    public class Mensagem
    {
        public int MensagemId { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }

        public List<int> ClienteId { get; set; }
    }
}
