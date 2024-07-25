using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Http;
using Newtonsoft.Json;

using PROJECT.DAL;

namespace TES_LOGISTICT 
{
    

    class Program 
    {
        class GetResponseBarang
        {
            public DataBarang[] data { get; set; }

            public string code { get; set; }
            public string message { get; set; }
        }

        class DataBarang
        {
            public string hs_code_format { get; set; }
            public string uraian_id { get; set; }
            public string sub_header { get; set; }
        }

        class GetResponseTarif
        {
            public DataTarif[] data { get; set; }

            public string code { get; set; }
            public string message { get; set; }
        }

        class DataTarif
        {
            public string hs_code { get; set; }
            public int bm { get; set; }
            public int ppnmb { get; set; }
            public int cukai { get; set; }
            public string bk { get; set; }
            public string ppnbk { get; set; }
        }

        static void Main(string[] args)
        {
            //string url1 = "https://api-hub.ilcs.co.id/my/n/barang?hs_code=";
            //string url2 = "https://api-hub.ilcs.co.id/my/n/tarif?hs_code=";
            string url3 = "https://api-hub.ilcs.co.id/my/n/";

            string input1 = Console.ReadLine();
            string param_url_1 = "barang?hs_code=" + input1;
            string param_url_2 = "tarif?hs_code=" + input1;

            //get barang
            var client_barang = new HttpClient();
            client_barang.BaseAddress = new Uri(url3);

            var response_barang = client_barang.GetAsync(param_url_1).Result;

            if (response_barang.IsSuccessStatusCode)
            {
                var responseContentBarang = response_barang.Content.ReadAsStringAsync().Result;
                var getResponseBarang = JsonConvert.DeserializeObject<GetResponseBarang>(responseContentBarang);
                string hs_code_format = getResponseBarang.data[0].hs_code_format;
                string uraian_id = getResponseBarang.data[0].uraian_id;
                string sub_header = getResponseBarang.data[0].sub_header;

                //get tarif
                var client_tarif = new HttpClient();
                client_tarif.BaseAddress = new Uri(url3);
                var response_tarif = client_tarif.GetAsync(param_url_2).Result;
                if (response_tarif.IsSuccessStatusCode)
                {
                    var responseContentTarif = response_tarif.Content.ReadAsStringAsync().Result;
                    var getResponseTarif = JsonConvert.DeserializeObject<GetResponseTarif>(responseContentTarif);
                    int bm = getResponseTarif.data[0].bm;

                    float input2 = Convert.ToInt32(Console.ReadLine());
                    float nilai_bm = input2 * bm / 100;

                    //insert to db
                    try
                    {
                        GenericDal _dal = null;
                        Hashtable _htParameters = null;

                        _htParameters = new Hashtable();
                        _htParameters["p_kode_barang"] = input1;
                        _htParameters["p_uaraian_barang"] = sub_header;
                        _htParameters["p_bm"] = bm;
                        _htParameters["p_nilai_komoditas"] = input2;
                        _htParameters["p_nilai_bm"] = nilai_bm;

                        _dal = new GenericDal();
                        _dal.Execute("sp_result_insert", _htParameters);

                        Console.WriteLine("Success save data");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + response_tarif.StatusCode);
                }

            }
            else
            {
                Console.WriteLine("Error: " + response_barang.StatusCode);
            }
        }
    }
}
