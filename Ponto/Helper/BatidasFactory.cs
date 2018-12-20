using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using Ponto.DTO;
using Ponto.Entity;

namespace Ponto.Helper
{
    /// <summary>
    /// maior gambeta pra nao ter que ficar formatando XLS kkk
    /// </summary>
    public class BatidasFactory
    {
        private string path;
        private readonly ExcelQueryFactory excel;
        public BatidasFactory()
        {
            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            path += @"\Folha\Controle_horas.xlsx";
            excel = new ExcelQueryFactory(path);
        }

        public string GetNomeUsuario()
        {
            return excel.Worksheet<ExcelControleHorasDTO>(0).ToList()[0].Nome;
        }

        public List<BatidasPonto> GetList()
        {
            var list = LoadArrays(excel.Worksheet<ExcelControleHorasDTO>(0).ToList());
            return list;
        }

        private List<BatidasPonto> LoadArrays(List<ExcelControleHorasDTO> lista)
        {
            var list = new List<BatidasPonto>();

            foreach (var item in lista)
            {
                var date = item.Data.Substring(0,10);
                switch (item.Entrada)
                {
                    case "Férias":
                    case "Feriado":
                    case "Atestado":
                        continue;
                    case "Falta":
                    case "Emenda":
                        list.Add(new BatidasPonto
                        {
                            DataEntrada = Convert.ToDateTime($"{date} 08:00"),
                            DataSaida = Convert.ToDateTime($"{date} 08:01")
                        });
                        continue;
                    default:
                        list.Add(new BatidasPonto
                        {
                            DataEntrada = Convert.ToDateTime($"{date} {item.Entrada}"),
                            DataSaida = Convert.ToDateTime($"{date} {item.Saida}")
                        });
                        continue;
                }
            }
          
            return list;
        }
    }
}

