using System.Text;
using ProjectData.Database.Criterias;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Daos
{
    public class VeiligheidDao : Dao<Veiligheid, VeiligheidCriteria>
    {
        protected override void Create(StringBuilder query, Veiligheid instance)
        {
            query.Append("(Marges, Regio_Code, Perioden, Wel_Eens_Onveilig, Vaak_Onveilig, Zakkenrollerij, Straat_Beroving, Woning_Inbraak, Mishandeling, Wel_Eens_Onveilig_Buurt, Vaak_Onveilig_Buurt, Avond_Buurt, Avond_Alleen_Thuis, Avond_Deur_Niet_Open, Loopt_Om, Bang_Slachtoffer, Criminaliteit_Buurt_Toe, Criminaliteit_Buurt_Af, Criminaliteit_Buurt_Gelijk, Cijfer_Veiligheid_Buurt, Uitgaan, Hangplekken, Centrum_Woonplaats, Winkelgebied, In_OV, Treinstation, Eigen_Huis, Onbekenden_Straat, Onbekenden_OV, Personeel_Winkels_Bedrijven, Personeel_Overheid, Bekenden_Partner_Familie_Vrienden) ");
            query.Append("VALUES (");
            query.Append("'" + instance.Marges + "', ");
            query.Append("'" + instance.RegioCode + "', ");
            query.Append("'" + instance.Perioden + "', ");
            query.Append("'" + instance.WelEensOnveilig + "', ");
            query.Append("'" + instance.VaakOnveilig + "', ");
            query.Append("'" + instance.Zakkenrollerij + "', ");
            query.Append("'" + instance.StraatBeroving + "', ");
            query.Append("'" + instance.WoningInbraak + "', ");
            query.Append("'" + instance.Mishandeling + "', ");
            query.Append("'" + instance.WelEensOnveiligBuurt + "', ");
            query.Append("'" + instance.VaakOnveiligBuurt + "', ");
            query.Append("'" + instance.AvondBuurt + "', ");
            query.Append("'" + instance.AvondAlleenThuis + "', ");
            query.Append("'" + instance.AvondDeurNietOpen + "', ");
            query.Append("'" + instance.LooptOm + "', ");
            query.Append("'" + instance.BangSlachtoffer + "', ");
            query.Append("'" + instance.CriminaliteitBuurtToe + "', ");
            query.Append("'" + instance.CriminaliteitBuurtAf + "', ");
            query.Append("'" + instance.CriminaliteitBuurtGelijk + "', ");
            query.Append("'" + instance.CijferVeiligheidBuurt + "', ");
            query.Append("'" + instance.Uitgaan + "', ");
            query.Append("'" + instance.Hangplekken + "', ");
            query.Append("'" + instance.CentrumWoonplaats + "', ");
            query.Append("'" + instance.Winkelgebied + "', ");
            query.Append("'" + instance.InOV + "', ");
            query.Append("'" + instance.Treinstation + "', ");
            query.Append("'" + instance.EigenHuis + "', ");
            query.Append("'" + instance.OnbekendenStraat + "', ");
            query.Append("'" + instance.OnbekendenOV + "', ");
            query.Append("'" + instance.PersoneelWinkelsBedrijven + "', ");
            query.Append("'" + instance.PersoneelOverheid + "', ");
            query.Append("'" + instance.BekendenPartnerFamilie + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "veiligheid";
        }
    }
}
