using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using YMSweb.Data.DataSql;
using YMSweb.Models.ViewModels;

namespace YMSweb.Controllers
{
    public class SmsController : TwilioController
    {
        SP_Operaciones _operaciones;
        public SmsController()
        {
            _operaciones = new SP_Operaciones();
        }
        public TwiMLResult Index(SmsRequest incomingMessage)
        {
         
            string oValue = "";
            if(incomingMessage.Body == null)
            {
                oValue = "V3Y809";
            }
            else
            {
                oValue = incomingMessage.Body;
            }

            string oIterar = "";
            var oResp = _operaciones.mWhatsapauto(oValue);
            foreach (var item in oResp)
            {
                oIterar = oIterar + " \n" +
                          "Placa: " + item.plac_desc + " \n" +
                          "Nro. Transporte: " + item.campla_nrotrans + " \n" +
                          "Canales: " + item.viaj_canales + " \n" +
                          "Hora propuesta de carga: " + item.vijcab_horapropuesta + " \n";
            }


            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("Consulta:");
            var task = new Task(() => SendWhatsappMessage(incomingMessage.To, incomingMessage.From, oIterar));
            task.Start();   
            return TwiML(messagingResponse);          
                       
        }

        public void SendWhatsappMessage(string to, string from, string Iterar)
        {
            string accountSid = Environment.GetEnvironmentVariable("AC680d3b93660aaba435c035a54fe345c0");
            string authToken = Environment.GetEnvironmentVariable("fc01492763b9eb42b51ac7742bac7209");
            Thread.Sleep(5000);
            Twilio.TwilioClient.Init(accountSid, authToken);
            MessageResource.Create(
            body: Iterar,
            from: new Twilio.Types.PhoneNumber(from),
            to: new Twilio.Types.PhoneNumber(to)
            );
        }

    }
}
