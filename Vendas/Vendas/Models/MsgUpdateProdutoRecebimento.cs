using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Vendas.Models;

namespace Estoque.Models
{
    public static class MsgUpdateProdutoRecebimento
    {
        public static void receber()
        {
            var serviceBusClient =
                new SubscriptionClient("<ServiceBusConnectionString>", "pagamentofeito", "PagamentoFeitoServicoB");

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            serviceBusClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);
        }

        private static Task ProcessMessageAsync(Message message, CancellationToken arg2)
        {
            var mensagem = message.Body.ParseJson<MsgUpdateProduto>();

            //Escrever aqui o código para processar a mensagem      
            Context _context = new Context();
            bool ProdutoExists = _context.Produtos.Any(e => e.Id == mensagem.ProdId);

            if (!ProdutoExists)
            {
                _context.Add(mensagem);
            }
            else
            {
                _context.Update(mensagem);
            }
            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
