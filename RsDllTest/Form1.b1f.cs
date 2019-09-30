using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using SAPbouiCOM.Framework;
using RevenueServices;
using RevenueServices.Inrerfaces;
using RevenueServices.Models.RequestModels;
using RevenueServices.Models;
using RevenueServices.Models.RequestFileters;
using RevenueServices.Models.ResponseModels;
using SAPbouiCOM;
using Application = SAPbouiCOM.Framework.Application;

namespace RsDllTest
{
    [FormAttribute("RsDllTest.Form1", "Form1.b1f")]
    public class Form1 : UserFormBase
    {
        public Form1()
        {
        }

        private RsClient _rsClient;

        //public Form1(IRsClient iRsClient)
        //{
        //    _rsClient = iRsClient;
        //}
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

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            UserModel userModel = new UserModel
            {
                UserName = "tbilisi",
                Password = "123456",
                AuthType = "0"
            };

            _rsClient = new RsClient();



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

            RsResponse<TokenOneStepResponse> auth = _rsClient.Authenticate(userModel).Result;
            var auth2 = _rsClient.GetUnitOfMeasures().Result;


            //responses.Add(auth, "1");

            //var x = RsClient.GetBarCodes(new BarCodesFilter()).Result;
            //var qew = new VatPayerModel { Tin = "12345678910", VatDate = DateTime.Now };

            //RsResponse<InvoiceSendResponse> activateInvoice = _rsClient.ActivateInvoice(invpost).Result;
            //responses.Add(activateInvoice, "2");

            //RsResponse<InvoiceSendResponse> activateInvoices = _rsClient.ActivateInvoices(listinvpost).Result;
            //responses.Add(activateInvoices, "3");


            //foreach (var res in responses)
            //{
            //    if (res.Key.Status.Id != 0)
            //    {
            //        Application.SBO_Application.MessageBox($"{res.Key.Status.Text} : Method {res.Value}");
            //    }
            //}

            //var state = _rsClient.GetSeqNum(DateTime.Now).Result;
        }
    }
}