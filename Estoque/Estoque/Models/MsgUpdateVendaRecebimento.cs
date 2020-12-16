using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Estoque.Models
{
    public static class MsgUpdateVendaRecebimento
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
            var mensagem = message.Body.ParseJson<MsgUpdateVenda>();

            //Escrever aqui o código para processar a mensagem      
            Context _context = new Context();
            bool ProdutoExists = _context.Produtos.Any(e => e.Id == mensagem.ProdId);

            if (ProdutoExists)            
            {
                var prod = _context.Produtos.FirstOrDefault(m => m.Id == mensagem.ProdId);

                //Baixando o estoque (atual - qtd. vendida)
                mensagem.ProdQtd = prod.qtdEstProd - mensagem.ProdQtd;
                _context.Update(mensagem);
                _context.SaveChangesAsync();
            }            

            return Task.CompletedTask;
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }        
}
