﻿namespace EstudoRBMQ.Relatorios
{
    internal static class Lista
    {
        public static List<SoliitacaoRelatorio> Relatorios = new(); 
    }
    public class SoliitacaoRelatorio
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime? ProcessedTime { get; set; }
    }
}