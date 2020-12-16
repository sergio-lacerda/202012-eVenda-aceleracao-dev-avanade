using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Estoque.Models
{
    public static class MsgUpdateProdutoEnvio
    {
        public static void enviar(int idProduto, int qtdProduto) 
        {
            MsgUpdateProduto mensagem = new MsgUpdateProduto { ProdId = idProduto, ProdQtd = qtdProduto };

            var serviceBusClient = new TopicClient("chave", "Tópico");

            var message = new Message(mensagem.ToJsonBytes());
            message.ContentType = "application/json";
            message.UserProperties.Add("CorrelationId", Guid.NewGuid().ToString());            

            serviceBusClient.SendAsync(message);             
        }
    }
}
