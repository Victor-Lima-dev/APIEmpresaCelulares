using System;

namespace APIEmpresaCelulares.Model
{
    public class Mensagem
    {
        public int MensagemId { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }

        //lista clientes que receberam a mensagem  
        public List<Cliente> Cliente { get; set; }
    }
}
