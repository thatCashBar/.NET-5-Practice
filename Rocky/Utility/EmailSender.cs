using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Rocky.Utility
{
    public class EmailSender: IEmailSender {
    public Task SendEmailAsync(string email, string subject, string htmlMessage) {
      return Execute(email, subject, htmlMessage);
    }

    public async Task Execute(string email, string subject, string htmlMessage) {
      MailjetClient client = new MailjetClient("3a72f31debd5c15e0a492c5b1e11c20d", "9f14e6f3f07c5d0da76369d3e1cb34b4") {
        Version = ApiVersion.V3_1,
      };
      MailjetRequest request = new MailjetRequest {
          Resource = Send.Resource,
        }
        .Property(Send.Messages, new JArray {
          new JObject {
            {
              "From",
              new JObject {
                {
                  "Email",
                  "jaxonpetersen94@protonmail.com"
                }, {
                  "Name",
                  "Jaxon"
                }
              }
            }, {
              "To",
              new JArray {
                new JObject {
                  {
                    "Email",
                    email
                  }, {
                    "Name",
                    "DotNetMastery"
                  }
                }
              }
            }, {
              "Subject",
              subject
            }, {
              "HTMLPart",
              htmlMessage
            }
          }
        });
      await client.PostAsync(request);
    }
  }
}