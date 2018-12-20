using LinqToExcel.Attributes;

namespace Ponto.DTO
{
    public class ExcelControleHorasDTO
    {
        [ExcelColumn("Data")]
        public string Data { get; set; }

        [ExcelColumn("Começo")] 
        public string Entrada { get; set; }

        [ExcelColumn("Fim")] 
        public string Saida { get; set; }

        [ExcelColumn("Nome")]
        public string Nome { get; set; }
    }
}