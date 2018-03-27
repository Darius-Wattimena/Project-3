using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using ProjectData.Database.Entities;

namespace ProjectData.Database
{
    public class DatabaseUtil
    {
        public static void TestConnection()
        {
            Database.GetInstance().TestConnection();
        }

        public static List<T> GetDataFromDataReader<T>(MySqlDataReader dr)
        {
            if (typeof(T) == typeof(Regio))
            {
                return DataReaderToRegio(dr) as List<T>;
            }
            else if (typeof(T) == typeof(Preventie))
            {
                return DataReaderToPreventie(dr) as List<T>;
            }
            else if (typeof(T) == typeof(Diefstal))
            {
                return DataReaderToDiefstal(dr) as List<T>;
            }
            return new List<T>();
        }

        private static List<Regio> DataReaderToRegio(IDataReader dr)
        {
            var regios = new List<Regio>();

            while (dr.Read())
            {
                var region = new Regio
                {
                    RegioId = dr.GetInt32(0),
                    Code = dr.GetString(1),
                    Name = dr.GetString(2)
                };
                regios.Add(region);
            }

            return regios;
        }

        private static List<Preventie> DataReaderToPreventie(IDataReader dr)
        {
            var preventies = new List<Preventie>();

            while (dr.Read())
            {
                var preventie = new Preventie
                {
                    Regios = dr.GetString(0),
                    Perioden = dr.GetString(1),
                    LichtAfwezig = dr.GetFloat(2)
                };
                preventies.Add(preventie);
            }

            return preventies;
        }

        private static List<Diefstal> DataReaderToDiefstal(IDataReader dr)
        {
            var diefstallen = new List<Diefstal>();

            while (dr.Read())
            {
                var diefstal = new Diefstal
                {
                    Gebruikgeweld = dr.GetInt32(0),
                    Soortdiefstal = dr.GetInt32(0),
                    Regios = dr.GetString(2),
                    Perioden = dr.GetString(3),
                    Totaaldiefstal = dr.GetFloat(4)
                };
                diefstallen.Add(diefstal);
            }

            return diefstallen;
        }
    }
}
