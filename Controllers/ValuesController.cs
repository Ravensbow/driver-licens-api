using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public List<Pytanie> Get(int id)
        {
            List<Pytanie> pod3 = new List<Pytanie>();
            List<Pytanie> wylosowane = new List<Pytanie>();

            char kategoria = Convert.ToChar(id);

            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand comand = conn.CreateCommand();


            comand.CommandText = "SELECT Numer_Pytania, TrescPL, OdpApl, OdpBpl, OdpCpl, Media, LiczbaPunktow,PoprawnaOdp FROM pytanie WHERE Zakres_Struktury = 'PODSTAWOWY' AND find_in_set('" + kategoria + "',Kategorie) and LiczbaPunktow = 3";

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                pod3.Add(new Pytanie { Numer_Pytania = ex.ToString() });
                return pod3;
            }

            #region Podstawa 3p.
            MySqlDataReader reader = comand.ExecuteReader();

            while (reader != null && reader.Read())
            {
                pod3.Add(new Pytanie
                {
                    Numer_Pytania = reader.GetString(0),
                    TrescPL = reader.GetString(1),
                    OdpApl = reader.GetString(2),
                    OdpBpl = reader.GetString(3),
                    OdpCpl = reader.GetString(4),
                    Media = reader.GetString(5),
                    LiczbaPunktow = reader.GetString(6),
                    PoprawnaOdp = reader.GetString(7)
                });
            }
            reader.Close();
            while (wylosowane.Count < 10)
            {
                Random rn = new Random();
                int los = rn.Next(0, pod3.Count);
                wylosowane.Add(pod3[los]);
                pod3.RemoveAt(los);
            }
            pod3.Clear();
            #endregion

            #region Podstawa 2p.
            comand.CommandText = "SELECT Numer_Pytania, TrescPL, OdpApl, OdpBpl, OdpCpl, Media, LiczbaPunktow,PoprawnaOdp FROM pytanie WHERE Zakres_Struktury = 'PODSTAWOWY' AND find_in_set('" + kategoria + "',Kategorie) and LiczbaPunktow = 2";

            reader = comand.ExecuteReader();

            while (reader != null && reader.Read())
            {
                pod3.Add(new Pytanie
                {
                    Numer_Pytania = reader.GetString(0),
                    TrescPL = reader.GetString(1),
                    OdpApl = reader.GetString(2),
                    OdpBpl = reader.GetString(3),
                    OdpCpl = reader.GetString(4),
                    Media = reader.GetString(5),
                    LiczbaPunktow = reader.GetString(6),
                    PoprawnaOdp = reader.GetString(7)
                });
            }
            reader.Close();
            while (wylosowane.Count < 16)
            {
                Random rn = new Random();
                int los = rn.Next(0, pod3.Count);
                wylosowane.Add(pod3[los]);
                pod3.RemoveAt(los);
            }
            pod3.Clear();
            #endregion

            #region Podstawa 1p.
            comand.CommandText = "SELECT Numer_Pytania, TrescPL, OdpApl, OdpBpl, OdpCpl, Media, LiczbaPunktow,PoprawnaOdp FROM pytanie WHERE Zakres_Struktury = 'PODSTAWOWY' AND find_in_set('" + kategoria + "',Kategorie) and LiczbaPunktow = 1";

            reader = comand.ExecuteReader();

            while (reader != null && reader.Read())
            {
                pod3.Add(new Pytanie
                {
                    Numer_Pytania = reader.GetString(0),
                    TrescPL = reader.GetString(1),
                    OdpApl = reader.GetString(2),
                    OdpBpl = reader.GetString(3),
                    OdpCpl = reader.GetString(4),
                    Media = reader.GetString(5),
                    LiczbaPunktow = reader.GetString(6),
                    PoprawnaOdp = reader.GetString(7)
                });
            }
            reader.Close();
            while (wylosowane.Count < 20)
            {
                Random rn = new Random();
                int los = rn.Next(0, pod3.Count);
                wylosowane.Add(pod3[los]);
                pod3.RemoveAt(los);
            }
            pod3.Clear();
            #endregion

            #region Specjalistyczne 3p.
            comand.CommandText = "SELECT Numer_Pytania, TrescPL, OdpApl, OdpBpl, OdpCpl, Media, LiczbaPunktow,PoprawnaOdp FROM pytanie WHERE Zakres_Struktury ='SPECJALISTYCZNY' AND find_in_set('" + kategoria + "',Kategorie) and LiczbaPunktow = 3";

            reader = comand.ExecuteReader();

            while (reader != null && reader.Read())
            {
                pod3.Add(new Pytanie
                {
                    Numer_Pytania = reader.GetString(0),
                    TrescPL = reader.GetString(1),
                    OdpApl = reader.GetString(2),
                    OdpBpl = reader.GetString(3),
                    OdpCpl = reader.GetString(4),
                    Media = reader.GetString(5),
                    LiczbaPunktow = reader.GetString(6),
                    PoprawnaOdp = reader.GetString(7)
                });
            }
            reader.Close();
            while (wylosowane.Count < 26)
            {
                Random rn = new Random();
                int los = rn.Next(0, pod3.Count);
                wylosowane.Add(pod3[los]);
                pod3.RemoveAt(los);
            }
            pod3.Clear();
            #endregion

            #region Specjalistyczne 2p.
            comand.CommandText = "SELECT Numer_Pytania, TrescPL, OdpApl, OdpBpl, OdpCpl, Media, LiczbaPunktow,PoprawnaOdp FROM pytanie WHERE Zakres_Struktury ='SPECJALISTYCZNY' AND find_in_set('" + kategoria + "',Kategorie) and LiczbaPunktow = 2";

            reader = comand.ExecuteReader();

            while (reader != null && reader.Read())
            {
                pod3.Add(new Pytanie
                {
                    Numer_Pytania = reader.GetString(0),
                    TrescPL = reader.GetString(1),
                    OdpApl = reader.GetString(2),
                    OdpBpl = reader.GetString(3),
                    OdpCpl = reader.GetString(4),
                    Media = reader.GetString(5),
                    LiczbaPunktow = reader.GetString(6),
                    PoprawnaOdp = reader.GetString(7)
                });
            }
            reader.Close();
            while (wylosowane.Count < 30)
            {
                Random rn = new Random();
                int los = rn.Next(0, pod3.Count);
                wylosowane.Add(pod3[los]);
                pod3.RemoveAt(los);
            }
            pod3.Clear();
            #endregion

            #region Specjalistyczne 1p.
            comand.CommandText = "SELECT Numer_Pytania, TrescPL, OdpApl, OdpBpl, OdpCpl, Media, LiczbaPunktow,PoprawnaOdp FROM pytanie WHERE Zakres_Struktury ='SPECJALISTYCZNY' AND find_in_set('" + kategoria + "',Kategorie) and LiczbaPunktow = 1";

            reader = comand.ExecuteReader();

            while (reader != null && reader.Read())
            {
                pod3.Add(new Pytanie
                {
                    Numer_Pytania = reader.GetString(0),
                    TrescPL = reader.GetString(1),
                    OdpApl = reader.GetString(2),
                    OdpBpl = reader.GetString(3),
                    OdpCpl = reader.GetString(4),
                    Media = reader.GetString(5),
                    LiczbaPunktow = reader.GetString(6),
                    PoprawnaOdp = reader.GetString(7)
                });
            }
            reader.Close();
            while (wylosowane.Count < 32)
            {
                Random rn = new Random();
                int los = rn.Next(0, pod3.Count);
                wylosowane.Add(pod3[los]);
                pod3.RemoveAt(los);
            }
            pod3.Clear();
            #endregion

            return wylosowane;

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
