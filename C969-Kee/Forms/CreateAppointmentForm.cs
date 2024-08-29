using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Kee.Appointments;
using ZstdSharp.Unsafe;

namespace C969_Kee.Forms
{
    public partial class CreateAppointmentForm : Form
    {
        private Appointments.Appointments appointment = new Appointments.Appointments();
        public CreateAppointmentForm()
        {
            InitializeComponent();
        }

        private void DescriptionBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {   
            AppointmentsDAO appointmentsDao = new AppointmentsDAO();
            DateTime startDate = DateTime.Parse(StartDatePicker.Text);
            DateTime endDate = DateTime.Parse(EndDatePicker.Text);

            appointment.Start = startDate;
            appointment.End = endDate;

            appointment.CustomerName = NameBox.Text;
            appointment.Description = DescriptionBox.Text;

            appointment.Phone = PhoneNumberBox.Text;
            appointment.CustomerAddress = AddressTextBox.Text;

            appointment.CustomerId = appointmentsDao.GetAllAppointmentsList().Count - 1;

            appointmentsDao.GetAllAppointmentsList().Add(appointment);
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Title_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneNumberBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
