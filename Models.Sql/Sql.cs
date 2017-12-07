using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAirport.Pim.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace MyAirport.Pim.Models
{
    public class Sql : AbstractDefinition
    {
        /// divers requetes exécutées dans les méthodes de classe
        string strCnx = ConfigurationManager.ConnectionStrings["MyAiport.Pim.Settings.DbConnect"].ConnectionString;

        string commandGetBagageIata = "SELECT b.ID_BAGAGE, c.NOM as compagnie, b.CODE_IATA, b.LIGNE, b.DATE_CREATION, b.ESCALE, cc.PRIORITAIRE ,cast(iif(b.CONTINUATION='N',0,1) as bit) as Continuation, cast(iif(bp.PARTICULARITE is null, 0, 1) as bit) as 'RUSH' " +
            "FROM BAGAGE b " +
            "LEFT OUTER JOIN BAGAGE_A_POUR_PARTICULARITE bap on bap.ID_BAGAGE = b.ID_BAGAGE " +
            "LEFT OUTER JOIN BAGAGE_PARTICULARITE bp on bp.ID_PART = bap.ID_PARTICULARITE and bp.PARTICULARITE = 'RUSH' " +
            "LEFT OUTER JOIN COMPAGNIE c on c.CODE_IATA = b.COMPAGNIE " +
            "LEFT OUTER JOIN COMPAGNIE_CLASSE cc on cc.ID_COMPAGNIE = c.ID_COMPAGNIE and cc.CLASSE = b.CLASSE " +
            "WHERE b.CODE_IATA = @codeIata";

        string commandGetBagageId = "SELECT b.ID_BAGAGE, c.NOM as compagnie, b.CODE_IATA, b.LIGNE, b.DATE_CREATION, b.ESCALE, cc.PRIORITAIRE ,cast(iif(b.CONTINUATION='N',0,1) as bit) as Continuation, cast(iif(bp.PARTICULARITE is null, 0, 1) as bit) as 'RUSH' " +
            "FROM BAGAGE b " +
            "LEFT OUTER JOIN BAGAGE_A_POUR_PARTICULARITE bap on bap.ID_BAGAGE = b.ID_BAGAGE " +
            "LEFT OUTER JOIN BAGAGE_PARTICULARITE bp on bp.ID_PART = bap.ID_PARTICULARITE and bp.PARTICULARITE = 'RUSH' " +
            "LEFT OUTER JOIN COMPAGNIE c on c.CODE_IATA = b.COMPAGNIE " +
            "LEFT OUTER JOIN COMPAGNIE_CLASSE cc on cc.ID_COMPAGNIE = c.ID_COMPAGNIE and cc.CLASSE = b.CLASSE " +
            "WHERE b.id_bagage = @id";

        string cmdCreateBagageString =
            "INSERT INTO BAGAGE(CODE_IATA, ORIGINE_CREATION, DATE_CREATION, CLASSE, PRIORITAIRE, STA, LOCAL_TRANFERT, ISUR, DESTINATION, ESCALE, EMB, RECOLE, COMPAGNIE, LIGNE, JOUR_EXPLOITATION, CONTINUATION, DCS_EMETTEUR, ORIGINE_SAFIR, EN_CONTINUATION, EN_TRANSFERT)"
            + "VALUES(@codeIata, 'D',@dateCreation, 'Y', @prioritaire, 'B', 'T', 0, @itineraire, 'MIA', 1, 0, @compagnie, @ligne, 17, @continuation, 'SB46', 0, 0, 0); SELECT SCOPE_IDENTITY()";
        
        string cmdCreateBagageString2 = "INSERT INTO BAGAGE_A_POUR_PARTICULARITE VALUES (@idBagage, @particularite)";

        string getAllCodeIata = "select code_iata from COMPAGNIE";
        /// <summary>
        /// Renvoie le bagage ayant l'id passé en parametre
        /// </summary>
        /// <param name="idBagage"></param>
        /// <returns></returns>
        public override BagageDefinition GetBagage(int idBagage)
        {
            BagageDefinition bagRes = null;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(this.commandGetBagageId, cnx);
                cmd.Parameters.AddWithValue("@id", idBagage);
                cnx.Open();

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if(sdr.Read())
                    {
                        bagRes = new BagageDefinition();

                        bagRes.IdBagage = sdr.GetInt32(sdr.GetOrdinal("id_bagage"));
                        bagRes.CodeIata = sdr.GetString(sdr.GetOrdinal("code_iata"));
                        bagRes.Compagnie = sdr.GetString(sdr.GetOrdinal("compagnie"));
                        bagRes.Ligne = sdr.GetString(sdr.GetOrdinal("ligne"));
                        bagRes.DateVol = sdr.GetDateTime(sdr.GetOrdinal("date_creation"));
                        bagRes.Itineraire = sdr.GetString(sdr.GetOrdinal("escale"));
                        bagRes.Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("prioritaire"));
                        bagRes.EnContinuation = sdr.GetBoolean(sdr.GetOrdinal("continuation"));
                        bagRes.Rush = sdr.GetBoolean(sdr.GetOrdinal("rush"));
                    }
                }
                cnx.Close();
                return bagRes;
            }
        }

        /// <summary>
        /// Renvoie une liste de bagage ayant le code IATA passé en parametre
        /// </summary>
        /// <param name="codeIataBagage"></param>
        /// <returns></returns>
        public override List<BagageDefinition> GetBagage(string codeIataBagage)
        {
            List<BagageDefinition> bagsRes = new List<BagageDefinition>();
            BagageDefinition bagRes = null;

            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(this.commandGetBagageIata, cnx);
                cmd.Parameters.AddWithValue("@codeIata", codeIataBagage);
                cnx.Open();

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    bagRes = new BagageDefinition();
                    while (sdr.Read())
                    {
                        
                        bagRes.IdBagage = sdr.GetInt32(sdr.GetOrdinal("id_bagage"));
                        bagRes.CodeIata = sdr.GetString(sdr.GetOrdinal("code_iata"));
                        if (!sdr.IsDBNull(sdr.GetOrdinal("prioritaire")))
                            bagRes.Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("prioritaire"));
                        else bagRes.Prioritaire = false;
                        bagRes.Compagnie = sdr.GetString(sdr.GetOrdinal("compagnie"));
                        bagRes.Ligne = sdr.GetString(sdr.GetOrdinal("ligne"));
                        bagRes.DateVol = sdr.GetDateTime(sdr.GetOrdinal("date_creation"));
                        bagRes.Itineraire = sdr.GetString(sdr.GetOrdinal("escale"));
                        bagRes.EnContinuation = sdr.GetBoolean(sdr.GetOrdinal("continuation"));
                        bagRes.Rush = sdr.GetBoolean(sdr.GetOrdinal("rush"));
                        Console.WriteLine(bagRes.Compagnie);
                        bagsRes.Add(bagRes);
                    }
                }                    
                cnx.Close();
                return bagsRes;
            }
        }

        /// <summary>
        /// Creer un nouveau bagage en checkant que la compagnie est bien existante
        /// </summary>
        /// <param name="monBagage"></param>
        /// <returns></returns>
        public override int CreateBagage(BagageDefinition monBagage)
        {
            long idNew = 0;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(this.cmdCreateBagageString, cnx);
                SqlCommand cmd2 = new SqlCommand(this.cmdCreateBagageString2, cnx);
               
                if (checkCompagnie(monBagage.Compagnie))
                {
                    cnx.Open();
                    cmd.Parameters.AddWithValue("@codeIata", monBagage.CodeIata);
                    cmd.Parameters.AddWithValue("@dateCreation", (System.Data.SqlTypes.SqlDateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))));

                    if (monBagage.Prioritaire)
                        cmd.Parameters.AddWithValue("@prioritaire", 1);
                    else cmd.Parameters.AddWithValue("@prioritaire", 0);

                    if (monBagage.Itineraire.Length < 3)
                        cmd.Parameters.AddWithValue("@itineraire", monBagage.Itineraire);
                    else
                        cmd.Parameters.AddWithValue("@itineraire", monBagage.Itineraire.Substring(0, 3));
                    if (monBagage.Compagnie.Length < 3)
                        cmd.Parameters.AddWithValue("@compagnie", monBagage.Compagnie);
                    else
                        cmd.Parameters.AddWithValue("@compagnie", monBagage.Compagnie.Substring(0, 3));

                    cmd.Parameters.AddWithValue("@ligne", monBagage.Ligne);
                    if (monBagage.EnContinuation)
                        cmd.Parameters.AddWithValue("@continuation", 'Y');
                    else
                        cmd.Parameters.AddWithValue("@continuation", 'N');
                    idNew = Convert.ToInt32(cmd.ExecuteScalar());
                    if (monBagage.Rush)
                    {
                        cmd2.Parameters.AddWithValue("@idBagage", idNew);
                        cmd2.Parameters.AddWithValue("@particularite", 15);
                        cmd2.ExecuteScalar();
                    }
                    cnx.Close();
                }
                else
                {
                    throw new ArgumentException("cie nok");                   
                }
            }
            return (int)idNew;
        }

        /// <summary>
        /// Methode qui check si la compagnie passée en parametre est contenue dans la table compagnie sql
        /// </summary>
        /// <param name="compagnie"></param>
        /// <returns></returns>
        public Boolean checkCompagnie(String compagnie)
        {
            Boolean monBool = false;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd3 = new SqlCommand(this.getAllCodeIata, cnx);
                cnx.Open();
                ArrayList maList = new ArrayList();
                using (SqlDataReader sdr = cmd3.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        maList.Add(sdr.GetString(0));
                    }
                }
                foreach (String item in maList)
                {
                    if (item.Contains(compagnie))
                    {
                        monBool = true;
                        break;
                    }
                }
            }
            return monBool;
        }
    }
}
