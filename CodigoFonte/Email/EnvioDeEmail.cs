using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Diagnostics;
using System.Web.UI;

namespace DIAD.ControleDeGastos.Email
{
    public class EnvioDeEmail : Page
    {
        public bool dispararEmail(string strTo,
            string strCC,
            string strBcc,
            string strFrom,
            string strAssunto,
            string strBody,
            int intPrioridade,
            bool blnHTML,
            bool blnDeliveryFail,
            string strSrvSMTP,
            int intPorta,
            string strUsuario,
            string strSenha)
        {
            try
            {
                MailMessage objMsg = new MailMessage();
                objMsg.To.Add(strTo);
                if (!(String.IsNullOrEmpty(strCC))) objMsg.CC.Add(strCC);
                if (!(String.IsNullOrEmpty(strBcc))) objMsg.CC.Add(strBcc);
                objMsg.From = new MailAddress(strFrom);
                objMsg.Subject = strAssunto;
                objMsg.Body = strBody;
                switch (intPrioridade)
                {
                    case 2:
                        objMsg.Priority = MailPriority.High;
                        break;
                    case 1:
                        objMsg.Priority = MailPriority.Normal;
                        break;
                    default:
                        objMsg.Priority = MailPriority.Low;
                        break;
                }
                objMsg.IsBodyHtml = blnHTML;
                if (blnDeliveryFail)
                    objMsg.DeliveryNotificationOptions =
                        DeliveryNotificationOptions.OnFailure;
                else
                    objMsg.DeliveryNotificationOptions =
                        DeliveryNotificationOptions.OnSuccess;
                //Definição do servidor SMTP
                SmtpClient objSMTP = new SmtpClient();
                objSMTP.Host = strSrvSMTP;
                objSMTP.Port = intPorta;
                System.Net.NetworkCredential objUser =
                    new System.Net.NetworkCredential();
                objUser.UserName = strUsuario;
                objUser.Password = strSenha;

                objSMTP.Credentials = objUser;

                objSMTP.EnableSsl = true;

                objSMTP.Send(objMsg);
                return true;
            }
            catch (Exception ex1)
            {
                try
                {
                    EventLog.WriteEntry("Email.EnvioDeEmail - método dispararEmail", ex1.Message);
                }
                catch (Exception ex2)
                {
                    throw ex2;
                }
                throw ex1;
            }
            finally
            {

            }
        }
    }
}
