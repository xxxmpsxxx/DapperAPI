﻿namespace DapperAPI.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public bool IsAtivo { get; set; }
    }
}
