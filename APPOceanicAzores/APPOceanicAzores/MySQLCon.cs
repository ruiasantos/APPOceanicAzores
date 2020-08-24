using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace APPOceanicAzores
{
    public class MySQLCon
    {
        MySqlConnection conexaoMySQL;
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

        public string CriarStringConexao()
        {
            builder.Server = "oceanicazores.tk";
            builder.Database = "admin_oceanicazores";
            builder.UserID = "admin_dbuoceanic";
            builder.Password = "OceanicDBp12#$";
            builder.Port = 3306;

            return builder.ToString();
        }

        public int CarregaUsers(string EmailLogin, string PasswordLogin)
        {
            string lista;
            string StringConexaoMysql = CriarStringConexao();
            string consulta = "SELECT name, email, phone, password from OceanicUsers where email='"+EmailLogin+"'";
            try
             {
                conexaoMySQL = new MySqlConnection(StringConexaoMysql);
                conexaoMySQL.Open();

                MySqlDataReader rdr = null;
                MySqlCommand cmd = new MySqlCommand(consulta, conexaoMySQL);

                rdr = cmd.ExecuteReader();
                lista = "";
                while (rdr.Read())
                {
                    lista = rdr["email"].ToString() + ";" + rdr["password"].ToString();
                }
                rdr.Close();

                //Verificação da posição do ;
                int pos = lista.IndexOf(";");

                if ((EmailLogin==lista.Substring(0, pos)) && PasswordLogin==lista.Substring(pos + 1))
                {
                    return 0;
                }
                else
                {
                    if (lista.Substring(0, pos) == EmailLogin)
                    { 
                        return 1;
                    }
                    else 
                    {
                        return 2;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexaoMySQL.Close();
            }
        }

        public void GravaUsers(string EmailLogin, string PasswordLogin, string PhoneLogin, string UsernameLogin)
        {
            string StringConexaoMysql = CriarStringConexao();
            string consulta = "SELECT email from OceanicUsers where email='" + EmailLogin + "'";
            try
            {
                conexaoMySQL = new MySqlConnection(StringConexaoMysql);
                conexaoMySQL.Open();

                MySqlDataReader rdr = null;
                MySqlCommand cmd = new MySqlCommand(consulta, conexaoMySQL);

                rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    if (conexaoMySQL.State == ConnectionState.Closed)
                    {
                        conexaoMySQL.Open();
                    }
                    string insert = "INSERT INTO OceanicUsers(name, email, password, phone) values ('"+UsernameLogin+"','"+EmailLogin+"','"+PasswordLogin+"','"+PhoneLogin+"')";
                    MySqlCommand cmd2 = new MySqlCommand(insert, conexaoMySQL);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    /// EMail existente
                    
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexaoMySQL.Close();
            }
        }
    }
}
