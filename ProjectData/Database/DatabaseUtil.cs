using System;
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
            var type = typeof(T);

            if (type == typeof(Regio))
            {
                return DataReaderToRegio(dr) as List<T>;
            }

            if (type == typeof(Preventie))
            {
                return DataReaderToPreventie(dr) as List<T>;
            }

            if (type == typeof(Diefstal))
            {
                return DataReaderToDiefstal(dr) as List<T>;
            }

            if (type == typeof(GemiddeldInkomen))
            {
                return DataReaderToGemiddeldInkomen(dr) as List<T>;
            }

            if (type == typeof(Veiligheid))
            {
                return DataReaderToVeiligheid(dr) as List<T>;
            }

            return new List<T>();
        }

        private static List<Veiligheid> DataReaderToVeiligheid(MySqlDataReader dr)
        {
            var veiligheids = new List<Veiligheid>();

            while (dr.Read())
            {
                var veiligheid = new Veiligheid
                {
                    VeiligheidsbelevingId = dr.GetInt32(0),
                    Marges = dr.GetString(1),
                    RegioCode = dr.GetString(2),
                    Perioden = dr.GetString(3),
                    WelEensOnveilig = dr.GetString(4),
                    VaakOnveilig = dr.GetString(5),
                    Zakkenrollerij = dr.GetString(6),
                    StraatBeroving = dr.GetString(7),
                    WoningInbraak = dr.GetString(8),
                    Mishandeling = dr.GetString(9),
                    WelEensOnveiligBuurt = dr.GetString(10),
                    VaakOnveiligBuurt = dr.GetString(11),
                    AvondBuurt = dr.GetString(12),
                    AvondAlleenThuis = dr.GetString(13),
                    AvondDeurNietOpen = dr.GetString(14),
                    LooptOm = dr.GetString(15),
                    BangSlachtoffer = dr.GetString(16),
                    CriminaliteitBuurtToe = dr.GetString(17),
                    CriminaliteitBuurtAf = dr.GetString(18),
                    CriminaliteitBuurtGelijk = dr.GetString(19),
                    CijferVeiligheidBuurt = dr.GetString(20),
                    Uitgaan = dr.GetString(21),
                    Hangplekken = dr.GetString(22),
                    CentrumWoonplaats = dr.GetString(23),
                    Winkelgebied = dr.GetString(24),
                    InOV = dr.GetString(25),
                    Treinstation = dr.GetString(26),
                    EigenHuis = dr.GetString(27),
                    OnbekendenStraat = dr.GetString(28),
                    OnbekendenOV = dr.GetString(29),
                    PersoneelWinkelsBedrijven = dr.GetString(30),
                    PersoneelOverheid = dr.GetString(31),
                    BekendenPartnerFamilie = dr.GetString(32)
                };
                veiligheids.Add(veiligheid);
            }

            return veiligheids;
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
                    PreventieId = dr.GetInt32(0),
                    RegioCode = dr.GetString(1),
                    Perioden = dr.GetString(2),
                    LichtBijAfwezigheid = dr.GetDecimal(3),
                    FietsInStalling = dr.GetDecimal(4),
                    SpullenUitAuto = dr.GetDecimal(5),
                    SpullenThuisLaten = dr.GetDecimal(6),
                    SociaalPreventiefGedragscore = dr.GetDecimal(7),
                    ExtraSlotenDeur = dr.GetDecimal(8),
                    Rolluiken = dr.GetDecimal(9),
                    Buitenverlichting = dr.GetDecimal(10),
                    Alarm = dr.GetDecimal(11),
                    PreventieSomscore = dr.GetDecimal(12)
                };
                preventies.Add(preventie);
            }

            return preventies;
        }

        private static List<GemiddeldInkomen> DataReaderToGemiddeldInkomen(IDataReader dr)
        {
            var gemiddeldInkomens = new List<GemiddeldInkomen>();

            while (dr.Read())
            {
                var gemiddeldInkomen = new GemiddeldInkomen
                {
                    GemiddeldInkomenId = dr.GetInt32(0),
                    RegioCode = dr.GetString(1),
                    Perioden = dr.GetString(2),
                    AantalPersonen = dr.GetDecimal(3),
                    GemiddeldBesteedbaarInkomen = dr.GetDecimal(4),
                    RangnummerBesteedbaarInkomen = dr.GetInt32(5),
                    GemiddeldGestandaardiseerdInkomen = dr.GetDecimal(6),
                    RangnummerGestandaardiseerdInkomen = dr.GetInt32(7),
                    AantalPersonen_2 = dr.GetDecimal(8),
                    InVanPersonenMetEnZonderInkomen = dr.GetInt32(9),
                    GemiddeldPersoonlijkInkomen = dr.GetDecimal(10),
                    RangnummerPersoonlijkInkomen = dr.GetInt32(11),
                    GemiddeldBesteedbaarInkomen_2 = dr.GetDecimal(12),
                    RangnummerBesteedbaarInkomen_2 = dr.GetInt32(13)
                };
                gemiddeldInkomens.Add(gemiddeldInkomen);
            }

            return gemiddeldInkomens;
        }

        private static List<Diefstal> DataReaderToDiefstal(IDataReader dr)
        {
            var diefstallen = new List<Diefstal>();

            while (dr.Read())
            {
                var diefstal = new Diefstal
                {
                    DiefstalId = dr.GetInt32(0),
                    GebruikVanGeweld = dr.GetString(1),
                    SoortDiefstal = dr.GetString(2),
                    RegioCode = dr.GetString(3),
                    Perioden = dr.GetString(4),
                    TotaalGeregistreerdeDiefstallen = dr.GetString(5),
                    GeregistreerdeDiefstallenRelatief = dr.GetString(6),
                    GeregistreerdeDiefstallenPer1000Inw = dr.GetDecimal(7),
                    TotaalOpgehelderdeDiefstallen = dr.GetString(8),
                    OpgehelderdeDiefstallenRelatief = dr.GetDecimal(9),
                    RegistratiesVanVerdachten = dr.GetString(10)
                };
                diefstallen.Add(diefstal);
            }

            return diefstallen;
        }
    }
}
