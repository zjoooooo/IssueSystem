using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IssueSystem
{
    class DBUtility
    {
        //Delete User from PMS
        public static bool DeleteUser(string user, string dbname, string ipaddress)
        {
            string constr = "Data Source=" + ipaddress + ";uid=sa;pwd=yzhh2007;database=" + dbname + ";Connection Timeout=15";
            string cmd = "Delete from logon where userID=@user";
            try
            {
                SqlHelper.ExecuteNonQuery(constr, CommandType.Text, cmd, new SqlParameter("@user", user));
                LogClass.WirteLine("Delete user ok");
                return true;
            }
            catch (SqlException sqle)
            {
                LogClass.WirteLine(dbname + " Sql error when delete user:" + sqle.ToString());
                return false;
            }
        }

        //Add User For PMS        
        public static bool AddUser(PmsUserClass user, string dbname, string ipaddress)
        {
            string constr = "Data Source=" + ipaddress + ";uid=sa;pwd=yzhh2007;database=" + dbname + ";Connection Timeout=15";
            string cmd = @"if EXISTS(select * from logon where userid=@username)
			                  BEGIN 
			                  update dbo.logon set expire_date=@expiredate,password=@password,Ulevel=@level where userID=@username                                                        
			                  END
	                       else 
		                      BEGIN
                              INSERT INTO [dbo].[logon](userID,password,ULevel,expire_date)
		                      VALUES(@username,@password,@level,@expiredate)		 
                              END";
            SqlParameter[] UserPara = new SqlParameter[]
                        {
                            new SqlParameter("@username",user.Name),
                            new SqlParameter("@password",user.Password),
                            new SqlParameter("@expiredate",user.ExpiredDate),
                            new SqlParameter("@level",user.Level)
                        };

            try
            {
                SqlHelper.ExecuteNonQuery(constr, CommandType.Text, cmd, UserPara);
                LogClass.WirteLine("Add user ok");
                return true;
            }
            catch (SqlException sqle)
            {
                LogClass.WirteLine(dbname + " Sql error when add user:" + sqle.ToString());
                return false;
            }
        }

        //Delete IU for Secure Parking Staff
        public static bool DeleteStaffIU(string IU, string plate, string dbname, string ipaddress)
        {
            string constr = "Data Source=" + ipaddress + ";uid=sa;pwd=yzhh2007;database=" + dbname + ";Connection Timeout=15";
            string cmd = "DELETE FROM [dbo].[season_mst] where season_id=@IU and vehicle_no=@plate;";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@IU", IU),
                new SqlParameter("@plate", plate)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(constr, CommandType.Text, cmd, para);
                LogClass.WirteLine("Delete StaffIU ok");
                return true;
            }
            catch (SqlException sqle)
            {
                LogClass.WirteLine(dbname + "Sql error when delete StaffIU:" + sqle.ToString());
                return false;
            }
        }
        //Add IU for Secure Parking Staff
        public static bool AddStaffIU(PmsVehicleClass vehicle, string dbname, string ipaddress)
        {
            string constr = "Data Source=" + ipaddress + ";uid=sa;pwd=yzhh2007;database=" + dbname + ";Connection Timeout=15";
            string cmd = @"declare @x int
                           select @x=(select count(*) from season_mst)                                           
	                       if EXISTS(select * from season_mst where season_no=@IU)
			                  BEGIN 
			                    UPDATE season_mst set s_status=1,date_to=@ExpiredDate,vehicle_no=@plate,holder_name=@name,holder_type=7,update_dt=GETDATE() where season_no=@IU
			                  END
	                       else 
		                      BEGIN
                                INSERT INTO [dbo].[season_mst](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,full_company)
		                        VALUES
		                        (1,0,'op',@x+1,2,1,7,@IU,@StartDate,@ExpiredDate,@plate,GETDATE(),'Secure Parking Singapore Pte Ltd')
                              END;";
            string startdate = DateTime.Now.ToString("yyyy-MM-dd ") + "00:00:00";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@IU", vehicle.IU),
                new SqlParameter("@plate",vehicle.Plate),
                new SqlParameter("@ExpiredDate", vehicle.ExpiredDate),
                new SqlParameter("@name",vehicle.Name),
                new SqlParameter("@StartDate",startdate)
            };

            try
            {
                SqlHelper.ExecuteNonQuery(constr, CommandType.Text, cmd, para);
                LogClass.WirteLine("Delete StaffIU ok");
                return true;
            }
            catch (SqlException sqle)
            {
                LogClass.WirteLine(dbname + "Sql error when add StaffIU:" + sqle.ToString());
                return false;
            }
        }
    }
}
