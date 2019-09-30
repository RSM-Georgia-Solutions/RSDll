using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using SAPbouiCOM.Framework;
using RevenueServices;
using RevenueServices.Models.RequestModels;
using RevenueServices.Models;
using RevenueServices.Models.ResponseModels;
using SAPbouiCOM;
using Application = SAPbouiCOM.Framework.Application;

namespace RsDllTest
{
    [FormAttribute("RsDllTest.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }
        /////test
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Button Button0;

        private void OnCustomInitialize()
        {
            var x = 0;
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            UserModel userModel = new UserModel
            {
                UserName = "tbilisi",
                Password = "1234561",
                AuthType = "0"
            };



            InvoiceModelPost invpost = new InvoiceModelPost
            {
                Invoice = new Invoice
                {
                    Id = 39632,
                }
            };


            List<Invoice> listinvpost = new List<Invoice> {
               new Invoice
               {
                   Id = -1
               }
            };

            Dictionary<IRsResponse, string> responses = new Dictionary<IRsResponse, string>();
            RsResponse<TokenOneStepResponse> auth = RsClient.Authenticate(userModel).Result;
            responses.Add(auth, "1");

            RsResponse<InvoiceSendResponse> activateInvoice = RsClient.ActivateInvoice(invpost).Result;
            responses.Add(activateInvoice, "2");

            RsResponse<InvoiceSendResponse> activateInvoices = RsClient.ActivateInvoices(listinvpost).Result;
            responses.Add(activateInvoices, "3");


            foreach (var res in responses)
            {
                if (res.Key.Status.Id != 0)
                {
                    Application.SBO_Application.MessageBox($"{res.Key.Status.Text} : Method {res.Value}");
                }
            }

            var state = RsClient.GetSeqNum(DateTime.Now).Result;
        }
    }
}