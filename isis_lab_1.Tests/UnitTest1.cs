using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Windows;

namespace isis_lab_1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void check_admin_password()
        {
            // arrange
            page_adminLogin pgad = new page_adminLogin();
            String password = "0000";
            bool expected = true;

            // act
            bool actual = pgad.pass_check(password);

            // assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void client_edit_check_empty_firstName()
        {
            // arrange
            Client client = new Client();
            page_Clients_Edit pce = new page_Clients_Edit(client);
            bool expected = true;

            // act
            bool actual = pce.check_empty_editField(client.FirstName);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void client_edit_check_empty_lastName()
        {
            // arrange
            Client client = new Client();
            page_Clients_Edit pce = new page_Clients_Edit(client);
            bool expected = true;

            // act
            bool actual = pce.check_empty_editField(client.LastName);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void client_edit_check_empty_patronymic()
        {
            // arrange
            Client client = new Client();
            page_Clients_Edit pce = new page_Clients_Edit(client);
            bool expected = true;

            // act
            bool actual = pce.check_empty_editField(client.Patronymic);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void client_edit_check_empty_birthday()
        {
            // arrange
            Client client = new Client();
            page_Clients_Edit pce = new page_Clients_Edit(client);
            bool expected = true;

            // act
            bool actual = pce.check_empty_editField(client.Birthday);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void client_edit_check_empty_email()
        {
            // arrange
            Client client = new Client();
            page_Clients_Edit pce = new page_Clients_Edit(client);
            bool expected = true;

            // act
            bool actual = pce.check_empty_editField(client.Email);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void client_edit_check_empty_phone()
        {
            // arrange
            Client client = new Client();
            page_Clients_Edit pce = new page_Clients_Edit(client);
            bool expected = true;

            // act
            bool actual = pce.check_empty_editField(client.Phone);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void client_edit_check_empty_genderCode()
        {
            // arrange
            Client client = new Client();
            page_Clients_Edit pce = new page_Clients_Edit(client);
            bool expected = true;

            // act
            bool actual = pce.check_empty_editField(client.GenderCode);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void page_new_services_admin_record()
        {
            // arrange
            Service service = new Service();
            page_new_Services_Admin_Record pnsar = new page_new_Services_Admin_Record(service);
            bool expected = true;

            // act
            StringBuilder str = new StringBuilder();
            str.Append("some text");
            bool actual = pnsar.new_service_admin_record_check_errors(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void check_page_client_visible()
        {
            // arrange
            page_Clients gc = new page_Clients();
            bool expected = true;

            // act
            bool actual = gc.is_page_visible(Visibility.Visible);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
