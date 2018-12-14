using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponto.Entity;

namespace Ponto.Helper
{
    /// <summary>
    /// maior gambeta pra nao ter que ficar formatando XLS kkk
    /// </summary>
    public class BatidasFactory
    {
        public List<BatidasPonto> GetList()
        {
            string[] data = {

                "14/09/2018",
                "17/09/2018",
                "18/09/2018",
                "19/09/2018",
                "20/09/2018",
                "21/09/2018",
                "24/09/2018",
                "25/09/2018",
                "26/09/2018",
                "27/09/2018",
                "28/09/2018",
                "01/10/2018",
                "02/10/2018",
                "03/10/2018",
                "04/10/2018",
                "05/10/2018",
                "08/10/2018",
                "09/10/2018",
                "10/10/2018",
                "11/10/2018",
                "12/10/2018",
                "15/10/2018",
                "16/10/2018",
                "17/10/2018",
                "18/10/2018",
                "19/10/2018",
                "22/10/2018",
                "23/10/2018",
                "24/10/2018",
                "25/10/2018",
                "26/10/2018",
                "29/10/2018",
                "30/10/2018",
                "31/10/2018",
                "01/11/2018",
                "02/11/2018",
                "05/11/2018",
                "06/11/2018",
                "07/11/2018",
                "08/11/2018",
                "09/11/2018",
                "12/11/2018",
                "13/11/2018",
                "14/11/2018",
                "15/11/2018",
                "16/11/2018",
                "19/11/2018",
                "20/11/2018",
                "21/11/2018",
                "22/11/2018",
                "23/11/2018",
                "26/11/2018",
                "27/11/2018",
                "28/11/2018",
                "29/11/2018",
                "30/11/2018",
                "03/12/2018",
                "04/12/2018",
                "05/12/2018",
                "06/12/2018",
                "07/12/2018",
                "10/12/2018",
                "11/12/2018",
                "12/12/2018",
                "13/12/2018",


            };
            string[] entrada = {
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "08:01",
                "08:36",
                "08:55",
                "10:19",
                "08:42",
                "08:39",
                "08:31",
                "08:00",
                "09:19",
                "09:16",
                "08:48",
                "09:25",
                "09:20",
                "Feriado",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "09:20",
                "08:55",
                "09:26",
                "09:07",
                "15:43",
                "08:09",
                "09:17",
                "08:32",
                "12:02",
                "Feriado",
                "10:07",
                "08:00",
                "08:21",
                "09:17",
                "10:02",
                "09:00",
                "08:02",
                "08:00",
                "Feriado",
                "Emenda",
                "Emenda",
                "Feriado",
                "08:07",
                "Falta",
                "07:41",
                "09:08",
                "09:52",
                "10:17",
                "09:06",
                "06:56",
                "Falta",
                "07:26",
                "09:53",
                "08:10",
                "09:56",
                "10:27",
                "11:56",
                "10:38",
                "11:01"
            };
            string[] saida =
            {
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "16:58",
                "17:37",
                "18:06",
                "19:23",
                "18:57",
                "18:06",
                "17:44",
                "17:00",
                "18:12",
                "18:52",
                "16:57",
                "19:02",
                "18:56",
                "Feriado",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "Férias",
                "19:04",
                "18:07",
                "18:57",
                "18:46",
                "19:53",
                "16:55",
                "18:46",
                "18:31",
                "19:46",
                "Feriado",
                "19:21",
                "17:10",
                "18:16",
                "19:23",
                "19:21",
                "18:46",
                "18:42",
                "19:08",
                "Feriado",
                "Emenda",
                "Emenda",
                "Feriado",
                "16:18",
                "Falta",
                "19:55",
                "17:45",
                "18:51",
                "19:01",
                "19:57",
                "19:07",
                "Falta",
                "18:17",
                "17:52",
                "19:49",
                "19:36",
                "19:41",
                "19:49",
                "19:19",
                "19:20",
            };


            var list = new List<BatidasPonto>();
            for (var i = 0; i < data.Length; i++)
            {
                var date = data[i];
                switch (entrada[i])
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
                            DataEntrada = Convert.ToDateTime($"{date} {entrada[i]}"),
                            DataSaida = Convert.ToDateTime($"{date} {saida[i]}")
                        });
                        continue;
                }
            }
            return list;
        }
    }
}

