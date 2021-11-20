using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace GroupViewProject
{
    class Main
    {

        // Строка подключения к БД
        string strConnection = @"Data Source=DESKTOP-7GLORK1\SQLEXPRESS;Initial Catalog=groupall;Integrated Security=True";
        
        /// <summary>
        /// Добавления данных о группе 
        /// </summary>
        /// <param name="group"> Класс Group</param>
        public void AddGroup (Group group)
        {
            // 
            string SqlCmd = $"INSERT INTO [dbo].[group] ([NameGroup],[NumberGroup],[CuratorGroup]) " +
                $"VALUES ('{group.NameGroup}','{group.NumberGroup}','{group.CuratorGroup}')";

            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlCmd, connection);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Группа добавлена");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        /// <summary>
        /// Чтения данных из таблицы group
        /// </summary>
        /// <returns></returns>
        public List<Group> ReadGroup()
        {
            string SqlCmd = "SELECT * FROM [dbo].[group]";
            List<Group> groups = new List<Group>();

            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlCmd, connection);

                    // Получаем строки из таблицы
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();

                    
                    if (sqlDataReader.HasRows)
                    {
                        // Построчно считываем данные
                        while (sqlDataReader.Read())
                        {
                            groups.Add(new Group()
                            {
                                idGroup = sqlDataReader.GetInt32(0),
                                NameGroup = sqlDataReader.GetString(1),
                                NumberGroup = sqlDataReader.GetString(2),
                                CuratorGroup = sqlDataReader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            return groups;
        }
        public void DelGroup(Group group)
        {
            string SqlCmd = $"Delete From [dbo].[group] Where idGroup={group.idGroup};";
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlCmd, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Группа удалена");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public void UpdGroup(Group group)
        {
            string SqlCmd = $"Update [dbo].[group] set NameGroup='{group.NameGroup}'  ,NumberGroup ='{group.NumberGroup}',CuratorGroup ='{group.CuratorGroup}' Where idGroup={group.idGroup};";
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlCmd, connection);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Группа изменена");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }




    /// <summary>
    ///  Описание таблицы из БД
    /// </summary>
    class Group
    {
        public int idGroup { get; set; }

        public string  NameGroup { get; set; }

        public string NumberGroup { get; set; }

        public string  CuratorGroup { get; set; }
    }
}
