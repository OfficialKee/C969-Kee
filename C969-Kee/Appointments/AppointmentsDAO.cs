using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C969_Kee.Database;
using MySql.Data.MySqlClient;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace C969_Kee.Appointments
{
    internal class AppointmentsDAO
    {
        public List<Appointments> GetAllAppointmentsList()
        {
             //DBConnection.startConnection();

            List<Appointments> returnedAppointmentsList = new List<Appointments>();
            //String selectQuery =
            //    "SELECT start, end, createdBy, Title, description, location, createDate, lastUpdate, appointmentId, customerId, contact FROM appointmen yest"; 
            String selectQueryTwo =
                "SELECT customer.customerId, customer.customerName, address.phone, address.address, appointment.description, appointment.start, appointment.end FROM customer JOIN address ON customer.addressId = address.addressId JOIN appointment on  customer.customerID = appointment.customerID  ";

            MySqlCommand cmd = new MySqlCommand(selectQueryTwo,DBConnection.Conn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Appointments appointment = new Appointments
                    {
                        
                        //CreatedBy = reader.GetString(2),
                        //Title = reader.GetString(3),
                        //Description = reader.GetString(4),
                        //Location = reader.GetString(5),
                        //CreateDate = reader.GetDateTime(6),
                        //UpdateDate = reader.GetDateTime(7),
                        //AppointmentID = reader.GetInt32(8),
                        //CustomerID = reader.GetInt32(9),
                        //Contact = reader.GetString(10),
                        
                        
                        CustomerId = reader.GetInt32(0),
                        CustomerName = reader.GetString(1),
                        Phone = reader.GetString(2),
                        CustomerAddress = reader.GetString(3),
                        Description = reader.GetString(4),
                        Start = reader.GetDateTime(5),
                        End = reader.GetDateTime(6),




                    };
                    returnedAppointmentsList.Add(appointment);
                }
            }



            return returnedAppointmentsList;
        }
    }
}
