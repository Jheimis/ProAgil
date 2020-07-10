namespace ProAgil.api.Model
{
    public class Evento
    {
        public int eventoId { get; set; }  
        public string local { get; set; }
        public string dataEvento { get; set; }
        public string tema { get; set; }
        public int qtdPessoas { get; set; }
        public string lote { get; set; }
        public string imageUrl { get; set; }

    }
}